using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.Services
{
    public class PropertyMapping<Tsource, Tdest>: IPropertyMapping
    {
        public Dictionary<string,PropertyMappingValue> mappingDictionary { get; private set; }

        public PropertyMapping(Dictionary<string, PropertyMappingValue> mappingDictionary)
        {
            this.mappingDictionary = mappingDictionary;
        }
    }
}
