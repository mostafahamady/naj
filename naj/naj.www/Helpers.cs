using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization;

namespace Naj.www
{
    public static class Extensions
    {
        public static IEnumerable<T> Sort<T>(this IEnumerable<T> obj, List<SortExperssion> sortExpressions)
        {
            foreach (var ex in sortExpressions)
            {
                var propertyInfo = typeof(T).GetProperty(ex.name);
                if (ex.desc)
                    obj = obj.OrderByDescending(x => propertyInfo.GetValue(x, null));
                else
                    obj = obj.OrderBy(x => propertyInfo.GetValue(x, null));
            }
            return obj;
        }

        public static IEnumerable<T> Search<T>(this IEnumerable<T> obj, List<string> SearchFields, string SearchKeyword)
        {
            foreach (var x in obj)
            {
                bool Rex = x.FieldContainsExpression(SearchFields[0], SearchKeyword).Compile()(x);
                for (int i = 1; i < SearchFields.Count; i++)
                    Rex = Rex || x.FieldContainsExpression(SearchFields[i], SearchKeyword).Compile()(x);
                if (Rex)
                    yield return x;
            }
        }

        public static Expression<Func<T, bool>> FieldContainsExpression<T>(this T obj, string FieldName, string FieldValue)
        {
            var parameter = Expression.Parameter(typeof(T), "type");
            var property = Expression.Property(parameter, FieldName);
            var method = typeof(string).GetMethod("Contains", new[] { typeof(string) });
            var value = Expression.Constant(FieldValue, typeof(string));
            var call = Expression.Call(property, method, value);

            return Expression.Lambda<Func<T, bool>>(call, parameter);
        }

        public static dynamic GridOperator<T>(this IEnumerable<T> obj, GridOperation Operations)
        {
            if (Operations != null)
                if (Operations.searchFields != null && !string.IsNullOrEmpty(Operations.searchKeyword))
                    if (Operations.sortExpression != null && Operations.sortExpression.Count > 0)
                        if (Operations.pageSize > 0 && Operations.currentPage > 0)
                            return
                                new
                                {
                                    ItemCount = obj.Search(Operations.searchFields, Operations.searchKeyword).Count(),
                                    DataSet =
                                        obj.Search(Operations.searchFields, Operations.searchKeyword)
                                            .Sort(Operations.sortExpression)
                                            .Skip(Operations.pageSize*(Operations.currentPage - 1))
                                            .Take(Operations.pageSize)
                                };
                        else
                            return
                                new
                                {
                                    ItemCount = obj.Search(Operations.searchFields, Operations.searchKeyword).Count(),
                                    DataSet =
                                        obj.Search(Operations.searchFields, Operations.searchKeyword)
                                            .Sort(Operations.sortExpression)
                                };
                    else if (Operations.pageSize > 0 && Operations.currentPage > 0)
                        return
                            new
                            {
                                ItemCount = obj.Search(Operations.searchFields, Operations.searchKeyword).Count(),
                                DataSet =
                                    obj.Search(Operations.searchFields, Operations.searchKeyword)
                                        .Skip(Operations.pageSize*(Operations.currentPage - 1))
                                        .Take(Operations.pageSize)
                            };
                    else
                        return
                            new
                            {
                                ItemCount = obj.Search(Operations.searchFields, Operations.searchKeyword).Count(),
                                DataSet = obj.Search(Operations.searchFields, Operations.searchKeyword)
                            };
                else if (Operations.sortExpression != null && Operations.sortExpression.Count > 0)
                    if (Operations.pageSize > 0 && Operations.currentPage > 0)
                        return
                            new
                            {
                                ItemCount = obj.Count(),
                                DataSet =
                                    obj.Sort(Operations.sortExpression)
                                        .Skip(Operations.pageSize*(Operations.currentPage - 1))
                                        .Take(Operations.pageSize)
                            };
                    else
                        return
                            new {ItemCount = obj.Count(), DataSet = obj.Sort(Operations.sortExpression)};
                else if (Operations.pageSize > 0 && Operations.currentPage > 0)
                    return
                        new
                        {
                            ItemCount = obj.Count(),
                            DataSet =
                                obj.Skip(Operations.pageSize*(Operations.currentPage - 1)).Take(Operations.pageSize)
                        };
                else
                    return new {ItemCount = obj.Count(), DataSet = obj};
            else
                return obj;
        }
    }

    [DataContract]
    public class SortExperssion
    {
        [DataMember]
        public string name { get; set; }
        [DataMember]
        public bool desc { get; set; }
    }

    [DataContract]
    public class GridOperation
    {
        [DataMember]
        public List<SortExperssion> sortExpression { get; set; }
        [DataMember]
        public List<string> searchFields { get; set; }
        [DataMember]
        public string searchKeyword { get; set; }
        [DataMember]
        public int pageSize { get; set; }
        [DataMember]
        public int currentPage { get; set; }
    }
}
