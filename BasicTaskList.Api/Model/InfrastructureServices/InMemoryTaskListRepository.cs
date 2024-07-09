using System.Collections.Concurrent;
using BasicTaskList.Api.Model.Core;
using Optional;

namespace BasicTaskList.Api.Model.InfrastructureServices;

public class InMemoryTaskListRepository : ITaskListRepository
{
    private static readonly IDictionary<string, TaskList> Db = new ConcurrentDictionary<string, TaskList>();
    
    public Task<TaskList> Put(TaskList taskList)
    {
        Db.Add(taskList.Id, taskList);
        return Task.FromResult(taskList);
    }

    public Task<Option<TaskList>> GetBy(string id)
    {
        return Task.FromResult(Db.ContainsKey(id) 
            ? Db[id].Some() 
            : Option.None<TaskList>());
    }
}