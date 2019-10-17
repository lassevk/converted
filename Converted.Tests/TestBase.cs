using NUnit.Framework;

namespace Converted.Tests
{
    public abstract class TestBase
    {
        [SetUp]
        public void SetUp()
        {
            ValueConverter = new ValueConverter(DefaultValueConverterProviders.Collection);
        }

        [TearDown]
        public void TearDown()
        {
            ValueConverter = null;
        }

        protected IValueConverter ValueConverter { get; private set; }
    }
}