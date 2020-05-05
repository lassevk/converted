using System.Linq;

using Converted.Adapter.Newtonsoft.Json.ValueConverters;

namespace Converted.Adapter.Newtonsoft.Json
{
    public static class Registrar
    {
        public static void Register()
        {
            if (DefaultValueConverterProviders.Collection.OfType<JsonTypesValueConverterProvider>().Any())
                return;

            DefaultValueConverterProviders.Collection.Add(new JsonTypesValueConverterProvider());
            DefaultValueConverterProviders.Collection.Add(new JsonEnumValueConverterProvider());
            DefaultValueConverterProviders.Collection.Add(new JsonSerializationValueConverterProvider());
        }
    }
}