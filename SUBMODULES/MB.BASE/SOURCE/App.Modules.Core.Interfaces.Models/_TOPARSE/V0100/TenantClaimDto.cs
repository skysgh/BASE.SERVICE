using App.Base.Shared.Models;

namespace App.Modules.Core.Interface.Models._TOPARSE.V0100
{
    using System;
    using App.Base.Shared.Models.Entities;

    /// <summary>
    /// DTO for <see cref="TenantClaim"/>
    /// </summary>
    [Serializable]
    public class TenantClaimDto /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */  : IHasGuidId, IHasTenantFK, IHasRecordState
    {
        private string? _authorityKey;
        private string? _key;
        private string? _value;
        private string? _signature;
        private RecordPersistenceState _recordState = RecordPersistenceState.Undefined;
        private Guid _tenantFK = Guid.Empty;

        /// <summary>
        /// 
        /// </summary>
        public virtual string AuthorityKey { get => _authorityKey ?? string.Empty; set => _authorityKey = value; }
        /// <summary>
        /// The TenantClaim Key.
        /// </summary>
        public virtual string Key { get => _key ?? string.Empty; set => _key = value; }
        /// <summary>
        /// The TenantClaim Value.
        /// </summary>
        public virtual string Value { get => _value ?? string.Empty; set => _value = value; }
        /// <summary>
        /// The TenantClaim Signature.
        /// </summary>
        public virtual string Signature { get => _signature ?? string.Empty; set => _signature = value; }
        /// <summary>
        /// The TenantClaim Id.
        /// </summary>
        public virtual Guid Id { get; set; }
        /// <summary>
        /// The TenantClaim RecordState.
        /// </summary>
        public virtual RecordPersistenceState RecordState { get => _recordState; set => _recordState = value; }
        /// <summary>
        /// Tenant Id
        /// </summary>
        public virtual Guid TenantFK { get => _tenantFK; set => _tenantFK = value; }
    }
}