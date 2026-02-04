using System.Reflection;
using App.Modules.Sys.Shared.Models.Implementations;
using App.Modules.Sys.Shared.Models.Enums;
using App.Modules.Sys.Initialisation.Implementation;

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
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var log = StartupLog.Instance;

            // =================================================================
            // PHASE 1: MODULE DISCOVERY & SERVICE REGISTRATION
            // =================================================================
            log.Log(TraceLevel.Info, 
                "=== INITIALIZING APPLICATION ===");
            
            // ONE CALL - discovers all modules recursively AND calls DoBeforeBuild
            var configBag = 
                EntryPointModuleAssemblyInitialiser
                .Initialize(
                Assembly.GetEntryAssembly()!,
                builder.Configuration,
                log,
                builder.Services);  // ← Pass services for DoBeforeBuild!
            
            // Register discovered services
            foreach (var service in configBag.LocalServices)
            {
                builder.Services.Add(service);
            }

            // Register discovered cache objects
            foreach (var cacheObject in configBag.CacheObjects)
            {
                builder.Services.Add(cacheObject);
            }

            // =================================================================
            // WORKSPACE ROUTING - Cache-backed, database-driven
            // =================================================================
            // Required for HttpContext (i.e., IContextService)
            builder.Services.AddHttpContextAccessor();
            
            // Bootstrap: Registry must be registered before cache objects are discovered
            // Cannot rely on auto-discovery here due to chicken-and-egg problem
            builder.Services.AddSingleton<App.Modules.Sys.Shared.Services.Caching.ICacheObjectRegistryService, 
                                         App.Modules.Sys.Infrastructure.Caching.Implementations.CacheObjectRegistryService>();
            
            // Workspace validation service (cache-backed)
            builder.Services.AddWorkspaceValidation();  // CRITICAL: Must be before AddWorkspaceRouting!
            
            builder.Services.AddWorkspaceRouting();     // Routing middleware

            // =================================================================
            // API DOCUMENTATION - MODULE-BASED (VERSIONED)
            // =================================================================
            builder.Services.AddControllers();
            // Each logical module registers its own documentation
            builder.Services.AddApiDocumentation(moduleName: "sys", apiVersion: "v1");
            // Future modules:
            // builder.Services.AddApiDocumentation(moduleName: "social", apiVersion: "v1");
            // builder.Services.AddApiDocumentation(moduleName: "work", apiVersion: "v1");

            var app = builder.Build();

            // =================================================================
            // PHASE 1.5: MODULE INITIALIZERS - DoAfterBuild
            // =================================================================
            log.Log(TraceLevel.Info, 
                $"=== CALLING {configBag.ModuleInitializers.Count} INITIALIZERS (AfterBuild) ===");
            
            foreach (var initializer in configBag.ModuleInitializers)
            {
                try
                {
                    log.Log(TraceLevel.Debug, 
                        $"Calling DoAfterBuild on {initializer.GetType().Name}");
                    initializer.DoAfterBuild(app.Services);
                }
                catch (Exception ex)
                {
                    log.Log(TraceLevel.Error, 
                        $"ERROR in {initializer.GetType().Name}.DoAfterBuild: {ex.Message}");
                }
            }

            // =================================================================
            // PRELOAD WORKSPACE CACHE
            // =================================================================
            await app.PreloadWorkspaceCacheAsync();

            // =================================================================
            // PHASE 2: SERVICE CONFIGURERS (Credentials)
            // =================================================================
            // Run configurers in order (DatabaseConfigurer runs first with Order=0)
            var orderedConfigurers = configBag.ServiceConfigurers
                .OrderBy(c => c.Order)
                .ToList();
            
            log.Log(TraceLevel.Info, 
                $"Running {orderedConfigurers.Count} service configurers in order...");
            
            foreach (var configurer in orderedConfigurers)
            {
                log.Log(TraceLevel.Debug, 
                    $"Configuring: {configurer.ServiceName} (Order: {configurer.Order})");
                configurer.Configure(app.Services);
            }

            // =================================================================
            // API DOCUMENTATION MIDDLEWARE - MODULE-BASED
            // =================================================================
            if (app.Environment.IsDevelopment())
            {
                // STANDARD machine-readable (tools):
                //   OpenAPI JSON: /openapi/sys-v1.json
                //   Swagger JSON: /swagger/sys-v1/swagger.json
                // CUSTOM human-readable:
                //   Swagger UI: /documentation/apis/swagger/sys/v1/ (per-module)
                //   Scalar UI: /scalar (single UI for all modules with dropdown)
                // CONVENIENCE redirects:
                //   /documentation/apis/scalar/sys/v1/ → /scalar
                //   /documentation/apis/scalar/ → /scalar
                
                // Per-module documentation
                app.UseApiDocumentation(
                    moduleName: "sys",
                    apiVersion: "v1",
                    enableOpenApi: true,
                    enableSwagger: true,
                    enableScalar: true);  // Creates redirect
                
                // Future modules:
                // app.UseApiDocumentation(moduleName: "social", apiVersion: "v1");
                
                // Single Scalar UI for ALL modules (must be called AFTER all UseApiDocumentation)
                app.UseScalarForAllModules();  // At /scalar with module dropdown + redirects
            }

            // =================================================================
            // MIDDLEWARE PIPELINE
            // =================================================================
            app.UseWorkspaceRouting();  // ? BEFORE UseRouting!
            
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseStaticFiles();
            app.MapControllers();

            app.Run();
        }
    }
}
