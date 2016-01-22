using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Psns.Common.Persistence.Definitions
{
    /// <summary>
    /// Defines a repository that provides access to a collection of type T
    /// </summary>
    /// <typeparam name="T">IIdentifiable class</typeparam>
    public interface IRepository<T> : IDisposable where T : class, IIdentifiable
    {
        /// <summary>
        /// Get all entities
        /// </summary>
        /// <returns>IEnumerable of T</returns>
        IEnumerable<T> All(params string[] includes);

        /// <summary>
        /// Create a given T
        /// </summary>
        /// <param name="entity">The T to create</param>
        /// <returns>The created T</returns>
        T Create(T entity);
        
        /// <summary>
        /// Search for a particular T
        /// </summary>
        /// <param name="predicate">A Linq Expression</param>
        /// <returns>IEnumerble<typeparamref name="T"/></returns>
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate, params string[] includes);

        /// <summary>
        /// Search for a T with given primary key values
        /// </summary>
        /// <param name="keyValues">Primary key values</param>
        /// <returns>A T or null if not found</returns>
        T Find(params object[] keyValues);

        /// <summary>
        /// Update a given T
        /// </summary>
        /// <param name="entity">The T to update</param>
        /// <returns>The updated T</returns>
        T Update(T entity, params string[] includes);

        /// <summary>
        /// Remove a T from the repository
        /// </summary>
        /// <param name="entity">The T to delete</param>
        /// /// <returns>The deleted T</returns>
        T Delete(T entity);

        /// <summary>
        /// Save all changes made
        /// </summary>
        /// <returns>The number of changes committed</returns>
        int SaveChanges();
    }
}