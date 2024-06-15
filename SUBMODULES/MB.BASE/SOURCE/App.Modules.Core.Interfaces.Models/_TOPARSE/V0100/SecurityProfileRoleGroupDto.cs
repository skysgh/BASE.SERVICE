using App.Base.Shared.Factories;
using App.Base.Shared.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace App.Modules.Core.Interface.Models._TOPARSE.V0100
{
    /// <summary>
    /// DTO for <c>SecurityProfileRoleGroup</c>
    /// </summary>
    public class SecurityProfileRoleGroupDto : IHasGuidId
    {
        private Guid id = Guid.Empty;
        private string? title = null;
        private string? description = null;
        private ICollection<SecurityProfileRoleGroupDto> groups = new Collection<SecurityProfileRoleGroupDto>();
        private ICollection<SecurityProfileRoleDto> roles = new Collection<SecurityProfileRoleDto>();

        /// <summary>
        /// Constructor
        /// </summary>
        public SecurityProfileRoleGroupDto()
        {
            Id = GuidFactory.NewGuid();

        }
        /// <summary>
        /// The Id
        /// </summary>
        public Guid Id { get => id; set => id = value; }

        /// <summary>
        /// Title
        /// </summary>
        public string Title { get => title ?? string.Empty; set => title = value; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get => description ?? string.Empty; set => description = value; }


        /// <summary>
        /// Groups
        /// </summary>
        public ICollection<SecurityProfileRoleGroupDto> Groups { get => groups; set => groups = value; }

        /// <summary>
        /// Roles
        /// </summary>
        public ICollection<SecurityProfileRoleDto> Roles { get => roles; set => roles = value; }


    }
}
