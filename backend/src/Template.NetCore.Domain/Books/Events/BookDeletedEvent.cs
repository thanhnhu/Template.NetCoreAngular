using System;

namespace Template.NetCore.Domain.Books.Events
{
    public class BookDeletedEvent : BookEvent
    {
        public BookDeletedEvent(Guid id)
        {
            Id = id;
        }
    }
}
