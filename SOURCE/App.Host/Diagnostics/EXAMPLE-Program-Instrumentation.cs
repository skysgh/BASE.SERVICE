// ============================================================================
// EXAMPLE: How to Instrument Program.cs with Startup Diagnostics
// ============================================================================
// This file shows where to add startup logging calls in Program.cs.
// Copy these patterns into your actual Program.cs file.
//
// NOTE: This is a documentation file only - not compiled.
// Add to .csproj:
// <ItemGroup>
//   <Compile Remove="Diagnostics\EXAMPLE-*.cs" />
// </ItemGroup>

#if FALSE  // Prevent compilation - this is documentation only

using App.Host.Diagnostics;
using App.Modules.Sys.Application.Interfaces.APIs.Services;
using App.Modules.Sys.Shared.Constants;

namespace App.Host;

/// <summary>
/// Example showing startup logging instrumentation patterns.
/// </summary>
internal static class ProgramStartupLoggingExample
{
    public static async Task MainExample(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var log = StartupLog.Instance;

        // =================================================================
        // PHASE 1: MODULE DISCOVERY & SERVICE REGISTRATION
        // =================================================================
        using (var scope = StartupDiagnosticsHelper.BeginScope(
            log,
            "Module Discovery",
            "Discovering and initializing logical modules",
            StartupTags.Module, StartupTags.Initialization))
        {
            var configBag = EntryPointModuleAssemblyInitialiser.Initialize(
                Assembly.GetEntryAssembly()!,
                builder.Configuration,
                log,
                builder.Services);

            scope.AddMetadata("ModulesFound", configBag.ModuleInitializers.Count);
            scope.AddMetadata("ServicesRegistered", configBag.LocalServices.Count);
        }

        // Log each discovered service
        StartupDiagnosticsHelper.LogStartup(
            log,
            TraceLevel.Info,
            $"Registering {configBag.LocalServices.Count} services",
            null,
            StartupTags.Service);

        foreach (var service in configBag.LocalServices)
        {
            // Log interface→implementation mapping
            StartupDiagnosticsHelper.LogStartup(
                log,
                TraceLevel.Debug,
                $"{service.ServiceType.Name} → {service.ImplementationType?.Name ?? "Factory"}",
                $"Lifetime: {service.Lifetime}",
                StartupTags.Service);
        }

        // =================================================================
        // MIDDLEWARE REGISTRATION
        // =================================================================
        using (var scope = StartupDiagnosticsHelper.BeginScope(
            log,
            "Workspace Routing Middleware",
            "Registering workspace resolution middleware",
            StartupTags.Middleware))
        {
            builder.Services.AddWorkspaceRouting();
            scope.AddMetadata("Type", "WorkspaceResolutionMiddleware");
        }

        // =================================================================
        // BUILD APP & INITIALIZE DIAGNOSTICS SERVICE
        // =================================================================
        var app = builder.Build();

        // CRITICAL: Initialize diagnostics helper with service instance
        var diagnosticsService = app.Services.GetRequiredService<IStartupDiagnosticsService>();
        StartupDiagnosticsHelper.Initialize(diagnosticsService);

        // Now all subsequent logs will be captured by diagnostics service!

        // =================================================================
        // DATABASE INITIALIZATION (with connection test)
        // =================================================================
        using (var scope = StartupDiagnosticsHelper.BeginScope(
            log,
            "Database Connection Test",
            "Testing connection to sysmdl schema",
            "Database/Connection", StartupTags.DbContext))
        {
            try
            {
                // Test connection
                var dbContext = app.Services.GetRequiredService<ModuleDbContext>();
                var canConnect = await dbContext.Database.CanConnectAsync();

                scope.AddMetadata("Success", canConnect);
                scope.AddMetadata("Provider", "SQL Server");
                scope.AddMetadata("Schema", "sysmdl");

                if (!canConnect)
                {
                    throw new InvalidOperationException("Cannot connect to database");
                }
            }
            catch (Exception ex)
            {
                scope.SetException(ex);
                throw;
            }
        }

        // =================================================================
        // MIGRATION HISTORY
        // =================================================================
        using (var scope = StartupDiagnosticsHelper.BeginScope(
            log,
            "Migration History",
            "Querying applied EF Core migrations",
            "Database/Migration", StartupTags.Migration))
        {
            var dbContext = app.Services.GetRequiredService<ModuleDbContext>();
            var appliedMigrations = await dbContext.Database.GetAppliedMigrationsAsync();

            scope.AddMetadata("MigrationsApplied", appliedMigrations.Count());

            foreach (var migration in appliedMigrations)
            {
                StartupDiagnosticsHelper.LogStartup(
                    log,
                    TraceLevel.Debug,
                    migration,
                    "Applied migration",
                    "Database/Migration", StartupTags.Migration);
            }
        }

        // =================================================================
        // STARTUP COMPLETE
        // =================================================================
        StartupDiagnosticsHelper.LogStartup(
            log,
            TraceLevel.Info,
            "Startup Complete",
            $"Application initialized in {diagnosticsService.GetTotalStartupDuration().TotalSeconds:F2}s",
            StartupTags.Initialization);

        // =================================================================
        // API ENDPOINT AVAILABLE
        // =================================================================
        // Diagnostics now available at:
        //   GET /api/sys/v1/diagnostics/startup
        //   GET /api/sys/v1/diagnostics/startup/summary

        app.Run();
    }
}

#endif // Documentation only

