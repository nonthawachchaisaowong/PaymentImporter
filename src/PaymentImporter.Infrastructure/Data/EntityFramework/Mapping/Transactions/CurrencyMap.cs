using PaymentImporter.Core.Domain.Entities.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PaymentImporter.Infrastructure.Data.EntityFramework.Mapping
{
    /// <summary>
    /// Represents an currency mapping configuration
    /// </summary>
    public partial class CurrencynMap : PaymentImporterEntityTypeConfiguration<Currency>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.ToTable(nameof(Currency));
            builder.HasKey(currency => currency.Id);

            base.Configure(builder);
        }

        #endregion
    }
}
