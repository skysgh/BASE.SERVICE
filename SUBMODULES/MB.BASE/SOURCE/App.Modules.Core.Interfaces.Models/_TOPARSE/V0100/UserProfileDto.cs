using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Modules.Core.Interface.Models._TOPARSE.V0100
{
    /// <summary>
    /// DTO of a User Profile.
    /// </summary>
    public class UserProfileDto
    {
        private string? displayName;
        private string? fullName;

        /// <summary>
        /// Id of User
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// FullName
        /// </summary>
        public string FullName { get => fullName ?? string.Empty; set => fullName = value; }

        /// <summary>
        /// DisplayName
        /// </summary>
        public string DisplayName { get => displayName ?? string.Empty; set => displayName = value; }
    }
}
