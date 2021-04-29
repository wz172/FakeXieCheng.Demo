using System.Collections.Generic;

namespace FakeXieCheng.Demo.Services
{
    public interface IPropertyMappingServer
    {
        Dictionary<string, PropertyMappingValue> GetPropertyMapping<Tsource, Tdest>();
        bool ExistPropertys<TSource, Tdest>(string fields);
        bool ExistShapeFields<Tsource>(string fields);
    }
}