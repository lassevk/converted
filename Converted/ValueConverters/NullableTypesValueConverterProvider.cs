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
            {
                Type underlyingInputType = inputType.GetGenericArguments()[0];
                Type underlyingOutputType = outputType.GetGenericArguments()[0];
#pragma warning disable 8600
                ValueConverterDelegate converter = mainValueConverter.TryGetConverter(underlyingInputType, underlyingOutputType);
#pragma warning restore 8600
                return (converter != null, converter);
            }

            if (inputTypeIsNullable)
            {
                Type underlyingInputType = inputType.GetGenericArguments()[0];
#pragma warning disable 8600
                ValueConverterDelegate converter = mainValueConverter.TryGetConverter(underlyingInputType, outputType);
#pragma warning restore 8600
                return (converter != null, converter);
            }

            if (outputTypeIsNullable)
            {
                Type underlyingOutputType = outputType.GetGenericArguments()[0];
#pragma warning disable 8600
                ValueConverterDelegate converter = mainValueConverter.TryGetConverter(inputType, underlyingOutputType);
#pragma warning restore 8600
                return (converter != null, converter);
            }

            return (false, null);
        }
    }
}