using BasicTaskList.Api.Model.Core;

namespace BasicTaskList.Api.Model.ApplicationServices;

public class TaskListReadModel  
{
    public static TaskListReadModel From(TaskList l)
    {
        return new TaskListReadModel(l.Id, l.Name, 
            l.Select(t => new Tuple<string, bool>(t.Text, t.Complete)));
    }
    
    public string Id { get; }
    public string Name { get; }
    public Tuple<string, bool>[] Tasks { get; }

    private TaskListReadModel(string id, string name, IEnumerable<Tuple<string, bool>> tasks)
    {
        Id = id;
        Name = name;
        Tasks = tasks.ToArray();
    }
}