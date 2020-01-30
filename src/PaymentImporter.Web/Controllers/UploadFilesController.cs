using PaymentImporter.Core;
using PaymentImporter.Core.Domain.Enums;
using PaymentImporter.Services.Helpers;
using PaymentImporter.Services.Importings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace PaymentImporter.Web.Controllers
{
    public class UploadFilesController : Controller
    {
        IImportingService _importingService;

        public UploadFilesController(IImportingService importingService)
        {
            _importingService = importingService;
        }

        [HttpPost("UploadFiles")]
        public IActionResult Index(IFormFile file)
        {
            var fileExt = FileHelper.GetSimpleExtension(file.FileName);

            if (!_importingService.IsValidFileType(fileExt))
            {
                return BadRequest("Unknown format.");
            }

            if (_importingService.IsValidFileLength(file.Length))
            {
                return BadRequest("File size must less than 1 MB.");
            }

            try
            {
                int rowsInport = _importingService.Import(file.OpenReadStream(), EnumHelper.Parse<ImportFileType>(fileExt));

                return Ok(string.Format("{0} Rows was imported", rowsInport));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}