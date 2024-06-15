﻿namespace App.Base.Shared.Models.Entities
{
    using System;

    /// <summary>
    /// System entity (not exposed to the system's exterior) for
    /// a Setting associated to a Principal.
    /// <para>
    /// TODO: Describe purpose better
    /// </para>
    /// </summary>
    public class PrincipalSetting : SettingBase
    {
        /// <summary>
        /// Id of the Principal/User who this Setting is for.
        /// </summary>
        public virtual Guid UserFK { get; set; }
    }
}