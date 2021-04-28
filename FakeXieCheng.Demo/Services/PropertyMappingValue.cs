using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeXieCheng.Demo.Services
{
    public class PropertyMappingValue
    {
        public IEnumerable<string>  DestinationPropertys { get; set; }
        public PropertyMappingValue(IEnumerable<string> destinationPropertys)
        {
            this.DestinationPropertys = destinationPropertys;
        }
        public PropertyMappingValue()
        {
            DestinationPropertys = new List<string>();
        }
    }
}