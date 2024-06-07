using System;

namespace Template.NetCore.Domain
{
    public abstract class BaseCommand
    {
        public Guid Id { get; set; }
    }
}
