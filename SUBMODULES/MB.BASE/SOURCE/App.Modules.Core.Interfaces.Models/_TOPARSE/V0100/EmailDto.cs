using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Modules.Core.Interface.Models._TOPARSE.V0100
{
    /// <summary>
    /// API DTO for system 
    /// <c>Email</c>
    /// </summary>
    public class EmailDto
    {
        /// <summary>
        /// The email destination
        /// </summary>
        public string? To { get; set; }

        /// <summary>
        /// The subject of the email
        /// </summary>
        public string? Subject { get; set; }

        /// <summary>
        /// The Body of the email
        /// </summary>
        public string? Body { get; set; }
    }
}
