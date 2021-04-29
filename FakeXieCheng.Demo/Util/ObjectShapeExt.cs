using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.Util
{
    public static class ObjectShapeExt
    {
        public static ExpandoObject ShapeData<Tsource>(this object source, string fields)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

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
            
            ExpandoObject expando = new ExpandoObject();
            propertyInfoList.ForEach(xt =>
            {
                var val = xt.GetValue(source);
                ((IDictionary<string, object>)expando).Add(xt.Name, val);
            });

            return expando;
        }
    }
}
