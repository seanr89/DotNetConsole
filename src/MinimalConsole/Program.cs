// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
MathCalc class1 = new MathCalc();
class1.Sum();


internal class MathCalc
{
    public void Sum() {
            int a = 5;
            int b = 6;
            int Sum = a + b;
            Console.WriteLine("Sum : {0}", Sum);
        }
}