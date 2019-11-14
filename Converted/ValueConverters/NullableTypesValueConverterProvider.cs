using System;

namespace Converted.ValueConverters
{
    public class NullableTypesValueConverterProvider : IValueConverterProvider
    {
        public (bool success, ValueConverterDelegate? valueConverter) TryGetConverter(
            IValueConverter mainValueConverter, Type inputType, Type outputType)
        {
            if (inputType == null)
                throw new ArgumentNullException(nameof(inputType));

            if (outputType == null)
                throw new ArgumentNullException(nameof(outputType));

            var inputTypeIsNullable = inputType.IsGenericType && inputType.GetGenericTypeDefinition() == typeof(Nullable<>);
            var outputTypeIsNullable = outputType.IsGenericType && outputType.GetGenericTypeDefinition() == typeof(Nullable<>);

            if (inputTypeIsNullable && outputTypeIsNullable)
                return TryGetConverterFromNullableToNullable(mainValueConverter, inputType, outputType);

            if (inputTypeIsNullable)
                return TryGetConverterFromNullable(mainValueConverter, inputType, outputType);

            if (outputTypeIsNullable)
                return TryGetConverterToNullable(mainValueConverter, inputType, outputType);

            return (false, null);
        }

        private static (bool success, ValueConverterDelegate? valueConverter) TryGetConverterToNullable(IValueConverter mainValueConverter, Type inputType, Type outputType)
        {
            Type underlyingOutputType = outputType.GetGenericArguments()[0];
#pragma warning disable 8600
            ValueConverterDelegate converter = mainValueConverter.TryGetConverter(inputType, underlyingOutputType);
#pragma warning restore 8600
            return (converter != null, converter);
        }

        private static (bool success, ValueConverterDelegate? valueConverter) TryGetConverterFromNullable(IValueConverter mainValueConverter, Type inputType, Type outputType)
        {
            Type underlyingInputType = inputType.GetGenericArguments()[0];
#pragma warning disable 8600
            ValueConverterDelegate converter = mainValueConverter.TryGetConverter(underlyingInputType, outputType);
#pragma warning restore 8600
            return (converter != null, converter);
        }

        private static (bool success, ValueConverterDelegate? valueConverter) TryGetConverterFromNullableToNullable(IValueConverter mainValueConverter, Type inputType, Type outputType)
        {
            Type underlyingInputType = inputType.GetGenericArguments()[0];
            Type underlyingOutputType = outputType.GetGenericArguments()[0];
#pragma warning disable 8600
            ValueConverterDelegate converter = mainValueConverter.TryGetConverter(underlyingInputType, underlyingOutputType);
#pragma warning restore 8600
            if (converter == null)
                return (false, null);

            return (true, (input, provider) => input == null ? (true, null) : converter(input, provider));
        }
    }
}