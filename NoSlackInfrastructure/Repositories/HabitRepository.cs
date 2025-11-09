using NoSlack.Domain.Interfaces;
using NoSlack.Domain.Models;
using NoSlack.Infrastructure.Data;

namespace NoSlack.Infrastructure.Repositories;

public class HabitRepository : IHabitRepository
{
    private readonly Context _context;
    public HabitRepository(Context context) => _context = context;
    
    public async Task<Habit> AddAsync(Habit habit)
    {
        _context.Habits.Add(habit);
        await _context.SaveChangesAsync();
        return habit;
    }

    public async Task<List<Habit>> GetAllAsync()
    {
        return _context.Habits.ToList();    
    }
    
}