using System;

namespace Template.NetCore.Domain
{
    public abstract class BaseEvent
    {
        public Guid Id { get; set; }
    }
}
