using System;
using System.ComponentModel.DataAnnotations;

namespace PaymentImporter.Core.Domain.Entities.Transactions
{
    public class Transaction : BaseEntity
    {
        /// <summary>
        /// Gets or sets the transaction identificator identifier
        /// </summary>
        [Required, MaxLength(50), StringLength(50)]
        public string TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the amount
        /// </summary>
        [Required]
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the transaction date
        /// </summary>
        [Required]
        public DateTime TransactionDate { get; set; }

        /// <summary>
        /// Gets or sets the TransactionStatusId
        /// </summary>
        [Required]
        public int TransactionStatusId { get; set; }

        /// <summary>
        /// Gets or sets the transaction status
        /// </summary>
        public virtual TransactionStatus TransactionStatus { get; set; }

        /// <summary>
        /// Gets or sets the CurrencyId
        /// </summary>
        [Required]
        public int CurrencyId { get; set; }

        /// <summary>
        /// Gets or sets the curenncy
        /// </summary>
        public virtual Currency Currency { get; set; }
    }
}
