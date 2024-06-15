//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Tasks;

//namespace App.Base.Infrastructure.ExtensionMethods
//{
//    /// <summary>
//    /// Extension
//    /// </summary>
//    public static class AssembliesExtensionMethods
//    {

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="assemblies"></param>
//        /// <param name="type"></param>
//        /// <returns></returns>
//        public static IEnumerable<Type> GetInstantiableTypesImplementing(
//            this Assembly[] assemblies,
//            Type type)
//        {
//            var results = new List<Type>();
//            foreach (var assembly in assemblies)
//            {
//                var resultSet = assembly.GetInstantiableTypesImplementing(type);
//                if (resultSet == null)
//                {
//                    continue;
//                }
//                results.AddRange(resultSet);
//            }
//            return results;
//        }

//    }
//}
