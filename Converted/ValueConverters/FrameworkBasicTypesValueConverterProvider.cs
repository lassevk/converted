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
            RegisterGuidConversions();
            RegisterVersionConversions();
            RegisterUriConversions();
        }

        private void RegisterUriConversions()
        {
            Register((Uri input, IFormatProvider? formatProvider) => input.ToString());
#pragma warning disable 8619
            Register<string, Uri>(
                (input, formatProvider)
                    => Uri.TryCreate(input, UriKind.RelativeOrAbsolute, out Uri output) ? (true, output) : (false, default));
#pragma warning restore 8619
        }

        private void RegisterVersionConversions()
        {
            Register((Version input, IFormatProvider? formatProvider) => input.ToString());
#pragma warning disable 8619
            Register<string, Version>(
                (input, formatProvider) => Version.TryParse(input, out Version output) ? (true, output) : (false, default));
#pragma warning restore 8619
        }

        private void RegisterGuidConversions()
        {
            Register((Guid input, IFormatProvider? formatProvider) => input.ToString());
            Register<string, Guid>((input, formatProvider) => Guid.TryParse(input, out Guid output) ? (true, output) : (false, default));
        }

        private void RegisterStringConversions()
        {
            Register((byte input, IFormatProvider? formatProvider) => input.ToString(formatProvider));
            Register<string, byte>(
                (input, formatProvider) => Byte.TryParse(input, NumberStyles.Any, formatProvider, out var output)
                    ? (true, output)
                    : (false, (byte)0));

            Register((sbyte input, IFormatProvider? formatProvider) => input.ToString(formatProvider));
            Register<string, sbyte>(
                (input, formatProvider) => SByte.TryParse(input, NumberStyles.Any, formatProvider, out var output)
                    ? (true, output)
                    : (false, (sbyte)0));

            Register((short input, IFormatProvider? formatProvider) => input.ToString(formatProvider));
            Register<string, short>(
                (input, formatProvider) => Int16.TryParse(input, NumberStyles.Any, formatProvider, out var output)
                    ? (true, output)
                    : (false, (short)0));

            Register((ushort input, IFormatProvider? formatProvider) => input.ToString(formatProvider));
            Register<string, ushort>(
                (input, formatProvider) => UInt16.TryParse(input, NumberStyles.Any, formatProvider, out var output)
                    ? (true, output)
                    : (false, (ushort)0));

            Register((int input, IFormatProvider? formatProvider) => input.ToString(formatProvider));
            Register<string, int>(
                (input, formatProvider)
                    => Int32.TryParse(input, NumberStyles.Any, formatProvider, out var output) ? (true, output) : (false, 0));

            Register((uint input, IFormatProvider? formatProvider) => input.ToString(formatProvider));
            Register<string, uint>(
                (input, formatProvider) => UInt32.TryParse(input, NumberStyles.Any, formatProvider, out var output)
                    ? (true, output)
                    : (false, (uint)0));

            Register((long input, IFormatProvider? formatProvider) => input.ToString(formatProvider));
            Register<string, long>(
                (input, formatProvider) => Int64.TryParse(input, NumberStyles.Any, formatProvider, out var output)
                    ? (true, output)
                    : (false, (long)0));

            Register((ulong input, IFormatProvider? formatProvider) => input.ToString(formatProvider));
            Register<string, ulong>(
                (input, formatProvider) => UInt64.TryParse(input, NumberStyles.Any, formatProvider, out var output)
                    ? (true, output)
                    : (false, (ulong)0));

            Register((float input, IFormatProvider? formatProvider) => input.ToString(formatProvider));
            Register<string, float>(
                (input, formatProvider) => Single.TryParse(input, NumberStyles.Any, formatProvider, out var output)
                    ? (true, output)
                    : (false, 0f));

            Register((double input, IFormatProvider? formatProvider) => input.ToString(formatProvider));
            Register<string, double>(
                (input, formatProvider) => Double.TryParse(input, NumberStyles.Any, formatProvider, out var output)
                    ? (true, output)
                    : (false, 0.0));

            Register((decimal input, IFormatProvider? formatProvider) => input.ToString(formatProvider));
            Register<string, decimal>(
                (input, formatProvider) => Decimal.TryParse(input, NumberStyles.Any, formatProvider, out var output)
                    ? (true, output)
                    : (false, 0M));

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