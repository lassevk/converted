using System;
using System.Collections.Generic;

namespace Converted.ValueConverters
{
    public abstract class BasicValueConverterProvider : IValueConverterProvider
    {
        private readonly Dictionary<(Type inputType, Type outputType), ValueConverterDelegate> _Converters =
            new Dictionary<(Type inputType, Type outputType), ValueConverterDelegate>();

        public (bool success, ValueConverterDelegate? valueConverter) TryGetConverter(Type inputType, Type outputType)
            => _Converters.TryGetValue((inputType, outputType), out ValueConverterDelegate converter) ? (true, converter) : (false, null);

        protected void Register<TInput, TOutput>(ValueConverterDelegate<TInput, TOutput> converter)
        {
            #pragma warning disable 8653
            Register(
                typeof(TInput), typeof(TOutput), (input, formatProvider) =>
                {
                    if (input == null)
                        return default(TOutput);

                    return converter((TInput)input, formatProvider);
                });

            #pragma warning restore 8653
        }

        protected void Register(Type inputType, Type outputType, ValueConverterDelegate converter)
        {
            _Converters.Add((inputType, outputType), converter);
        }
    }
}