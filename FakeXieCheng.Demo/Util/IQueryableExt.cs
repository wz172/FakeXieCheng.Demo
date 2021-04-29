using FakeXieCheng.Demo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;

namespace FakeXieCheng.Demo.Util
{
    public static class IQueryableExt
    {
        public static IQueryable<T> ApplySort<T>(this IQueryable<T> source,string orderBy,Dictionary<string, PropertyMappingValue> mappingDic)
        {
            if (source==null)
            {
                throw new ArgumentNullException("source");
            }
            if (string.IsNullOrEmpty(orderBy))
            {
                throw new ArgumentNullException("orderBy");
            }
            if (mappingDic == null)
            {
                throw new ArgumentNullException("mappingDic");
            }
            var orderByStr = string.Empty;
            string[] inputOrderByStrArray = orderBy.Split(',');
            foreach (string itemStr in inputOrderByStrArray)
            {
                bool orderbyDesc = itemStr.Trim().EndsWith("desc");

                //找到字段名称
                string propertyName = string.Empty;
                int blankIndexOfstr = itemStr.IndexOf(' ');
                if (blankIndexOfstr==-1)
                {
                    propertyName = itemStr;
                }
                else
                {
                    propertyName = itemStr.Substring(0, blankIndexOfstr );
                }
                if (!mappingDic.ContainsKey(propertyName))
                {
                    throw new Exception($"mappingDic 不包含key {propertyName}");
                }

                var propertyMappingValue = mappingDic[propertyName];
                if (propertyMappingValue==null)
                {
                    throw new Exception("propertyMappingValue不能为空");
                }

                foreach (var destinationProperty in propertyMappingValue.DestinationPropertys.Reverse())
                {
                    if (!string.IsNullOrEmpty(orderByStr))
                    {
                        orderByStr += " ,";
                    }
                    orderByStr += destinationProperty;
                    if (orderbyDesc)
                    {
                        orderByStr += " descending";
                    }
                    else
                    {
                        orderByStr += " ascending";
                    }
                }
            }
            return source.OrderBy(orderByStr);
        }
    }
}
