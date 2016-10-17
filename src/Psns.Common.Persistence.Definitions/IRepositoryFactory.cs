namespace Psns.Common.Persistence.Definitions
{
    /// <summary>
    /// Defines a factory object that creates IRepositories
    /// </summary>
    public interface IRepositoryFactory
    {
        /// <summary>
        /// Get an IRepository of type T
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns>IRepository of type T</returns>
        IRepository<T> Get<T>() where T : class, IIdentifiable;
    }
}