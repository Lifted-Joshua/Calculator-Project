using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorLibrary;
public class CalculatorStorage
{
    /// <summary>
    /// Gets or sets number of times the calculator has been used
    /// </summary>
    public int Counter { get; set; }

    /// <summary>
    /// Gets or sets a list containing previous calculations
    /// </summary>
    public List<Calculation> Calculations { get; set; }

    /// <summary>
    /// Gets or sets streamwriter to save calculations to file
    /// </summary>
    public StreamWriter _writer;

    public CalculatorStorage()
    {
        Calculations = new List<Calculation>();

        string currentDir = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(currentDir, "Calculations.txt");

        _writer = new StreamWriter(filePath, append: true);
    }

    public void PersistData()
    {
        _writer.WriteLine(Counter.ToString());

        foreach (var text in Calculations)
        {
            _writer.WriteLine(text.DisplayText);
        }
    }
}