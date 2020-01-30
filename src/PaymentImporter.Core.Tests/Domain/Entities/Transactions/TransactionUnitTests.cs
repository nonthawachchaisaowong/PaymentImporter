using PaymentImporter.Core.Domain.Entities.Transactions;
using NUnit.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaymentImporter.Core.Tests.Domain
{
    [TestFixture]
    public class TransactionUnitTests
    {
        [Test]
        public void TransactionUnitTests_GetErrorMessageWhenTransactionIdTooLong()
        {
            Transaction transaction = new Transaction
            {
                TransactionId = "Inv01010121211213224455478444845599855545644554544544544454444"
            };
            var results = new List<ValidationResult>();

            var context = new ValidationContext(transaction);
            var actual = Validator.TryValidateObject(transaction, context, results, validateAllProperties: true);

            Assert.IsTrue(results.Count > 0);
            Assert.AreEqual("The field TransactionId must be a string or array type with a maximum length of '50'.", results[0].ErrorMessage);
        }
    }
}
