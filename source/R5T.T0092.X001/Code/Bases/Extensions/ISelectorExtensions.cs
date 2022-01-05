using System;

using R5T.T0060;
using R5T.T0092;


namespace System
{
    public static class ISelectorExtensions
    {
        public static Func<T, Guid> SelectIdentity<T>(this ISelector _)
            where T : IIdentified
        {
            return identified => identified.Identity;
        }

        public static Func<T, string> SelectName<T>(this ISelector _)
            where T: INamed
        {
            return named => named.Name;
        }
    }
}
