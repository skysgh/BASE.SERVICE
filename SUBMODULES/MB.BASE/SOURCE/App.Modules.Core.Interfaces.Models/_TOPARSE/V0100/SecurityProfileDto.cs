using App.Base.Shared.Factories;
using App.Base.Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Modules.Core.Interface.Models._TOPARSE.V0100
{
    /// <summary>
    /// DTO for <c>SecurityProfile</c>
    /// </summary>
    public class SecurityProfileDto : IHasGuidId
    {
        private ICollection<SecurityProfileRoleDto> roles = new Collection<SecurityProfileRoleDto>();
        private ICollection<SecurityProfileRoleGroupDto> accountGroups = new Collection<SecurityProfileRoleGroupDto>();
        private string? key = string.Empty;
        private Guid id = Guid.Empty;
        private ICollection<SecurityProfileSecurityProfilePermissionAssignmentDto> permissionsAssignments = new Collection<SecurityProfileSecurityProfilePermissionAssignmentDto>();

        /// <summary>
        /// Constructor
        /// </summary>
        public SecurityProfileDto()
        {
            Id = Guid.Empty;
            GuidFactory.NewGuid();
        }

        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get => id; set => id = value; }


        /// <summary>
        /// Key
        /// </summary>
        public string Key { get => key ?? string.Empty; set => key = value; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<SecurityProfileRoleGroupDto> AccountGroups { get => accountGroups; set => accountGroups = value; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<SecurityProfileRoleDto> Roles { get => roles; set => roles = value; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<SecurityProfileSecurityProfilePermissionAssignmentDto> PermissionsAssignments { get => permissionsAssignments; set => permissionsAssignments = value; }
    }
}
