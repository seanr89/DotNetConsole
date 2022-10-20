// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
MathCalc class1 = new MathCalc();
class1.Sum();

Console.WriteLine("What is your name?");
var name = Console.ReadLine();
var currentDate = DateTime.Now;
Console.WriteLine($"{Environment.NewLine}Hello, {name}, on {currentDate:d} at {currentDate:t}!");
Console.Write($"{Environment.NewLine}Press any key to exit...");
Console.ReadKey(true);

internal class MathCalc
{
    public void Sum() {
            int a = 5;
            int b = 6;
            int Sum = a + b;
            Console.WriteLine("Sum : {0}", Sum);
        }
}