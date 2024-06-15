using App.Base.Shared.Models;

namespace App.Modules.Core.Interface.Models._TOPARSE.V0100
{
    using System;

    /// <summary>
    /// An API DTO
    /// of a Category to describe a Principal
    /// </summary>
    public class PrincipalCategoryDto /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId
    {
        /// <summary>
        /// The Record Id
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// Whether the category is enabled or not
        /// </summary>
        public virtual bool Enabled { get; set; }

        /// <summary>
        /// The Text/display title of the Category
        /// </summary>
        public virtual string? Text { get; set; }

        /// <summary>
        /// The displayable Description of the Category 
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// The hint as to the order to display
        /// </summary>
        public virtual int DisplayOrderHint { get; set; }

        /// <summary>
        /// The hint as to the style in which to render the element.
        /// </summary>
        public virtual string? DisplayStyleHint { get; set; }

    }
}