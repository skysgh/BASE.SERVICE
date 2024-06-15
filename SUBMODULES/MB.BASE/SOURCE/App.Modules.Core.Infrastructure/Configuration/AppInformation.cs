using App.Base.Shared.Models.Messages;
using App.Modules.Core.Shared.Models.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Base.Infrastructure.Configuration
{
    /// <summary>
    /// Information about the application.
    /// </summary>
    public static class AppInformation
    {
        /// <summary>
        /// Context information of Application
        /// </summary>
        public static AppContext Context
        {
            get => _context;
        }
        private readonly static AppContext _context = new();

        /// <summary>
        /// Configuration of Application
        /// </summary>
        public static AppConfiguration Configuration
        {
            get => _configuration; 
        }
        private readonly static AppConfiguration _configuration = new();


        /// <summary>
        /// Log of initialisation steps.
        /// </summary>
        public static AppInitialisationLog StartupLog
        {
            get => _startupLog;
        }
        private readonly static AppInitialisationLog _startupLog = new();

        
    }
}