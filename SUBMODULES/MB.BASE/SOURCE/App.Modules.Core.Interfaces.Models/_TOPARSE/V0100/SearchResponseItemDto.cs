namespace App.Modules.Core.Interface.Models._TOPARSE.V0100
{
    /// <summary>
    /// API DTO for internal <see cref="SearchResponseItem"/>
    /// </summary>
    public class SearchResponseItemDto  /* Avoid CONTRACTS on DTOs: UNDUE RISK OF INADVERTENT CHANGE */  //: IHasGuidId, IHasRecordState
    {
        /// <summary>
        /// The Source record's identity (guid, int, combination, etc.)
        /// </summary>
        public virtual string? SourceTypeKey { get; set; }

        /// <summary>
        /// An textual identifier (key) for the type of record returned (Person, Address, etc.)
        /// </summary>
        //[Key]
        public virtual string? SourceIdentifier { get; set; }

        /// <summary>
        /// The display title summarising the search response item.
        /// </summary>
        public virtual string? Title { get; set; }

        /// <summary>
        /// The description of the Search Response Item
        /// </summary>
        public virtual string? Description { get; set; }
        /// <summary>
        /// The image to show beside the displayed item.
        /// </summary>
        public virtual string? ImageUrl { get; set; }
    }
}