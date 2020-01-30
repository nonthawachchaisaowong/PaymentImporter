using PaymentImporter.Core.Domain.Entities.Logs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PaymentImporter.Infrastructure.Data.EntityFramework.Mapping
{
    /// <summary>
    /// Represents an log mapping configuration
    /// </summary>
    public partial class LogMap : PaymentImporterEntityTypeConfiguration<Log>
    {
        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public override void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable(nameof(Log));
            builder.HasKey(log => log.Id);

            builder.Ignore(logItem => logItem.LogLevel);

            base.Configure(builder);
        }

        #endregion
    }
}
