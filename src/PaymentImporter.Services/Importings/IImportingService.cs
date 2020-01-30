using PaymentImporter.Core.Domain.Enums;
using System.IO;

namespace PaymentImporter.Services.Importings
{
    public interface IImportingService
    {
        bool IsValidFileLength(long fileLength);
        bool IsValidFileType(string fileExtention);
        int Import(Stream stream, ImportFileType fileType);
    }
}
