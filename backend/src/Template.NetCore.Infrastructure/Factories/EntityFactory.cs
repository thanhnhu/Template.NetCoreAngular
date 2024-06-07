using Template.NetCore.Domain.Tasks;
using Template.NetCore.Domain.Tasks.ValueObjects;

/*
 * Factories are concerned with creating new entities and value objects. 
 * They also validate the invariants for the newly created objects.
 * 
 * This is the EntityFactory, which creates new instances of Entities 
 * and Aggregate Roots.)
 */

namespace Template.NetCore.Infrastructure.Factories
{
    public class EntityFactory : ITaskFactory
    {
        public Task CreateTaskInstance(Summary summary, Description description)
        {
            return new TaskFactory(summary, description);
        }
    }
}
