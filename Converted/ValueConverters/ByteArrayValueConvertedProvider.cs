using System;

namespace Converted.ValueConverters
{
    public class ByteArrayValueConvertedProvider : BasicValueConverterProvider
    {
        public ByteArrayValueConvertedProvider()
        {
            Register((byte[] input, IFormatProvider? formatProvider) => Convert.ToBase64String(input));
            Register((string input, IFormatProvider? formatProvider) => Convert.FromBase64String(input));
        }
    }
}