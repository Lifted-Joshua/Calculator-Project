using System.Diagnostics;
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
                calculation.DisplayText = $"{num1} + {num2} = {result}";
                calculation.Result = result;
                _calculatorStorage.Calculations.Add(calculation);
                break;
            case "m":
                result = num1 * num2;
                writer.WriteValue("Multiply");
                calculation.DisplayText = $"{num1} + {num2} = {result}";
                calculation.Result = result;
                _calculatorStorage.Calculations.Add(calculation);
                break;
            case "d":
                // Ask the user to enter a non-zero divisor.
                if (num2 != 0)
                {
                    result = num1 / num2;
                    writer.WriteValue("Divide");
                    calculation.DisplayText = $"{num1} + {num2} = {result}";
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

    public void displayCalculatorStorage()
    {

    }


    // CalculatorLibrary.cs
    public void Finish()
    {

        writer.WriteEndArray();
        writer.WriteEndObject();
        writer.Close();
    }
}
