using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0092;
using R5T.T0098;


namespace System
{
    public static class IOperationExtensions
    {
        /// <summary>
        /// If the namespaced type name is not ignored, get the set of duplicate extension method bases by type name.
        /// </summary>
        public static Dictionary<string, T[]> GetUnignoredDuplicateNameSets<T>(this IOperation _,
            T[] nameds,
            string[] ignoredNameds,
            Func<string, string> nameTransformer)
            where T : INamed
        {
            var unignoredExtensionMethodBases = _.GetUnignoredNameds(
                nameds,
                ignoredNameds);

            // Determine any new duplicate extension method base type names (not namespaced type names).
            var duplicateTypeNameSets = unignoredExtensionMethodBases.GetDuplicateNameSets(
                nameTransformer);

            return duplicateTypeNameSets;
        }

        public static IEnumerable<T> GetUnignoredNameds<T>(this IOperation _,
            T[] extensionMethodBases,
            string[] ignoredNames)
            where T : INamed
        {
            var ignoredNamesHash = new HashSet<string>(ignoredNames);

            var unignoredRepositoryExtensionMethodBases = extensionMethodBases
                .ExceptWhere(x => ignoredNamesHash.Contains(x.Name))
                ;

            return unignoredRepositoryExtensionMethodBases;
        }
    }
}
