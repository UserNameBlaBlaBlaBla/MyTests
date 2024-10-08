using Avalonia.Data.Converters;
using Eremex.AvaloniaUI.Controls.PropertyGrid;
using System;
using System.Globalization;
using System.Net;

namespace EremexPropertyGridTest.Converters
{
    public class EndPointToStringConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;

            if (((IPropertyGridEditableNode)value).DataObject is EndPoint endPoint)
            {
                if (endPoint == null)
                    throw new ArgumentNullException(nameof(endPoint));

                switch (endPoint)
                {
                    case DnsEndPoint dnsEndPoint:
                        return $"{dnsEndPoint.Host}:{dnsEndPoint.Port}";

                    default:
                        return endPoint.ToString();
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
