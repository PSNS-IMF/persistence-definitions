using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ninject;
using Ninject.Parameters;

namespace Psns.Common.Persistence.Definitions
{
    /// <summary>
    /// An implementation of IRepositoryFactory that uses Ninject as the locator
    /// </summary>
    public class RepositoryFactory : IRepositoryFactory
    {
        IKernel _kernel;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="kernel">The Ninject IKernel</param>
        public RepositoryFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        /// <summary>
        /// Call the Ninject Kernel to get an IRepository of type T
        /// </summary>
        /// <typeparam name="T">The type of IRepository to get</typeparam>
        /// <returns>IRepository of type T</returns>
        public virtual IRepository<T> Get<T>() where T : class, IIdentifiable
        {
            return _kernel.GetService(typeof(IRepository<T>)) as IRepository<T>;
        }
    }
}
