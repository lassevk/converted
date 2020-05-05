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
        [TestCase(TestEnum.Value4, 4)]
        public void Convert_FromEnumToInt32_ProducesExpectedResults(TestEnum input, int expected)
        {
            int output = ValueConverter.Convert<TestEnum, int>(input);
            Assert.That(output, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(TestEnum.Value0, 0)]
        [TestCase(TestEnum.Value1, 1)]
        [TestCase(TestEnum.Value2, 2)]
        [TestCase(TestEnum.Value4, 4)]
        public void Convert_FromNullableEnumToInt32_ProducesExpectedResults(TestEnum? input, int expected)
        {
            int output = ValueConverter.Convert<TestEnum?, int>(input);
            Assert.That(output, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(TestEnum.Value0, 0)]
        [TestCase(TestEnum.Value1, 1)]
        [TestCase(TestEnum.Value2, 2)]
        [TestCase(TestEnum.Value4, 4)]
        public void Convert_FromEnumToNullableInt32_ProducesExpectedResults(TestEnum input, int? expected)
        {
            int? output = ValueConverter.Convert<TestEnum, int?>(input);
            Assert.That(output, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(TestEnum.Value0, 0)]
        [TestCase(TestEnum.Value1, 1)]
        [TestCase(TestEnum.Value2, 2)]
        [TestCase(TestEnum.Value4, 4)]
        [TestCase(null, null)]
        public void Convert_FromNullableEnumToNullableInt32_ProducesExpectedResults(TestEnum? input, int? expected)
        {
            int? output = ValueConverter.Convert<TestEnum?, int?>(input);
            Assert.That(output, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(0, TestEnum.Value0)]
        [TestCase(3, TestEnum.Value1 | TestEnum.Value2)]
        public void Convert_FromNullableInt32ToEnum_ProducesExpectedResults(int? input, TestEnum? expected)
        {
            TestEnum? output = ValueConverter.Convert<int?, TestEnum?>(input);
            Assert.That(output, Is.EqualTo(expected));
        }
        
        [Test]
        [TestCase("Value0", TestEnum.Value0)]
        [TestCase("Value1,Value2", TestEnum.Value1 | TestEnum.Value2)]
        [TestCase("Value1 | Value2", TestEnum.Value1 | TestEnum.Value2)]
        public void Convert_FromStringToEnum_ProducesExpectedResults(string input, TestEnum? expected)
        {
            TestEnum? output = ValueConverter.Convert<string, TestEnum?>(input);
            Assert.That(output, Is.EqualTo(expected));
        }
    }
}