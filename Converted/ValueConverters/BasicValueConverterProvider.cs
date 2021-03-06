﻿using System;
using System.Collections.Generic;

namespace Converted.ValueConverters
{
    public abstract class BasicValueConverterProvider : IValueConverterProvider
    {
        private readonly Dictionary<(Type inputType, Type outputType), ValueConverterDelegate> _Converters =
            new Dictionary<(Type inputType, Type outputType), ValueConverterDelegate>();

        public (bool success, ValueConverterDelegate? valueConverter) TryGetConverter(IValueConverter mainValueConverter, Type inputType, Type outputType)
            => _Converters.TryGetValue((inputType, outputType), out ValueConverterDelegate converter) ? (true, converter) : (false, null);

        protected void Register<TInput, TOutput>(Func<TInput, IFormatProvider?, TOutput> converter)
        {
#pragma warning disable 8601,8604
            Register(typeof(TInput), typeof(TOutput), (input, formatProvider) => (true, converter((TInput)input, formatProvider)));
#pragma warning restore 8601,8604
        }

        protected void Register<TInput, TOutput>(ValueConverterDelegate<TInput, TOutput> converter)
        {
#pragma warning disable 8601,8604
            Register(typeof(TInput), typeof(TOutput), (input, formatProvider) => converter((TInput)input, formatProvider));
#pragma warning restore 8601,8604
        }

        private void Register(Type inputType, Type outputType, ValueConverterDelegate converter)
        {
            _Converters.Add((inputType, outputType), converter);
        }
    }
}