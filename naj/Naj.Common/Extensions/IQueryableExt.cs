using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Naj.Common
{
    public enum WhereOpertaor
    {
        LessThan,
        LessThanOrEqual,
        Equal,
        GreaterThan,
        GreaterThanOrEqual,
        NotEqual,
        Between,
        Contain,
        StartWith,
        EndWith
    }

    public static class ExpressionHelpers
    {
        public sealed class SwapExpressionVisitor : ExpressionVisitor
        {
            private readonly Expression _from, _to;
            private SwapExpressionVisitor(Expression from, Expression to)
            {
                _from = @from;
                _to = to;
            }

            /// <summary>
            /// Swaps <paramref name="from"/> expression with <paramref name="to"/> expression within a given lambda
            /// </summary>
            /// <param name="lambda">Lambda expression to perform swap on</param>
            /// <param name="from">Existing expression to locate</param>
            /// <param name="to">Expression to replace </param>
            /// <returns>Re-configured expression</returns>
            public static Expression<T> Swap<T>(Expression<T> lambda, Expression from, Expression to)
            {
                return Expression.Lambda<T>(Swap(lambda.Body, from, to), lambda.Parameters);
            }

            private static Expression Swap(Expression body, Expression from, Expression to)
            {
                return new SwapExpressionVisitor(from, to).Visit(body);
            }

            public override Expression Visit(Expression node)
            {
                return node == _from ? _to : base.Visit(node);
            }
        }

        /// <summary>
        /// Builds an array of expressions that map to every string property on an object
        /// </summary>
        /// <typeparam name="T">Type of object to retrieve properties from</typeparam>
        /// <returns>An array of expressions for each string property</returns>
        public static Expression<Func<T, string>>[] GetStringProperties<T>()
        {
            var parameter = Expression.Parameter(typeof(T));
            var stringProperties = typeof(T).GetProperties()
                                            .Where(property => property.PropertyType == typeof(String)
                                                            && property.CanRead);

            var result = new List<Expression<Func<T, string>>>();
            // Loop through each string property...
            foreach (var property in stringProperties)
            {
                Expression body = Expression.Property(parameter, property);
                // ...and build a lambda expression to represent it
                result.Add(Expression.Lambda<Func<T, string>>(body, parameter));
            }
            return result.ToArray();
        }

        public static Expression BuildOrExpression(Expression existingExpression, Expression expressionToAdd)
        {
            if (existingExpression == null) return expressionToAdd;

            //Build 'OR' expression for each property
            return Expression.OrElse(existingExpression, expressionToAdd);
        }

        public static MethodCallExpression BuildContainsExpression<T>(Expression<Func<T, string>> stringProperty, ConstantExpression searchTermExpression)
            => Expression.Call(stringProperty.Body, typeof(string).GetMethod("Contains"), searchTermExpression);

        public static MethodCallExpression BuildToLowerExpression<T>(Expression<Func<T, string>> stringProperty)
            => Expression.Call(stringProperty.Body, typeof(string).GetMethod("ToLower"));

        public static MethodCallExpression BuildIndexOfExpression<T>(Expression<Func<T, string>> stringProperty, ConstantExpression searchTermExpression)
            => Expression.Call(stringProperty.Body, "IndexOf", null, searchTermExpression, Expression.Constant(StringComparison.OrdinalIgnoreCase));
    }

    public static class QueryableExt
    {
        public static IQueryable<TEntity> Where<TEntity>(this IQueryable<TEntity> sequence, string PropertyName, WhereOpertaor Operator, params object[] PropertyValues)
        {
            ParameterExpression entity = Expression.Parameter(typeof(TEntity), "");
            Expression property = Expression.PropertyOrField(entity, PropertyName);
            Expression value1 = Expression.Convert(Expression.Constant(PropertyValues[0]), property.Type);
            Expression value2 = Expression.Convert(Expression.Constant(PropertyValues[1]), property.Type);
            Expression where = null;

            switch (Operator)
            {
                case WhereOpertaor.LessThan:
                    where = Expression.LessThan(property, value1);
                    break;
                case WhereOpertaor.LessThanOrEqual:
                    where = Expression.LessThanOrEqual(property, value1);
                    break;
                case WhereOpertaor.Equal:
                    where = Expression.Equal(property, value1);
                    break;
                case WhereOpertaor.GreaterThan:
                    where = Expression.GreaterThan(property, value1);
                    break;
                case WhereOpertaor.GreaterThanOrEqual:
                    where = Expression.GreaterThanOrEqual(property, value1);
                    break;
                case WhereOpertaor.NotEqual:
                    where = Expression.NotEqual(property, value1);
                    break;
                case WhereOpertaor.Between:
                    where = Expression.AndAlso(Expression.GreaterThanOrEqual(property, value1), Expression.LessThanOrEqual(property, value2));
                    break;
                case WhereOpertaor.Contain:
                    where = Expression.Call(property, "Contains", null, value1);
                    break;
                case WhereOpertaor.StartWith:
                    where = Expression.Call(property, "StartsWith", null, value1);
                    break;
                case WhereOpertaor.EndWith:
                    where = Expression.Call(property, "EndsWith", null, value1);
                    break;
            }

            Expression lambda = Expression.Lambda(where, new ParameterExpression[] { entity });
            Type[] exprArgTypes = { sequence.ElementType };
            MethodCallExpression methodCall = Expression.Call(typeof(Queryable),
                           "Where",
                           exprArgTypes,
                           sequence.Expression,
                           lambda);
            return (IQueryable<TEntity>)sequence.Provider.CreateQuery<TEntity>(methodCall);
        }

        public static IQueryable<TEntity> Search<TEntity>(this IQueryable<TEntity> sequence, string SearchTerm)
        {
            if (String.IsNullOrEmpty(SearchTerm))
            {
                return sequence;
            }

            var stringProperties = ExpressionHelpers.GetStringProperties<TEntity>();
            return sequence.Search(SearchTerm.Split((char[])null,StringSplitOptions.RemoveEmptyEntries), stringProperties);
        }

        public static IQueryable<TEntity> Search<TEntity>(this IQueryable<TEntity> sequence, string[] SearchTerms, params Expression<Func<TEntity, string>>[] StringProperties)
        {
            if (SearchTerms == null || SearchTerms.Length == 0) return sequence;


            //Variable to hold merged 'OR' expression
            Expression orExpression = null;

            foreach (var searchTerm in SearchTerms)
            {

                var searchTermExpression = Expression.Constant(searchTerm);
                var stringIgnoreCaseComparerExpression = Expression.Constant(StringComparer.InvariantCultureIgnoreCase);

                //Retrieve first parameter to use accross all expressions
                var singleParameter = StringProperties[0].Parameters.Single();

                //Build a contains expression for each property
                foreach (var stringProperty in StringProperties)
                {
                    //Syncronise single parameter accross each property
                    var swappedParamExpression = ExpressionHelpers.SwapExpressionVisitor.Swap(stringProperty, stringProperty.Parameters.Single(), singleParameter);

                    //Build expression to represent x.[propertyX].Contains(searchTerm)
                    var indexOfExpression = Expression.Call(swappedParamExpression.Body, "IndexOf", null, searchTermExpression, Expression.Constant(StringComparison.OrdinalIgnoreCase));
                    var containsExpression = BinaryExpression.GreaterThanOrEqual(indexOfExpression, Expression.Constant(0));

                    orExpression = ExpressionHelpers.BuildOrExpression(orExpression, containsExpression);
                }
            }

            var lambda = Expression.Lambda<Func<TEntity, bool>>(orExpression, StringProperties[0].Parameters.Single());
            Type[] exprArgTypes = { sequence.ElementType };
            MethodCallExpression methodCall = Expression.Call(typeof(Queryable),
                           "Where",
                           exprArgTypes,
                           sequence.Expression,
                           lambda);
            return (IQueryable<TEntity>)sequence.Provider.CreateQuery<TEntity>(methodCall);
        }
    }
}
