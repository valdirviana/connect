using ConnectAPI.Domain.Base.Filter;
using System;
using System.Collections.Generic;

namespace ConnectAPI.Repository.Helper
{
    public class SearchHelper
    {
        public class DynamicWhereDapper
        {
            public string Condition { get; set; }
            public IDictionary<string, dynamic> Param { get; set; }
            public string DbField { get; set; }
        }

        public static IEnumerable<DynamicWhereDapper> GetWhereText(IEnumerable<BaseFilter> filters, IReadOnlyDictionary<string, string> searchDictionary)
        {
            var whereDynamicList = new List<DynamicWhereDapper>();

            if (filters == null) return whereDynamicList;

            foreach (var filter in filters)
            {
                string field;

                searchDictionary.TryGetValue(filter.Property, out field);
                if (string.IsNullOrEmpty(field)) field = filter.Property;

                if (filter.Value != null && field != null)
                {
                    var dynamicWhere = new DynamicWhereDapper { DbField = field };

                    switch (filter.Condition)
                    {
                        case Conditions.Equals:
                            dynamicWhere.Condition = $"{field} = @{filter.Property}";
                            dynamicWhere.Param = new Dictionary<string, dynamic> { { filter.Property, filter.Value } };
                            whereDynamicList.Add(dynamicWhere);
                            break;
                        case Conditions.NotEquals:
                            dynamicWhere.Condition = $"{field} <> @{filter.Property}";
                            dynamicWhere.Param = new Dictionary<string, dynamic> { { filter.Property, filter.Value } };
                            whereDynamicList.Add(dynamicWhere);
                            break;
                        case Conditions.NotContains:
                            dynamicWhere.Condition = $"{field} NOT LIKE @{filter.Property}";
                            dynamicWhere.Param = new Dictionary<string, dynamic> { { filter.Property, "%" + filter.Value + "%" } };
                            whereDynamicList.Add(dynamicWhere);
                            break;
                        case Conditions.GreaterThan:
                            dynamicWhere.Condition = $"{field} > @{filter.Property}";
                            dynamicWhere.Param = new Dictionary<string, dynamic> { { filter.Property, filter.Value } };
                            whereDynamicList.Add(dynamicWhere);
                            break;
                        case Conditions.GreaterThanOrEqual:
                            dynamicWhere.Condition = $"{field} >= @{filter.Property}";
                            dynamicWhere.Param = new Dictionary<string, dynamic> { { filter.Property, filter.Value } };
                            whereDynamicList.Add(dynamicWhere);
                            break;
                        case Conditions.LessThan:
                            dynamicWhere.Condition = $"{field} < @{filter.Property}";
                            dynamicWhere.Param = new Dictionary<string, dynamic> { { filter.Property, filter.Value } };
                            whereDynamicList.Add(dynamicWhere);
                            break;
                        case Conditions.LessThanOrEqual:
                            dynamicWhere.Condition = $"{field} <= @{filter.Property}";
                            dynamicWhere.Param = new Dictionary<string, dynamic> { { filter.Property, filter.Value } };
                            whereDynamicList.Add(dynamicWhere);
                            break;
                        case Conditions.Contains:
                            dynamicWhere.Condition = $"{field} LIKE @{filter.Property}";
                            dynamicWhere.Param = new Dictionary<string, dynamic> { { filter.Property, "%" + filter.Value + "%" } };
                            whereDynamicList.Add(dynamicWhere);
                            break;
                        case Conditions.StartsWith:
                            dynamicWhere.Condition = $"{field} LIKE @{filter.Property}";
                            dynamicWhere.Param = new Dictionary<string, dynamic> { { filter.Property, filter.Value + "%" } };
                            whereDynamicList.Add(dynamicWhere);
                            break;
                        case Conditions.EndsWith:
                            dynamicWhere.Condition = $"{field} LIKE @{filter.Property}";
                            dynamicWhere.Param = new Dictionary<string, dynamic> { { filter.Property, "%" + filter.Value } };
                            whereDynamicList.Add(dynamicWhere);
                            break;
                        case Conditions.IsNull:
                            dynamicWhere.Condition = $"{field} IS NULL ";
                            whereDynamicList.Add(dynamicWhere);
                            break;
                        case Conditions.IsNotNull:
                            dynamicWhere.Condition = $"{field} IS NOT NULL ";
                            whereDynamicList.Add(dynamicWhere);
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }
            }
            return whereDynamicList;
        }
    }
}
