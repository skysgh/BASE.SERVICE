using App.Base.Shared.Models;

namespace App.Modules.Core.Interface.Models._TOPARSE.V0100
{
    using System;
    using App.Base.Shared.Models.Entities;

    /// <summary>
    /// An API DTO 
    /// for a Role.
    /// </summary>
    public class RoleDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId, IHasRecordState
    {

        /// <summary>
        /// The Id of the Role.
        /// </summary>
        public virtual Guid Id
        {
            get; set;
        }
        /// <summary>
        /// TODO: Improve documentation
        /// </summary>
        public string? ModuleKey { get; set; }

        /// <summary>
        /// The state of the record.
        /// </summary>
        public virtual RecordPersistenceState RecordState
        {
            get; set;
        }

        /// <summary>
        /// Whether the Role is enabled or not.
        /// </summary>
        public virtual bool Enabled
        {
            get; set;
        }


        /// <summary>
        /// The unique key of the Role
        /// </summary>
        public virtual string? Key
        {
            get; set;
        }
        /// <summary>
        /// The data classification of the Role.
        /// </summary>
        public DataClassificationDto? DataClassification
        {
            get; set;
        }


    }
}