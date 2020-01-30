using PaymentImporter.Core.Domain.Entities.Transactions;
using PaymentImporter.Core.Domain.Repositories;
using PaymentImporter.Services.Transactions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace PaymentImporter.Services.Tests.Transactions
{
    public class TransactionServicUnitTests
    {
        [Test]
        public void TransactionServicUnitTests_CanGetAllCurrencies()
        {
            var data = new List<Transaction>
            {
                new Transaction { TransactionId = "Inv001" },
                new Transaction { TransactionId = "Inv002" },
            }.AsQueryable();

            var mockRepro = new Mock<IRepository<Transaction>>();
            mockRepro.Setup(c => c.GetAll()).Returns(data);

            var service = new TransactionService(mockRepro.Object);
            var transactions = service.GetAllTransactions();

            Assert.AreEqual(2, transactions.Count);
            Assert.AreEqual("Inv001", transactions[0].TransactionId);
            Assert.AreEqual("Inv002", transactions[1].TransactionId);
        }
    }
}
