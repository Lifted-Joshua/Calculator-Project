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

    public CalculatorStorage()
    {
        Calculations = new List<Calculation>();
    }



}