using PaymentImporter.Services.Transactions;
using PaymentImporter.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace PaymentImporter.Web.Controllers
{
    public class HomeController : Controller
    {
        ITransactionApiService _transactionService;    

        public HomeController(ITransactionApiService transactionService)
        {       
            _transactionService = transactionService;
        }

        public IActionResult List()
        {        
            return View(_transactionService.GetAllTransactionDtos());
        }   

        public IActionResult Upload()
        {
            return View();
        }   

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
