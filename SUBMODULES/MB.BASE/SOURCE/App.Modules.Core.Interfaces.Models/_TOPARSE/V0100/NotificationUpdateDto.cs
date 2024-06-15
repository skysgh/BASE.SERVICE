using App.Base.Shared.Models;
using App.Base.Shared.Models.Entities;
using System;


namespace App.Modules.Core.Interface.Models._TOPARSE.V0100
{
    /// <summary>
    /// An API DTO of a
    /// <see cref="Notification"/>
    /// </summary>
    public class NotificationUpdateDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId
    {
        /// <inheritdoc/>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// Status whether Message has been read.
        /// </summary>
        public virtual bool Read { get; set; }


        /// <summary>
        /// The time the client read the message (if offline, will be different than time server records it).
        /// </summary>
        public virtual DateTime DateTimeModifiedUtc { get; set; }

    }
}
