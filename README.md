# Calculator Project

A C# console calculator built as part of the [C# Academy](https://www.thecsharpacademy.com/) curriculum.

## Features

- Basic arithmetic: addition, subtraction, multiplication, and division
- Input validation with re-prompt on invalid entries
- JSON operation log written to `Calculator.log`
- Calculation history stored in `Calculations.txt` and viewable during the session
- Tracks how many times the calculator has been used per session

## Project Structure

| Project | Purpose |
|---|---|
| `Calculator` | Console app entry point and user interaction |
| `CalculatorLibrary` | Core logic — `Calculator`, `CalculatorStorage`, and `Calculation` model |

## How to Run

```bash
dotnet run --project Calculator
```

## Usage

1. Enter the first number and press Enter.
2. Enter the second number and press Enter.
3. Choose an operation:
   - `a` — Add
   - `s` — Subtract
   - `m` — Multiply
   - `d` — Divide
4. The result is displayed. Enter `n` to exit or any other key to continue.

## Requirements

- [.NET 10 SDK](https://dotnet.microsoft.com/)
- [Newtonsoft.Json](https://www.newtonsoft.com/json) (used for JSON logging)
