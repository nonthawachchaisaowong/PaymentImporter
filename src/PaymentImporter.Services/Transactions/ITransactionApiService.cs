using PaymentImporter.Core.Dto.Transactions;
using System;
using System.Collections.Generic;

namespace PaymentImporter.Services.Transactions
{
    public interface ITransactionApiService
    {
        List<TransactionResponseDto> GetAllTransactionDtos(string currency = "", string status = "", string start_date = "", string end_date = "");        
    }
}
