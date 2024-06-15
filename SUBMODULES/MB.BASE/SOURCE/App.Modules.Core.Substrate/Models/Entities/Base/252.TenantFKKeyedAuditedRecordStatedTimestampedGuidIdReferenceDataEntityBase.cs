namespace App.Base.Shared.Models.Entities.Base
{
    /// <summary>
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
    /// <item><see cref="IHasKeyGenericValue{T}"/></item>
    /// </list>
    /// </para>    
    /// 
    /// </summary>
    public abstract class TenantFKKeyedAuditedRecordStatedTimestampedGuidIdReferenceDataKeyGenValueEntityBase
        : UntenantedAuditedRecordStatedTimestampedGuidIdReferenceDataKeyGenValueEntityBase<Guid>, 
   IHasTenantFK
    {

        /// <summary>
        /// Gets or sets the FK of the Tenancy this mutable model belongs to.
        /// </summary>
        public virtual Guid TenantFK { get; set; }

    }
}