using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorLibrary;
public class Calculation
{
    /// <summary>
    /// Gets or sets the calculation as a string.
    /// </summary>
    public string DisplayText { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the calculation result.
    /// </summary>
    public double Result { get; set; }
}
