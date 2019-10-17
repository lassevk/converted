using System;

namespace Converted
{
    public interface IValueConverterProvider
    {
        (bool success, ValueConverterDelegate? valueConverter) TryGetConverter(IValueConverter mainValueConverter, Type inputType, Type outputType);
    }
}