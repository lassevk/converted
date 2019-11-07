using System;

namespace Converted.ValueConverters
{
    public class BoxingValueConverterProvider : IValueConverterProvider
    {
        public (bool success, ValueConverterDelegate? valueConverter) TryGetConverter(IValueConverter mainValueConverter, Type inputType, Type outputType)
        {
            if (inputType == typeof(object) && !outputType.IsClass)
                return (true, (input, provider) =>
                {
                    if (input is null)
                        return (false, default!);

                    if (input.GetType() == outputType)
                        return (true, input);

                    return (false, default!);
                });

            if (!inputType.IsClass && outputType == typeof(object))
                return (true, (input, provider) => (true, input));

            return (false, null);
        }
    }
}