using ConsoleApp1.Cotracts.Repository;
using ConsoleApp1.Repositories;
using ConsoleApp1.Cotracts.Service;
using ConsoleApp1.Enums;
using ConsoleApp1.Entities;
using ConsoleApp1.Infrustrutcher;
using System.Threading.Tasks;

namespace ConsoleApp1.Services;

public class UserTaskServices : IUserTaskService
{
    private readonly IUserTaskRepository _userTaskRepository;

    public UserTaskServices()
    {
        _userTaskRepository = new UserTaskRepository();
    }

    public void Create(string title, TaskPriority priority, DateTime time)
    {
        var userId = InMemoryDb.User.Id;

        _userTaskRepository.Create(title, priority, userId, time);


    }

    public void ChangeState(int taskId, TaskState state)
    {
        var tasks = GetAllByPriority();
        foreach (var task in tasks)
        {
            if (task == null || task.UserId != InMemoryDb.User.Id)
            {
                throw new Exception("Task not found or access denied.");
            }
            if (task.Id == taskId)
            {
                task.State = state;
                _userTaskRepository.ChangeState(taskId, state);
            }

        }
        throw new Exception("somthing happend pleas try again later");
    }

    public void Delete(int taskId)
    {
        var tasks = GetAllByPriority();
        foreach (var task in tasks)
        {
            if (task == null || task.UserId != InMemoryDb.User.Id)
            {
                throw new Exception("Task not found or access denied.");
            }

            _userTaskRepository.Delete(taskId);
        }
    }

    public List<UserTask> GetAllByPriority()
    {
        var userId= InMemoryDb.User.Id;
        var tasks = _userTaskRepository.GetAllByPriority(userId);
        return tasks;
    }

    public List<UserTask> GetAllBySubmitedTime()
    {
        var userId = InMemoryDb.User.Id;
        var tasks = _userTaskRepository.GetAllBySubmitedTime(userId);
        return tasks;
    }

        public List<UserTask> Search(string keyword)
    {
        var userId = InMemoryDb.User.Id;
        return _userTaskRepository.Search(userId, keyword);
    }

    public void Update(UserTask task,int taskId)
    {
        var Tasks = InMemoryDb.User.Tasks;
        if (Tasks == null )
        {
            throw new Exception("Task not found or access denied.");
        }
        foreach(var existingTask in Tasks)
        {
            
            if (existingTask.Id == taskId)
            {
                existingTask.Title = task.Title;
                existingTask.Priority = task.Priority;
                existingTask.TaskSubmittingTime = task.TaskSubmittingTime;
                existingTask.State = task.State;
                _userTaskRepository.Update(existingTask);
            }
        }
        throw new Exception("Task not found or access denied.");





    }
}
