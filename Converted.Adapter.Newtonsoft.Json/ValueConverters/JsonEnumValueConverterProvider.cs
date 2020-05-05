using System;

using Newtonsoft.Json.Linq;

namespace Converted.Adapter.Newtonsoft.Json.ValueConverters
{
    public class JsonEnumValueConverterProvider : IValueConverterProvider
    {
        public (bool success, ValueConverterDelegate? valueConverter) TryGetConverter(
            IValueConverter mainValueConverter, Type inputType, Type outputType)
        {
            if (inputType != typeof(JValue) && inputType != typeof(JObject) && inputType != typeof(JArray))
                return (false, null);

            if (!outputType.IsEnum)
                return (false, null);

            return (true, (input, provider) => ConvertValueToEnum(input, provider, outputType, mainValueConverter));
        }

        private (bool success, object? output) ConvertValueToEnum(
            object? input, IFormatProvider? formatprovider, Type outputType, IValueConverter mainValueConverter)
        {
            if (!(input is JToken token))
                return (false, null);

            object? result = null;
            switch (token)
            {
                case JObject obj:
                    result = ConvertObjectToEnum(obj, outputType, mainValueConverter);
                    break;

                case JArray array:
                    result = ConvertArrayToEnum(array, outputType, mainValueConverter);
                    break;

                case JValue value when value.Type == JTokenType.String:
                    result = ConvertStringToEnum(value.Value<string>(), outputType, mainValueConverter);
                    break;

                case JValue value when value.Type == JTokenType.Integer:
                    result = ConvertIntegerToEnum(value.Value<int>(), outputType, mainValueConverter);
                    break;
            }

            return (result != null, result);
        }

        private int GetInt32Value(string name, Type enumType, IValueConverter mainValueConverter)
        {
            object? enumValue = mainValueConverter.Convert(name, typeof(string), enumType);
            if (enumValue is null)
                return 0;

            var integerValue = (int?)mainValueConverter.Convert(enumValue, enumType, typeof(int));
            return integerValue ?? 0;
        }

        private int GetInt32Value(JValue value, Type enumType, IValueConverter mainValueConverter)
        {
            if (value.Type == JTokenType.String)
                return GetInt32Value(value.Value<string>(), enumType, mainValueConverter);

            return value.Value<int>();
        }

        private object? ConvertObjectToEnum(JObject obj, Type outputType, IValueConverter mainValueConverter)
        {
            var value = 0;
            foreach (JProperty property in obj.Properties())
            {
                var name = property.Name;
                if (!Enum.IsDefined(outputType, name))
                    continue;

                var isIncluded = property.Value.Value<bool>();
                if (!isIncluded)
                    continue;

                value |= GetInt32Value(name, outputType, mainValueConverter);
            }

            return mainValueConverter.Convert(value, typeof(int), outputType);
        }

        private object? ConvertArrayToEnum(JArray array, Type outputType, IValueConverter mainValueConverter)
        {
            var value = 0;
            foreach (JToken element in array)
            {
                if (element is JValue elementValue)
                    value |= GetInt32Value(elementValue, outputType, mainValueConverter);
            }

            return mainValueConverter.Convert(value, typeof(int), outputType);
        }

        private object? ConvertStringToEnum(string value, Type outputType, IValueConverter mainValueConverter)
        {
            Console.WriteLine("Here");
            return mainValueConverter.Convert(GetInt32Value(value, outputType, mainValueConverter), typeof(int), outputType);
        }

        private object? ConvertIntegerToEnum(int value, Type outputType, IValueConverter mainValueConverter)
            => mainValueConverter.Convert(value, typeof(int), outputType);
    }
}