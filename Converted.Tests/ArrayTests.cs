using NUnit.Framework;

namespace Converted.Tests
{
    [TestFixture]
    public class ArrayTests
    {
        [Test]
        public void Convert_ByteArrayToString_ReturnsBase64EncodedByteArray()
        {
            var bytes = new byte[] { 1, 2, 3, 4, 5 };

            var output = ValueConverter.Default.Convert<byte[], string>(bytes);

            Assert.That(output, Is.EqualTo("AQIDBAU="));
        }

        [Test]
        public void Convert_StringToByteArray_ReturnsBase64DecodedByteArray()
        {
            byte[] output = ValueConverter.Default.Convert<string, byte[]>("AQIDBAU=");

            CollectionAssert.AreEqual(new byte[] { 1, 2, 3, 4, 5 }, output);
        }

        [Test]
        public void Convert_CharArrayToString_ReturnsStringWithCharacters()
        {
            var output = ValueConverter.Default.Convert<char[], string>(new char[] { 'T', 'e', 's', 't' });

            Assert.That(output, Is.EqualTo("Test"));
        }

        [Test]
        public void Convert_StringToCharArray_ReturnsCharArrayWithCharactersFromString()
        {
            char[] output = ValueConverter.Default.Convert<string, char[]>("Test");

            CollectionAssert.AreEqual(new[] { 'T', 'e', 's', 't' }, output);
        }
    }
}