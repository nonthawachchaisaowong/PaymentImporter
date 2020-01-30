using System.Linq;

namespace PaymentImporter.Core.Domain.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        #region Methods

        /// <summary>
        /// Get all etntities
        /// </summary>
        /// <returns></returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Get entity by id
        /// </summary>
        /// <param name="id">id of entity</param>
        /// <returns></returns>
        TEntity GetById(int id);

        /// <summary>
        /// Create entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Create(TEntity entity);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        void Update(TEntity entity);

        /// <summary>
        /// Delete entity by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        void Delete(TEntity entity);

        #endregion

        #region Properties

        /// <summary>
        /// Gets a table
        /// </summary>
        IQueryable<TEntity> Table { get; }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        IQueryable<TEntity> TableNoTracking { get; }

        #endregion
    }

}
