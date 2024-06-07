using System;

namespace Template.NetCore.Domain.Books.Events
{
    public class BookUpdatedEvent : BookEvent
    {
        public BookUpdatedEvent(Guid id, string author, string title, string description)
        {
            Id = id;
            Author = author;
            Title = title;
            Description = description;
        }
    }
}
