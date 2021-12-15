using System;
using System.Collections.Generic;

using R5T.Magyar;

using R5T.T0092;

using Instances = R5T.T0092.X001.Instances;


namespace System.Linq
{
    public static class INamedIdentifiedExtensions
    {
        public static WasFound<T> FindSingleByNameAndIdentity<T>(this IEnumerable<T> namedIdentifieds,
            T namedIdentified)
            where T : INamedIdentified
        {
            var output = namedIdentifieds.FindSingle(Instances.Predicate.SameNameAndIdentity(namedIdentified));
            return output;
        }

        public static WasFound<T> FindSingleByNameAndIdentity<T>(this IEnumerable<T> namedIdentifieds,
            Guid identity, string name)
            where T : INamedIdentified
        {
            var output = namedIdentifieds.FindSingle(Instances.Predicate.NameAndIdentityIs<T>(identity, name));
            return output;
        }

        public static WasFound<T> FindSingleByIdentityOrThenName<T>(this IEnumerable<T> namedIdentifieds, T namedIdentified)
            where T : INamedIdentified
        {
            var wasFoundByIdentity = namedIdentifieds.FindSingleByIdentity(namedIdentified.Identity);
            if (wasFoundByIdentity)
            {
                return wasFoundByIdentity;
            }

            var wasFoundByName = namedIdentifieds.FindSingleByName(namedIdentified.Name);
            return wasFoundByName;
        }
    }
}


namespace R5T.T0092.X001
{
    public static class INamedIdentifiedExtensions
    {
        public static string ToTokenizedRepresentation(this INamedIdentified namedIdentified,
            string tokenSeparator)
        {
            var representation = $"{namedIdentified.Name}{tokenSeparator}{namedIdentified.Identity}";
            return representation;
        }

        public static string ToTokenizedRepresentation(this INamedIdentified namedIdentified)
        {
            var output = namedIdentified.ToTokenizedRepresentation(Strings.PipeSpace);
            return output;
        }

        public static string ToStringRepresentation(this INamedIdentified namedIdentified)
        {
            var representation = $"{namedIdentified.Name} ({namedIdentified.Identity})";
            return representation;
        }
    }
}
