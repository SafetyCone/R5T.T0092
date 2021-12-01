using System;

using R5T.T0060;

using R5T.T0092;


namespace System
{
    public static class IPredicateProviderExtensions
    {
        public static Func<T, bool> SelectIdentifiedByIdentity<T>(this IPredicateProvider _,
            Guid identity)
            where T : IIdentified
        {
            bool Output(T identified) => identified.Identity == identity;
            return Output;
        }
    }
}