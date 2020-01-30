using PaymentImporter.Core.Domain.Entities.Transactions;
using PaymentImporter.Core.Domain.Repositories;
using PaymentImporter.Services.Transactions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace PaymentImporter.Services.Tests.TransactionStatuss
{
    public class TransactionStatusServicUnitTests
    {
        [Test]
        public void TransactionStatusServicUnitTests_CanGetAllCurrencies()
        {
            var data = new List<TransactionStatus>
            {
                new TransactionStatus { Status = "Approved" },
                new TransactionStatus { Status = "Rejected" },
            }.AsQueryable();

            var mockRepro = new Mock<IRepository<TransactionStatus>>();
            mockRepro.Setup(c => c.GetAll()).Returns(data);

            var service = new TransactionStatusService(mockRepro.Object);
            var transactions = service.GetAllTransactionStatuses();

            Assert.AreEqual(2, transactions.Count);
            Assert.AreEqual("Approved", transactions[0].Status);
            Assert.AreEqual("Rejected", transactions[1].Status);
        }
    }
}
