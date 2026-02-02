using App.Modules.Sys.Application.Initialisation;
using App.Modules.Sys.Initialisation;
using App.Modules.Sys.Initialisation.Implementation.Base;

namespace App.Host._Initialisation
{
    public class AppHostAssemblyInitialiser : ModuleAssemblyInitialiserBase
    {
        public AppHostAssemblyInitialiser():base()
        {
            this.Initialisers.Push(ApplicationModuleAssemblyInitialiser);
        }
    }
}
