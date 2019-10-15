using System;

namespace Converted
{
    public interface IValueConverterProvider
    {
        (bool success, ValueConverterDelegate? valueConverter) TryGetConverter(Type inputType, Type outputType);
    }
}