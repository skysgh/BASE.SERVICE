using App.Modules.Sys.Application.Domains.Diagnostics.Services;
using App.Modules.Sys.Application.Domains.Diagnostics.SmokeTesting.Models;
using App.Modules.Sys.Shared.Constants;
using App.Modules.Sys.Shared.Models.Enums;
using App.Modules.Sys.Shared.Models.Implementations;

namespace App.Host.Diagnostics;

/// <summary>
/// Helper to log startup events to both StartupLog and IStartupDiagnosticsApplicationService.
/// Bridges legacy StartupLog with new diagnostics Application service.
/// </summary>
internal static class StartupDiagnosticsHelper
{
    private static IStartupDiagnosticsApplicationService? _diagnosticsService;

    /// <summary>
    /// Initialize with diagnostics Application service instance.
    /// Call this after DI container is built.
    /// </summary>
    public static void Initialize(IStartupDiagnosticsApplicationService diagnosticsService)
    {
        _diagnosticsService = diagnosticsService;
    }

    /// <summary>
    /// Log a startup event to both StartupLog and diagnostics service.
    /// </summary>
    /// <param name="log">Legacy StartupLog instance.</param>
    /// <param name="level">Log level.</param>
    /// <param name="title">Entry title.</param>
    /// <param name="description">Optional description.</param>
    /// <param name="tags">Optional tags for categorization.</param>
#pragma warning disable IDE0060 // Remove unused parameter - kept for future use when Application Service exposes these methods
    public static void LogStartup(
        StartupLog log,
        TraceLevel level,
        string title,
        string? description = null,
        params string[] tags)
#pragma warning restore IDE0060
    {
        // Log to legacy StartupLog (for Output window)
        log.Log(level, title);
        if (!string.IsNullOrEmpty(description))
        {
            log.Log(level, $"  → {description}");
        }

        // Log to new diagnostics service (for API endpoint)
        // TODO: Application Service doesn't expose LogEntry - this is Infrastructure concern
        // if (_diagnosticsService != null)
        // {
        //     var entry = new StartupLogEntry();
        //     entry.Start(title, description, tags);
        //     entry.Level = level;
        //     entry.FinalizeEntry();
        //     _diagnosticsService.LogEntry(entry);
        // }
    }

    /// <summary>
    /// Begin a scoped startup operation (auto-logs on dispose).
    /// </summary>
    /// <param name="log">Legacy StartupLog instance.</param>
    /// <param name="title">Entry title.</param>
    /// <param name="description">Optional description.</param>
    /// <param name="tags">Optional tags.</param>
    /// <returns>Disposable scope.</returns>
    public static StartupScope BeginScope(
        StartupLog log,
        string title,
        string? description = null,
        params string[] tags)
    {
        return new StartupScope(log, _diagnosticsService, title, description, tags);
    }

    /// <summary>
    /// Disposable scope for automatic startup logging.
    /// </summary>
    public class StartupScope : IDisposable
    {
        private readonly StartupLog _log;
#pragma warning disable CS0649 // Field is never assigned - will be used when Application Service exposes scope methods
        private readonly IStartupLogScope? _diagnosticsScope;
#pragma warning restore CS0649
        private readonly string _title;
        private readonly DateTime _startTime;
        private bool _disposed;

        public StartupScope(
            StartupLog log,
#pragma warning disable IDE0060 // Remove unused parameter
            IStartupDiagnosticsApplicationService? diagnosticsService,
            string title,
            string? description,
            string[] tags)
#pragma warning restore IDE0060
        {
            _log = log;
            _title = title;
            _startTime = DateTime.UtcNow;

            // Log start to legacy log
            log.Log(TraceLevel.Info, $"Starting: {title}");

            // Begin scope in diagnostics service
            // TODO: Application Service doesn't expose BeginScope - this is Infrastructure concern
            // _diagnosticsScope = diagnosticsService?.BeginScope(title, description, tags);
        }

        /// <summary>
        /// Add metadata to the diagnostic entry.
        /// </summary>
        public void AddMetadata(string key, object value)
        {
            _diagnosticsScope?.AddMetadata(key, value);
        }

        /// <summary>
        /// Mark operation as failed.
        /// </summary>
        public void SetException(Exception ex)
        {
            _log.Log(TraceLevel.Error, $"Failed: {_title} - {ex.Message}");
            _diagnosticsScope?.SetException(ex);
        }

        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }

            var duration = DateTime.UtcNow - _startTime;
            _log.Log(TraceLevel.Info, $"Completed: {_title} ({duration.TotalMilliseconds:F0}ms)");

            _diagnosticsScope?.Dispose();
            _disposed = true;
        }
    }
}
