namespace PaymentImporter.Core.Domain.Entities.Transactions
{
    public class TransactionStatus : BaseEntity
    {
        /// <summary>
        /// Gets or sets the transaction Status    
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Gets or sets the transaction unified format : (one letter code for status)
        /// </summary>
        public string UnifiedFormat { get; set; }       
    }
}
