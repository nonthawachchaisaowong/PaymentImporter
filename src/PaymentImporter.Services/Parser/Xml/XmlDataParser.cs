using PaymentImporter.Core.Dto.Transactions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace PaymentImporter.Services.Parser.Xml
{
    public class XmlDataParser : DataParser
    {
        public override IList<TransactionFileRecordDto> ParseTransactions(Stream stream)
        {
            XmlReader reader = XmlReader.Create(stream);            
            XElement xElement = XElement.Load(reader);

            var transactionElements = xElement.Elements().
                Select(s => new TransactionFileRecordDto
                {   TransactionId = s.Attribute("id").Value,
                    Amount = s.Element("PaymentDetails").Element("Amount").Value,
                    CurrencyCode = s.Element("PaymentDetails").Element("CurrencyCode").Value,
                    TransactionDate = s.Element("TransactionDate").Value,
                    Status = s.Element("Status").Value
                }).ToList();

            return transactionElements;
        }
    }
}
