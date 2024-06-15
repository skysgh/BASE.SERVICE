﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Base.Shared.Models.CacheItems
{
    /// <summary>
    /// Cacheable information about a Tenancy
    /// </summary>
    public class TenancyInfo
    {
        /// <summary>
        /// The id/subdomain identifying 
        /// the tenancy.
        /// </summary>
        public string? TenancyId { get; set; }

        /// <summary>
        /// A list of environment 
        /// identities associated with this tenancy.
        /// </summary>
        public string[]? AssociatedEnvNames { get; set; }
    }
}
