namespace App.Modules.Core.Interface.Models._TOPARSE.V0100
{
    using System;
    using App.Base.Shared.Models.Entities;

    /// <summary>
    /// API DTO for system 
    /// <see cref="DataClassification"/>
    /// </summary>
    [Serializable]
    public class DataClassificationDto /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */
    {
        /// <summary>
        /// The record Id
        /// </summary>
        public virtual NZDataClassification Id { get; set; }

        /// <summary>
        /// Whether the data classification is enabled or not.
        ///<para>
        /// TODO: improve documentation: what does that impact?
        ///</para>
        /// </summary>
        public virtual bool Enabled { get; set; }
        /// <summary>
        /// The display title of the Data classification
        /// </summary>
        public virtual string? Title { get; set; }

        /// <summary>
        /// A description of the data classification
        /// </summary>
        public virtual string? Description { get; set; }
        /// <summary>
        /// A hint as to how to order the display data classification
        /// </summary>
        public virtual int DisplayOrderHint { get; set; }
        /// <summary>
        /// A hint as to how to display the data classifaction
        /// </summary>
        public virtual string? DisplayStyleHint { get; set; }
    }


}
