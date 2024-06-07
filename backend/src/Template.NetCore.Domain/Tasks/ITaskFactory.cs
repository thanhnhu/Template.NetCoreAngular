using Template.NetCore.Domain.Tasks.ValueObjects;

/*
 * Factories are concerned with creating new entities and value objects. 
 * They also validate the invariants for the newly created objects.
 * 
 * This is the interface definition to create Tasks (to be implemented in
 * Infrastructure layer)
 */

namespace Template.NetCore.Domain.Tasks
{
    public interface ITaskFactory
    {
        Task CreateTaskInstance(Summary summary, Description description);
    }
}
