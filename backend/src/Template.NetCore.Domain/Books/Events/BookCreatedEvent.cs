using System;

namespace Template.NetCore.Domain.Books.Events
{
    public class BookCreatedEvent : BookEvent
    {
        public BookCreatedEvent(Guid id, string author, string title, string description)
        {
            Id = id;
            Author = author;
            Title = title;
            Description = description;
        }
    }
}
