using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;

namespace CalculatorLibrary;

public class Calculator
{
    private int _counter = 0;
    private CalculatorStorage _calculatorStorage;
    JsonWriter writer;
    public Calculator(CalculatorStorage calculatorStorage)
    {
        // Points to the same CalculatorStorage object that Program.cs is using
        _calculatorStorage = calculatorStorage;

        // This creates a file called "Calculator.log" and we assign it to a variable of type streamWriter which allows us to perform write operations
        StreamWriter logFile = File.CreateText("Calculator.log");


        // Every call to Trace.Write, Trace.WriteLine, etc., immediately flushes the buffer to the output.
        // This ensures logs are visible right away but can reduce performance due to more frequent I/O operations.
        Trace.AutoFlush = true;

        // Creating a JSON writer that will write our log data into JSON format instead of plain text.
        writer = new JsonTextWriter(logFile);
        writer.Formatting = Formatting.Indented;
        writer.WriteStartObject();
        writer.WritePropertyName("Operations");
        writer.WriteStartArray();
    }
    public double DoOperation(double num1, double num2, string op)
    {
        _calculatorStorage.Counter++;


        double result = double.NaN; // Default value is "not-a-number" which we use if an operation, such as division, could result in an error.
        writer.WriteStartObject();
        writer.WritePropertyName("Operand1");
        writer.WriteValue(num1);
        writer.WritePropertyName("Operand2");
        writer.WriteValue(num2);
        writer.WritePropertyName("Operation");

        // Use a switch statement to do the math.
        Calculation calculation = new Calculation();

        switch (op)
        {
            case "a":
                result = num1 + num2;
                writer.WriteValue("Add");
                calculation.DisplayText = $"{num1} + {num2} = {result}";
                calculation.Result = result;
                _calculatorStorage.Calculations.Add(calculation);
                break;
            case "s":
                result = num1 - num2;
                writer.WriteValue("Subtract");
                calculation.DisplayText = $"{num1} - {num2} = {result}";
                calculation.Result = result;
                _calculatorStorage.Calculations.Add(calculation);
                break;
            case "m":
                result = num1 * num2;
                writer.WriteValue("Multiply");
                calculation.DisplayText = $"{num1} * {num2} = {result}";
                calculation.Result = result;
                _calculatorStorage.Calculations.Add(calculation);
                break;
            case "d":
                // Ask the user to enter a non-zero divisor.
                if (num2 != 0)
                {
                    result = num1 / num2;
                    writer.WriteValue("Divide");
                    calculation.DisplayText = $"{num1} / {num2} = {result}";
                    calculation.Result = result;
                    _calculatorStorage.Calculations.Add(calculation);
                }
                break;
            // Return text for an incorrect option entry.
            default:
                break;
        }

        writer.WritePropertyName("Result");
        writer.WriteValue(result);
        writer.WriteEndObject();


        return result;
    }

    public double DoAdvancedOperation(double num1, string op)
    {
        _calculatorStorage.Counter++;

        double result = double.NaN; // Default value is "not-a-number" which we use if an operation, such as division, could result in an error.
        writer.WriteStartObject();
        writer.WritePropertyName("Operand1");
        writer.WriteValue(num1);
        writer.WritePropertyName("Operation");

        Calculation calculation = new Calculation();

        switch (op)
        {
            case "1":
                result = SquareRoot(num1);
                writer.WriteValue("Square root");
                calculation.DisplayText = $"Square root of {num1} = {result}";
                calculation.Result = result;
                _calculatorStorage.Calculations.Add(calculation);
                break;
            case "2":
                result = PowerOf10(num1);
                writer.WriteValue("Power of 10");
                calculation.DisplayText = $"10 raised to the power of {num1} = {result}";
                calculation.Result = result;
                _calculatorStorage.Calculations.Add(calculation);
                break;
            case "3":
                result = Sin(num1);
                writer.WriteValue("Sin");
                calculation.DisplayText = $"Sin of {num1} = {result}";
                calculation.Result = result;
                _calculatorStorage.Calculations.Add(calculation);
                break;
            case "4":
                result = Cosine(num1);
                writer.WriteValue("Cosine");
                calculation.DisplayText = $"Cosine of {num1} = {result}";
                calculation.Result = result;
                _calculatorStorage.Calculations.Add(calculation);
                break;
            case "5":
                result = Tangent(num1);
                writer.WriteValue("Tangent");
                calculation.DisplayText = $"Tangent of {num1} = {result}";
                calculation.Result = result;
                _calculatorStorage.Calculations.Add(calculation);
                break;
            default:
                break;
        }

        return result;
    }

    // CalculatorLibrary.cs
    public void Finish()
    {

        writer.WriteEndArray();
        writer.WriteEndObject();
        writer.Close();
    }

    private static double SquareRoot(double num) => Math.Sqrt(num);
    private static double PowerOf10(double num) => Math.Pow(10, num);
    private static double Sin(double num) => Math.Sin(num);
    private static double Cosine(double num) => Math.Cos(num);
    private static double Tangent(double num) => Math.Tan(num);

}
