using System.Data;
using NoSlackConsole.Services;
using Spectre.Console;
using Rule = Spectre.Console.Rule;

namespace NoSlackConsole.UI;

public class AddHabitMenu
{
    private readonly ApiClient _client;

    public AddHabitMenu(ApiClient client) => _client = client;

    public async Task Show()
    {
        AnsiConsole.Clear();
        AnsiConsole.Write(new Rule("[bold blue]NEW HABIT INPUT[/]").LeftJustified());

        var name = AnsiConsole.Ask<string>("[purple]Enter habit name:[/]");

        if (string.IsNullOrWhiteSpace(name))
        {
            AnsiConsole.Markup("[red]Invalid input, try again...[/]");
            return;
        }

        var created = await _client.Create(name);
        AnsiConsole.Markup("[green]Habit added: {0} (ID: {1})[/]", created.Name, created.Id);

        AnsiConsole.Prompt(new TextPrompt<string>("Press Enter to return..."));
    }
}