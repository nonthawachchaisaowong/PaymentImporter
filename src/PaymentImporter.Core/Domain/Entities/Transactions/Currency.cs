using System.ComponentModel.DataAnnotations;

namespace PaymentImporter.Core.Domain.Entities.Transactions
{
    /// <summary>
    /// Represents a currency
    /// </summary>
    public class Currency : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name
        /// </summary>
        [Required, MaxLength(100), StringLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the currency code
        /// </summary>
        [Required, MaxLength(3), StringLength(3)]
        public string CurrencyCode { get; set; }
    }
}
