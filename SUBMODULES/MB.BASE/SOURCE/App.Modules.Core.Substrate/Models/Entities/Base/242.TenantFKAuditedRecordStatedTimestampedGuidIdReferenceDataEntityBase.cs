namespace App.Base.Shared.Models.Entities.Base
{
    using System;
    using App.Base.Shared.Factories;
    using App.Base.Shared.Models.Contracts;


    /// <summary>
    /// Base abstract class for Mutable 
    /// Reference data. 
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
    /// <item><see cref="IHasReferenceDataOfGenericIdEnabledTitleDescImgUrlDisplayHints{TId}"/></item>,
    /// </list>
    /// </para>    
    /// 
    /// </summary>
    public abstract class TenantFKAuditedRecordStatedTimestampedGuidIdReferenceDataEntityBase :
        UntenantedAuditedRecordStatedTimestampedGuidIdReferenceDataEntityBase,
        IHasTenantFK
        
    {

        /// <summary>
        /// Gets or sets the FK of the Tenancy this mutable model belongs to.
        /// </summary>
        public virtual Guid TenantFK { get; set; }


        /// <summary>
        /// Initializes a new instance of the <see cref="TenantFKAuditedRecordStatedTimestampedGuidIdReferenceDataEntityBase"/> class.
        /// </summary>
        protected TenantFKAuditedRecordStatedTimestampedGuidIdReferenceDataEntityBase()
        {
        }
    }
}