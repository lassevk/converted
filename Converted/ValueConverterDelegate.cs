using System;

namespace Converted
{
    public delegate (bool success, object? output) ValueConverterDelegate(object? input, IFormatProvider? formatProvider = null);

    public delegate (bool success, TOutput output) ValueConverterDelegate<in TInput, TOutput>(TInput input, IFormatProvider? formatProvider = null);
}