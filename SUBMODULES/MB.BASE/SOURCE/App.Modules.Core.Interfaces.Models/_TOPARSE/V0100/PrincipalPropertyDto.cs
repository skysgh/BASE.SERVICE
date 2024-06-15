using App.Base.Shared.Models;

namespace App.Modules.Core.Interface.Models._TOPARSE.V0100
{
    using System;
    using App.Base.Shared.Models.Entities;

    /// <summary>
    /// API DTO for 
    /// Properties describing a Principal
    /// </summary>
    public class PrincipalPropertyDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId, IHasRecordState, IHasKey
    {
        /// <summary>
        /// The FK to the parent Property
        /// <para>
        /// Note no navigation up property provided.
        /// </para>
        /// </summary>
        public virtual Guid PrincipalFK { get; set; }


        /// <summary>
        /// The value of the property.
        /// </summary>
        public virtual string? Value { get; set; }

        /// <summary>
        /// The Id of the Property describing the Principal
        /// </summary>
        public virtual Guid Id { get; set; }
        /// <summary>
        /// The unqiey key for the property.
        /// </summary>
        public virtual string Key { get; set; } = string.Empty;
        /// <summary>
        /// The state of the persisted record.
        /// </summary>
        public virtual RecordPersistenceState RecordState { get; set; }
    }
}