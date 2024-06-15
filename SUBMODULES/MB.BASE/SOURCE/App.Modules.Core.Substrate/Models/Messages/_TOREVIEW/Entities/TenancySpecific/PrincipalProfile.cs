namespace App.Base.Shared.Models.Entities.TenancySpecific
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
     
    /// <summary>
    /// The profile (not same as Security Profile) of a Principal.
    /// </summary>
    public class PrincipalProfile : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase, IHasEnabled {

        /// <summary>
        /// Get/Set from when the Principal is enabled.
        /// </summary>
        public DateTime? EnabledBeginningUtc { get; set; }
        
        /// <summary>
        /// Get/Set until when the Principal is enabled (eg: Contract)
        /// </summary>
        public DateTime? EnabledEndingUtc { get; set; }
        
        /// <summary>
        /// Is the Principal Enabled.
        /// </summary>
        public virtual bool Enabled { get; set; }


        /// <summary>
        /// Display (user Modifiable) name of Principal
        /// </summary>
        public virtual string DisplayName { get; set; } = string.Empty;

        /// <summary>
        /// Get/Set the FK of the Data Classification of the Principal.
        /// </summary>
        public virtual NZDataClassification? DataClassificationFK { get; set; }
        /// <summary>
        /// Get/Set the Data Classification of the Principal.
        /// </summary>
        public virtual DataClassification? DataClassification { get; set; }

        /// <summary>
        /// Get/Set the Category of Principal
        /// </summary>
        public virtual PrincipalProfileCategory? Category { get; set; }
        /// <summary>
        /// Get/Set the FK of the Category of the Principal
        /// </summary>
        public virtual Guid CategoryFK { get; set; }


        /// <summary>
        /// Get the Collection of Tags associated.
        /// </summary>
        public virtual ICollection<PrincipalProfileTag> Tags
        {
            get
            {
                if (this._tags == null)
                {
                    this._tags = new Collection<PrincipalProfileTag>();
                }
                return this._tags;
            }
            set => this._tags = value;
        }
        private ICollection<PrincipalProfileTag>? _tags;




        /// <summary>
        /// Get the collection of properties of this Profile.
        /// </summary>
        public virtual ICollection<PrincipalProfileProperty> Properties
        {
            get
            {
                if (this._properties == null)
                {
                    this._properties = new Collection<PrincipalProfileProperty>();
                }
                return this._properties;
            }
            set => this._properties = value;
        }
        private ICollection<PrincipalProfileProperty>? _properties;

        /// <summary>
        /// Get the Claims associated to this <see cref="Principal"/>
        /// </summary>
        public virtual ICollection<PrincipalProfileClaim> Claims
        {
            get
            {
                if (this._claims == null)
                {
                    this._claims = new Collection<PrincipalProfileClaim>();
                }
                return this._claims;
            }
            set => this._claims = value;
        }
        private ICollection<PrincipalProfileClaim>? _claims;





    }
}