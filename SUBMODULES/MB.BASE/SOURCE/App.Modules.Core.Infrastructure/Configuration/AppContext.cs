namespace App.Base.Infrastructure.Configuration
{
    /// <summary>
    /// Context information about the 
    /// <see cref="AppInformation"/>.
    /// </summary>
    public class AppContext
    {

        // =========|=========|=========|=========|=========|=========|
        // =========|=========|=========|=========|=========|=========|
        /// <summary>
        /// Gets the name of the machine under which process
        /// is running.
        /// </summary>
        public string? MachineName;

        // =========|=========|=========|=========|=========|=========|
        // =========|=========|=========|=========|=========|=========|

        /// <summary>
        /// Gets the Network Domain Name under which the base process thread User is running.
        /// </summary>
        public string? ThreadUserDomainName;
        /// <summary>
        /// Gets the base process thread User is running.
        /// </summary>
        public string? ThreadUserName;

        // =========|=========|=========|=========|=========|=========|
        // =========|=========|=========|=========|=========|=========|
        /// <summary>
        /// Gets the name of the OS Platform
        /// Example: <c>Win32NT</c>
        /// </summary>
        public string? OSPlatform;

        /// <summary>
        /// Gets the version of the OS platform.
        /// Example: <c>10.0.19044.0</c>
        /// </summary>
        public Version? OSPlatformVersion;

        /// <summary>
        /// Gets the version of the OS platform.
        /// Example: <c>Microsoft Windows NT 10.0.19044.0</c>
        /// </summary>
        public string? OSPlatformVersionString;

        // =========|=========|=========|=========|=========|=========|
        // =========|=========|=========|=========|=========|=========|


        /// <summary>
        /// Chip Architecture Enumeration
        /// </summary>
        public System.Runtime.InteropServices.Architecture Architecture;

        // =========|=========|=========|=========|=========|=========|
        // =========|=========|=========|=========|=========|=========|

        /// <summary>
        /// Version of .NET
        /// </summary>
        public Version? FrameworkVersion;

        /// <summary>
        /// Displayable Title description of the Framwork
        /// <para>
        /// eg: "NetCoreApp, Version=v2.1"
        /// </para>
        /// </summary>
        public string? FrameworkTitle;
        // =========|=========|=========|=========|=========|=========|
        // =========|=========|=========|=========|=========|=========|



        /// <summary>
        /// Gets the Path to the EXE of the Process.
        /// <para>
        /// eg: <c>C:\NOSYNC\REPOS\BASE.Jump.Dev\SOURCE\App.Service.Host\bin\debug\net7.0\App.Service.Host.exe</c> 
        /// (notice similarity to <see cref="BaseDirectoryPath"/>)
        /// </para>
        /// </summary>
        public string? ProcessPath;

        /// <summary>
        /// Gets whether the Process is running as 64 bit.
        /// </summary>
        public bool ProcessIs64;

        // =========|=========|=========|=========|=========|=========|
        // =========|=========|=========|=========|=========|=========|




        /// <summary>
        /// Gets the Name of the Application
        /// <para>
        /// Example: <c>App.Service.Host.Web.Dev</c> (The *Host* Assembly)
        /// </para>
        /// </summary>
        public string? ApplicationName
        {
            get
            {
                return _applicationName;
            }
            set
            {
                //if (!string.IsNullOrEmpty(_applicationName))
                //{
                //    new DevelopmentException($"Resetting {nameof(ApplicationName)}.");
                //}
                _applicationName = value;
            }
        }
        private string? _applicationName;


        /// <summary>
        /// Name of the Environment.
        /// <para>
        /// Example: <c>Development</c>
        /// </para>
        /// </summary>
        public string? ApplicationEnvironmentName
        {
            get
            {
                return _applicationEnvironmentName;
            }
            set
            {
                //if (!string.IsNullOrEmpty(_environmentName))
                //{
                //    new DevelopmentException($"Resetting {nameof(EnvironmentName)}.");
                //}
                _applicationEnvironmentName = value;
            }
        }
        private string? _applicationEnvironmentName;

        // =========|=========|=========|=========|=========|=========|
        // =========|=========|=========|=========|=========|=========|

        /// <summary>
        /// Gets the ContentRootPath
        /// <para>
        /// Example: <c>"C:\NOSYNC\REPOS\BASE.Jump.Dev\SOURCE\App.Service.Host" (No slash on end).</c>
        /// </para>
        /// </summary>
        public string? ContentRootPath
        {
            get
            {
                return _contentRootPath;
            }
            set
            {
                if (!string.IsNullOrEmpty(_contentRootPath))
                {
                    throw new Exception($"Resetting {nameof(ContentRootPath)}.");
                }
                _contentRootPath = value;
            }
        }
        private string? _contentRootPath;


        /// <summary>
        /// Gets the Directory used to resolve
        /// default DLLs.
        /// <para>
        /// ContentRoot + bin + Debug + frameworktypeandVersion. 
        /// </para>
        /// <para>
        /// Example: <c>"//C:\NOSYNC\REPOS\BASE.Jump.Dev\SOURCE\App.Service.Host\bin\Debug\net7.0"</c> (Slash removed from end)
        /// </para>
        /// </summary>
        public string? BaseDirectoryPath
        {
            get => _BaseDirectoryPath;
            set
            {
                if (!string.IsNullOrEmpty(_BaseDirectoryPath))
                {
                    throw new Exception($"Resetting {nameof(BaseDirectoryPath)}.");
                }
                _BaseDirectoryPath = value;
            }
        }
        private string? _BaseDirectoryPath;


        /// <summary>
        /// Gets the Directory used to resolve
        /// default DLLs.
        /// <para>
        /// Example: <c>"C:\NOSYNC\REPOS\BASE.Jump.Dev\SOURCE\App.Service.Host\wwwroot"</c> (no slash on end)
        /// and wwwroot is updatable via Configuration, later.
        /// </para>
        /// </summary>
        public string? WebRootPath
        {
            get => _webRootPath;
            set
            {
                //It's ok to update (eg: from 'wwwroot' to 'www')
                _webRootPath = value;
            }
        }
        private string? _webRootPath;

        /// <summary>
        /// 
        /// <para>
        /// Example: <c>"C:\REPOS\BASE.Jump.Dev\SOURCE\App.Service.Host\MODULES"</c>
        /// </para>
        /// </summary>
        public string? ModuleDirectoryPath
        {
            get => _moduleDirectoryPath;
            set
            {
                _moduleDirectoryPath = value;
            }
        }
        private string? _moduleDirectoryPath;

        /// <summary>
        /// 
        /// <para>
        /// Example: <c>"C:\REPOS\BASE.Jump.Dev\SOURCE\App.Service.Host\COMPONENTS"</c>
        /// </para>
        /// </summary>
        public string? ComponentDirectoryPath
        {
            get => _componentDirectoryPath;
            set
            {
                _componentDirectoryPath = value;
            }
        }
        private string? _componentDirectoryPath;

    }
}