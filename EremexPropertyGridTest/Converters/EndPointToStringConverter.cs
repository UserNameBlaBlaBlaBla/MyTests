using Avalonia.Data.Converters;
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

            if (value is EndPoint endPoint)
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
            var valueString = value as string;

            if (string.IsNullOrEmpty(valueString))
                return null;

            var index = valueString.LastIndexOf(':');

            if (index == -1)
                throw new ArgumentException("Incorrect endpoint format.");

            var host = valueString.Substring(0, index);
            var isSuccess = int.TryParse(valueString.Substring(index + 1),out var port);

            if (!isSuccess)
                throw new ArgumentException("Incorrect port format.");

            if (!IPAddress.TryParse(host, out IPAddress addr))
                return new DnsEndPoint(host, port);

            return new IPEndPoint(addr, port);
        }
    }
}
