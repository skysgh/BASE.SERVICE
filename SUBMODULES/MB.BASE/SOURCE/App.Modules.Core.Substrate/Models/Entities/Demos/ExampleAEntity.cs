using App.Base.Shared.Attributes;
using App.Base.Shared.Factories;

namespace App.Base.Shared.Models.Entities.Demos
{
    /// <summary>
    /// Internal Simple (no Children) Demo Entity
    /// <para>
    /// Used to demonstrate correct mapping
    /// from an internal entity to an external
    /// entity, using an ObjectMapping 
    /// implementing
    /// <c></c>
    /// </para>
    /// </summary>
    [ForDemoOnly]
    public class ExampleAEntity :
        IHasGuidId,
        IHasRecordState,
        IHasEnabled,
        IHasTitle,
        IHasDescription
    {
        /// <inheritdoc/>
        public Guid Id { get; set; } = GuidFactory.NewGuid();

        /// <inheritdoc/>
        public RecordPersistenceState RecordState { get; set; }

        /// <inheritdoc/>
        public bool Enabled {get;set;}

        /// <inheritdoc/>
        public string Title { get; set; }

        /// <inheritdoc/>
        public string Description { get; set; }
    }
}
