using PaymentImporter.Services.Helpers;
using NUnit.Framework;
using System;

namespace PaymentImporter.Services.Tests.Helpers
{
    public class DateTimeHelperUnitTests
    {
        [Test]
        public void DateTimeHelperUnitTests_CanParseDateTime()
        {
            var date = DateTimeHelper.ParseDate("20/02/2019 12:33:16");

            var expectedDate = new DateTime(2019, 02, 20, 0, 33, 16);
            Assert.AreEqual(expectedDate, date);
        }

        [Test]
        public void DateTimeHelperUnitTests_CanCheckDateIsValid()
        {
            var isValid = DateTimeHelper.IsValidDate("20/02/2019 12:33:16");
     
            Assert.IsTrue(isValid);
        }
    }
}
