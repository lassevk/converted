using System;

namespace Converted
{
    public interface IValueConverter
    {
        ValueConverterDelegate? TryGetConverter(Type inputType, Type outputType);
    }
}