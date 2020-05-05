using System;

using Newtonsoft.Json.Linq;

using NUnit.Framework;

namespace Converted.Adapter.Newtonsoft.Json.Tests
{
    [TestFixture]
    public class JsonEnumTests
    {
        public JsonEnumTests()
        {
            Registrar.Register();
        }

        [Test]
        [TestCase("\"A\"", Test.A)]
        [TestCase("\"B\"", Test.B)]
        [TestCase("\"A|B\"", Test.A | Test.B)]
        [TestCase("\"A,B\"", Test.A | Test.B)]
        [TestCase("[1]", Test.A)]
        [TestCase("[2]", Test.B)]
        [TestCase("[3]", Test.A | Test.B)]
        [TestCase("[1,2]", Test.A | Test.B)]
        [TestCase("[\"A\"]", Test.A)]
        [TestCase("[\"B\"]", Test.B)]
        [TestCase("[\"A|B\"]", Test.A | Test.B)]
        [TestCase("[\"A,B\"]", Test.A | Test.B)]
        [TestCase("[\"A\",\"B\"]", Test.A | Test.B)]
        [TestCase("{}", Test.None)]
        [TestCase("{\"A\":false}", Test.None)]
        [TestCase("{\"A\":true}", Test.A)]
        [TestCase("{\"B\":true}", Test.B)]
        [TestCase("{\"A\":true,\"B\":true}", Test.A | Test.B)]
        public void Convert_WithTestCases_ProducesExpectedResult(string json, Test expected)
        {
            var token = JToken.Parse(json);
            var output = (Test?)ValueConverter.Default.Convert(token, token.GetType(), typeof(Test));

            Assert.That(output, Is.EqualTo(expected));
        }
    }

    [Flags]
    public enum Test
    {
        None = 0,
        A = 1,
        B = 2,
        C = 4
    }
}