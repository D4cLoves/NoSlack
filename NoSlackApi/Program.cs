using Microsoft.EntityFrameworkCore;
using NoSlack.Domain.Interfaces;
using NoSlack.Infrastructure.Data;
using NoSlack.Infrastructure.Repositories;
using NoSlackApplication.Commands;

namespace NoSlackApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddDbContext<Context>(options =>
            options.UseSqlite("Data Source=habits.db"));

        builder.Services.AddScoped<IHabitRepository, HabitRepository>();

        builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateHabitCommand).Assembly));
        
    
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();
        app.MapControllers();  

        app.Run();
    }
}