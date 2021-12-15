using System;
using System.Collections.Generic;

using R5T.T0060;
using R5T.T0092;


namespace System
{
    public static class IPredicateExtensions
    {
        public static Func<T, bool> IdentityIs<T>(this IPredicate _, Guid identity)
            where T : IIdentified
        {
            return identified => identified.Identity == identity;
        }

        public static Func<T, bool> IdentityIs<T>(this IPredicate _,
            IEnumerable<Guid> identities,
            Dictionary<Guid, bool> results)
            where T : IIdentified
        {
            var uniqueIdentitiesHash = new HashSet<Guid>(identities);

            bool Output(T mapping)
            {
                var identity = mapping.Identity;

                var contains = uniqueIdentitiesHash.Contains(identity);
                if (contains)
                {
                    results.Add(identity, true);
                }
                else
                {
                    results.Add(identity, false);
                }

                return contains;
            }

            return Output;
        }

        public static Func<T, bool> NameIs<T>(this IPredicate _, string name)
            where T : INamed
        {
            return named => named.Name == name;
        }

        public static Func<T, bool> NameIs<T>(this IPredicate _,
            IEnumerable<string> names,
            Dictionary<string, bool> results)
            where T : INamed
        {
            var uniqueNamesHash = new HashSet<string>(names);

            bool Output(T mapping)
            {
                var name = mapping.Name;

                var contains = uniqueNamesHash.Contains(name);
                if (contains)
                {
                    results.Add(name, true);
                }
                else
                {
                    results.Add(name, false);
                }

                return contains;
            }

            return Output;
        }

        public static Func<T, bool> NameAndIdentityIs<T>(this IPredicate _,
            Guid identity, string name)
            where T : INamedIdentified
        {
            return namedIdentified => namedIdentified.Identity == identity && namedIdentified.Name == name;
        }

        public static Func<T, bool> SameNameAndIdentity<T>(this IPredicate _,
            T namedIdentified)
            where T : INamedIdentified
        {
            return _.NameAndIdentityIs<T>(namedIdentified.Identity, namedIdentified.Name);
        }
    }
}
