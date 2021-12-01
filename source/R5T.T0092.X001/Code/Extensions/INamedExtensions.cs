using System;
using System.Collections.Generic;
using System.Linq;

using R5T.T0092;


namespace System
{
    public static class INamedExtensions
    {
        public static IEnumerable<string> GetAllNames(this IEnumerable<INamed> nameds)
        {
            var output = nameds
                .Select(xNamed => xNamed.Name)
                ;

            return output;
        }

        public static IEnumerable<string> GetAllDistinctNamesInAlphabeticalOrder(this IEnumerable<INamed> nameds)
        {
            var output = nameds.GetAllNames()
                .Distinct()
                .OrderAlphabetically()
                ;

            return output;
        }

        public static IEnumerable<string> GetDuplicateNamesInAlphabeticalOrder(this IEnumerable<INamed> nameds)
        {
            var output = nameds.GetAllNames()
                .WhereDuplicates(xName => xName)
                .Select(xGroup => xGroup.Key)
                .OrderAlphabetically()
                ;

            return output;
        }

        public static IEnumerable<IGrouping<string, T>> WhereDuplicateNames<T>(this IEnumerable<T> nameds)
            where T : INamed
        {
            var output = nameds
                .WhereDuplicates(xNamed => xNamed.Name)
                ;

            return output;
        }
    }
}
