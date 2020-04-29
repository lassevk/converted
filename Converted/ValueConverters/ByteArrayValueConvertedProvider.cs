using System;

namespace Converted.ValueConverters
{
    public class ByteArrayValueConvertedProvider : BasicValueConverterProvider
    {
        public ByteArrayValueConvertedProvider()
        {
            Register((byte[] input, IFormatProvider? formatProvider) => Convert.ToBase64String(input));
            Register((string input, IFormatProvider? formatProvider) => Convert.FromBase64String(input));
            
            Register((byte[] input, IFormatProvider? formatProvider) => new Guid(input));
            Register((Guid input, IFormatProvider? formatProvider) => input.ToByteArray());
        }
    }
}