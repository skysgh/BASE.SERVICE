namespace App.Base.Shared.Models.Messages
{
    using App.Base.Shared.Factories;

    /// <summary>
    /// A model to hold the results of a 
    /// self assessement of integration, etc.
    /// Again, this is to provide to support
    /// stakeholders a way of ensuring the system
    /// is up and running.
    /// </summary>
    public class ConfigurationTestStepSummary : IHasGuidId
    {
        private string title=String.Empty;
        private string description=String.Empty;

        /// <summary>
        /// Note than although this model is not persisted in 
        /// a datastore, an Id is still required, as it is expressed
        /// via OData.
        /// </summary>
        public ConfigurationTestStepSummary()
        {
            this.Id = GuidFactory.NewGuid();
        }
        /// <summary>
        /// TODO: Describe
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// TODO: Describe
        /// </summary>
        public ConfigurationStepType Type { get; set; }

        /// <summary>
        /// TODO: Describe
        /// </summary>
        public ConfigurationStepStatus Status { get; set; }

        /// <summary>
        /// TODO: Describe
        /// </summary>
        public DateTimeOffset DateTime { get; set; }
        /// <summary>
        /// TODO: Describe
        /// </summary>
        public string Title { get => title; set => title = value ?? String.Empty; }
        /// <summary>
        /// TODO: Describe
        /// </summary>
        public string Description { get => description; set => description = value??String.Empty; }
    }
}
