
using ConsoleApp1.Entities;
using ConsoleApp1.Enums;

namespace ConsoleApp1.Cotracts.Service;

public interface IUserTaskService
{
    void Create(string title, TaskPriority priority, DateTime timeToDone);
    List<UserTask> GetAllByPriority();
    List<UserTask> GetAllBySubmitedTime();
    void Update(UserTask task, int taskId);
    void Delete(int taskId);
    void ChangeState(int taskId, TaskState state);
    List<UserTask> Search(string keyword);
}
