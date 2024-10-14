using Avalonia.Data.Converters;
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

            if (value is SecureString secureString)
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
            var valueString = value as string;

            if (string.IsNullOrEmpty(valueString))
                return null;

            var secureString = new SecureString();
            foreach (var c in valueString)
                secureString.AppendChar(c);
            return secureString;
        }
    }
}
