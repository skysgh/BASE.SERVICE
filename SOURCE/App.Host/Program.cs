using System.Reflection;
using App.Modules.Sys.Shared.Models.Implementations;
using App.Modules.Sys.Substrate.Contracts.Initialisation;

namespace App.Host
{
    /// <summary>
    /// Entry class.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var log = StartupLog.Instance;

            // =================================================================
            // PHASE 1: MODULE DISCOVERY & SERVICE REGISTRATION
            // =================================================================
            log.Log(Microsoft.Extensions.Logging.LogLevel.Information, 
                "=== INITIALIZING APPLICATION ===");
            
            // ONE CALL - discovers all modules recursively
            var initializer = new EntryPointModuleAssemblyInitialiser();
            var configBag = initializer.Initialize(
                Assembly.GetEntryAssembly()!,
                builder.Configuration,
                log);
            
            // Register discovered services
            foreach (var service in configBag.LocalServices)
            {
                builder.Services.Add(service);
            }

            // Add ASP.NET Core services
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // =================================================================
            // PHASE 2: SERVICE CONFIGURERS (Credentials)
            // =================================================================
            foreach (var configurer in configBag.ServiceConfigurers)
            {
                configurer.ConfigureService(app.Services, builder.Configuration, log);
            }

            // Configure pipeline
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.MapControllers();

            app.Run();
        }
    }
}
