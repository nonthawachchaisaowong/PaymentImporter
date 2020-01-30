using PaymentImporter.Core.Domain.Entities.Logs;
using PaymentImporter.Core.Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentImporter.Services.Logging
{
    /// <summary>
    /// Logger interface
    /// </summary>
    public partial interface ILogger
    {
        Log GetLogBy(int id);
        void DeleteLog(Log log);
        IList<Log> GetAllLogs();
        Log InsertLog(LogLevel logLevel, string shortMessage, string fullMessage = "");
        void InsertLog(Log transaction);
        void UpdateLog(Log transaction);
    }
}
