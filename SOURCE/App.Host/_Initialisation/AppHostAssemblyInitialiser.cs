using App.Modules.Base.Application.Initialisation;
using App.Modules.Base.Initialisation;
using App.Modules.Base.Initialisation.Implementation.Base;

namespace App.Host._Initialisation
{
    public class AppHostAssemblyInitialiser : ModuleAssemblyIntialiserBase
    {
        public AppHostAssemblyInitialiser():base()
        {
            this.Initialisers.Push(ApplicationModuleAssemblyInitialiser);
        }
    }
}
