using Microsoft.EntityFrameworkCore;
using NoSlack.Domain.Models;

namespace NoSlack.Infrastructure.Data;

public class Context : DbContext
{
    public DbSet<Habit> Habits { get; set; } = null!;
    
    public Context(DbContextOptions<Context> options) : base(options) { }
}