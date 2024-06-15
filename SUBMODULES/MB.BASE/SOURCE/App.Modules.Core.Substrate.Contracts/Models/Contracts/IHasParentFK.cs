using System;
using System.ComponentModel;

namespace App.Base.Shared.Models
{
    /// <summary>
    /// <para>
    /// See <see cref="IHasParentFKNullable"/>
    /// </para>
    /// <para>
    /// See <see cref="IHasOwnerFK"/></para>
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IHasParentFK
    {
        /// <summary>
        /// The FK of the parent object.
        /// </summary>
        Guid ParentFK { get; set; }
    }
}