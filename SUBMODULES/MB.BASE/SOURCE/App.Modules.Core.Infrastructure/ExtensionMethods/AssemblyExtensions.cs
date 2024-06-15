﻿// Extensions are always put in root namespace
// for maximum usability from elsewhere:

namespace App
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Extension methods to the Assembly type.
    /// </summary>
    public static class AssemblyExtensions
    {

        /// <summary>
        /// Get other Assemblies 
        /// in same Logical Module.
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="assemblies"></param>
        /// <returns></returns>
        /// <c>DevelopmentException</c>
        public static IEnumerable<Assembly> GetRelatedAppModuleAssemblies(
            this Assembly assembly, 
            IEnumerable<Assembly> assemblies)
        {

            if (!GetAppModuleName(assembly, out string? result, out string? prefix))
            {
                throw new Exception("Assembly given has no discernible prefix.");
            }

            var tmp = assemblies.ToArray();

            return tmp
                .Where(a => a.GetName()!.Name!.StartsWith(prefix!))
                .OrderByDescending(x => x.GetReferencedAssemblies().Length);
        }

        /// <summary>
        /// Gets the Module Name from the Assembly
        /// (presumably a Presentation Assembly 
        /// containing the Controller Action found
        /// via the Route)
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static string? GetAppModuleName (this Assembly assembly) {


            GetAppModuleName(assembly, out string? result, out string? prefix);

            return result;

        }

        /// <summary>
        /// Gets the Module Name from the Assembly
        /// (presumably a Presentation Assembly 
        /// containing the Controller Action found
        /// via the Route)
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="result"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        public static bool GetAppModuleName(this Assembly assembly, out string? result, out string? prefix)
        {
            return assembly.GetName().GetAppModuleName(out result, out prefix);
        }


        /// <summary>
        /// Finds types in an assembly that have the specified Contract.
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        [System.Diagnostics.DebuggerHidden]
        public static IEnumerable<Type>? GetInstantiableTypesImplementing(this Assembly assembly, Type type)
        {
            // Return only types that are subsets of the given type (or are same)
            // that are instantiable, and not generic.

            //An Alternate way of investigating whether it is an interface or not
            //is typeof(HasDo).GetInterfaces().Any(x=>x == typeof(IHasDo)).Dump("Implements Interface");
            try
            {
                return assembly.GetTypes().Where(x =>
                    type.IsAssignableFrom(x)
                    &&
                    !x.IsAbstract
                    &&
                    !x.IsInterface
                    &&
                    !x.IsGenericTypeDefinition
                );
            }
            catch (ReflectionTypeLoadException)
            {
                //No biggie
                System.Diagnostics.Trace.TraceInformation($"Running 'GetInstantiableTypesImplementing', could not find {type.Name}");
            }
            return null;
        }

        /// <summary>
        /// Determine whether Assembly contains type.
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool ContainsType(this Assembly assembly, Type type)
        {

            return (type.Assembly == assembly);
        }
    }
}