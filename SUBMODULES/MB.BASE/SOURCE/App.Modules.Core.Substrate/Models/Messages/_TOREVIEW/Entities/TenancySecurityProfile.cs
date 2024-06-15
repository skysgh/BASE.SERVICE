using App.Base.Shared.Models;
using App.Base.Shared.Models.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Base.Shared.Models.Entities
{
    /// <summary>
    ///  System entity (not exposed to the system's exterior) for
    /// the Security Profile of a User in a specific Tenancy.
    /// <para>
    /// TODO: Confirm documentation accuracy.
    /// </para>
    /// </summary>
    public class TenancySecurityProfile : TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase, IHasKey
    {

        /// <summary>
        /// Whether User is Enabled in this Tenancy.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The unique key of this user (ie, the UserName).
        /// </summary>
        public string Key { get; set; }


        /// <summary>
        /// Collection of <see cref="TenancySecurityProfileRoleGroup"/>
        /// describing TODO.
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
        /// TODO: Is Public required?
        /// </summary>
        public ICollection<TenancySecurityProfileRoleGroup>? _accountGroups;


        /// <summary>
        /// Collection of <see cref="TenancySecurityProfileAccountRole"/>
        /// describing TODO.
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
        /// TODO: Is this Public needed?
        /// </summary>
        public ICollection<TenancySecurityProfileAccountRole>? _roles;


        /// <summary>
        /// Collection of <see cref="TenancySecurityProfileTenancySecurityProfilePermissionAssignment"/>
        /// describing TODO.
        /// </summary>
        public ICollection<TenancySecurityProfileTenancySecurityProfilePermissionAssignment> PermissionsAssignments
        {
            get
            {
                return _permissionsAssignments ?? (_permissionsAssignments = new Collection<TenancySecurityProfileTenancySecurityProfilePermissionAssignment>());
            }
            set
            {
                _permissionsAssignments = value;
            }
        }
        /// <summary>
        /// TODO: Is this public needed?
        /// </summary>
        public ICollection<TenancySecurityProfileTenancySecurityProfilePermissionAssignment>? _permissionsAssignments;



    }
}
