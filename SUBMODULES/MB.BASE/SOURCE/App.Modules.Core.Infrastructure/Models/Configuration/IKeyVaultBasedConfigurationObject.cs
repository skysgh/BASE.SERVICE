using App.Base.Shared.Models.Configuration;

namespace App.Base.Shared.Models.ConfigurationSettings
{
    /// <summary>
    /// Contract for objects that will be passed through the 
    /// KeyVault based Config Factory
    /// </summary>
    public interface IKeyVaultBasedConfigurationObject : IConfigurationObject
    {
    }
}
