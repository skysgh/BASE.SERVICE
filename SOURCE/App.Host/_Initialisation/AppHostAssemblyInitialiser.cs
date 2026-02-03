// ============================================================================
// OBSOLETE - COMMENTED OUT (Lessons Learnt)
// ============================================================================
// This class was part of an instance-based initializer chain pattern that was
// never fully connected to the actual bootstrapping process.
//
// PROBLEM:
// - EntryPointModuleAssemblyInitialiser.Initialize() is STATIC
// - It never instantiates these ModuleAssemblyInitialiser classes
// - Services and ServiceProvider properties were never set
// - DoBeforeBuild/DoAfterBuild were never called
//
// CURRENT APPROACH:
// Phase 1: Static discovery via EntryPointModuleAssemblyInitialiser
// Phase 2: IServiceConfigurer pattern (with Order property for sequencing)
//
// See: Service-Configurer-Order-Guide.md for current pattern
// ============================================================================

/*
using App.Modules.Sys.Application.Initialisation;
using App.Modules.Sys.Initialisation;
using App.Modules.Sys.Initialisation.Implementation.Base;

namespace App.Host._Initialisation
{
    /// <summary>
    /// OBSOLETE: Instance-based initializer (never connected to bootstrap).
    /// </summary>
    public class AppHostAssemblyInitialiser : ModuleAssemblyInitialiserBase
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AppHostAssemblyInitialiser():base()
        {
            // This was trying to push ApplicationModuleAssemblyInitialiser
            // but the chain was never invoked!
            // this.Initialisers.Push(new ApplicationModuleAssemblyInitialiser());
        }
    }
}
*/

