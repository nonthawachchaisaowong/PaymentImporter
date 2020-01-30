using PaymentImporter.Core.Domain.Entities.Transactions;
using PaymentImporter.Core.Dto.Transactions;

namespace PaymentImporter.Core.Dto
{
    public interface IDtoHelpers
    {
        TransactionResponseDto PrepareTransactionDTO(Transaction transaction);
    }
}
