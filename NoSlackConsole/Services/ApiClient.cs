using System.Net.Http.Json;

namespace NoSlackConsole.Services;

public class ApiClient
{
    private readonly HttpClient _http = new() { BaseAddress = new Uri("https://localhost:44324/") };

    public async Task<Habit> Create(string name)
    {
        var resp = await _http.PostAsJsonAsync("api/habits", new { Name = name });
        return await resp.Content.ReadFromJsonAsync<Habit>() ?? new(0, "");
    }

    public async Task<List<Habit>> GetAllHabit()
    {
        var resp = await _http.GetAsync("api/habits");
        return await resp.Content.ReadFromJsonAsync<List<Habit>>() ?? new List<Habit>();
    }
}

public record Habit(int Id, string Name);