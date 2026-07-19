using System;
using System.Text.RegularExpressions;
using CalculatorLibrary;

namespace Calculator;
public static class MenuOperations
{
    public static bool DoBasicOperations(CalculatorStorage calculatorStorage, CalculatorLibrary.Calculator calculator)
    {
        bool endApp = false;

        // Declare variables and set to empty.
        // Use Nullable types (with ?) to match type of System.Console.ReadLine
        string? numInput1 = "";
        string? numInput2 = "";
        double result = 0;

        // Call reuse result to allow user to use a previous result as a value for the operation
        numInput1 = ReuseResult(calculatorStorage);

        // Ask the user to type the first number.

        //This will only run if num1Input is string.empty
        // This if is added becuase if the user picks to use the display result from the list in next calculation num1 will be set as that value, so there is no need to ask user to enter num1 again
        if(numInput1 == string.Empty)
        {
            Console.Write("Type a number, and then press Enter: ");
            numInput1 = Console.ReadLine();
        }


        double cleanNum1 = 0;
        while (!double.TryParse(numInput1, out cleanNum1))
        {
            Console.Write("This is not valid input. Please enter a numeric value: ");
            numInput1 = Console.ReadLine();
        }


        // Ask the user to type the second number.
        Console.Write("Type another number, and then press Enter: ");
        numInput2 = Console.ReadLine();

        double cleanNum2 = 0;
        while (!double.TryParse(numInput2, out cleanNum2))
        {
            Console.Write("This is not valid input. Please enter a numeric value: ");
            numInput2 = Console.ReadLine();
        }

        // Ask the user to choose an operator.
        Console.WriteLine("Choose an operator from the following list:");
        Console.WriteLine("\ta - Add");
        Console.WriteLine("\ts - Subtract");
        Console.WriteLine("\tm - Multiply");
        Console.WriteLine("\td - Divide");
        Console.Write("Your option? ");

        string? op = Console.ReadLine();

        // Validate input is not null, and matches the pattern
        if (op == null || ! Regex.IsMatch(op, "^(a|s|m|d)$"))
        {
            Console.WriteLine("Error: Unrecognized input.");
        }
        else
        {
            try
            {
                result = calculator.DoOperation(cleanNum1, cleanNum2, op);
                if (double.IsNaN(result))
                {
                    Console.WriteLine("This operation will result in a mathematical error.\n");
                }
                else Console.WriteLine("Your result: {0:0.##}\n", result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
            }
        }
        Console.WriteLine("------------------------\n");

        // Wait for the user to respond before closing.
        Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");

        if (Console.ReadLine() == "n") {
            calculator.Finish();
            endApp = true;
        }

        Console.WriteLine("\n"); // Friendly linespacing.

        return endApp;
    }


    public static bool PerformAdvancedOperations(CalculatorStorage calculatorStorage, CalculatorLibrary.Calculator calculator)
    {
        bool endApp = false;

        string? numInput1 = "";
        double result = 0;

        // Call reuse result to allow user to use a previous result as a value for the operation
        numInput1 = ReuseResult(calculatorStorage);

        if(numInput1 == string.Empty)
        {
            Console.Write("Type a number, and then press Enter: ");
            numInput1 = Console.ReadLine();
        }


        double cleanNum1 = 0;
        while (!double.TryParse(numInput1, out cleanNum1))
        {
            Console.Write("This is not valid input. Please enter a numeric value: ");
            numInput1 = Console.ReadLine();
        }


        // Ask the user to choose an operator.
        Console.WriteLine("Choose an operator from the following list:");
        Console.WriteLine("\t1 - Square root");
        Console.WriteLine("\t2 - Power of 10");
        Console.WriteLine("\t3 - Sine");
        Console.WriteLine("\t4 - Cosine");
        Console.WriteLine("\t5 - Tangent");
        Console.Write("Your option? ");

        string? op = Console.ReadLine();

        // Validate input is not null, and matches the pattern
        if (op == null || ! Regex.IsMatch(op, "^(1|2|3|4|5)$"))
        {
            Console.WriteLine("Error: Unrecognized input.");
        }
        else
        {
            try
            {
                result = calculator.DoAdvancedOperation(cleanNum1, op);
                if (double.IsNaN(result))
                {
                    Console.WriteLine("This operation will result in a mathematical error.\n");
                }
                else Console.WriteLine("Your result: {0:0.##}\n", result);
            }
            catch (Exception e)
            {
                Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
            }
        }
        Console.WriteLine("------------------------\n");

        // Wait for the user to respond before closing.
        Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");

        if (Console.ReadLine() == "n") {
            calculator.Finish();
            endApp = true;
        }


        Console.WriteLine("\n"); // Friendly linespacing.

        return endApp;
    }

    private static string ReuseResult(CalculatorStorage calculatorStorage)
    {
        string value = string.Empty;
        if (calculatorStorage.Calculations.Count > 0)
        {
            string userMenuOptions;
            bool validMenuOption = false;

            Console.WriteLine("Do you want to see the list of calculations");
            Console.WriteLine("\ty - Yes");
            Console.WriteLine("\tn - No");
            userMenuOptions = Console.ReadLine();

            while(!validMenuOption)
            {
                if(userMenuOptions == "y" || userMenuOptions == "n")
                {
                    validMenuOption = true;
                    switch (userMenuOptions)
                    {
                        case "y":
                            value = ProcessCalculationHistoryChoice(DisplayResultsList(calculatorStorage), calculatorStorage.Calculations);
                            break;
                        case "n":
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Pick a valid options");
                    Console.WriteLine("\ty - Yes");
                    Console.WriteLine("\tn - No");
                    userMenuOptions = Console.ReadLine();
                }
            }
        }

        return value;
    }



    private static string DisplayResultsList(CalculatorStorage calculatorStorage)
    {
        string userChoice;
        bool validUserChoice = false;
        Console.WriteLine("Displaying the calculcations history\r");
        Console.WriteLine("------------------------\n");
        foreach(var calculations in calculatorStorage.Calculations)
        {
            Console.WriteLine(calculations.DisplayText);
        }

        Console.WriteLine("Choose an option from the following list:");
        Console.WriteLine("\td - Delete the current list");
        Console.WriteLine("\tp - Pick a past result as input for a new calculation");
        Console.WriteLine("\te - Exit calculations history view");
        userChoice = Console.ReadLine();

        while(!validUserChoice)
        {
            if (userChoice == "d" || userChoice == "p" || userChoice == "e")
            {
                validUserChoice = true;
            }
            else
            {
                Console.WriteLine("\td - Delete the current list");
                Console.WriteLine("\tp - Pick a past result as input for a new calculation");
                Console.WriteLine("\te - Exit calculations history view");
                userChoice = Console.ReadLine();
            }
        }

        return userChoice!;
    }

    private static string ProcessCalculationHistoryChoice(string userChoice, List<Calculation> calculations)
    {
        // Add an if check to check if the returned result from DisplayResultsList is n or p
        // if n just delete the entire list, if it is p then figure out a way to set one of numbers to the list result they picked
        if(userChoice == "d")
        {
            // Clear/ empty the list
            calculations.Clear();
            return string.Empty;
        }
        else if (userChoice == "e")
        {
            return string.Empty;
        }
        else
        {
            return Convert.ToString(SelectChoiceFromList(calculations));
        }
    }

    private static double SelectChoiceFromList(List<Calculation> calculations)
    {
        bool validUserChoice = false;
        string userChoice;
        int result;
        Console.WriteLine($"Displaying history of calculations\r");
        Console.WriteLine("------------------------\n");

        for(var i = 0; i < calculations.Count; i++)
        {
            Console.WriteLine($"Item {i+1}: {calculations[i].DisplayText}");
        }

        Console.WriteLine($"Select a choice between 1 and {calculations.Count}");
        userChoice = Console.ReadLine();

        while(!int.TryParse(userChoice, out result))
        {
            Console.WriteLine($"Select a choice between 1 and {calculations.Count}");
            userChoice = Console.ReadLine();
        }


        while(!validUserChoice)
        {
            if(result < 1 || result > calculations.Count)
            {
                Console.WriteLine($"Select a choice between 1 and {calculations.Count}");
                int.TryParse(Console.ReadLine(), out result);
            }
            else
            {
                validUserChoice = true;
            }
        }

        return calculations[result-1].Result;
    }
}
