using System.Data;
using System.Drawing;
using Spectre.Console;
using NoSlackConsole.Services;
using Color = Spectre.Console.Color;
using Rule = Spectre.Console.Rule;

namespace NoSlackConsole.UI;

public class ViewHabitsMenu
{
    private readonly ApiClient _client;

    public ViewHabitsMenu(ApiClient client) => _client = client;

    public async Task Show()
    {
        AnsiConsole.Clear();
        AnsiConsole.Write(new Rule("[bold blue]HABIT SCAN[/]").LeftJustified());

        var habits = await _client.GetAllHabit();

        if (!habits.Any())
        {
            AnsiConsole.Markup("[red]No habits in system...[/]");
            AnsiConsole.Prompt(new TextPrompt<string>("Press Enter to return..."));
            return;
        }

        var table = new Table().Border(TableBorder.Rounded);
        table.AddColumn("ID");
        table.AddColumn("Name");

        foreach (var habit in habits)
        {
            table.AddRow(habit.Id.ToString(), habit.Name);
        }

        AnsiConsole.Write(table);

        AnsiConsole.Markup("[purple]Select a habit to view details (or Enter to back):[/]");
        var selected = AnsiConsole.Prompt(new SelectionPrompt<Habit>()
            .Title("Choose habit:")
            .AddChoices(habits)
            .UseConverter(h => h.Name)
            .HighlightStyle(new Style(foreground: Color.Purple, decoration: Decoration.Bold))
        );

        // Здесь добавь действия для выбранной привычки, лох! Пока заглушка.
        AnsiConsole.Markup("[blue]Selected: {0} (ID: {1})[/]", selected.Name, selected.Id);
        AnsiConsole.Prompt(new TextPrompt<string>("Press Enter to return..."));
    }
}