using System;

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

        public static void SetIdentityIfNotSet(this IMutableIdentified mutableIdentified,
            Random random)
        {
            mutableIdentified.SetIdentityIfNotSet(() => Instances.GuidOperator.NewSeededGuid(random));
        }
    }
}
