using System;
using System.Collections.Generic;
using System.Linq;

using NUnit.Framework;

namespace Converted.Tests
{
    [TestFixture]
    public class DefaultValueConverterTests
    {
        private IValueConverter _ValueConverter;

        [SetUp]
        public void SetUp()
        {
            _ValueConverter = new ValueConverter(DefaultValueConverterProviders.Collection);
        }

        [TearDown]
        public void TearDown()
        {
            _ValueConverter = null;
        }

        public static IEnumerable<TestCaseData> ExpectedConversionTypeCombinations()
        {
            Type[] integralTypes = new[]
            {
                typeof(byte), typeof(sbyte), typeof(short), typeof(ushort), typeof(int), typeof(uint), typeof(long), typeof(ulong)
            };

            Type[] floatingPointTypes = new[]
            {
                typeof(float), typeof(double), typeof(decimal)
            };

            Type[] numericTypes = integralTypes.Concat(floatingPointTypes).ToArray();

            foreach (Type inputType in numericTypes)
                foreach (Type outputType in numericTypes)
                    yield return new TestCaseData(inputType, outputType).SetName($"{NameOf(inputType)} -> {NameOf(outputType)}");

            foreach (Type type in numericTypes)
            {
                yield return new TestCaseData(type, typeof(string)).SetName($"{NameOf(type)} -> string");
                yield return new TestCaseData(typeof(string), type).SetName($"string -> {NameOf(type)}");
            }

            foreach (Type type in integralTypes)
            {
                yield return new TestCaseData(type, typeof(bool)).SetName($"{NameOf(type)} -> bool");
                yield return new TestCaseData(typeof(bool), type).SetName($"bool -> {NameOf(type)}");
            }

            yield return new TestCaseData(typeof(bool), typeof(string)).SetName("bool -> string");
            yield return new TestCaseData(typeof(string), typeof(bool)).SetName("string -> bool");

            yield return new TestCaseData(typeof(Guid), typeof(string)).SetName("Guid -> string");
            yield return new TestCaseData(typeof(string), typeof(Guid)).SetName("string -> Guid");

            yield return new TestCaseData(typeof(Version), typeof(string)).SetName("Version -> string");
            yield return new TestCaseData(typeof(string), typeof(Version)).SetName("string -> Version");
        
            yield return new TestCaseData(typeof(Uri), typeof(string)).SetName("Uri -> string");
            yield return new TestCaseData(typeof(string), typeof(Uri)).SetName("string -> Uri");
        }

        [Test]
        [TestCaseSource(nameof(ExpectedConversionTypeCombinations))]
        public void TryGetConverter_ForAllFrameworkCombinations_ReturnsConverter(Type inputType, Type outputType)
        {
            ValueConverterDelegate converter = _ValueConverter.TryGetConverter(inputType, outputType);
            Assert.NotNull(converter);
        }

        private static string NameOf(Type type)
        {
            return type.FullName switch
            {
                "System.Byte" => "byte",
                "System.SByte" => "sbyte",
                "System.Int16" => "short",
                "System.UInt16" => "ushort",
                "System.Int32" => "int",
                "System.UInt32" => "uint",
                "System.Int64" => "long",
                "System.UInt64" => "ulong",
                "System.Decimal" => "decimal",
                "System.Double" => "double",
                "System.Single" => "float",
                _ => type.Name
            };
        }
    }
}