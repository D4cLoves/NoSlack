using NoSlack.Domain.Models;

namespace NoSlack.Domain.Interfaces;

public interface IHabitRepository
{
    Task<Habit> AddAsync(Habit habit);
    Task<List<Habit>> GetAllAsync();
}