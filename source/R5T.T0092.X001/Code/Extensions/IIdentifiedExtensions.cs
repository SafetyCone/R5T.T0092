using System;
using System.Collections.Generic;
using System.Linq;

using R5T.Magyar;

using R5T.T0092;

using Instances = R5T.T0092.X001.Instances;


namespace System
{
    public static class IIdentifiedExtensions
    {
        public static bool IsIdentitySet(this IIdentified identified)
        {
            var output = Instances.GuidOperator.IsSet(identified.Identity);
            return output;
        }

        public static bool IsIdentityUnset(this IIdentified identified)
        {
            var output = Instances.GuidOperator.IsUnset(identified.Identity);
            return output;
        }

        public static void VerifyIsIdentitySet(this IIdentified identified)
        {
            var isIdentitySet = identified.IsIdentitySet();
            if (!isIdentitySet)
            {
                throw new Exception("Identity is not set.");
            }
        }
    }
}


namespace System.Linq
{
    public static class IIdentifiedExtensions
    {
        public static Dictionary<Guid, WasFound<T>> FindDictionaryByIdentity<T>(this IEnumerable<T> items,
            IEnumerable<Guid> localIdentities)
            where T : IIdentified
        {
            var identitiesHash = new HashSet<Guid>(localIdentities);

            var foundItems = items
                .Where(x => identitiesHash.Contains(x.Identity))
                .Now();

            var notFoundIdentities = identitiesHash.Except(foundItems
                .Select(x => x.Identity));

            var output = foundItems
                .Select(x => (x.Identity, WasFound.Found(x)))
                .Concat(notFoundIdentities
                    .Select(x => (x, WasFound.NotFound<T>())))
                .ToDictionary(
                    x => x.Item1,
                    x => x.Item2);

            return output;
        }

        public static WasFound<T> FindSingleByIdentity<T>(this IEnumerable<T> items, Guid identity)
            where T : IIdentified
        {
            var output = items.FindSingle(Instances.Predicate.IdentityIs<T>(identity));
            return output;
        }

        public static IEnumerable<Guid> GetIdentities<T>(this IEnumerable<T> identifieds)
            where T : IIdentified
        {
            var output = identifieds
                .Select(x => x.Identity)
                ;

            return output;
        }

        public static Dictionary<Guid, T> ToDictionaryByIdentity<T>(this IEnumerable<T> identifieds)
            where T : IIdentified
        {
            var output = identifieds.ToDictionary(
                x => x.Identity);

            return output;
        }

        public static void VerifyAllIdentitiesAreSet<T>(this IEnumerable<T> identifieds)
            where T : IIdentified
        {
            foreach (var identified in identifieds)
            {
                identified.VerifyIsIdentitySet();
            }
        }

        public static void VerifyDistinctByIdentity<T>(this IEnumerable<T> identifieds)
           where T : IIdentified
        {
            identifieds.GetIdentities().VerifyDistinct();
        }

        public static IEnumerable<T> WhereIdentityIs<T>(this IEnumerable<T> identifieds, Guid identity)
            where T : IIdentified
        {
            var output = identifieds.Where(Instances.Predicate.IdentityIs<T>(identity));
            return output;
        }
    }
}
