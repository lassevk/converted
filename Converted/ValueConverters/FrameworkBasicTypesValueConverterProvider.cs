using System;
using System.Globalization;

namespace Converted.ValueConverters
{
    public class FrameworkBasicTypesValueConverterProvider : BasicValueConverterProvider
    {
        public FrameworkBasicTypesValueConverterProvider()
        {
            RegisterByteConversions();
            RegisterSByteConversions();
            RegisterUInt16Conversions();
            RegisterInt16Conversions();
            RegisterUInt32Conversions();
            RegisterInt32Conversions();
            RegisterUInt64Conversions();
            RegisterInt64Conversions();
            RegisterSingleConversions();
            RegisterDoubleConversions();
            RegisterDecimalConversions();
            RegisterBooleanConversions();
            RegisterStringConversions();
        }

        private void RegisterStringConversions()
        {
            Register((byte input, IFormatProvider? formatProvider) => input.ToString(formatProvider));
            Register((string input, IFormatProvider? formatProvider) => byte.TryParse(input, NumberStyles.Any, formatProvider, out byte output) ? output : (byte)0);

            Register((sbyte input, IFormatProvider? formatProvider) => input.ToString(formatProvider));
            Register((string input, IFormatProvider? formatProvider) => sbyte.TryParse(input, NumberStyles.Any, formatProvider, out sbyte output) ? output : (sbyte)0);
        
            Register((short input, IFormatProvider? formatProvider) => input.ToString(formatProvider));
            Register((string input, IFormatProvider? formatProvider) => short.TryParse(input, NumberStyles.Any, formatProvider, out short output) ? output : (short)0);
        
            Register((ushort input, IFormatProvider? formatProvider) => input.ToString(formatProvider));
            Register((string input, IFormatProvider? formatProvider) => ushort.TryParse(input, NumberStyles.Any, formatProvider, out ushort output) ? output : (ushort)0);
        
            Register((int input, IFormatProvider? formatProvider) => input.ToString(formatProvider));
            Register((string input, IFormatProvider? formatProvider) => int.TryParse(input, NumberStyles.Any, formatProvider, out int output) ? output : 0);

            Register((uint input, IFormatProvider? formatProvider) => input.ToString(formatProvider));
            Register((string input, IFormatProvider? formatProvider) => uint.TryParse(input, NumberStyles.Any, formatProvider, out uint output) ? output : (uint)0);
        
            Register((long input, IFormatProvider? formatProvider) => input.ToString(formatProvider));
            Register((string input, IFormatProvider? formatProvider) => long.TryParse(input, NumberStyles.Any, formatProvider, out long output) ? output : (long)0);
        
            Register((ulong input, IFormatProvider? formatProvider) => input.ToString(formatProvider));
            Register((string input, IFormatProvider? formatProvider) => ulong.TryParse(input, NumberStyles.Any, formatProvider, out ulong output) ? output : (ulong)0);
        
            Register((float input, IFormatProvider? formatProvider) => input.ToString(formatProvider));
            Register((string input, IFormatProvider? formatProvider) => float.TryParse(input, NumberStyles.Any, formatProvider, out float output) ? output : 0f);

            Register((double input, IFormatProvider? formatProvider) => input.ToString(formatProvider));
            Register((string input, IFormatProvider? formatProvider) => double.TryParse(input, NumberStyles.Any, formatProvider, out double output) ? output : 0.0);
        
            Register((decimal input, IFormatProvider? formatProvider) => input.ToString(formatProvider));
            Register((string input, IFormatProvider? formatProvider) => decimal.TryParse(input, NumberStyles.Any, formatProvider, out decimal output) ? output : 0M);

            Register(
                (string input, IFormatProvider? formatProvider) => input switch
                {
                    "False" => false,
                    "FALSE" => false,
                    "false" => false,
                    "0" => false,
                    "True" => true,
                    "TRUE" => true,
                    "true" => true,
                    "1" => true,
                    _ => false
                });
        }

        private void RegisterBooleanConversions()
        {
            Register((bool input, IFormatProvider? formatProvider) => input ? (byte)1 : (byte)0);
            Register((bool input, IFormatProvider? formatProvider) => input ? (sbyte)1 : (sbyte)0);
            Register((bool input, IFormatProvider? formatProvider) => input ? (ushort)1 : (ushort)0);
            Register((bool input, IFormatProvider? formatProvider) => input ? (short)1 : (short)0);
            Register((bool input, IFormatProvider? formatProvider) => input ? (uint)1 : (uint)0);
            Register((bool input, IFormatProvider? formatProvider) => input ? 1 : 0);
            Register((bool input, IFormatProvider? formatProvider) => input ? (ulong)1 : (ulong)0);
            Register((bool input, IFormatProvider? formatProvider) => input ? (long)1 : (long)0);
            Register((bool input, IFormatProvider? formatProvider) => input ? "True" : "False");
        }

        private void RegisterByteConversions()
        {
            Register((byte input, IFormatProvider? formatProvider) => (sbyte)input);

            Register((byte input, IFormatProvider? formatProvider) => (short)input);
            Register((byte input, IFormatProvider? formatProvider) => (ushort)input);

            Register((byte input, IFormatProvider? formatProvider) => (int)input);
            Register((byte input, IFormatProvider? formatProvider) => (uint)input);

            Register((byte input, IFormatProvider? formatProvider) => (long)input);
            Register((byte input, IFormatProvider? formatProvider) => (ulong)input);

            Register((byte input, IFormatProvider? formatProvider) => (float)input);
            Register((byte input, IFormatProvider? formatProvider) => (double)input);
            Register((byte input, IFormatProvider? formatProvider) => (decimal)input);

            Register((byte input, IFormatProvider? formatProvider) => input != 0);
        }

        private void RegisterSByteConversions()
        {
            Register((sbyte input, IFormatProvider? formatProvider) => (byte)input);

            Register((sbyte input, IFormatProvider? formatProvider) => (short)input);
            Register((sbyte input, IFormatProvider? formatProvider) => (ushort)input);

            Register((sbyte input, IFormatProvider? formatProvider) => (int)input);
            Register((sbyte input, IFormatProvider? formatProvider) => (uint)input);

            Register((sbyte input, IFormatProvider? formatProvider) => (long)input);
            Register((sbyte input, IFormatProvider? formatProvider) => (ulong)input);

            Register((sbyte input, IFormatProvider? formatProvider) => (float)input);
            Register((sbyte input, IFormatProvider? formatProvider) => (double)input);
            Register((sbyte input, IFormatProvider? formatProvider) => (decimal)input);

            Register((sbyte input, IFormatProvider? formatProvider) => input != 0);
        }

        private void RegisterUInt16Conversions()
        {
            Register((ushort input, IFormatProvider? formatProvider) => (byte)input);
            Register((ushort input, IFormatProvider? formatProvider) => (sbyte)input);

            Register((ushort input, IFormatProvider? formatProvider) => (short)input);

            Register((ushort input, IFormatProvider? formatProvider) => (int)input);
            Register((ushort input, IFormatProvider? formatProvider) => (uint)input);

            Register((ushort input, IFormatProvider? formatProvider) => (long)input);
            Register((ushort input, IFormatProvider? formatProvider) => (ulong)input);

            Register((ushort input, IFormatProvider? formatProvider) => (float)input);
            Register((ushort input, IFormatProvider? formatProvider) => (double)input);
            Register((ushort input, IFormatProvider? formatProvider) => (decimal)input);

            Register((ushort input, IFormatProvider? formatProvider) => input != 0);
        }

        private void RegisterInt16Conversions()
        {
            Register((short input, IFormatProvider? formatProvider) => (byte)input);
            Register((short input, IFormatProvider? formatProvider) => (sbyte)input);

            Register((short input, IFormatProvider? formatProvider) => (ushort)input);

            Register((short input, IFormatProvider? formatProvider) => (int)input);
            Register((short input, IFormatProvider? formatProvider) => (uint)input);

            Register((short input, IFormatProvider? formatProvider) => (long)input);
            Register((short input, IFormatProvider? formatProvider) => (ulong)input);

            Register((short input, IFormatProvider? formatProvider) => (float)input);
            Register((short input, IFormatProvider? formatProvider) => (double)input);
            Register((short input, IFormatProvider? formatProvider) => (decimal)input);

            Register((short input, IFormatProvider? formatProvider) => input != 0);
        }
 
        private void RegisterUInt32Conversions()
        {
            Register((uint input, IFormatProvider? formatProvider) => (byte)input);
            Register((uint input, IFormatProvider? formatProvider) => (sbyte)input);

            Register((uint input, IFormatProvider? formatProvider) => (short)input);
            Register((uint input, IFormatProvider? formatProvider) => (ushort)input);

            Register((uint input, IFormatProvider? formatProvider) => (int)input);

            Register((uint input, IFormatProvider? formatProvider) => (long)input);
            Register((uint input, IFormatProvider? formatProvider) => (ulong)input);

            Register((uint input, IFormatProvider? formatProvider) => (float)input);
            Register((uint input, IFormatProvider? formatProvider) => (double)input);
            Register((uint input, IFormatProvider? formatProvider) => (decimal)input);

            Register((uint input, IFormatProvider? formatProvider) => input != 0);
        }

        private void RegisterInt32Conversions()
        {
            Register((int input, IFormatProvider? formatProvider) => (byte)input);
            Register((int input, IFormatProvider? formatProvider) => (sbyte)input);

            Register((int input, IFormatProvider? formatProvider) => (short)input);
            Register((int input, IFormatProvider? formatProvider) => (ushort)input);

            Register((int input, IFormatProvider? formatProvider) => (uint)input);

            Register((int input, IFormatProvider? formatProvider) => (long)input);
            Register((int input, IFormatProvider? formatProvider) => (ulong)input);

            Register((int input, IFormatProvider? formatProvider) => (float)input);
            Register((int input, IFormatProvider? formatProvider) => (double)input);
            Register((int input, IFormatProvider? formatProvider) => (decimal)input);

            Register((int input, IFormatProvider? formatProvider) => input != 0);
        }

        private void RegisterUInt64Conversions()
        {
            Register((ulong input, IFormatProvider? formatProvider) => (byte)input);
            Register((ulong input, IFormatProvider? formatProvider) => (sbyte)input);

            Register((ulong input, IFormatProvider? formatProvider) => (short)input);
            Register((ulong input, IFormatProvider? formatProvider) => (ushort)input);

            Register((ulong input, IFormatProvider? formatProvider) => (int)input);
            Register((ulong input, IFormatProvider? formatProvider) => (uint)input);

            Register((ulong input, IFormatProvider? formatProvider) => (long)input);

            Register((ulong input, IFormatProvider? formatProvider) => (float)input);
            Register((ulong input, IFormatProvider? formatProvider) => (double)input);
            Register((ulong input, IFormatProvider? formatProvider) => (decimal)input);

            Register((ulong input, IFormatProvider? formatProvider) => input != 0);
        }

        private void RegisterInt64Conversions()
        {
            Register((long input, IFormatProvider? formatProvider) => (byte)input);
            Register((long input, IFormatProvider? formatProvider) => (sbyte)input);

            Register((long input, IFormatProvider? formatProvider) => (short)input);
            Register((long input, IFormatProvider? formatProvider) => (ushort)input);

            Register((long input, IFormatProvider? formatProvider) => (int)input);
            Register((long input, IFormatProvider? formatProvider) => (uint)input);

            Register((long input, IFormatProvider? formatProvider) => (ulong)input);

            Register((long input, IFormatProvider? formatProvider) => (float)input);
            Register((long input, IFormatProvider? formatProvider) => (double)input);
            Register((long input, IFormatProvider? formatProvider) => (decimal)input);

            Register((long input, IFormatProvider? formatProvider) => input != 0);
        }

        private void RegisterSingleConversions()
        {
            Register((float input, IFormatProvider? formatProvider) => (byte)input);
            Register((float input, IFormatProvider? formatProvider) => (sbyte)input);

            Register((float input, IFormatProvider? formatProvider) => (short)input);
            Register((float input, IFormatProvider? formatProvider) => (ushort)input);

            Register((float input, IFormatProvider? formatProvider) => (int)input);
            Register((float input, IFormatProvider? formatProvider) => (uint)input);

            Register((float input, IFormatProvider? formatProvider) => (long)input);
            Register((float input, IFormatProvider? formatProvider) => (ulong)input);

            Register((float input, IFormatProvider? formatProvider) => (double)input);
            Register((float input, IFormatProvider? formatProvider) => (decimal)input);
        }

        private void RegisterDoubleConversions()
        {
            Register((double input, IFormatProvider? formatProvider) => (byte)input);
            Register((double input, IFormatProvider? formatProvider) => (sbyte)input);

            Register((double input, IFormatProvider? formatProvider) => (short)input);
            Register((double input, IFormatProvider? formatProvider) => (ushort)input);

            Register((double input, IFormatProvider? formatProvider) => (int)input);
            Register((double input, IFormatProvider? formatProvider) => (uint)input);

            Register((double input, IFormatProvider? formatProvider) => (long)input);
            Register((double input, IFormatProvider? formatProvider) => (ulong)input);

            Register((double input, IFormatProvider? formatProvider) => (float)input);
            Register((double input, IFormatProvider? formatProvider) => (decimal)input);
        }

        private void RegisterDecimalConversions()
        {
            Register((decimal input, IFormatProvider? formatProvider) => (byte)input);
            Register((decimal input, IFormatProvider? formatProvider) => (sbyte)input);

            Register((decimal input, IFormatProvider? formatProvider) => (short)input);
            Register((decimal input, IFormatProvider? formatProvider) => (ushort)input);

            Register((decimal input, IFormatProvider? formatProvider) => (int)input);
            Register((decimal input, IFormatProvider? formatProvider) => (uint)input);

            Register((decimal input, IFormatProvider? formatProvider) => (long)input);
            Register((decimal input, IFormatProvider? formatProvider) => (ulong)input);

            Register((decimal input, IFormatProvider? formatProvider) => (float)input);
            Register((decimal input, IFormatProvider? formatProvider) => (double)input);
        }
    }
}