using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.Util
{
    public static class IEnumerableExt
    {
        public static IEnumerable<ExpandoObject> ShapeData<Tsource>(this IEnumerable<Tsource> source, string fields)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            var expandoObjectList = new List<ExpandoObject>();
            var propertyInfoList = new List<PropertyInfo>();
            if (string.IsNullOrEmpty(fields))
            {
                //1 此时返回所有类型字段
                var propertyInfoLs = typeof(Tsource).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
                propertyInfoList.AddRange(propertyInfoLs);
            }
            else
            {
                string[] propertyInputStrArray = fields.Split(',');
                foreach (string propertyInpurStr in propertyInputStrArray)
                {
                    //2 获取用户输入字符串对应的属性
                    var propertyInfo = typeof(Tsource).GetProperty(propertyInpurStr.Trim(), BindingFlags.Public | BindingFlags.IgnoreCase | BindingFlags.Instance);
                    if (propertyInfo == null)
                    {
                        throw new ArgumentException(nameof(propertyInpurStr));
                    }
                    propertyInfoList.Add(propertyInfo);
                }
            }
            //3 致此propertyInfoList列表中存储了对象需要数据塑型的 属性  开始遍历数据源
            foreach (Tsource itemSource in source)
            {
                ExpandoObject expando = new ExpandoObject();
                propertyInfoList.ForEach(xt =>
                {
                    var val = xt.GetValue(itemSource);
                    ((IDictionary<string, object>)expando).Add(xt.Name, val);
                });
                expandoObjectList.Add(expando);
            }
            return expandoObjectList;
        }
    }
}
