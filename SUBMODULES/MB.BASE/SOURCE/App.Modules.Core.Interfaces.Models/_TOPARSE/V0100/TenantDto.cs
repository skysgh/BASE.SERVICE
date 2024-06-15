using App.Base.Shared.Models;

namespace App.Modules.Core.Interface.Models._TOPARSE.V0100
{
    using App.Base.Shared.Models.Entities;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// DTO for <see cref="Tenant"/>
    /// </summary>
    [Serializable]
    public class TenantDto /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */  : IHasGuidId, IHasEnabled
    {
        private ICollection<TenantClaimDto> _claims = new Collection<TenantClaimDto>();
        private Guid _id;
        private bool _enabled;
        private string? _hostName;
        private string? _key;
        private string? _displayName;
        private bool _isDefault;
        private ICollection<TenantPropertyDto> _properties = new Collection<TenantPropertyDto>();
        private DataClassificationDto _dataClassification = new DataClassificationDto();


        /// <summary>
        /// The Tenant's Datastore Id.
        /// </summary>
        public virtual Guid Id { get => _id; set => _id = value; }
        /// <summary>
        /// Whether the Tenant is Enabled.
        /// </summary>
        public virtual bool Enabled { get => _enabled; set => _enabled = value; }
        /// <summary>
        /// The host Name
        /// </summary>
        public virtual string HostName { get => _hostName ?? string.Empty; set => _hostName = value; }

        /// <summary>
        /// The Tenant key
        /// </summary>
        public virtual string Key { get => _key ?? string.Empty; set => _key = value; }
        /// <summary>
        /// The Tenant display name
        /// </summary>
        public virtual string DisplayName { get => _displayName ?? string.Empty; set => _displayName = value; }
        /// <summary>
        /// Whether it's the default Tenant
        /// </summary>
        public bool IsDefault { get => _isDefault; set => _isDefault = value; }

        /// <summary>
        /// Gets the <see cref="DataClassificationDto"/> of the tenant
        /// </summary>
        public DataClassificationDto DataClassification { get => _dataClassification; set => _dataClassification = value; }

        /// <summary>
        /// Gets collection of properties of the Tenant.
        /// </summary>
        public virtual ICollection<TenantPropertyDto> Properties
        {
            get
            {
                if (_properties == null)
                {
                    _properties = new Collection<TenantPropertyDto>();
                }
                return _properties;
            }
            set => _properties = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<TenantClaimDto> Claims
        {
            get
            {
                if (_claims == null)
                {
                    _claims = new Collection<TenantClaimDto>();
                }
                return _claims;
            }
            set => _claims = value;
        }
    }
}