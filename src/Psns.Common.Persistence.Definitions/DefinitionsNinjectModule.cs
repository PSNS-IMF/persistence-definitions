using Ninject.Modules;

namespace Psns.Common.Persistence.Definitions
{
    /// <summary>
    /// Contains Ninject bindings for module
    /// </summary>
    public class DefinitionsNinjectModule : NinjectModule
    {
        /// <summary>
        /// Binds IRepositoryFactory to RepositoryFactory
        /// </summary>
        public override void Load()
        {
            Bind<IRepositoryFactory>().To<RepositoryFactory>();
        }
    }
}
