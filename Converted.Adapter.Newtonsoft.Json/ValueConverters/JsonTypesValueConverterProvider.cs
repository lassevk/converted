using System;
using System.Linq;

using Converted.ValueConverters;

using Newtonsoft.Json.Linq;

namespace Converted.Adapter.Newtonsoft.Json.ValueConverters
{
    public class JsonTypesValueConverterProvider : BasicValueConverterProvider
    {
        public JsonTypesValueConverterProvider()
        {
            Register((JValue token, IFormatProvider? formatProvider) => token.Value<string>());
            
            Register((JValue value, IFormatProvider? formatProvider) => value.Value<byte>());
            Register((JValue value, IFormatProvider? formatProvider) => value.Value<sbyte>());
            
            Register((JValue value, IFormatProvider? formatProvider) => value.Value<short>());
            Register((JValue value, IFormatProvider? formatProvider) => value.Value<ushort>());
            
            Register((JValue value, IFormatProvider? formatProvider) => value.Value<int>());
            Register((JValue value, IFormatProvider? formatProvider) => value.Value<uint>());
            
            Register((JValue value, IFormatProvider? formatProvider) => value.Value<long>());
            Register((JValue value, IFormatProvider? formatProvider) => value.Value<ulong>());
            
            Register((JValue value, IFormatProvider? formatProvider) => value.Value<float>());
            Register((JValue value, IFormatProvider? formatProvider) => value.Value<double>());
            Register((JValue value, IFormatProvider? formatProvider) => value.Value<decimal>());
            
            Register((JValue value, IFormatProvider? formatProvider) => value.Value<DateTime>());
            
            Register((JValue value, IFormatProvider? formatProvider) => value.Value<bool>());

            Register((JValue value, IFormatProvider? formatProvider) => Guid.Parse(value.Value<string>()));
            Register((JValue value, IFormatProvider? formatProvider) => Version.Parse(value.Value<string>()));
            Register((JValue value, IFormatProvider? formatProvider) => new Uri(value.Value<string>()));

            Register((JValue value, IFormatProvider? formatProvider) => value.Value<string>().ToCharArray());
            Register((JValue value, IFormatProvider? formatProvider) => Convert.FromBase64String(value.Value<string>()));

            Register((JArray array, IFormatProvider? formatProvider) => array.Select(token => token.Value<string>()));
            Register((JArray array, IFormatProvider? formatProvider) => array.Select(token => token.Value<string>().ToArray()));
            Register((JArray array, IFormatProvider? formatProvider) => array.Select(token => token.Value<string>().ToList()));
        }
    }
}