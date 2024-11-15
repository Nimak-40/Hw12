using ConsoleApp1.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entities;

public class UserTask
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Title { get; set; }

    public TaskState State { get; set; }

    public TaskPriority Priority { get; set; }

    [Required]
    public User User { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public DateTime TaskSubmittingTime { get; set; }
}
