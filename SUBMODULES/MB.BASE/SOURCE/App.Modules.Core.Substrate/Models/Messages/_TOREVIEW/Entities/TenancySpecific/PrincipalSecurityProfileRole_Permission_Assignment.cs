namespace App.Base.Shared.Models.Entities.TenancySpecific
{
    using App.Base.Shared.Models.Entities;
    using System;

    /// <summary>
    /// An assignment of an Permission to a Role within a Secuirity Profile
    /// </summary>
    public class PrincipalSecurityProfileRolePrincipalSecurityProfilePermissionAssignment : TenantFKAuditedRecordStatedTimestampedNoIdEntityBase
    {
        /// <summary>
        /// The FK of the Role
        /// </summary>
        public Guid RoleFK { get; set; }
        /// <summary>
        /// The Role to which the Permission is assigned.
        /// </summary>
        public PrincipalSecurityProfileRole? Role { get; set; }

        /// <summary>
        /// The FK of the Permission being assigned to the Role.
        /// </summary>
        public Guid PermissionFK { get; set; }
        /// <summary>
        /// The Permission being assigned to the Role.
        /// </summary>
        public PrincipalSecurityProfilePermission Permission { get; set; }

        /// <summary>
        /// How it is being assigned (+/-)
        /// </summary>
        public AssignmentType AssignmentType { get; set; }
    }

}

