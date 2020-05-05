using System;
using System.Linq;

using Newtonsoft.Json.Linq;

namespace Converted.Adapter.Newtonsoft.Json.ValueConverters
{
    public class JsonSerializationValueConverterProvider : IValueConverterProvider
    {
        private readonly Type[] _SupportedTypes = new[] { typeof(JObject), typeof(JArray), typeof(JValue) };
        
        public (bool success, ValueConverterDelegate? valueConverter) TryGetConverter(
            IValueConverter mainValueConverter, Type inputType, Type outputType)
        {
            if (_SupportedTypes.Contains(inputType))
                return (true, (input, provider) =>
                {
                    if (!(input is JToken token))
                        return (false, default);
                    
                    var output = token.ToObject(outputType);
                    return (output != null, output);
                });

            return (false, null);
        }
    }
}