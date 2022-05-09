namespace Utilities;

/// <summary>
/// Helper class to simplify styling and formatting of the excel worksheet
/// </summary>
public static class ConsoleHelpers
{
    /// <summary>
    /// Test method to handle Yes/No selection on console apps
    /// </summary>
    /// <param name="title">The text to display on the read message</param>
    /// <returns></returns>
    public static bool Confirm(string title)
    {
        ConsoleKey response;
        do
        {
            Console.Write($"{ title } [y/n] ");
            response = Console.ReadKey(false).Key;
            if (response != ConsoleKey.Enter)
            {
                Console.WriteLine();
            }
        } while (response != ConsoleKey.Y && response != ConsoleKey.N);

        return (response == ConsoleKey.Y);
    }

    //helper function that waits for any key to continue
    public static void WaitForAnyKeyPress(string msg)
    {
        Console.WriteLine($"\n{msg}");
        Console.ReadKey(true);
    }


    public static void ReadSpecificKey(ConsoleKey keyin)
    {
        ConsoleKey key;
        Console.WriteLine($"The console app is waiting for you to press the {keyin} button. Press escape to move on at any time.");
        do
        {
            while (!Console.KeyAvailable)
            {
                //
            }
            // Key is available - read it
            key = Console.ReadKey(true).Key;
            if(key == keyin)
            {
                Console.WriteLine("You pressed the correct key!");
            }
        } while (key != ConsoleKey.Escape);
    }

    /// <summary>
    /// this method will handle the Ctrl+C event and will ask for confirmation
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public static void cancelHandler(object sender, ConsoleCancelEventArgs e)
    {
        var isCtrlC = e.SpecialKey == ConsoleSpecialKey.ControlC;
        if (isCtrlC)
        {
            string confirmation = "";
            Console.Write("Are you sure you want to cancel the task? (y/n)");
            confirmation = Console.ReadLine() ?? "y";

            if (confirmation.Equals("y", StringComparison.OrdinalIgnoreCase))
            {
                e.Cancel = true;
                Environment.Exit(0);
            }
            else
            {
                Console.CancelKeyPress += new ConsoleCancelEventHandler(cancelHandler);
            }
        }
    }
}