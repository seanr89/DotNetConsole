

namespace MenuApp;

public class Menu
{
    private List<MenuOption> _options;
    public Menu(List<MenuOption> options)
    {
        _options = options;
    }

    /// <summary>
    /// Supports drawing of the current menu selection option (>)
    /// </summary>
    /// <param name="selectedOption">The current selected item</param>
    /// <param name="clear">default:false - Supports cleaning of console</param>
    public void updateMenuWithLocation(MenuOption selectedOption, bool clear = false)
    {
        //TODO: 
         if(clear)
                Console.Clear();

            foreach (MenuOption option in _options)
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