using PaymentImporter.Core.Domain.Entities.Transactions;
using PaymentImporter.Core.Domain.Repositories;
using PaymentImporter.Services.Transactions;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace PaymentImporter.Services.Tests.Transactions
{
    public class CurrencyServicUnitTests
    {
        [Test]
        public void CurrencyServicUnitTests_CanGetAllCurrencies()
        {
            var data = new List<Currency>
            {
                new Currency { Name = "US Dollar", CurrencyCode = "USD" },
                new Currency { Name = "Thai Baht", CurrencyCode = "THB" },
            }.AsQueryable();

            var mockRepro = new Mock<IRepository<Currency>>();
            mockRepro.Setup(c => c.GetAll()).Returns(data);

            var service = new CurrencyService(mockRepro.Object);
            var currencies = service.GetAllCurrencies();

            Assert.AreEqual(2, currencies.Count);
            Assert.AreEqual("US Dollar", currencies[0].Name);
            Assert.AreEqual("Thai Baht", currencies[1].Name);
            Assert.AreEqual("USD", currencies[0].CurrencyCode);
            Assert.AreEqual("THB", currencies[1].CurrencyCode);
        }       
    }
}
