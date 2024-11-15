using ConsoleApp1.Cotracts.Service;
using ConsoleApp1.Entities;
using ConsoleApp1.Enums;
using ConsoleApp1.Services;

public class Program
{
    private IUserService _userServices;
    private IUserTaskService _userTaskService;

    public Program()
    {
        _userServices = new UserServices();
        _userTaskService= new UserTaskServices();
    }

    
    private void ShowMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the User Management System");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Register");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    LoginUser();
                    break;
                case "2":
                    RegisterUser();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    
    private void LoginUser()
    {
        Console.Write("Enter username: ");
        var username = Console.ReadLine();

        Console.Write("Enter password: ");
        var password = Console.ReadLine();

        try
        {
            
            var loginSuccess = _userServices.Login(username, password);
            if (loginSuccess)
            {
                Console.WriteLine("Login successful!");
                RunUserTaskService();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();
    }

    
    private void RegisterUser()
    {
        Console.Write("Enter username: ");
        var username = Console.ReadLine();

        Console.Write("Enter password: ");
        var password = Console.ReadLine();

        try
        {
            var registerSuccess = _userServices.Register(username, password);
            if (registerSuccess)
            {
                Console.WriteLine("Registration successful!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("Press any key to return to the menu...");
        Console.ReadKey();
    }

    public  void RunUserTaskService()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("User Task Management System");
            Console.WriteLine("1. Create Task");
            Console.WriteLine("2. Change Task State");
            Console.WriteLine("3. Delete Task");
            Console.WriteLine("4. View All Tasks by Priority");
            Console.WriteLine("5. View All Tasks by Submission Time");
            Console.WriteLine("6. Search Task by Keyword");
            Console.WriteLine("7. Update Task");
            Console.WriteLine("8. Exit");
            Console.Write("Choose an option: ");

            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateTask();
                    break;
                case "2":
                    ChangeTaskState();
                    break;
                case "3":
                    DeleteTask();
                    break;
                case "4":
                    ViewTasksByPriority();
                    break;
                case "5":
                    ViewTasksBySubmissionTime();
                    break;
                case "6":
                    SearchTask();
                    break;
                case "7":
                    UpdateTask();
                    break;
                case "8":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }

    public  void CreateTask()
    {
        Console.Write("Enter task title: ");
        var title = Console.ReadLine();

        Console.Write("Enter task priority (Low, Medium, High): ");
        var priority = Enum.Parse<TaskPriority>(Console.ReadLine(), true);

        Console.Write("Enter task due date (yyyy-mm-dd): ");
        var time = DateTime.Now;

        _userTaskService.Create(title, priority, time);


        Console.WriteLine("Task created successfully!");
    }

    private void ChangeTaskState()
    {
        Console.Write("Enter task ID to change state: ");
        var taskId = int.Parse(Console.ReadLine());

        Console.Write("Enter new task state (Pending, InProgress, Completed): ");
        var state = Enum.Parse<TaskState>(Console.ReadLine(), true);

        _userTaskService.ChangeState(taskId, state);
        Console.WriteLine("Task state changed successfully!");
    }

    private void DeleteTask()
    {
        Console.Write("Enter task ID to delete: ");
        var taskId = int.Parse(Console.ReadLine());

        _userTaskService.Delete(taskId);
        Console.WriteLine("Task deleted successfully!");
    }

    private void ViewTasksByPriority()
    {
        var tasks = _userTaskService.GetAllByPriority();
        Console.WriteLine("Tasks by Priority:");
        foreach (var task in tasks)
        {
            Console.WriteLine($"ID: {task.Id}, Title: {task.Title}, Priority: {task.Priority}");
        }
    }

    private void ViewTasksBySubmissionTime()
    {
        var tasks = _userTaskService.GetAllBySubmitedTime();
        Console.WriteLine("Tasks by Submission Time:");
        foreach (var task in tasks)
        {
            Console.WriteLine($"ID: {task.Id}, Title: {task.Title}, Submission Time: {task.TaskSubmittingTime}");
        }
    }

    private void SearchTask()
    {
        Console.Write("Enter keyword to search: ");
        var keyword = Console.ReadLine();

        var tasks = _userTaskService.Search(keyword);
        Console.WriteLine("Search Results:");
        foreach (var task in tasks)
        {
            Console.WriteLine($"ID: {task.Id}, Title: {task.Title}");
        }
    }

    private void UpdateTask()
    {
        Console.Write("Enter task ID to update: ");
        var taskId = int.Parse(Console.ReadLine());

        Console.Write("Enter new task title: ");
        var title = Console.ReadLine();

        Console.Write("Enter new task priority (Low, Medium, High): ");
        var priority = Enum.Parse<TaskPriority>(Console.ReadLine(), true);

        Console.Write("Enter new task due date (yyyy-mm-dd): ");
        var timeToDone = DateTime.Parse(Console.ReadLine());

        Console.Write("Enter new task state (Pending, InProgress, Completed): ");
        var state = Enum.Parse<TaskState>(Console.ReadLine(), true);

        var task = new UserTask
        {
            Id = taskId,
            Title = title,
            Priority = priority,
            TaskSubmittingTime = timeToDone,
            State = state
        };

        _userTaskService.Update(task, taskId);
        Console.WriteLine("Task updated successfully!");
    }

    public static void Main(string[] args)
    {
        var program = new Program();
        program.ShowMenu();
    }


}
