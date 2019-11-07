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

            return (input, provider) =>
            {
                var (success, output) = temp(input, provider);
                return (success, (TOutput)output!);
            };
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

        public static TOutput Convert<TInput, TOutput>(
            this IValueConverter valueConverter, TInput input, IFormatProvider? formatProvider = null)
        {
            var value = Convert(valueConverter, input, typeof(TInput), typeof(TOutput), formatProvider);
            if (value == null)
                return default!;

            return (TOutput)value;
        }

        public static T ConvertTo<T>(this IValueConverter valueConverter, object input, IFormatProvider? formatProvider = null)
        {
            if (input is null)
            {
                if (typeof(T).IsClass)
                    return default!;

                throw new FormatException($"Unable to convert from null value to '{typeof(T)}', conversion not possible");
            }

            var value = Convert(valueConverter, input, input.GetType(), typeof(T), formatProvider);
            if (value is null)
                return default!;

            return (T)value;
        }
    }
}