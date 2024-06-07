namespace Template.NetCore.Domain.Books.Commands
{
    public class BookCommand: BaseCommand
    {
        public string Author { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
