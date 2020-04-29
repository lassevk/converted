using System;

namespace Converted.ValueConverters
{
    public class CharArrayValueConverterProvider : BasicValueConverterProvider
     {
         public CharArrayValueConverterProvider()
         {
             Register((char[] input, IFormatProvider? formatProvider) => new string(input));
             Register((string input, IFormatProvider? formatProvider) => input.ToCharArray());
         }
    }
}