using System.ComponentModel.DataAnnotations;

namespace NoSlack.Domain.Models;

public class Habit
{
    [Key] 
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}