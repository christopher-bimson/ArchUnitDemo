using System.Collections;

namespace BasicTaskList.Api.Model.Core;

public class TaskList : IEnumerable<TodoTask>
{
    private readonly IList<TodoTask> tasks;
    public string Id { get; }
    public string Name { get; }
    
    public TaskList(string name, IEnumerable<string> tasks)
    {
        Id = Guid.NewGuid().ToString();
        Name = name;
        this.tasks = new List<TodoTask>(TodoTask.From(tasks));
    }

    public IEnumerator<TodoTask> GetEnumerator()
    {
        return tasks.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}