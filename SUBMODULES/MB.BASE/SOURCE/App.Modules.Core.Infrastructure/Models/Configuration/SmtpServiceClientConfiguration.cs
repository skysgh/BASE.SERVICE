﻿

namespace App.Base.Shared.Models.Configuration.AppHost
{
    using App.Base.Shared.Attributes;
    using App.Base.Shared.Models.ConfigurationSettings;

    /// <summary>
    /// A Service Configuration package for the SMTP service.
    /// </summary>
    public class SmtpServiceClientConfiguration: IHostSettingsBasedConfigurationObject
    {

        /// <summary>
        /// The SMTP account Key 
        /// </summary>
        // Make sure this kind of secrets are not gotten from AppSettings.
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationSmtpServiceClientId)]
        public string? Key
        {
            get; set;
        }

        /// <summary>
        /// The SMTP account secret.
        /// <para>
        /// Make sure this kind of secrets are not gotten from AppSettings.
        /// </para>
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.KeyVault)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationSmtpServiceClientSecret)]
        public string? Secret
        {
            get; set;
        }


        /// <summary>
        /// The url for web service
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationSmtpServiceBaseUri)]
        public string? BaseUri
        {
            get; set;
        }

        /// <summary>
        /// THe port to use. 
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationSmtpServicePort)]
        public int? Port
        {
            get; set;
        }

        /// <summary>
        /// Setup up the default source email adddress to use when sending out email.
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationSmtpServiceFrom)]
        public string? From
        {
            get; set;
        }

        /// <summary>
        /// Additional configuration of misc kind (handler expected to know how to decode/use)
        /// </summary>
        [ConfigurationSettingSource(ConfigurationSettingSource.SourceType.AppSettingsViaDeploymentPipeline)]
        [Alias(Constants.ConfigurationKeys.AppCoreIntegrationSmtpServiceClientMiscConfig)]
        public string? MiscConfig
        {
            get; set;
        }
    }
}