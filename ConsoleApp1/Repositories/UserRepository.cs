using ConsoleApp1.Cotracts.Repository;
using ConsoleApp1.Cotracts.Service;
using ConsoleApp1.Entities;
using ConsoleApp1.Infrustrutcher;

namespace ConsoleApp1.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository()
    {
        _context = new AppDbContext();
    }
    public User Login(string username, string password)
    {
        var user = _context.Users.FirstOrDefault(p => p.UserName == username && p.Password == password);
        return user;
    }
    public bool Register(string username, string password)
    {
        
        if (_context.Users.Any(x => x.UserName == username))
        {
            
            return false;
        }

        
        var user = new User
        {
            UserName = username,
            Password = password,
            RegesterTime = DateTime.Now
        };

       
        _context.Users.Add(user);
        _context.SaveChanges();

        return true; 
    }

    bool IUserRepository.GetUserByUsername(string username)
    {
        if (string.IsNullOrEmpty(username))
        {
            throw new ArgumentException("Username cannot be null or empty.");
        }

        
        return _context.Users.Any(user => user.UserName == username);
    }
}