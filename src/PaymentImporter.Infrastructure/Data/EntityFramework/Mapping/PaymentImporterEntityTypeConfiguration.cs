using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentImporter.Core.Domain.Entities;

namespace PaymentImporter.Infrastructure.Data.EntityFramework.Mapping
{
    /// <summary>
    /// Represents base entity mapping configuration
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public partial class PaymentImporterEntityTypeConfiguration<TEntity> : IMappingConfiguration, IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        #region Utilities

        //Allows configuration for an entity type to be factored into a separate class, 
        //rather than in-line in OnModelCreating(ModelBuilder). Implement this interface,
        //applying configuration for the entity in the Configure(EntityTypeBuilder<TEntity>)
        //method, and then apply the configuration to the model using ApplyConfiguration<TEntity>(IEntityTypeConfiguration<TEntity>) in OnModelCreating(ModelBuilder).

        /// <summary>
        /// Developers can override this method in custom partial classes in order to add some custom configuration code
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        protected virtual void PostConfigure(EntityTypeBuilder<TEntity> builder)
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// Configures the entity
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity</param>
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            //add custom configuration
            this.PostConfigure(builder);
        }

        /// <summary>
        /// Apply this mapping configuration
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for the database context</param>
        public virtual void ApplyConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(this);
        }

        #endregion
    }
}