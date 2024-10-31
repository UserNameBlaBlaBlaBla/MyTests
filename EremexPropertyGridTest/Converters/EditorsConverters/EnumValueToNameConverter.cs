using Avalonia.Data.Converters;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace EremexPropertyGridTest.Converters.EditorsConverters
{
    internal class EnumValueToNameConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is Enum enumValue)
            {
                var enumMembers = value.GetType().GetMember(value.ToString());
                if (enumMembers.Count() > 0)
                {
                    var enumMember = enumMembers.First();
                    var displayAttribute = enumMember.GetCustomAttribute<DisplayAttribute>();
                    if (displayAttribute != null)
                        return displayAttribute.Name;
                    else
                        return string.Empty;
                }
                else
                    return string.Empty;
            }
            else
               return string.Empty;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
