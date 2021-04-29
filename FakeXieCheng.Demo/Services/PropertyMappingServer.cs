using FakeXieCheng.Demo.DTOS;
using FakeXieCheng.Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.Services
{
    public class PropertyMappingServer : IPropertyMappingServer
    {
        private Dictionary<string, PropertyMappingValue> touristRouteProperMapping = new Dictionary<string, PropertyMappingValue>(StringComparer.OrdinalIgnoreCase)
        {
            {"Id",new PropertyMappingValue (new List<string>(){  "ID"}) },
            { "Title",new PropertyMappingValue(new List<string>(){ "title"})},
             { "Rating",new PropertyMappingValue(new List<string>(){ "Rating"})},
              { "OriginalPrice",new PropertyMappingValue(new List<string>(){ "OriginalPrice"})},
        };

        private IList<IPropertyMapping> propertyMappings = new List<IPropertyMapping>();

        public PropertyMappingServer()
        {
            propertyMappings.Add(new PropertyMapping<TouristRoutDTO, TouristRout>(touristRouteProperMapping));
        }
        public Dictionary<string, PropertyMappingValue> GetPropertyMapping<Tsource, Tdest>()
        {
            //获取匹配的映射对象
            var matchingMapping = propertyMappings.OfType<PropertyMapping<Tsource, Tdest>>();
            if (matchingMapping.Count() == 1)
            {
                return matchingMapping.First().mappingDictionary;
            }
            throw new Exception($"没办法找到属性映射字典<{typeof(Tsource)},{typeof(Tdest)}>");
        }

        public bool ExistPropertys<TSource, Tdest>(string fields)
        {
            if (string.IsNullOrEmpty(fields))
            {
                return true;
            }
            var mappingDic = GetPropertyMapping<TSource, Tdest>();
            if (mappingDic == null)
            {
                return false;
            }
            string[] propertysInputArray = fields.Split(',');
            foreach (string itemPropInput in propertysInputArray)
            {
                string tirmProperty = itemPropInput.Trim();
                //获取用户输的的字段名称
                int blankIndex = itemPropInput.IndexOf(" ");
                string orderByPropertyName = string.Empty;
                if (blankIndex == -1)
                {
                    orderByPropertyName = itemPropInput;
                }
                else
                {
                    orderByPropertyName = itemPropInput.Substring(0, blankIndex);
                }
                if (!mappingDic.ContainsKey(orderByPropertyName))
                {
                    return false;
                }
            }
            return true;
        }

        public  bool ExistShapeFields<Tsource>(string fields)
        {
            if (string.IsNullOrEmpty(fields))
            {
                return true;
            }
            //获取类型所有属性字段
            PropertyInfo[] propertyinfoArrayOfAllPublic = typeof(Tsource).GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);
            string[] propertysStrArrayOfInput = fields.Split(',');
            foreach (string itemPropertyStr in propertysStrArrayOfInput)
            {
                if (!propertyinfoArrayOfAllPublic.Any(xt => xt.Name.ToLowerInvariant() == itemPropertyStr.Trim().ToLowerInvariant()))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
