using System;

namespace Converted.ValueConverters
{
    public class ToStringValueConverterProvider : IValueConverterProvider
    {
        private static readonly ValueConverterDelegate _Converter = ConvertToString;

        private static object? ConvertToString(object? input, IFormatProvider? formatProvider)
        {
            if (input == null)
                return null;

            if (formatProvider != null)
                if (input is IFormattable formattable)
                    return formattable.ToString(null, formatProvider);

            return input.ToString();
        }

        public (bool success, ValueConverterDelegate? valueConverter) TryGetConverter(Type inputType, Type outputType)
            => outputType == typeof(string) ? (true, _Converter) : (false, null);
    }
}