using NoSlackConsole.Services;
using NoSlackConsole.UI;

namespace NoSlackConsole;

class Program
{
    static async Task Main(string[] args)  // ← ДОБАВЬ async Task!
    {
        var client = new ApiClient();
        await new MainMenu(client).Show();
    }
}