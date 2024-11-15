using ConsoleApp1.Entities;
using ConsoleApp1.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Cotracts.Repository;

public interface IUserTaskRepository
{

    void Create(string title, TaskPriority priority, int userId, DateTime timeToDone);
    List<UserTask> GetAllByPriority(int userId);
    List<UserTask> GetAllBySubmitedTime(int userId);
    void Update(UserTask task);
    void Delete(int taskId);
    void ChangeState(int taskId, TaskState state);
    List<UserTask> Search(int userId, string keyword);

}
