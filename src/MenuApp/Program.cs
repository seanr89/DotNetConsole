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
}