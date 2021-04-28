using FakeXieCheng.Demo.DTOS;
using FakeXieCheng.Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            propertyMappings.Add(new PropertyMapping<TouristRout, TouristRoutDTO>(touristRouteProperMapping));
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
    }


}
