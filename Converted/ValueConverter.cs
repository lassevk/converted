using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Converted
{
    public class ValueConverter : IValueConverter
    {
        private static readonly ValueConverterDelegate _IdentityConverter = (value, formatProvider) => (true, value);

        private static readonly Lazy<IValueConverter> _Default = new Lazy<IValueConverter>(
            () => new ValueConverter(DefaultValueConverterProviders.Collection), LazyThreadSafetyMode.ExecutionAndPublication);

        private readonly object _Lock = new object();

        private readonly Dictionary<(Type inputType, Type outputType), ValueConverterDelegate> _Converters =
            new Dictionary<(Type inputType, Type outputType), ValueConverterDelegate>();

        private readonly List<IValueConverterProvider> _ValueConverterProviders;

        public ValueConverter(IEnumerable<IValueConverterProvider> valueConverterProviders)
        {
            if (valueConverterProviders == null)
                throw new ArgumentNullException(nameof(valueConverterProviders));

            _ValueConverterProviders = valueConverterProviders.ToList();
        }

        public static IValueConverter Default => _Default.Value;

        public ValueConverterDelegate? TryGetConverter(Type inputType, Type outputType)
        {
            if (inputType == null)
                throw new ArgumentNullException(nameof(inputType));

            if (outputType == null)
                throw new ArgumentNullException(nameof(outputType));

            if (inputType == outputType)
                return _IdentityConverter;

            (Type sourceType, Type targetType) key = (sourceType: inputType, targetType: outputType);

            lock (_Lock)
            {
                if (_Converters.TryGetValue(key, out ValueConverterDelegate converter))
                    return converter;

                converter = TrySynthesizeConverter(inputType, outputType);
                if (converter == null)
                    return null;

                _Converters[key] = converter;
                return converter;
            }
        }

        private ValueConverterDelegate TrySynthesizeConverter(Type inputType, Type outputType)
            => (
                from provider in _ValueConverterProviders
                let result = provider.TryGetConverter(this, inputType, outputType)
                where result.success
                select result.valueConverter).FirstOrDefault();
    }
}