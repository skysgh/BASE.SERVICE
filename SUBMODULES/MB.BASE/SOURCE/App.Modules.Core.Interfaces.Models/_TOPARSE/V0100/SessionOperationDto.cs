using App.Base.Shared.Models;

namespace App.Modules.Core.Interface.Models._TOPARSE.V0100
{
    using App.Base.Shared.Models.Entities;
    using System;

    /// <summary>
    /// DTO for <see cref="SessionOperation"/>
    /// </summary>
    public class SessionOperationDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */ : IHasGuidId
    {
        private string? clientIp;
        private string? url;
        private string? resourceTenantKey;
        private string? controllerName;
        private string? actionName;
        private string? actionArguments;
        private DateTimeOffset beginDateTimeUtc = DateTimeOffset.MinValue;
        private DateTimeOffset endDateTimeUtc = DateTimeOffset.MinValue;
        private TimeSpan duration = TimeSpan.Zero;
        private string? responseCode;
        private Guid id = Guid.Empty;

        /// <summary>
        /// The IP of the client
        /// </summary>
        public virtual string ClientIp { get => clientIp ?? string.Empty; set => clientIp = value; }
        /// <summary>
        /// The Url requested
        /// </summary>
        public virtual string Url { get => url ?? string.Empty; set => url = value; }
        /// <summary>
        /// The Resource's Tenant Key
        /// </summary>
        public virtual string ResourceTenantKey { get => resourceTenantKey ?? string.Empty; set => resourceTenantKey = value; }
        /// <summary>
        /// The request's Controller
        /// </summary>
        public virtual string ControllerName { get => controllerName ?? string.Empty; set => controllerName = value; }
        /// <summary>
        /// The Request's Action
        /// </summary>
        public virtual string ActionName { get => actionName ?? string.Empty; set => actionName = value; }
        /// <summary>
        /// The Request's Action Arguments
        /// </summary>
        public virtual string ActionArguments { get => actionArguments ?? string.Empty; set => actionArguments = value; }
        /// <summary>
        /// The request's begin datetime
        /// </summary>
        public virtual DateTimeOffset BeginDateTimeUtc { get => beginDateTimeUtc; set => beginDateTimeUtc = value; }
        /// <summary>
        /// The request's end datetime
        /// </summary>
        public virtual DateTimeOffset EndDateTimeUtc { get => endDateTimeUtc; set => endDateTimeUtc = value; }
        /// <summary>
        /// The request's duration
        /// </summary>
        public virtual TimeSpan Duration { get => duration; set => duration = value; }
        /// <summary>
        /// The request's response code
        /// </summary>
        public virtual string ResponseCode { get => responseCode ?? string.Empty; set => responseCode = value; }

        /// <summary>
        /// The Id of the session operation record
        /// </summary>
        public virtual Guid Id { get => id; set => id = value; }

    }
}