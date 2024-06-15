using System;
using System.Collections.Generic;

namespace App.Modules.Core.Interface.Models._TOPARSE.V0100
{
    using App.Base.Shared.Models;
    using App.Base.Shared.Models.Entities;
    using System.Collections.ObjectModel;

    /// <summary>
    /// API DTO for system 
    /// <see cref="NavigationRoute"/>
    /// </summary>
    public class NavigationRouteDto : /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */  IHasGuidId
    {
        /// <summary>
        /// Id
        /// </summary>
        public Guid Id
        {
            get; set;
        }

        /// <summary>
        /// Route enabled
        /// </summary>
        public bool Enabled
        {
            get; set;
        }

        /// <summary>
        /// Nullable FK of parent Route.
        /// </summary>
        public Guid OwnerFK
        {
            get; set;
        }


        /// <summary>
        /// Displayable Text on Route button
        /// </summary>
        public string? Text
        {
            get; set;
        }

        /// <summary>
        /// Displayable Description
        /// </summary>
        public string? Description
        {
            get; set;
        }
        /// <summary>
        /// Display Order hint
        /// </summary>
        public int DisplayOrderHint
        {
            get; set;
        }

        /// <summary>
        /// Display style hint
        /// </summary>
        public string? DisplayStyleHint
        {
            get; set;
        }

        /// <summary>
        /// Child/Nested routes
        /// </summary>
        public ICollection<NavigationRouteDto> Chilldren
        {
            get
            {
                return _children ?? (_children = new Collection<NavigationRouteDto>());
            }
        }

        private ICollection<NavigationRouteDto> _children = new Collection<NavigationRouteDto>();
    }
}
