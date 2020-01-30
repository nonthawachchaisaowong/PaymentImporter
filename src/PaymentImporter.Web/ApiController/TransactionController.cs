using PaymentImporter.Core.Dto.Transactions;
using PaymentImporter.Services.Transactions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace PaymentImporter.Web.ApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        #region Fields
        ITransactionApiService _transactionApiService;
        #endregion

        #region Ctor
        public TransactionController(ITransactionApiService transactionApiService)
        {
            _transactionApiService = transactionApiService;
        }
        #endregion

        [HttpGet]
        [Route("/api/transactions")]
        public ActionResult<List<TransactionResponseDto>> GetAll(string currency = "", string status = "", string start_date = "", string end_date = "")
        {
            try
            {
                var transactions = _transactionApiService.GetAllTransactionDtos(currency, status, start_date, end_date);

                return Ok(transactions);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}