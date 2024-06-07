using Template.NetCore.Domain.Books.Events;
using System.Threading.Tasks;

namespace Template.NetCore.Application.Handlers
{
    public class BookEventHandler
    {
        public async Task HandleBookCreatedEvent(BookCreatedEvent bookCreatedEvent)
        {
            // Here you can do whatever you need with this event, you can propagate the data using a queue, calling another API or sending a notification or whatever
            // With this scenario, you are building a event driven architecture with microservices and DDD
            await Task.Run(() => { });
        }

        public async Task HandleBookUpdatedEvent(BookUpdatedEvent bookUpdatedEvent)
        {
            // Here you can do whatever you need with this event, you can propagate the data using a queue, calling another API or sending a notification or whatever
            // With this scenario, you are building a event driven architecture with microservices and DDD
            await Task.Run(() => { });
        }

        public async Task HandleBookDeletedEvent(BookDeletedEvent bookDeletedEvent)
        {
            // Here you can do whatever you need with this event, you can propagate the data using a queue, calling another API or sending a notification or whatever
            // With this scenario, you are building a event driven architecture with microservices and DDD
            await Task.Run(() => { });
        }
    }
}
