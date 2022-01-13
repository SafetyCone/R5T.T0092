using System;
using System.Collections.Generic;


namespace R5T.T0092
{
    public class NamedIdentifiedEqualityComparer<T> : IEqualityComparer<T>
        where T : INamedIdentified
    {
        #region Static

        public static NamedIdentifiedEqualityComparer<T> Instance { get; } = new();

        #endregion


        public bool Equals(T x, T y)
        {
            var output = true
                && x.Identity == y.Identity
                && x.Name == y.Name
                ;

            return output;
        }

        public int GetHashCode(T obj)
        {
            var output = HashCode.Combine(
                obj.Identity,
                obj.Name);

            return output;
        }
    }
}
