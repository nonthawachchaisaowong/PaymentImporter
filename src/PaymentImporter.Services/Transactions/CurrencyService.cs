using PaymentImporter.Core.Domain.Entities.Transactions;
using PaymentImporter.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentImporter.Services.Transactions
{
    public class CurrencyService : ICurrencyService
    {
        #region Fields
        IRepository<Currency> _currencyRepositor;
        #endregion

        #region Ctor
        public CurrencyService(IRepository<Currency> currencyRepositor)
        {
            _currencyRepositor = currencyRepositor;
        }
        #endregion

        #region Method
        public Currency GetCurrencyBy(int id)
        {
            return _currencyRepositor.GetById(id);
        }

        public void DeleteCurrency(Currency currency)
        {
            _currencyRepositor.Delete(currency);
        }

        public IList<Currency> GetAllCurrencies()
        {
            return _currencyRepositor.GetAll().ToList();
        }

        public void InsertCurrency(Currency transaction)
        {
            _currencyRepositor.Create(transaction);
        }

        public void UpdateCurrency(Currency transaction)
        {
            _currencyRepositor.Update(transaction);
        }

        public Currency GetCurrencyBy(string currencyCode)
        {
            //TODO: Need to be improve             
            return GetAllCurrencies().Where(c => c.CurrencyCode.Equals(currencyCode, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
        }
        #endregion
    }
}
