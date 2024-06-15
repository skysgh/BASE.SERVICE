using App.Base.Shared.Models;

namespace App.Modules.Core.Interface.Models._TOPARSE.V0100
{
    using System;

    /// <summary>
    /// An API DTO of
    /// a Tag describing a Principal
    /// </summary>
    public class PrincipalTagDto /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId
    {
        /// <summary>
        /// The record Id of the tag
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// Whether the tag is enabled or not
        /// </summary>
        public virtual bool Enabled { get; set; }

        /// <summary>
        /// The display title of the tag
        /// </summary>
        public virtual string? Text { get; set; }

        /// <summary>
        /// The description of the tag
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The hint as to the order in which to display a collection of Tags
        /// </summary>
        public virtual int DisplayOrderHint { get; set; }

        /// <summary>
        /// The hint as to how to display the Tag
        /// </summary>
        public virtual string? DisplayStyleHint { get; set; }

    }
}