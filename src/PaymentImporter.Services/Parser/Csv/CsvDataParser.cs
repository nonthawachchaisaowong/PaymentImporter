using CsvHelper;
using PaymentImporter.Core.Dto.Transactions;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PaymentImporter.Services.Parser.Csv
{
    public class CsvDataParser : DataParser
    { 
        public override IList<TransactionFileRecordDto> ParseTransactions(Stream stream)
        {  
            TextReader textReader = new StreamReader(stream);

            using (var csv = new CsvReader(textReader))
            {
                csv.Configuration.HasHeaderRecord = false;
                var records = csv.GetRecords<TransactionFileRecordDto>().ToList();
                return records;
            }         
        }       
    }
}
