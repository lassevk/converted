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
            return (input, provider) =>
            {
                var (success, output) = temp(input, provider);
                return (success, (TOutput)output);
            };
#pragma warning restore 8601
        }

        public static (bool success, object? output) TryConvert(
            this IValueConverter valueConverter, object? input, Type inputType, Type outputType, IFormatProvider? formatProvider = null)
        {
            ValueConverterDelegate? converter = valueConverter.TryGetConverter(inputType, outputType);
            return converter?.Invoke(input, formatProvider) ?? (false, null);
        }

        public static (bool success, TOutput output) TryConvert<TInput, TOutput>(
            this IValueConverter valueConverter, TInput input, IFormatProvider? formatProvider = null)
        {
            ValueConverterDelegate<TInput, TOutput>? converter = valueConverter.TryGetConverter<TInput, TOutput>();
            return converter?.Invoke(input, formatProvider) ?? (false, default);
        }

        public static object? Convert(
            this IValueConverter valueConverter, object? input, Type inputType, Type outputType, IFormatProvider? formatProvider = null)
        {
            ValueConverterDelegate? converter = valueConverter.TryGetConverter(inputType, outputType);
            if (converter == null)
                throw new FormatException($"Unable to convert from type '{inputType}' to '{outputType}', no conversion registered");

            var (success, output) = converter(input, formatProvider);
            if (!success)
                throw new FormatException($"Unable to convert from type '{inputType}' to '{outputType}', conversion not possible");

            return output;

        }

#pragma warning disable 8601
        public static TOutput Convert<TInput, TOutput>(
            this IValueConverter valueConverter, TInput input, IFormatProvider? formatProvider = null)
            => (TOutput)Convert(valueConverter, input, typeof(TInput), typeof(TOutput), formatProvider);
#pragma warning restore 8601
    }
}