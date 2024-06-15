using App.Base.Shared.Attributes;
using App.Base.Shared.Constants;
using App.Modules.Core.Shared.Constants;

namespace App.Base.Shared.Models.Configuration
{
    /// <summary>
    /// Configuration object to host
    /// all Base App Settings.
    /// </summary>
    [Alias(AppConfiguration.Name)]
    public class AppConfiguration : IConfigurationObject
    {

        /// <summary>
        /// Singleton Instance
        /// <para>
        ///  TODO: HACK.
        /// </para>
        /// </summary>
        public static AppConfiguration Instance 
            { get; private set; } 
            = new AppConfiguration();


        /// <summary>
        /// Configuration Section Name.
        /// </summary>
        public const string Name = DefaultConstants.App;

        /// <summary>
        /// Configuration Section Path.
        /// </summary>
        public const string Path = Name;

        /// <summary>
        /// Child collection of hosting Settings
        /// </summary>
        public Hosting Hosting { get; set; } = new Hosting();

        /// <summary>
        /// Child collection of Environment Settings
        /// </summary>
        public Environments Environments { get; set; } = new Environments();

        /// <summary>
        /// Child collection of Media Routing Settings
        /// </summary>
        public Medias Medias { get; set; } = new Medias();

        /// <summary>
        /// Child collection of Media Routing Settings
        /// </summary>
        public Components Components { get; set; } = new Components();

        /// <summary>
        /// Child collection of System Capability Settings
        /// </summary>
        public Capabilities Capabilities { get; set; } = new Capabilities();


        /// <summary>
        /// Call *after* Binding to
        /// fill in defaults if missing.
        /// </summary>
        public void Initialise()
        {
            if (this.Environments.Defaults.Length == 0)
            {
                this.Environments.Defaults =
                [
                    "bt","dt","st","ut","ct","tr","pp",this.Environments.ProductionEnvironmentId
                ];
            }
            if (this.Medias.Defaults.Length == 0) {
                this.Medias.Defaults = [
                    this.Medias.WWWMediaId, "media"
                ];
            }
        }
    }

    /// <summary>
    /// Configuration object
    /// for detailing Hosting Settings.
    /// <para>
    /// A sub object of 
    /// <see cref="Directories"/>
    /// </para>
    /// </summary>
    [Alias(Hosting.Name)]
    public class Hosting : IConfigurationObject
    {
        /// <summary>
        /// Configuration Section Name.
        /// </summary>
        public const string Name = "Hosting";

        /// <summary>
        /// Configuration Section Path.
        /// </summary>
        public const string Path = AppConfiguration.Path + Name;

        /// <summary>
        /// TEST
        /// </summary>
        public string Something { get; set; }
    }

    /// <summary>
    /// Configuration Object 
    /// for detailing AppConfiguration
    /// specific to Environments
    /// </summary>
    [Alias(Environments.Name)]
    public class Environments : IConfigurationObject
    {
        /// <summary>
        /// Configuration Section Name.
        /// </summary>
        public const string Name = $"{DefaultConstants.Environment}s";

        /// <summary>
        /// Configuration Section Path.
        /// </summary>
        public const string Path = AppConfiguration.Path + Name;
        /// <summary>
        /// TEST
        /// </summary>
        public string Something { get; set; }


        /// <summary>
        /// The Environment Id for Production.
        /// </summary>
        public string ProductionEnvironmentId { get; set; } = "prod";

        /// <summary>
        /// Strip off <see cref="ProductionEnvironmentId"/>
        /// if it is present.
        /// </summary>
        public bool StripProdEnvironmentId { get; set; } = true;

        /// <summary>
        /// List of default environment Ids to parse
        /// for in Host subdomains
        /// (eg: <c>'st.www.sometenant.someservice.tld'</c>)
        /// </summary>
        public string[] Defaults { get => defaults; set => defaults = value; }
        private string[] defaults = [];

    }

    /// <summary>
    /// Collection of settings regarding
    /// routing media
    /// </summary>
    [Alias(Medias.Name)]
    public class Medias : IConfigurationObject
    {

        /// <summary>
        /// Configuration Section Name.
        /// </summary>
        public const string Name = "Medias";

        /// <summary>
        /// Configuration Section Path.
        /// </summary>
        public const string Path = AppConfiguration.Path + Name;

        /// <summary>
        /// TEST
        /// </summary>
        public string Something { get; set; }


        /// <summary>
        /// The Environment Id for Production.
        /// </summary>
        public string WWWMediaId { get; set; } = "www";

        /// <summary>
        /// Strip off <see cref="WWWMediaId"/>
        /// if it is present.
        /// </summary>
        public bool EnforceWWWMediaId { get; set; } = false;


        /// <summary>
        /// List of default SubDomains to resolve 
        /// Host settings for (eg: 'www.sometenancy.someservice.tld')
        /// </summary>
        public string[] Defaults { get => defaults; set => defaults = value; }
        private string[] defaults = [];
    }


    /// <summary>
    /// Collection of settings regarding
    /// component handling
    /// </summary>
    [Alias(Medias.Name)]
    public class Components : IConfigurationObject
    {
        /// <summary>
        /// Configuration Section Name.
        /// </summary>
        public const string Name = $"{DefaultConstants.Component}s";

        /// <summary>
        /// Configuration Section Path.
        /// </summary>
        public const string Path = AppConfiguration.Path + Name;

        /// <summary>
        /// The Prefix (ie, "App.") used for all application 
        /// Assemblies, to more easily distinguish them from 
        /// 3rd party or "System."
        /// libraries.
        /// </summary>
        public string AppPrefix { get; set; } = AppConstants.AssemblyPrefix;


        ///// <summary>
        ///// Method to set AppPrefix
        ///// </summary>
        ///// <param name="value"></param>
        //public void SetAppPrefix(string value) { AppPrefix = value; }


        /// <summary>
        /// Array of Keys of Components to load by reflection
        /// </summary>
        public string[] ComponentKeys { get; set; } = [];

        /// <summary>
        /// Array of Modules to load by reflection
        /// </summary>
        public string[] ModuleKeys { get; set; } = [];


        /// <summary>
        /// Sub Directories associated to this application
        /// where to look for Components
        /// </summary>
        public Directories Directories
        {
            get
            {
                return _directories ??= new Directories();
            }

        }
        Directories _directories;
    }

    /// <summary>
    /// Collection of Settings regarding
    /// System Capabilities
    /// </summary>
    [Alias(Capabilities.Name)]
    public class Capabilities : IConfigurationObject
    {
        /// <summary>
        /// Configuration Section Name.
        /// </summary>
        public const string Name = DefaultConstants.Capabilities;

        /// <summary>
        /// Configuration Section Path.
        /// </summary>
        public const string Path = AppConfiguration.Path + Name;

        /// <summary>
        /// TEST
        /// </summary>
        public string Something { get; set; }
        /// <summary>
        /// Collection of Multi
        /// </summary>
        public MultiTenancies MultiTenancies { get; set; }
            = new MultiTenancies();

    }

    /// <summary>
    /// 
    /// </summary>
    [Alias(MultiTenancies.Name)]
    public class MultiTenancies : IConfigurationObject, IHasEnabled
    {
        /// <summary>
        /// Configuration Section Name.
        /// </summary>
        public const string Name = $"Multi{DefaultConstants.Tenancies}";

        /// <summary>
        /// Configuration Section Path.
        /// </summary>
        public const string Path = Capabilities.Path + Name;

        /// <inheritdoc/>
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// The Id of the default/fallback tenant 
        /// </summary>
        public string DefaultTenantId { get; set; } = DefaultConstants.Default;
    }





    ///// <summary>
    ///// Collection of settings specific to 
    ///// Module loading
    ///// </summary>
    //[Alias(Modules.Name)]
    //public class Modules : IConfigurationObject, IHasEnabled
    //{
    //    /// <summary>
    //    /// Configuration Section Name.
    //    /// </summary>
    //    public const string Name = DefaultConstants.Modules;

    //    /// <summary>
    //    /// Configuration Section Name.
    //    /// </summary>
    //    public const string Path = Capabilities.Path + Name;

    //    /// <inheritdoc/>
    //    public bool Enabled { get; set; }



    //}


    /// <summary>
    /// 
    /// </summary>
    [Alias(Directories.Name)]
    public class Directories : IConfigurationObject
    {


        /// <summary>
        /// Configuration Section Name.
        /// </summary>
        public const string Name = $"{DefaultConstants.Directories}";

        /// <summary>
        /// Configuration Section Path.
        /// </summary>
        public const string Path = Components.Path + Name;


        /// <summary>
        /// Method to set the Root property 
        /// (as it doesn't have a <c>set</c>
        /// operation so that <c>IConfiguration</c> 
        /// doesn't try to set it when reading from 
        /// <c>app.config</c>
        /// <para>
        /// Invoked from 
        /// <c>AppStartupBeforeBuildApp</c>
        /// </para>
        /// </summary>
        public void SetContentRoot(string contentRootPath)
        {
            ContentRoot = contentRootPath;
        }

        /// <summary>
        /// Root Content Directory of Website.
        /// <para>
        /// Note that it only has a public <c>get</c>, and not a <c>set</c>
        /// so that <c>IConfiguration</c>
        /// doesn't try to set the value while it's filling in the other 
        /// public properties.
        /// </para>
        /// <para>
        /// Set by invoking the 
        /// <see cref="SetContentRoot"/> 
        /// method. 
        /// </para>
        /// </summary>
        public string ContentRoot { get; private set; } = string.Empty;


        /// <summary>
        /// The MODULES Directory ("MODULES")
        /// </summary>
        public string ModulesSubDirectory { get; set; } = DefaultConstants.Module.SimplePluralise().ToUpper();

        /// <summary>
        /// The MODULES Directory ("COMPONENTS")
        /// </summary>
        public string ComponentsSubDirectory { get; set; } = DefaultConstants.Component.SimplePluralise().ToUpper();
    }
}
