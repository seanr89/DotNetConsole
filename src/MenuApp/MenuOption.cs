
namespace MenuApp;

/// <summary>
/// A breakdown of a single menu event with an action to execute!
/// </summary>
/// <param name="Name">The displayed menu name of the Action to run</param>
/// <param name="Operation">A function/class to execute</param>
/// <returns>a menu option record</returns>
public record MenuOption(string Name, Action Operation);