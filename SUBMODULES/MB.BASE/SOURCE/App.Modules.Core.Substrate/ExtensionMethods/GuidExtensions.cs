﻿// Extensions are always put in root namespace
// for maximum usability from elsewhere:

namespace App
{
    using System;
    using App.Base.Shared.Factories;

    /// <summary>
    /// An extension to <see cref="Guid"/> objects
    /// to generate a new Guid using the <see cref="GuidFactory"/>.
    /// </summary>
    public static class GuidExtensions
    {
        /// <summary>
        /// Generate a new Guid.
        /// <para>
        /// IMPORTANT: Does not change the value of the Guid.
        /// </para>
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
#pragma warning disable IDE0060 // Remove unused parameter
        public static Guid Generate(this Guid guid)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            return GuidFactory.NewGuid();
        }
    }
}