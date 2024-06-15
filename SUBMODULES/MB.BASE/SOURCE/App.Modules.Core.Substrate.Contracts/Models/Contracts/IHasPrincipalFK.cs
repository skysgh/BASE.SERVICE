﻿namespace App.Base.Shared.Models
{
    using App.Base.Shared.Models.Entities;
    using System;

    /// <summary>
    /// Contract for associating a 
    /// <c>Principal</c> to 
    /// a model.
    /// <para>
    /// There is no equivalent
    /// <c>IHasPrincipalFKNullable</c>
    /// </para>
    /// </summary>
    public interface IHasPrincipalFK
    {
        /// <summary>
        /// The FK of the <c>Principal</c>
        /// </summary>
        Guid PrincipalFK { get; set; }
    }
}