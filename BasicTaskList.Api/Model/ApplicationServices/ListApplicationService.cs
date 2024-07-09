using BasicTaskList.Api.Model.Core;
using Optional;

namespace BasicTaskList.Api.Model.ApplicationServices;

public class ListApplicationService
{
    private readonly ITaskListRepository repository;

    public ListApplicationService(ITaskListRepository repository)
    {
        this.repository = repository;
    }
    
    public async Task<TaskListReadModel> Create(string name, IEnumerable<string> tasks)
    {
        var l = new TaskList(name, tasks);
        l = await repository.Put(l);
        return TaskListReadModel.From(l);
    }

    public async Task<Option<TaskListReadModel>> GetById(string id)
    {
        var maybeList = await repository.GetBy(id);

        var maybeReadModel = 
            maybeList.Match(
                some: list => TaskListReadModel.From(list).Some(),
                () => Option.None<TaskListReadModel>()
            );
        
        return maybeReadModel;
    }
}