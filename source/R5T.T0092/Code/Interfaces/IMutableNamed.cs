using System;


namespace R5T.T0092
{
    public interface IMutableNamed : INamed
    {
        new string Name { get; set; }
    }
}
