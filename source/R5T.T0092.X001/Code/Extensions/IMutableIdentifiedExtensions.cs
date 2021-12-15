using System;
using System.Collections.Generic;

using R5T.T0092;

using Instances = R5T.T0092.X001.Instances;


namespace System
{
    public static class IMutableIdentifiedExtensions
    {
        public static void SetIdentityIfNotSet(this IMutableIdentified mutableIdentified,
            Func<Guid> newIdentityConstructor)
        {
            var isIdentityUnset = mutableIdentified.IsIdentityUnset();
            if (isIdentityUnset)
            {
                mutableIdentified.Identity = newIdentityConstructor();
            }
        }

        public static void SetIdentityIfNotSet(this IMutableIdentified mutableIdentified)
        {
            mutableIdentified.SetIdentityIfNotSet(Instances.GuidOperator.NewGuid);
        }

        public static void SetIdentitiesIfNotSet<T>(this IEnumerable<T> mutableIdentifieds)
            where T : IMutableIdentified
        {
            foreach (var mutableIdentified in mutableIdentifieds)
            {
                mutableIdentified.SetIdentityIfNotSet();
            }
        }

        public static void SetIdentityIfNotSet(this IMutableIdentified mutableIdentified,
            Random random)
        {
            mutableIdentified.SetIdentityIfNotSet(() => Instances.GuidOperator.NewSeededGuid(random));
        }
    }
}
