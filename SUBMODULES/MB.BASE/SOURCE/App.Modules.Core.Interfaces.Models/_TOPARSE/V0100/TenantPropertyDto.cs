using App.Base.Shared.Models;

namespace App.Modules.Core.Interface.Models._TOPARSE.V0100
{
    using System;
    using App.Base.Shared.Models.Entities;

    /// <summary>
    /// DTO for a <see cref="TenantProperty"/>
    /// </summary>
    [Serializable]
    public class TenantPropertyDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId, IHasTenantFK, IHasRecordState
    {
        private string? _key;
        private string? _value;
        private Guid _id = Guid.Empty;
        private RecordPersistenceState _recordState = RecordPersistenceState.Undefined;
        private Guid _tenantFK = Guid.Empty;

        /// <summary>
        /// The Property Key
        /// </summary>
        public virtual string Key { get => _key ?? string.Empty; set => _key = value; }
        /// <summary>
        /// The Property Value
        /// </summary>
        public virtual string Value { get => _value ?? string.Empty; set => _value = value; }
        /// <summary>
        /// The Datastore Id of the Property
        /// </summary>
        public virtual Guid Id { get => _id; set => _id = value; }
        /// <summary>
        /// The State of the record.
        /// </summary>
        public virtual RecordPersistenceState RecordState { get => _recordState; set => _recordState = value; }
        /// <summary>
        /// The Id of the Tenancy.
        /// </summary>
        public virtual Guid TenantFK { get => _tenantFK; set => _tenantFK = value; }
    }
}