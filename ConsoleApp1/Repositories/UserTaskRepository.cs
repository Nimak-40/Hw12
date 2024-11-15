using ConsoleApp1.Cotracts.Repository;
using ConsoleApp1.Entities;
using ConsoleApp1.Enums;
using ConsoleApp1.Infrustrutcher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Repositories;

public class UserTaskRepository : IUserTaskRepository
{
    private readonly AppDbContext _context;

    public UserTaskRepository()
    {
        _context = new AppDbContext();
    }

    public void Create(string title, TaskPriority priority, int userId, DateTime SubmitedTime)
    {
        var task = new Entities.UserTask
        {
            Title = title,
            Priority = priority,
            UserId = userId,
            TaskSubmittingTime = SubmitedTime,
            State = TaskState.Pending 
        };
        _context.Tasks.Add(task);
        _context.SaveChanges();
    }

    public List<UserTask> GetAllByPriority(int userId)
    {
        return _context.Tasks
            .Where(t => t.UserId == userId)
            .OrderBy(t => t.Priority)
            .ToList();
    }

    public List<UserTask> GetAllBySubmitedTime(int userId)
    {
        return _context.Tasks
            .Where(t => t.UserId == userId)
            .OrderBy(t => t.TaskSubmittingTime)
            .ToList();
    }

    public void Update(UserTask task)
    {
        var existingTask = _context.Tasks.Find(task.Id);
        if (existingTask != null)
        {
            existingTask.Title = task.Title;
            existingTask.Priority = task.Priority;
            existingTask.TaskSubmittingTime = task.TaskSubmittingTime;
            existingTask.State = task.State;

            _context.SaveChanges();
        }
    }

    public void Delete(int taskId)
    {
        var task = _context.Tasks.Find(taskId);
        if (task != null)
        {
            _context.Tasks.Remove(task);
            _context.SaveChanges();
        }
    }

    public void ChangeState(int taskId, TaskState state)
    {
        var task = _context.Tasks.Find(taskId);
        if (task != null)
        {
            task.State = state;
            _context.SaveChanges();
        }
    }

    public List<UserTask> Search(int userId, string keyword)
    {
        return _context.Tasks
            .Where(t => t.UserId == userId && t.Title.Contains(keyword))
            .ToList();
    }
}
