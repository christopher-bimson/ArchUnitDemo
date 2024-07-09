using BasicTaskList.Api.Controllers;
using BasicTaskList.Api.Model.ApplicationServices;

namespace BasicTaskList.Api.Resources;

public class ListResource
{
    public static ListResource From(TaskListReadModel readModel)
    {
        return new ListResource(readModel.Id, readModel.Name, 
            readModel.Tasks.Select(m => new TaskResource(m.Item1, m.Item2)).ToArray());
    }
    
    public string Id { get; }
    public string Name { get; } 
    public TaskResource[] Tasks { get; }
    
    public ListResource(string id, string name, TaskResource[] tasks)
    {
        Id = id;
        Name = name;
        Tasks = tasks;
    }
}