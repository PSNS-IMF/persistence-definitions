using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Psns.Common.Persistence.Definitions
{
    /// <summary>
    /// Used to declare the IRepository action on which the property will be included
    /// </summary>
    public enum IncludeCases
    {
        Index,
        Update,
        Find
    }

    /// <summary>
    /// Used to declare that a given property should be included in an IRepository action
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class IncludePropertyAttribute : Attribute
    {
        /// <summary>
        /// The IRepository action on which the property will be included
        /// </summary>
        public readonly IncludeCases IncludeCase;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="includeCase">The IRepository action on which the property will be included</param>
        public IncludePropertyAttribute(IncludeCases includeCase)
        {
            IncludeCase = includeCase;
        }
    }
}
