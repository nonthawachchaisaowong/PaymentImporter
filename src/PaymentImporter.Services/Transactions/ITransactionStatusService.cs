using PaymentImporter.Core.Domain.Entities.Transactions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentImporter.Services.Transactions
{
    public interface ITransactionStatusService
    {
        IList<TransactionStatus> GetAllTransactionStatuses();
        TransactionStatus GetTransactionStatusBy(int id);
        TransactionStatus GetTransactionStatusBy(string Status);
        void DeleteTransactionStatus(TransactionStatus transactionStatus);
        void InsertTransactionStatus(TransactionStatus transactionStatus);
        void UpdateTransactionStatus(TransactionStatus transactionStatus); 
    }
}
