using PaymentImporter.Core.Domain.Entities.Transactions;
using PaymentImporter.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentImporter.Services.Transactions
{
    public class TransactionStatusService : ITransactionStatusService
    {
        #region Fields
        IRepository<TransactionStatus> _transactionStatusRepositor;
        #endregion
        
        #region Ctor
        public TransactionStatusService(IRepository<TransactionStatus> transactionRepository)
        {
            _transactionStatusRepositor = transactionRepository;
        }
        #endregion

        #region Methods
        public TransactionStatus GetTransactionStatusBy(int id)
        {
            return  _transactionStatusRepositor.GetById(id);
        }

        public void DeleteTransactionStatus(TransactionStatus transactionStatus)
        {
            _transactionStatusRepositor.Delete(transactionStatus);
        }

        public IList<TransactionStatus> GetAllTransactionStatuses()
        {
            return _transactionStatusRepositor.GetAll().ToList();
        }
        public void InsertTransactionStatus(TransactionStatus transactionStatus)
        {
            _transactionStatusRepositor.Create(transactionStatus);
        }

        public void UpdateTransactionStatus(TransactionStatus transactionStatus)
        {
            _transactionStatusRepositor.Update(transactionStatus);
        }
        public TransactionStatus GetTransactionStatusBy(string Status)
        {
            return GetAllTransactionStatuses().Where(t => t.Status.Equals(Status, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
        }
        #endregion
    }
}
