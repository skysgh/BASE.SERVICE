namespace App.Modules.Core.Interface.Models._TOPARSE.V0100
{
    using App.Base.Shared.Models;
    using App.Base.Shared.Models.Entities;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// DTO for a <see cref="TenantedNavigationRoute"/>
    /// <para>
    /// </para>
    /// </summary>
    public class TenantedNavigationRouteDto : /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */  IHasGuidId
    {
        private ICollection<TenantedNavigationRouteDto> _children = new TenantedNavigationRouteDto[0];
        private Guid _id = Guid.Empty;
        private bool _enabled = false;
        private Guid _ownerFK = Guid.Empty;
        private string? text;
        private string? _description;
        private int _displayOrderHint = 0;
        private string? _displayStyleHint;

        /// <summary>
        /// The Id of TenantedNavigationRoute
        /// </summary>
        public Guid Id
        {
            get => _id; set => _id = value;
        }
        /// <summary>
        /// Whether the TenantedNavigationRoute is enabled or not.
        /// </summary>
        public bool Enabled { get => _enabled; set => _enabled = value; }


        /// <summary>
        /// The Guid of the TenantedNavigationRoute Owner
        /// </summary>
        public Guid OwnerFK
        {
            get => _ownerFK; set => _ownerFK = value;
        }

        /// <summary>
        /// The TenantedNavigationRoute text
        /// </summary>
        public string Text
        {
            get => text ?? string.Empty; set => text = value;
        }

        /// <summary>
        /// The TenantedNavigationRoute description.
        /// </summary>
        public string Description
        {
            get => _description ?? string.Empty; set => _description = value;
        }
        /// <summary>
        /// Hint as to Display Order
        /// </summary>
        public int DisplayOrderHint
        {
            get => _displayOrderHint; set => _displayOrderHint = value;
        }
        /// <summary>
        /// Hint as to Display Style
        /// </summary>
        public string DisplayStyleHint
        {
            get => _displayStyleHint ?? string.Empty; set => _displayStyleHint = value;
        }

        /// <summary>
        /// Collection of child <see cref="TenantedNavigationRouteDto"/>
        /// </summary>
        public ICollection<TenantedNavigationRouteDto> Chilldren
        {
            get
            {
                return _children ?? (_children = new Collection<TenantedNavigationRouteDto>());
            }
        }

    }
}