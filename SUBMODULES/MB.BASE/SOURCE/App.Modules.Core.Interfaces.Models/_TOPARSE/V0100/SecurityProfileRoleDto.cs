namespace App.Modules.Core.Interface.Models._TOPARSE.V0100
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using App.Base.Shared.Factories;
    using App.Base.Shared.Models;

    /// <summary>
    /// DTO for <c>SecurityProfileRole</c>
    /// </summary>
    public class SecurityProfileRoleDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId
    {
        private Guid id;
        private string? title = string.Empty;
        private string? description = string.Empty;
        private ICollection<SecurityProfilePermissionDto> permissions = new Collection<SecurityProfilePermissionDto>();

        /// <summary>
        /// Constructor
        /// </summary>
        public SecurityProfileRoleDto()
        {
            Id = GuidFactory.NewGuid();

        }
        /// <summary>
        /// The Id
        /// </summary>
        public Guid Id { get => id; set => id = value; }

        /// <summary>
        /// The Title
        /// </summary>
        public string Title { get => title ?? string.Empty; set => title = value; }

        /// <summary>
        /// The Description
        /// </summary>
        public string Description { get => description ?? string.Empty; set => description = value; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<SecurityProfilePermissionDto> Permissions { get => permissions; set => permissions = value; }

    }
}

