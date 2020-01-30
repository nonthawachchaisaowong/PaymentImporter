using PaymentImporter.Core.Domain.Enums;
using PaymentImporter.Core.Dto.Transactions;
using PaymentImporter.Services.Parser.Csv;
using PaymentImporter.Services.Parser.Xml;

using System;
using System.Collections.Generic;
using System.IO;

namespace PaymentImporter.Services.Parser
{
    public class DataParserFactory
    {
        public static IList<TransactionFileRecordDto> GetTransactionFileRecords(Stream stream, ImportFileType fileType)
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
                    throw new Exception("Unsuppot file type!");
            }
        }
    }
}
