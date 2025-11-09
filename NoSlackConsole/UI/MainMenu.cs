using System.Data;
using System.Drawing;
using NoSlackConsole.Services;
using Spectre.Console;
using Color = Spectre.Console.Color;
using Rule = Spectre.Console.Rule;

namespace NoSlackConsole.UI;

public class MainMenu
{
    private readonly ApiClient _client;

    public MainMenu(ApiClient client) => _client = client;

    public async Task Show()
    {
        while (true)
        {
            AnsiConsole.Clear();
            AnsiConsole.Write(new Rule("[bold blue]CYBERPUNK HABIT TRACKER[/]").LeftJustified());

            var choice = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[purple]Choose action:[/]")
                    .AddChoices("Create Habit", "View All Habits", "Exit")
                    .HighlightStyle(new Style(foreground: Color.Purple, decoration: Decoration.Bold))
            );

            switch (choice)
            {
                case "Create Habit":
                    await new AddHabitMenu(_client).Show();
                    break;
                case "View All Habits":
                    await new ViewHabitsMenu(_client).Show();
                    break;
                case "Exit":
                    AnsiConsole.Markup("[bold red]Exiting cyberpunk mode...[/]");
                    return;
            }
        }
    }
}