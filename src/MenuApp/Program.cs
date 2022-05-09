using Utilities;

namespace MenuApp;

class Program
{
    public static List<MenuOption> options = new List<MenuOption>();
    public static Menu? _menu = null;
    static void Main(string[] args)
    {
        Console.Clear();

        // See https://aka.ms/new-console-template for more information
        Console.WriteLine("Please select from one of the options!");
        Console.CancelKeyPress += new ConsoleCancelEventHandler(ConsoleHelpers.cancelHandler);

        // TODO: move to a menu list class to be configured externally
        // i.e. drive it via DI of a IMenuOption interface
        options = new List<MenuOption>
        {
            new MenuOption("1. Output Sample Message", () => Console.WriteLine("Welcome to the app!")),
            new MenuOption("2. Clear Log", () => Console.Clear()),
            new MenuOption("9. Exit", () => Environment.Exit(0)),
        };

        _menu = new Menu(options);

        // Set the default index of the selected item to be the first
        int index = 0;

        // Talk to menu and display menu and default the location
        _menu.updateMenuWithLocation(options[index], false);

        // Store key info in here
        ConsoleKeyInfo keyinfo;
        do
        {
            keyinfo = Console.ReadKey();

            // Handle each key input (down arrow will write the menu again with a different selected item)
            if (keyinfo.Key == ConsoleKey.DownArrow)
            {
                if (index + 1 < options.Count)
                {
                    index++;
                    _menu.updateMenuWithLocation(options[index], true);
                }
            }
            if (keyinfo.Key == ConsoleKey.UpArrow)
            {
                if (index - 1 >= 0)
                {
                    index--;
                    _menu.updateMenuWithLocation(options[index], true);
                }
            }
            // Handle different action for the option
            if (keyinfo.Key == ConsoleKey.Enter)
            {
                options[index].Operation.Invoke();
                index = 0;
            }
        }
        while (keyinfo.Key != ConsoleKey.X);
        Console.ReadKey();
    }
}