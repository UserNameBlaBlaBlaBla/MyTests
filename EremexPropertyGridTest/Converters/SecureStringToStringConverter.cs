using Avalonia.Data.Converters;
using Eremex.AvaloniaUI.Controls.PropertyGrid;
using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security;

namespace EremexPropertyGridTest.Converters
{
    public class SecureStringToStringConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            var propertyGridEditableNode = (IPropertyGridEditableNode)value;

            if (propertyGridEditableNode.DataObject is SecureString secureString)
            {
                if (value == null)
                    return null;

                var bstr = Marshal.SecureStringToBSTR(secureString);

                try
                {
                    return Marshal.PtrToStringBSTR(bstr);
                }
                finally
                {
                    Marshal.ZeroFreeBSTR(bstr);
                }
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
