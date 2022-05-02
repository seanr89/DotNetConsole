using Utilities;

namespace MenuApp;

class Program
{
    public static List<MenuOption> options;
    static void Main(string[] args)
    {
        // Console.Clear();

        // See https://aka.ms/new-console-template for more information
        Console.WriteLine("Hello, World!");

        options = new List<MenuOption>
        {
            new MenuOption("1. Output Message", () => Console.WriteLine("Hello User again")),
            new MenuOption("2. Clear Log", () => Console.Clear()),
            new MenuOption("9. Exit", () => Environment.Exit(0)),
        };

        // Set the default index of the selected item to be the first
            int index = 0;

            // Write the menu out
            WriteMenu(options, options[index]);

            Console.CancelKeyPress += new ConsoleCancelEventHandler(ConsoleHelpers.cancelHandler);

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
                        WriteMenu(options, options[index]);
                    }
                }
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        WriteMenu(options, options[index]);
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

        /// <summary>
        /// Supports drawing of the current menu selection option (>)
        /// </summary>
        /// <param name="options">Array of options to search</param>
        /// <param name="selectedOption">The current selected item</param>
        /// <param name="clear">default:false - Supports cleaning of console</param>
        static void WriteMenu(List<MenuOption> options, MenuOption selectedOption, bool clear = false)
        {
            if(clear)
                Console.Clear();

            foreach (MenuOption option in options)
            {
                if (option == selectedOption)
                {
                    Console.Write("> ");
                }
                else
                {
                    Console.Write(" ");
                }
                Console.WriteLine(option.Name);
            }
        }
}