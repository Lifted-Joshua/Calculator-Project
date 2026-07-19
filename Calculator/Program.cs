using System.Text.RegularExpressions;
using Calculator;
using CalculatorLibrary;

class Program
{
    private static readonly CalculatorStorage _calculatorStorage = new CalculatorStorage();
    private static readonly CalculatorLibrary.Calculator _calculator = new CalculatorLibrary.Calculator(_calculatorStorage);

    public static void Main(string[] args)
    {
        bool endApp = false;
        // Display title as the C# console calculator app.
        Console.WriteLine("Console Calculator in C#\r");
        Console.WriteLine("------------------------\n");

        while(!endApp)
        {
            // Display a choice for user to select if they want to perform advanced operations if yes call a method called advanced operations. If no continue with asking for second input
            Console.WriteLine($"Do you want to perform basic operations or advanced operations");
            Console.WriteLine("\ta - Advanced");
            Console.WriteLine("\tAny button - Basic");

            if (Console.ReadLine() == "a")
            {
                endApp = MenuOperations.PerformAdvancedOperations(_calculatorStorage, _calculator);
            }
            else
            {
                endApp = MenuOperations.DoBasicOperations(_calculatorStorage, _calculator);
            }

            //Think of menuoperation public methods should return a bool that will be used to control endApp
        }
    }



}