using NUnit.Framework;

namespace Converted.Tests
{
    [TestFixture]
    public class EnumConversionTests : TestBase
    {
        [Test]
        [TestCase(TestEnum.Value0, 0)]
        [TestCase(TestEnum.Value1, 1)]
        [TestCase(TestEnum.Value2, 2)]
        [TestCase(TestEnum.Value10, 10)]
        public void Convert_FromEnumToInt32_ProducesExpectedResults(TestEnum input, int expected)
        {
            int output = ValueConverter.Convert<TestEnum, int>(input);
            Assert.That(output, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(TestEnum.Value0, 0)]
        [TestCase(TestEnum.Value1, 1)]
        [TestCase(TestEnum.Value2, 2)]
        [TestCase(TestEnum.Value10, 10)]
        public void Convert_FromNullableEnumToInt32_ProducesExpectedResults(TestEnum? input, int expected)
        {
            int output = ValueConverter.Convert<TestEnum?, int>(input);
            Assert.That(output, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(TestEnum.Value0, 0)]
        [TestCase(TestEnum.Value1, 1)]
        [TestCase(TestEnum.Value2, 2)]
        [TestCase(TestEnum.Value10, 10)]
        public void Convert_FromEnumToNullableInt32_ProducesExpectedResults(TestEnum input, int? expected)
        {
            int? output = ValueConverter.Convert<TestEnum, int?>(input);
            Assert.That(output, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(TestEnum.Value0, 0)]
        [TestCase(TestEnum.Value1, 1)]
        [TestCase(TestEnum.Value2, 2)]
        [TestCase(TestEnum.Value10, 10)]
        [TestCase(null, null)]
        public void Convert_FromNullableEnumToNullableInt32_ProducesExpectedResults(TestEnum? input, int? expected)
        {
            int? output = ValueConverter.Convert<TestEnum?, int?>(input);
            Assert.That(output, Is.EqualTo(expected));
        }
    }
}