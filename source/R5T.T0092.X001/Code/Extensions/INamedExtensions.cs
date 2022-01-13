using System;
using System.Collections.Generic;
using System.Linq;

using R5T.Magyar;

using R5T.T0092;

using Instances = R5T.T0092.X001.Instances;


namespace System
{
    public static class INamedExtensions
    {
        public static IEnumerable<string> GetAllNames<T>(this IEnumerable<T> nameds)
            where T : INamed
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

        public static Dictionary<string, T[]> GetDuplicateNameSets<T>(this IEnumerable<T> nameds,
            Func<string, string> nameTransformer)
            where T : INamed
        {
            var output = nameds
                .Select(x => (TransformedName: nameTransformer(x.Name), Value: x))
                .WhereDuplicates(x => x.TransformedName)
                .ToDictionary(
                    x => x.Key,
                    x => x.Select(y => y.Value).ToArray());

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


namespace System.Linq
{
    public static class INamedExtensions
    {
        public static T[] FindArrayByName<T>(this IEnumerable<T> nameds, string name)
            where T : INamed
        {
            var output = nameds.FindArray(Instances.Predicate.NameIs<T>(name));
            return output;
        }

        public static WasFound<T> FindSingleByName<T>(this IEnumerable<T> nameds, string name)
            where T : INamed
        {
            var output = nameds.FindSingle(Instances.Predicate.NameIs<T>(name));
            return output;
        }

        public static Dictionary<string, T> ToDictionaryByName<T>(this IEnumerable<T> nameds)
            where T : INamed
        {
            var output = nameds.ToDictionary(Instances.Selector.SelectName<T>());
            return output;
        }

        public static Dictionary<string, T[]> ToDictionaryOfArraysByName<T>(this IEnumerable<T> nameds)
            where T: INamed
        {
            var output = nameds.ToDictionaryOfArrays(Instances.Selector.SelectName<T>());
            return output;
        }

        public static void VerifyDistinctNames<T>(this IEnumerable<T> nameds)
            where T: INamed
        {
            nameds.GetAllNames().VerifyDistinct();
        }
    }
}
