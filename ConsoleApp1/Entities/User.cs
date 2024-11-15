using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Entities;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string UserName { get; set; }

    [Required]
    [MaxLength(50)]
    public string Password { get; set; }

    [InverseProperty("User")]
    public List<UserTask> Tasks { get; set; } = new List<UserTask>();

    public DateTime RegesterTime { get; set; }
}

