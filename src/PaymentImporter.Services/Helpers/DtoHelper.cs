using PaymentImporter.Core.Domain.Entities.Transactions;
using PaymentImporter.Core.Dto;
using PaymentImporter.Core.Dto.Transactions;
using PaymentImporter.Services.Logging;
using PaymentImporter.Services.Transactions;

namespace PaymentImporter.Services.Helpers
{
    public class DtoHelper : IDtoHelpers
    {
        #region Fields
        ITransactionService _transactionService;
        ICurrencyService _currencyService;
        ITransactionStatusService _transactionStatusService;
        ILogger _logger;
        #endregion

        #region Ctor
        public DtoHelper(ITransactionService transactionService,
            ICurrencyService currencyService,
            ITransactionStatusService transactionStatusService,
            ILogger logger)
        {
            _transactionService = transactionService;
            _currencyService = currencyService;
            _transactionStatusService = transactionStatusService;
            _logger = logger;
        }
        #endregion

        #region Method
        public TransactionResponseDto PrepareTransactionDTO(Transaction transaction)
        {
            // Get reference object
            var currency = _currencyService.GetCurrencyBy(transaction.CurrencyId);
            var transactionStatus = _transactionStatusService.GetTransactionStatusBy(transaction.TransactionStatusId);

            //Build dto
            TransactionResponseDto transactionResponseDto = new TransactionResponseDto();
            transactionResponseDto.TransactionId = transaction.TransactionId;
            transactionResponseDto.Payment = string.Format("{0} {1}", transaction.Amount, currency.CurrencyCode);
            transactionResponseDto.Status = transactionStatus.UnifiedFormat;

            return transactionResponseDto;
        }
        #endregion
    }
}
