namespace Template.NetCore.Domain.Books.Commands
{
    public class CreateNewBookCommand : BookCommand
    {
        public CreateNewBookCommand(string author, string title, string description)
        {
            Author = author;
            Title = title;
            Description = description;
        }
    }
}
