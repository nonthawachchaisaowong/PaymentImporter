using PaymentImporter.Core.Domain.Entities.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PaymentImporter.Infrastructure.Data.EntityFramework.Mapping
{
    /// <summary>
    /// Represents an transaction
    /// </summary>
    public partial class TransactionMap : PaymentImporterEntityTypeConfiguration<Transaction>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable(nameof(Transaction));
            builder.HasKey(transaction => transaction.Id);

            builder.HasOne(transaction => transaction.TransactionStatus)
                .WithMany()
                .HasForeignKey(affiliate => affiliate.TransactionStatusId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(transaction => transaction.Currency)
                .WithMany()
                .HasForeignKey(affiliate => affiliate.CurrencyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }

        #endregion
    }
}
