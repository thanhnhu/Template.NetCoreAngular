using System;

namespace Template.NetCore.Domain.Books.Commands
{
    public class UpdateBookCommand : BookCommand
    {
        public UpdateBookCommand(Guid id, string author, string title, string description)
        {
            Id = id;
            Author = author;
            Title = title;
            Description = description;
        }
    }
}
