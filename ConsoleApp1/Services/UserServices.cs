using ConsoleApp1.Cotracts.Repository;
using ConsoleApp1.Cotracts.Service;
using ConsoleApp1.Entities;
using ConsoleApp1.Infrustrutcher;
using ConsoleApp1.Repositories;
namespace ConsoleApp1.Services;

public class UserServices : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserServices()
    {
        _userRepository = new UserRepository();
    }

    public bool Login(string username, string password)
    {
        var user = _userRepository.Login(username, password);
        if (user != null && username == user.UserName && password == user.Password)
        {
            InMemoryDb.User = user;
            return true;
        }
        if (user == null)
        {
            throw new Exception("Wrong, please try again later.");
        }

        throw new Exception("Something went wrong, please try again later.");
    }

    public bool Register(string username, string password)
    {
        
        var existingUser = _userRepository.GetUserByUsername(username);
        if (existingUser != null&& existingUser==true)
        {
            throw new Exception("Username already exists.");
        }

        _userRepository.Register(username, password);

        return true;
    }
}