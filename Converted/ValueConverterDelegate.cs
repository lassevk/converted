using System;

namespace Converted
{
    public delegate object? ValueConverterDelegate(object? input, IFormatProvider? formatProvider = null);

    public delegate TOutput ValueConverterDelegate<in TInput, out TOutput>(TInput input, IFormatProvider? formatProvider = null);
}