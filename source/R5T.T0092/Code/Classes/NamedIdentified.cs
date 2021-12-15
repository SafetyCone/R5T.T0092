using System;


namespace R5T.T0092
{
    public class NamedIdentified : INamedIdentified
    {
        public Guid Identity { get; set; }

        public string Name { get; set; }
    }
}
