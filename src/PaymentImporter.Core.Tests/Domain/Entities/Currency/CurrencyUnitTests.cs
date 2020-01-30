using NUnit.Framework;
using PaymentImporter.Core.Domain.Entities.Transactions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaymentImporter.Core.Tests.Domain
{
    [TestFixture]
    public class CurrencyUnitTests
    {
        [Test]
        public void CurrencyUnitTests_GetErrorMessageWhenCurrencyCodeTooLong()
        {
            Currency currency = new Currency
            {
                Name ="US Dollar",
                CurrencyCode = "InvalidCode"
            };
            var results = new List<ValidationResult>();

            var context = new ValidationContext(currency);
            var actual = Validator.TryValidateObject(currency, context, results, validateAllProperties: true);

            Assert.IsTrue(results.Count > 0);
            Assert.AreEqual("The field CurrencyCode must be a string or array type with a maximum length of '3'.", results[0].ErrorMessage);
        }
    }
}
