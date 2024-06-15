using App.Base.Infrastructure.Configuration;
using App.Base.Shared.Models.Messages;
using App.Modules.Core.Infrastructure.NewFolder.Services;
using App.Modules.Core.Shared.Models.Messages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Modules.Core.Infrastructure.NewFolder.Services.Implementations
{
    /// <summary>
    /// Implementation of the Startup Logging 
    /// Service. 
    /// <para>
    /// It's so it can persist messages both in the 
    /// <see cref="AppInitialisationLog"/> instance, as well 
    /// as the logging environment if it is available.
    /// </para>
    /// </summary>
    public class StartupLoggingService : IStartupLoggingService
    {

        private ILogger? _logger;

        /// <summary>
        /// Constructor
        /// </summary>
        public StartupLoggingService()
        {

        }
        /// <inheritdoc/>
        public void SetLogger(ILogger appLogger)
        {
            _logger = appLogger;
        }

        /// <inheritdoc/>
        public void LogMessage(LogLevel logLevel, string message)
        {
            AppInformation.StartupLog.Journal.Add(message);
            _logger!.Log(logLevel, message);
        }
    }
}
