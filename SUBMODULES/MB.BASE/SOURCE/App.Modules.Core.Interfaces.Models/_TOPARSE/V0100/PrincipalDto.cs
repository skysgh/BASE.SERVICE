using App.Base.Shared.Models;

namespace App.Modules.Core.Interface.Models._TOPARSE.V0100
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;


    /// <summary>
    /// An API DTO
    /// for a Principal
    /// </summary>
    public class PrincipalDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId, IHasEnabled
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private ICollection<PrincipalClaimDto> _claims;
        private ICollection<PrincipalPropertyDto> _properties;
        private ICollection<PrincipalTagDto> _tags;
        private ICollection<PrincipalLoginDto> _logins;
        private ICollection<RoleDto> _roles;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        /// <summary>
        /// The full name of the Pricipal
        /// <para>
        /// TODO: This is PI that may be best moved to a detachable Element...but that might lead to needing more Joins.
        /// </para>
        /// </summary>
        public string? FullName { get; set; }

        /// <summary>
        /// The display name of the principal.
        /// <para>
        /// TODO: This is PI that may be best moved to a detachable Element...but that might lead to needing more Joins.
        /// </para>
        /// </summary>
        public virtual string? DisplayName { get; set; }

        /// <summary>
        /// The Data Classification of the Principal
        /// </summary>
        public DataClassificationDto? DataClassification { get; set; }

        /// <summary>
        /// The Category of the Principal.
        /// </summary>
        public PrincipalCategoryDto? Category { get; set; }


        /// <summary>
        /// Collection of Security Roles the Principal has.
        /// <para>
        /// TODO: Should probably be only in the Security Profile.
        /// </para>
        /// </summary>
        public ICollection<RoleDto> Roles
        {
            get
            {
                if (_roles == null)
                {
                    _roles = new Collection<RoleDto>();
                }
                return _roles;
            }
            set => _roles = value;
        }

        /// <summary>
        /// Collection of Digital Identities associated to a Principal.
        /// </summary>
        public ICollection<PrincipalLoginDto> Logins
        {
            get
            {
                if (_logins == null)
                {
                    _logins = new Collection<PrincipalLoginDto>();
                }
                return _logins;
            }
            set => _logins = value;
        }

        /// <summary>
        /// Collection of Tags describing a Principal
        /// </summary>
        public virtual ICollection<PrincipalTagDto> Tags
        {
            get
            {
                if (_tags == null)
                {
                    _tags = new Collection<PrincipalTagDto>();
                }
                return _tags;
            }
            set => _tags = value;
        }

        /// <summary>
        /// Collection of properties describing a Principal
        /// </summary>
        public virtual ICollection<PrincipalPropertyDto> Properties
        {
            get
            {
                if (_properties == null)
                {
                    _properties = new Collection<PrincipalPropertyDto>();
                }
                return _properties;
            }
            set => _properties = value;
        }

        /// <summary>
        /// The collection of claims associated to the Principal.
        /// </summary>
        public virtual ICollection<PrincipalClaimDto> Claims
        {
            get
            {
                if (_claims == null)
                {
                    _claims = new Collection<PrincipalClaimDto>();
                }
                return _claims;
            }
            set => _claims = value;
        }

        /// <summary>
        /// Whether The Principal is enabled or not.
        /// </summary>
        public virtual bool Enabled { get; set; }

        /// <summary>
        /// The Id of the Record
        /// </summary>
        public virtual Guid Id { get; set; }
    }
}