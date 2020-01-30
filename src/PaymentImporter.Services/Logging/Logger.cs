using PaymentImporter.Core.Domain.Entities.Logs;
using PaymentImporter.Core.Domain.Enums;
using PaymentImporter.Core.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PaymentImporter.Services.Logging
{
    public class Logger : ILogger
    {
        IRepository<Log> _logRepositor;

        public Logger(IRepository<Log> currencyRepositor)
        {
            _logRepositor = currencyRepositor;
        }

        public Log GetLogBy(int id)
        {
            return _logRepositor.GetById(id);
        }

        public void DeleteLog(Log log)
        {
            _logRepositor.Delete(log);
        }

        public IList<Log> GetAllLogs()
        {
            return _logRepositor.GetAll().ToList();
        }

        public virtual Log InsertLog(LogLevel logLevel, string shortMessage, string fullMessage = "")
        {  
            var log = new Log
            {
                LogLevel = logLevel,
                ShortMessage = shortMessage,
                FullMessage = fullMessage,
                CreatedOnUtc = DateTime.UtcNow
            };     

            return log;
        }

        public void InsertLog(Log log)
        {
            _logRepositor.Create(log);
        }

        public void UpdateLog(Log log)
        {
            _logRepositor.Update(log);
        }
    }
}
