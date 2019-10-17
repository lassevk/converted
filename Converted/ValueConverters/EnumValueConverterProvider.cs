using System;

namespace Converted.ValueConverters
{
    public class EnumValueConverterProvider : IValueConverterProvider
    {
        public (bool success, ValueConverterDelegate? valueConverter) TryGetConverter(IValueConverter mainValueConverter, Type inputType, Type outputType)
        {
            if (inputType.IsEnum && !outputType.IsEnum)
                return TryGetConverterFromEnum(mainValueConverter, inputType, outputType);

            return (false, null);
        }

        private (bool success, ValueConverterDelegate? valueConverter) TryGetConverterFromEnum(IValueConverter mainValueConverter, Type inputType, Type outputType)
        {
            var underlyingType = inputType.GetEnumUnderlyingType();

            if (underlyingType == outputType)
                return (true, delegate(object? input, IFormatProvider? formatProvider)
                {
                    if (input == null)
                        return (false, null);
                    var output = Convert.ChangeType(input, outputType);
                    return (output != null, output);
                });

            return (false, null);
        }
    }
}