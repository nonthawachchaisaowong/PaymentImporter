using PaymentImporter.Core.Dto.Transactions;
using System.Collections.Generic;
using System.IO;

namespace PaymentImporter.Services.Parser
{
    public abstract class DataParser 
    {
        public abstract IList<TransactionFileRecordDto> ParseTransactions(Stream stream);
    }
}
