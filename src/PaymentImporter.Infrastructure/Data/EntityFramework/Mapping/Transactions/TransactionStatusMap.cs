using PaymentImporter.Core.Domain.Entities.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PaymentImporter.Infrastructure.Data.EntityFramework.Mapping
{
    /// <summary>
    /// Represents an transactionstatus
    /// </summary>
    public partial class TransactionStatusMap : PaymentImporterEntityTypeConfiguration<TransactionStatus>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<TransactionStatus> builder)
        {
            builder.ToTable(nameof(TransactionStatus));
            builder.HasKey(transactionStatus => transactionStatus.Id);

            base.Configure(builder);
        }

        #endregion
    }
}
