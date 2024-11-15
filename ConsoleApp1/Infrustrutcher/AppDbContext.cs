using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace ConsoleApp1.Infrustrutcher;

public class AppDbContext :DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-SJNEDPF\\SQLEXPRESS;Database=Hw12;User Id=sa;Password=Nimak1640;TrustServerCertificate=True;"
            );
        base.OnConfiguring(optionsBuilder);
    }
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
    }

    public DbSet <UserTask> Tasks { get; set; }
    public DbSet<User> Users { get; set; }



}
