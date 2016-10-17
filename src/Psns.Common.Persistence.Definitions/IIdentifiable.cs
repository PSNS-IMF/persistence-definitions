using System.Collections.Generic;

namespace Psns.Common.Persistence.Definitions
{
    /// <summary>
    /// Defines an object that can be identified
    /// </summary>
    public interface IIdentifiable
    {
        /// <summary>
        /// An integer Property
        /// </summary>
        int Id { get; }
    }

    /// <summary>
    /// Used to compare to IIdentifiables
    /// </summary>
    public class IdentifiableComparer : IEqualityComparer<IIdentifiable>
    {
        /// <summary>
        /// Determines if two IIdentifiables are Equal
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns>If x.Id == y.Id</returns>
        public bool Equals(IIdentifiable x, IIdentifiable y)
        {
            return x.Id == y.Id;
        }

        public int GetHashCode(IIdentifiable obj)
        {
            return obj.Id;
        }
    }
}
