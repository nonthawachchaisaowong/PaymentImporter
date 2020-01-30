using PaymentImporter.Core.Dto;
using PaymentImporter.Core.Dto.Transactions;
using PaymentImporter.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentImporter.Services.Transactions
{
    public class TransactionApiService : ITransactionApiService
    {
        #region Fields
        ITransactionService _transactionService;
        ICurrencyService _currencyService;
        ITransactionStatusService _transactionStatusService;
        IDtoHelpers _dtoHelpers;
        #endregion

        #region Ctor
        public TransactionApiService(
            ITransactionService transactionService,
            ICurrencyService currencyService,
            ITransactionStatusService transactionStatusService,
            IDtoHelpers dtoHelpers)
        {
            _transactionService = transactionService;
            _currencyService = currencyService;
            _transactionStatusService = transactionStatusService;
            _dtoHelpers = dtoHelpers;
        }
        #endregion

        #region Methods
        public List<TransactionResponseDto> GetAllTransactionDtos(string currency = "", string status = "", string start_date = "", string end_date = "")
        {
            var transactions = _transactionService.GetAllTransactions();

            // Filters by currency
            if (!string.IsNullOrEmpty(currency))
            {
                var currencyEntity = _currencyService.GetCurrencyBy(currency);

                if (currencyEntity == null)
                    throw new Exception("Invalid 'currency' query parameter");

                transactions = transactions.Where(t => t.CurrencyId == currencyEntity.Id).ToList();
            }

            // Filters by status
            if (!string.IsNullOrEmpty(status))
            {
                var transactionStatusEntity = _transactionStatusService.GetTransactionStatusBy(status);

                if (transactionStatusEntity == null)
                    throw new Exception("Invalid 'status' query parameter");

                transactions = transactions.Where(t => t.TransactionStatusId == transactionStatusEntity.Id).ToList();
            }

            // Filters by date range 
            if (!string.IsNullOrEmpty(start_date))
            {
                if (!DateTimeHelper.IsValidDate(start_date))
                    throw new Exception("Invalid 'start_date' query parameter");

                var startDate = DateTimeHelper.ParseDate(start_date);
                transactions = transactions.Where(t => t.TransactionDate >= startDate).ToList();
            }

            if (!string.IsNullOrEmpty(end_date))
            {
                if (!DateTimeHelper.IsValidDate(end_date))
                    throw new Exception("Invalid 'end_date' query parameter");

                var endDate = DateTimeHelper.ParseDate(end_date);
                transactions = transactions.Where(t => t.TransactionDate <= endDate).ToList();
            }

            // Convert to dtos
            return transactions.Select(t => _dtoHelpers.PrepareTransactionDTO(t)).ToList();
        }
        #endregion
    }
}
