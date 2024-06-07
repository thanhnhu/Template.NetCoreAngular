namespace Template.NetCore.Domain.Books.Events
{
    public class BookEvent : BaseEvent
    {
        public string Author { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
