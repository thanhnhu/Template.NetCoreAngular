using System;

namespace Template.NetCore.Domain.Books.Commands
{
    public class DeleteBookCommand : BookCommand
    {
        public DeleteBookCommand(Guid id)
        {
            Id = id;
        }
    }
}
