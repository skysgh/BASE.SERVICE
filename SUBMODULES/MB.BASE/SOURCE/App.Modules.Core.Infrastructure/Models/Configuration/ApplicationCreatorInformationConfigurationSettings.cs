namespace App.Base.Shared.Models.ConfigurationSettings
{
    using System;
    using App.Base.Shared.Attributes;

    /// <summary>
    /// An immutable host configuration object 
    /// describing the Creator of the application
    /// (distinct from the Distributor/Resellers) in many commercial cases.
    /// <para>
    /// An Immutable Host Settings configuration object
    /// retrieved from the Host Settings.
    /// </para>
    /// </summary>
    /// <seealso cref="App.Base.Shared.Models.IHasName" />
    /// <seealso cref="App.Base.Shared.Models.IHasDescription" />
    public class ApplicationCreatorInformationConfigurationSettings : IHostSettingsBasedConfigurationObject,  IHasName, IHasDescription
    {

        Guid _id = Guid.Empty;
        string _name = string.Empty;
        string _description = string.Empty;
        string _siteUrl = string.Empty;
        string _contactUrl = string.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationCreatorInformationConfigurationSettings"/> class.
        /// </summary>
        public ApplicationCreatorInformationConfigurationSettings()
        {
        }

        /// <summary>
        /// OData always needs an Id.
        /// <para>
        /// It can be another field, but too much bother
        /// to configure it...
        /// </para>
        /// </summary>
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        /// <summary>
        /// The name of the Application Creator
        /// <para>
        /// (eg: "Acme Something, Inc.")
        /// </para>
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Constants.ConfigurationKeys.AppCoreApplicationCreatorName)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        /// <summary>
        /// The Description of the System Creator.
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Constants.ConfigurationKeys.AppCoreApplicationCreatorDescription)]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        /// <summary>
        /// The Url for the System Creator's general Website.
        /// <para>
        /// It's generally not the product page.
        /// </para>
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Constants.ConfigurationKeys.AppCoreApplicationCreatorSiteUrl)]
        public string SiteUrl
        {
            get { return _siteUrl; }
            set { _siteUrl = value; }
        }

        /// <summary>
        /// The Url for the System Creator's ContactUs page.
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSetting)]
        [Alias(Constants.ConfigurationKeys.AppCoreApplicationCreatorContactUrl)]
        public string ContactUrl
        {
            get { return _contactUrl; }
            set { _contactUrl = value; }
        }
    }
}