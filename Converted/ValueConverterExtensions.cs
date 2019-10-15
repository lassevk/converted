using System;

namespace Converted
{
    public static class ValueConverterExtensions
    {
        public static ValueConverterDelegate<TInput, TOutput>? TryGetConverter<TInput, TOutput>(this IValueConverter valueConverter)
        {
            ValueConverterDelegate? temp = valueConverter.TryGetConverter(typeof(TInput), typeof(TOutput));
            if (temp == null)
                return null;

#pragma warning disable 8601
            return (input, provider) => (TOutput)temp(input, provider);
#pragma warning restore 8601
        }

        public static (bool success, object? output) TryConvert(
            this IValueConverter valueConverter, object? input, Type inputType, Type outputType, IFormatProvider? formatProvider = null)
        {
            ValueConverterDelegate? converter = valueConverter.TryGetConverter(inputType, outputType);
            return converter == null ? (false, null) : (true, converter(input, formatProvider));
        }

        public static (bool success, TOutput output) TryConvert<TInput, TOutput>(
            this IValueConverter valueConverter, TInput input, IFormatProvider? formatProvider = null)
        {
            ValueConverterDelegate<TInput, TOutput>? converter = valueConverter.TryGetConverter<TInput, TOutput>();
            return converter == null ? (false, default) : (true, converter(input, formatProvider));
        }

        public static object? Convert(
            this IValueConverter valueConverter, object? input, Type inputType, Type outputType, IFormatProvider? formatProvider = null)
        {
            ValueConverterDelegate? converter = valueConverter.TryGetConverter(inputType, outputType);
            if (converter == null)
                throw new FormatException($"Unable to convert from type '{inputType}' to '{outputType}', no conversion registered");

            return converter(input, formatProvider);
        }

#pragma warning disable 8601
        public static TOutput Convert<TInput, TOutput>(
            this IValueConverter valueConverter, TInput input, IFormatProvider? formatProvider = null)
            => (TOutput)Convert(valueConverter, input, typeof(TInput), typeof(TOutput), formatProvider);
#pragma warning restore 8601
    }
}