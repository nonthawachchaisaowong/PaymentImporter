using System;
using System.Globalization;

namespace PaymentImporter.Services.Helpers
{
    public class DateTimeHelper
    {
       
        private const string DATETIME_FORMAT = "dd/MM/yyyy hh:mm:ss";

        public static DateTime ParseDate(string dateString)
        {       
            return DateTime.ParseExact(dateString, DATETIME_FORMAT , CultureInfo.InvariantCulture);
        }

        public static bool IsValidDate(string dateString)
        {
            return DateTime.TryParseExact(dateString, DATETIME_FORMAT,
                       CultureInfo.InvariantCulture,
                       DateTimeStyles.None,
                       out DateTime dt);
        }
    }
}
