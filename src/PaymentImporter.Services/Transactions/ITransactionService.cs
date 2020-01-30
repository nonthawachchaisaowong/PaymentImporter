using PaymentImporter.Core.Domain.Entities.Transactions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentImporter.Services.Transactions
{
    public interface ITransactionService
    {
        IList<Transaction> GetAllTransactions();
        Transaction GetTransactionBy(int id);
        void DeleteTransaction(Transaction transaction);
        void InsertTransaction(Transaction transaction);
        void UpdateTransaction(Transaction transaction); 
    }
}
