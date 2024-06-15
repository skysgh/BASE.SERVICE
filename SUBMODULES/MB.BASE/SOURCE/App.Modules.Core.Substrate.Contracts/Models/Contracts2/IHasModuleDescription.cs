using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.Base.Shared.Models;

namespace App.Modules.Core.Shared.Contracts.Models.Contracts
{
    /// <summary>
    /// Contract for a Configuration object that 
    /// describes a Module.
    /// <para>
    /// Examples of use by Implementations thereof
    /// are for the configuration of Swagger
    /// at startup.
    /// </para>
    /// </summary>
    public interface IHasModuleDescription : IHasTitleAndDescription
    {
        /// <summary>
        /// Url to Organisation
        /// responsible for Module.
        /// </summary>
        string OrganisationUrl { get; }

        /// <summary>
        /// Url to Contact Information 
        /// regarding Organisation
        /// responsible for Module.
        /// </summary>
        string ContactUrl { get; }

    }
}
