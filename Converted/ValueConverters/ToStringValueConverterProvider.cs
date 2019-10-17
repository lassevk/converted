using System;

namespace Converted.ValueConverters
{
    public class ToStringValueConverterProvider : IValueConverterProvider
    {
        private static readonly ValueConverterDelegate _Converter = ConvertToString;

        private static (bool success, object? output) ConvertToString(object? input, IFormatProvider? formatProvider)
        {
            if (input == null)
                return (true, ""); // In line with Convert.ToString((object)null)

            if (formatProvider != null)
                if (input is IFormattable formattable)
                    return (true, formattable.ToString(null, formatProvider));

            return (true, input.ToString());
        }

        public (bool success, ValueConverterDelegate? valueConverter) TryGetConverter(Type inputType, Type outputType)
            => outputType == typeof(string) ? (true, _Converter) : (false, null);
    }
}