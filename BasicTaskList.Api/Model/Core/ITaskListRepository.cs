using Optional;

namespace BasicTaskList.Api.Model.Core;

public interface ITaskListRepository
{
   Task<TaskList> Put(TaskList taskList);
   Task<Option<TaskList>> GetBy(string id);
}