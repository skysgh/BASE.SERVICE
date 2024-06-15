﻿namespace App.Base.Shared.Models.Entities
{
    using System;
    using App.Base.Shared.Factories;


    /// <summary>
    /// <para>
    /// Note that this Base runs parrallel to
    /// <see cref="TenantFKAuditedRecordStatedTimestampedCustomIdEntityBase{TId}"/>
    /// (inheritence line is based on Id Type).
    /// </para>
    /// 
    /// <para>
    /// Does Not Implements:
    /// <list type="bullet">
    /// </list>
    /// </para>
    /// 
    /// <para>
    /// Does Implement:
    /// <list type="bullet">
    /// <item><see cref="IHasGuidId"/></item>,
    /// <item><see cref="IHasTimestampRecordStateInRecordAuditability"/></item>,
    /// </list>
    /// </para>    
    /// 
    /// </summary>
    public abstract class TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase :
        UntenantedAuditedRecordStatedTimestampedCustIdEntityBase<Guid>,
        IHasTenantFK,
        IHasGuidId
        
    {
        /// <summary>
        /// Gets or sets the FK of the Tenancy this mutable model belongs to.
        /// </summary>
        public virtual Guid TenantFK { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        protected TenantFKAuditedRecordStatedTimestampedGuidIdEntityBase()
        {
            this.Id = GuidFactory.NewGuid();
        }


    }


}