using System;
using System.Collections.Generic;
using System.Linq;

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
        public static IEnumerable<Guid> GetIdentities(this IEnumerable<IIdentified> identifieds)
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
    }
}
