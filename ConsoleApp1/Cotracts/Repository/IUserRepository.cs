using ConsoleApp1.Entities;
using ConsoleApp1.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Cotracts.Repository;

public interface IUserRepository
{
    public User Login(string username, string password);

    bool Register(string username, string password);

    bool GetUserByUsername(string username);

}
