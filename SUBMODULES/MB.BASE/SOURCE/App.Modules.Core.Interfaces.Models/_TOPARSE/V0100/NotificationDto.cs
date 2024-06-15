using App.Base.Shared.Models;

namespace App.Modules.Core.Interface.Models._TOPARSE.V0100
{
    using System;
    using App.Base.Shared.Models.Entities;
    /// <summary>
    /// API DTO for system 
    /// <see cref="Notification"/>
    /// </summary>

    public class NotificationDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */  : IHasGuidId, IHasTenantFK //, IHasRecordState
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public NotificationDto()
        {
            Id = Guid.NewGuid();
        }

        /// <summary>
        /// Get/Set type of Notification
        /// </summary>
        public virtual NotificationType Type { get; set; }

        /// <summary>
        /// Get/Set level of Notification
        /// </summary>
        public virtual TraceLevel Level { get; set; }

        /// <summary>
        /// Get/Set source of notification
        /// </summary>
        public virtual string? From { get; set; }

        /// <summary>
        /// Get/Set image for notification
        /// </summary>
        public virtual string? ImageUrl { get; set; }

        /// <summary>
        /// TODO: Improve documentation
        /// </summary>
        public virtual string? Class { get; set; }

        /// <summary>
        /// Get/Set when Notification was created
        /// </summary>
        public virtual DateTime DateTimeCreatedUtc { get; set; }

        /// <summary>
        /// Get/Set when Notification was read by recipient
        /// </summary>
        public virtual DateTime? DateTimeReadUtc { get; set; }

        /// <summary>
        ///     Status whether Message has been read.
        /// </summary>
        public virtual bool IsRead
        {
            get => DateTimeReadUtc.HasValue;
            set
            {
                if (value == false)
                {
                    DateTimeReadUtc = null;
                }
                else
                {
                    if (!DateTimeReadUtc.HasValue)
                    {
                        DateTimeReadUtc = DateTime.UtcNow;
                    }
                }
            }
        }

        /// <summary>
        ///     1-100% complete.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Text of notification
        /// </summary>
        public string? Text { get; set; }

        /// <summary>
        /// Get storage record Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Get FK of storage Tenant. 
        /// </summary>
        public Guid TenantFK { get; set; }
    }
}