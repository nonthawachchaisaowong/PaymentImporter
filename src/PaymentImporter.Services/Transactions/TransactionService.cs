using PaymentImporter.Core.Domain.Entities.Transactions;
using PaymentImporter.Core.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace PaymentImporter.Services.Transactions
{
    public class TransactionService : ITransactionService
    {
        #region Fields
        IRepository<Transaction> _transactionRepositor;
        #endregion

        #region Ctor
        public TransactionService(IRepository<Transaction> transactionRepository)
        {
            _transactionRepositor = transactionRepository;
        }
        #endregion

        #region Methods
        public Transaction GetTransactionBy(int id)
        {
            return _transactionRepositor.GetById(id);
        }

        public void DeleteTransaction(Transaction transaction)
        {
            _transactionRepositor.Delete(transaction);
        }

        public IList<Transaction> GetAllTransactions()
        {
            return _transactionRepositor.GetAll().ToList();
        }

        public void InsertTransaction(Transaction transaction)
        {
            _transactionRepositor.Create(transaction);
        }

        public void UpdateTransaction(Transaction transaction)
        {
            _transactionRepositor.Update(transaction);
        }
        #endregion
    }
}
