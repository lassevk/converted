using System.Collections.Generic;

using Converted.ValueConverters;

namespace Converted
{
    public class DefaultValueConverterProviders
    {
        public static readonly List<IValueConverterProvider> Collection = new List<IValueConverterProvider>();

        static DefaultValueConverterProviders()
        {
            Collection.Add(new FrameworkBasicTypesValueConverterProvider());
            Collection.Add(new NullableTypesValueConverterProvider());
            Collection.Add(new ToStringValueConverterProvider());
            Collection.Add(new EnumValueConverterProvider());
            Collection.Add(new BoxingValueConverterProvider());

            // ToObject ?
            // Enum ?
        }
    }
}