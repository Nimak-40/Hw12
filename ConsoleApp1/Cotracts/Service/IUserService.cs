using ConsoleApp1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Cotracts.Service;

public interface IUserService
{
    bool Login(string username, string password);

    bool Register(string username, string password);
}
