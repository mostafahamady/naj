using System;
using System.Linq.Expressions;

namespace Naj.Common
{
    public static class LinqExpression
    {
        public static Expression<Func<TSequence, bool>> EqualExpression<TSequence, TProperty>(string PropertyName, TProperty PropertyValue)
        {
            ParameterExpression param = Expression.Parameter(typeof(TSequence), "t");
            MemberExpression prop = Expression.PropertyOrField(param, PropertyName);
            BinaryExpression body = Expression.Equal(prop, Expression.Constant(PropertyValue, typeof(TProperty)));
            Expression<Func<TSequence, bool>> lambda = Expression.Lambda<Func<TSequence, bool>>(body, param);

            return lambda;
        }
    }
}
