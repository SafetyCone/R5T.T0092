using System;


namespace R5T.T0092
{
    public interface IMutableIdentified : IIdentified
    {
        new Guid Identity { get; set; }
    }
}
