using Template.NetCore.Domain.Tasks.ValueObjects;
using System;

/*
 * Factories are concerned with creating new entities and value objects. 
 * They also validate the invariants for the newly created objects.
 * 
 * This is the TaskFactory, which creates new instances of Tasks,
 * it inherits from Task Domain model as you can see
 */

namespace Template.NetCore.Infrastructure.Factories
{
    public class TaskFactory : Domain.Tasks.Task
    {
        public TaskFactory()
        {

        }

        public TaskFactory(Summary summary, Description description)
        {
            TaskId = new TaskId(Guid.NewGuid());
            Summary = summary;
            Description = description;
        }
    }
}
