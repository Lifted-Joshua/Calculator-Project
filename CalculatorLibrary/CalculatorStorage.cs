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
    }

    /// <summary>
    /// Gets counter value.
    /// </summary>
    /// <returns>Number of times the calculator has been used</returns>
    public int NumberOfCalculations() => Counter;

}