namespace NoSlack.UI;

public class MainMenu
{
    private int _selectedIndex = 0;
    private readonly string[] _menuItem = { "Add Habbit", "View All", "Exit" };

    public void Start()
    {
        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine(" === Welcome to the JSON Tracker! ===");
            for (int i = 0; i < _menuItem.Length; i++)
            {
                if (i == _selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"> {_menuItem[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"  {_menuItem[i]}");
                }
            }

            var key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    _selectedIndex = (_selectedIndex == 0) ? _menuItem.Length - 1 : _selectedIndex - 1;
                    Console.Beep(200, 100);
                    break;
                
                case ConsoleKey.DownArrow:
                    _selectedIndex = (_selectedIndex == _menuItem.Length - 1) ? 0 : _selectedIndex + 1;
                    Console.Beep(200, 100);
                    break;
            }
        }
        
    }
}