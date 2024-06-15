using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Modules.Core.Interface.Models._TOPARSE.V0100
{
    /// <summary>
    /// The API DTO for one of the Digital Identities
    /// associated to a Principal
    /// </summary>
    public class PrincipalLoginDto
    {
        /// <summary>
        /// The Id of the record.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// The FK of the parent Principal
        /// </summary>
        public Guid PrincipalFK { get; set; }

        /// <summary>
        /// Can be used to disallow an external IdP login that was previsoulsy trusted.
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The Credential Name/Login the external IdP uses to distinguish users by (eg: google.com, sts, etc.).
        /// </summary>
        public string? IdPLogin { get; set; }

        /// <summary>
        /// The Subject Identifier the external IdP uses to distinguish users by (eg: 'some guid, joeblow', 'joeblow@google.com', etc.).
        /// </summary>
        public string? SubLogin { get; set; }

        /// <summary>
        /// Last datetime the user signed in via this login.
        /// </summary>
        public DateTime LastLoggedInUtc { get; set; }
    }
}
