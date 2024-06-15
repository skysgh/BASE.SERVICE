
namespace App.Base.Shared.Models.Messages
{
    using System;
    using App.Base.Shared.Factories;

    /// <summary>
    /// A record of a configuration step that was undertaken.
    /// For use by support personnel remotely reviewing configuration.
    /// </summary>
    public class ConfigurationStepRecord : IHasGuidId, IHasTitleAndDescription
    {
        Guid _id;
        ConfigurationStepType _type = ConfigurationStepType.Undefined;
        private string _description = string.Empty;
        private string _title = string.Empty;
        private DateTimeOffset _dateTime= DateTimeOffset.MinValue;
        private ConfigurationStepStatus _status = ConfigurationStepStatus.Undefined;


        /// <summary>
        /// <para>
        /// Note than although this model is not persisted in 
        /// a datastore, an Id is still required, as it is expressed
        /// via OData.
        /// </para>
        /// </summary>
        public ConfigurationStepRecord()
        {
            this.Id = GuidFactory.NewGuid();
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="dateTime"></param>
        public ConfigurationStepRecord(DateTimeOffset dateTime)
        {
            DateTime = dateTime;
        }

        /// <summary>
        /// The Record Identifier
        /// </summary>
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// The <see cref="ConfigurationStepType"/>
        /// as to whether about setting up Security, Peformance, etc.
        /// </summary>
        public ConfigurationStepType Type { get => _type; set => _type = value; }

        /// <summary>
        /// The <see cref="ConfigurationStepStatus"/>
        /// as to whether it was successful or not.
        /// </summary>
        public ConfigurationStepStatus Status { get => _status; set => _status = value; }

        /// <summary>
        /// The <see cref="DateTimeOffset"/> 
        /// at which the event occurred.
        /// </summary>
        public DateTimeOffset DateTime { get => _dateTime; set => _dateTime = value; }
        /// <summary>
        /// The display Title of the configuration step event.
        /// </summary>
        public string Title { get => _title; set => _title = value; }
        /// <summary>
        /// The display Description of the configuration step event.
        /// </summary>
        public string Description { get => _description; set => _description = value; }
    }
}
