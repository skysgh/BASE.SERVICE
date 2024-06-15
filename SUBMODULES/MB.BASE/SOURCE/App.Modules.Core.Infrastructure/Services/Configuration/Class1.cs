using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Modules.Core.Infrastructure.NewFolder.Services.Configuration
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class ValidationConstraintConfiguration
    {
        public Permitted Permitted { get; } = new Permitted();
        public Excluded Excluded { get; } = new Excluded();

    }

    public class Permitted
    {
        public List<string> AssemblyNames { get; } = new List<string>();
        public List<string> Namespaces { get; } = new List<string>();
    }
    public class Excluded
    {
        public List<string> AssemblyNames { get; } = new List<string>();
        public List<string> Namespaces { get; } = new List<string>();
        public List<string> Words { get; } = new List<string>();
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member

}
