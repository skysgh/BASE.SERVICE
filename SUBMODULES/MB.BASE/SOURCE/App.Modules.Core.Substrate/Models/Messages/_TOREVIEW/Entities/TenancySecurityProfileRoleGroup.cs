namespace App.Base.Shared.Models.Entities
{
    using App.Base.Shared.Models;
    using App.Base.Shared.Models.Entities;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    
    /// <summary>
    /// A nestable Group of Roles,
    /// attachable to a Tenancy Security Profile.
    /// <para>
    /// TODO: Document purpose better
    /// </para>
    /// </summary>
    public class TenancySecurityProfileRoleGroup :
        TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase , 
        IHasTitle, 
        IHasTitleAndDescription,
        IHasParentFKNullable, 
        IHasParentNullable<TenancySecurityProfileRoleGroup>
    {
        /// <summary>
        /// Get/Set the title 
        /// </summary>
        public string Title { get; set; }
        
        /// <summary>
        /// Get/Set the description
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// Nullable FK of the parent Role Group.
        /// </summary>
        public Guid? ParentFK { get; set; }

        /// <summary>
        /// The parent Role Group.
        /// </summary>
        public TenancySecurityProfileRoleGroup? Parent { get; set; }

        /// <summary>
        /// The collection of child Role Groups
        /// </summary>
        public ICollection<TenancySecurityProfileRoleGroup> AccountGroups
        {
            get
            {
                return _accountGroups ?? (_accountGroups = new Collection<TenancySecurityProfileRoleGroup>());
            }
            set
            {
                _accountGroups = value;
            }
        }
        /// <summary>
        /// TODO: Why public?
        /// </summary>
        public ICollection<TenancySecurityProfileRoleGroup>? _accountGroups;


        /// <summary>
        /// THe collection of Roles assigned to this Role Group
        /// </summary>
        public ICollection<TenancySecurityProfileAccountRole> Roles
        {
            get
            {
                return _roles ?? (_roles = new Collection<TenancySecurityProfileAccountRole>());
            }
            set
            {
                _roles = value;
            }
        }
        /// <summary>
        /// TODO: Why public?
        /// </summary>
        public ICollection<TenancySecurityProfileAccountRole>? _roles;

        //TODO: Could get large. Do we want this? Maybe it should only be on Account.
        //public ICollection<Account> Accounts { get; set; } 

    }

}

