using App.Base.Shared.Attributes;


namespace App.Base.Shared.Models.ConfigurationSettings
{
    /// <summary>
    /// Configuration Settings for configuring the GeoIPService
    /// </summary>
    public class GeoIPServiceConfigurationSettings
    {
        /// <summary>
        /// The Service Credentials key
        /// <para>
        /// Make sure this kind of secrets are not gotten from AppSettings.
        /// </para>
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationGeoIPServiceClientId)]
        public string? ClientId
        {
            get; set;
        }

        /// <summary>
        /// The Service Credentials Secret
        /// <para>
        /// Make sure this kind of secrets are not gotten from AppSettings.
        /// </para>
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.KeyVault)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationGeoIPServiceClientSecret)]
        public string? Secret
        {
            get; set;
        }


        /// <summary>
        /// Url of the remote service.
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationGeoIPServiceBaseUri)]
        public string? BaseUri
        {
            get; set;
        }


        /// <summary>
        /// Misc configuration that can be used to configure the service.
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationGeoIPServiceClientMiscConfig)]
        public string? MiscConfig
        {
            get; set;
        }
    }
}
