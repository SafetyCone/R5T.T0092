using System;
using System.Collections.Generic;


namespace R5T.T0092
{
    public class NamedEqualityComparer : IEqualityComparer<INamed>
    {
        #region Static

        public static NamedEqualityComparer Instance { get; } = new();

        #endregion


        public bool Equals(INamed x, INamed y)
        {
            var output = x.Name == y.Name;
            return output;
        }

        public int GetHashCode(INamed obj)
        {
            var output = obj.Name.GetHashCode();
            return output;
        }
    }


    public class NamedEqualityComparer<T> : IEqualityComparer<T>
        where T : INamed
    {
        #region Static

        public static NamedEqualityComparer<T> Instance { get; } = new();

        #endregion


        public bool Equals(T x, T y)
        {
            var output = x.Name == y.Name;
            return output;
        }

        public int GetHashCode(T obj)
        {
            var output = obj.Name.GetHashCode();
            return output;
        }
    }
}
