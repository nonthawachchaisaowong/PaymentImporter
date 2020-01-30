using PaymentImporter.Core;
using PaymentImporter.Core.Domain.Entities.Transactions;
using PaymentImporter.Core.Domain.Enums;
using PaymentImporter.Core.Dto.Transactions;
using PaymentImporter.Services.Helpers;
using PaymentImporter.Services.Logging;
using PaymentImporter.Services.Parser;
using PaymentImporter.Services.Parser.Csv;
using PaymentImporter.Services.Parser.Xml;
using PaymentImporter.Services.Transactions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PaymentImporter.Services.Importings
{
    public class ImportingService : IImportingService
    {
        #region Fields
        ITransactionService _transactionService;
        ICurrencyService _currencyService;
        ITransactionStatusService _transactionStatusService;
        ILogger _logger;
        #endregion

        #region Ctor
        public ImportingService(ITransactionService transactionService,
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
        private IList<TransactionFileRecordDto> GetTransactionFileRecords(Stream stream, ImportFileType fileType)
        {
            DataParser dataParser;

            switch (fileType)
            {
                case ImportFileType.Csv:
                    {
                        dataParser = new CsvDataParser();
                        return dataParser.ParseTransactions(stream);
                    }
                case ImportFileType.Xml:
                    {
                        dataParser = new XmlDataParser();
                        return dataParser.ParseTransactions(stream);
                    }
                default:
                    return null;
            }
        }
        public bool IsValidFileLength(long fileLength)
        {
            // TODO: Must store in configuration file
            var maxLength = 1048576; //1 MB
            return fileLength > maxLength;
        }

        public bool IsValidFileType(string fileExtension)
        {
            return EnumHelper.IsDefined<ImportFileType>(fileExtension);
        }

        public int Import(Stream stream, ImportFileType fileType)
        {
            var allTransactionFileRecords = GetTransactionFileRecords(stream, fileType);

            IList<string> messages = new List<string>();

            var counter = 0;

            foreach (var transactionRecord in allTransactionFileRecords)
            {
                try
                {
                    //TODO: Need to validate each data cell check invalid file record and add better error messsage
                    Transaction transaction = new Transaction();
                    transaction.TransactionId = transactionRecord.TransactionId;
                    transaction.Amount = decimal.Parse(transactionRecord.Amount);

                    transaction.TransactionDate = DateTimeHelper.ParseDate(transactionRecord.TransactionDate);
                    transaction.TransactionStatusId = _transactionStatusService.GetTransactionStatusBy(transactionRecord.Status).Id;
                    transaction.CurrencyId = _currencyService.GetCurrencyBy(transactionRecord.CurrencyCode).Id;
                    _transactionService.InsertTransaction(transaction);

                    counter++;
                }
                catch (Exception ex)
                {
                    var errMessage = string.Format("Transaction Id: {0} : {1}", transactionRecord.TransactionId, ex.Message);

                    _logger.InsertLog(LogLevel.Information, errMessage);

                    messages.Add(errMessage);                 
                }
            }
            
            if(messages.Any())
                throw new  Exception(string.Join("\r\n", messages.ToArray()));

            return counter;
        }
        #endregion
    }
}
