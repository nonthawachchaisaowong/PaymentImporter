using PaymentImporter.Core.Domain.Entities.Transactions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentImporter.Services.Transactions
{
    public interface ICurrencyService
    {
        IList<Currency> GetAllCurrencies();
        Currency GetCurrencyBy(int id);
        Currency GetCurrencyBy(string currencyCode);
        void DeleteCurrency(Currency currency);
        void InsertCurrency(Currency currency);
        void UpdateCurrency(Currency currency);
    }
}
