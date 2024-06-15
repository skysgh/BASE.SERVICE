namespace App.Base.Shared.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// System entity (not exposed to the system's exterior) for
    /// The Principal within the System.
    /// <para>
    /// On screen or elsewhere, it's common to refer to this type of entity as a User.
    /// </para>
    /// <para>
    /// But it's *not* called User because a security Principal can be a User, but also a Device or Service.
    /// </para>
    /// </summary>
    public class Principal : UntenantedAuditedRecordStatedTimestampedGuidIdEntityBase, IHasEnabled
    {
        /// <summary>
        /// The UTC DateTime at which the User is enabled.
        /// <para>
        /// (eg: the date at which their contract starts)
        /// </para>
        /// </summary>
        public DateTime? EnabledBeginningUtc { get; set; }
        /// <summary>
        /// The UTC DateTime up to which the User/Principal is enabled to use the system
        /// <para>
        /// (eg: up to their contractor contract's end date).
        /// </para>
        /// </summary>
        public DateTime? EnabledEndingUtc { get; set; }
        /// <summary>
        /// Enabled or not.
        /// <para>
        /// Note that this supercedes their use date start/end
        /// </para>
        /// </summary>
        public virtual bool Enabled { get; set; }

        /// <summary>
        /// The name of the user.
        /// <para>
        /// TODO: Not good here. 
        /// Move to an associated Person identity
        /// so that this table has the least PI as possible.
        /// </para>
        /// </summary>
        public virtual string FullName { get; set; }

        /// <summary>
        /// This is the Principal's displayed preferred Name 
        /// which they can set (it starts off as being equal
        /// to their <see cref="FullName"/>.
        /// </summary>
        public virtual string DisplayName { get; set; }

        /// <summary>
        /// The FK to the <see cref="DataClassification"/> record of the person.
        /// </summary>
        public virtual NZDataClassification? DataClassificationFK { get; set; }
        /// <summary>
        /// The Data Classification record of the person.
        /// </summary>
        public virtual DataClassification? DataClassification { get; set; }

        /// <summary>
        /// The <see cref="PrincipalCategory"/> of the Principal.
        /// </summary>
        public virtual PrincipalCategory? Category { get; set; }
        /// <summary>
        /// The FK of the <see cref="Principal"/>'s <see cref="PrincipalCategory"/>.
        /// </summary>
        public virtual Guid CategoryFK { get; set; }

        /// <summary>
        /// The collection of externally defined (ie, from an IdP) 
        /// Digital Identities of the <see cref="Principal"/>.
        /// </summary>
        public virtual ICollection<PrincipalLogin> Logins
        {
            get
            {
                if (this._logins == null)
                {
                    this._logins = new Collection<PrincipalLogin>();
                }
                return this._logins;
            }
            set => this._logins = value;
        }
        private ICollection<PrincipalLogin>? _logins;


        /// <summary>
        /// The collection of <see cref="PrincipalTag"/>'s
        /// associated to the <see cref="Principal"/>.
        /// </summary>
        public virtual ICollection<PrincipalTag> Tags
        {
            get
            {
                if (this._tags == null)
                {
                    this._tags = new Collection<PrincipalTag>();
                }
                return this._tags;
            }
            set => this._tags = value;
        }
        private ICollection<PrincipalTag>? _tags;




        /// <summary>
        /// The collection of <see cref="PrincipalProperty"/>
        /// that belong to the <see cref="Principal"/>.
        /// </summary>
        public virtual ICollection<PrincipalProperty> Properties
        {
            get
            {
                if (this._properties == null)
                {
                    this._properties = new Collection<PrincipalProperty>();
                }
                return this._properties;
            }
            set => this._properties = value;
        }
        private ICollection<PrincipalProperty>? _properties;

        /// <summary>
        /// The collection of the <see cref="Principal"/>'s
        /// <see cref="PrincipalClaim"/>s
        /// (properties verified by a trusted 3rd party).
        /// </summary>
        public virtual ICollection<PrincipalClaim> Claims
        {
            get
            {
                if (this._claims == null)
                {
                    this._claims = new Collection<PrincipalClaim>();
                }
                return this._claims;
            }
            set => this._claims = value;
        }
        private ICollection<PrincipalClaim>? _claims;





        /// <summary>
        /// The System Roles (not Group Roles) 
        /// associated to the <see cref="Principal"/>.
        /// </summary>
        public virtual ICollection<SystemRole> Roles
        {
            get
            {
                if (this._roles == null)
                {
                    this._roles = new Collection<SystemRole>();
                }
                return this._roles;
            }
            set => this._roles = value;
        }
        private ICollection<SystemRole>? _roles;

    }
}