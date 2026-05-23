
using System.Text.RegularExpressions;
using CalculatorLibrary;

const int CalculatorAppMenu = 1;
const int ListHistoryMenu = 2;
const int DeleteHistoryMenu = 3;

bool endApp = false;
// Display title as the C# console calculator app.
Console.WriteLine("Console Calculator in C#\r");
Console.WriteLine("------------------------\n");

Calculator calculator = new Calculator();

while (!endApp)
{
    ListMenu();

    string? menuInput = "";
    Console.Write("Type a menu number, and then press Enter: ");
    menuInput = Console.ReadLine();

    double chosenMenu = 0;
    while (!double.TryParse(menuInput, out chosenMenu))
    {
        Console.Write("This is not valid input. Please enter a numeric value: ");
        menuInput = Console.ReadLine();
    }

    switch (chosenMenu)
    {
        case CalculatorAppMenu:
            CalculatorApp();
            break;
        case ListHistoryMenu:
            calculator.ListHistory();
            break;
        case DeleteHistoryMenu:
            calculator.ClearList();
            break;
        default:
            break;
    }

    Console.WriteLine("\n"); // Friendly linespacing. 

    // Wait for the user to respond before closing.
    Console.Write("Press 'n' and Enter to close the app, or press any other key and Enter to continue: ");
    if (Console.ReadLine() == "n") endApp = true;

    Console.WriteLine("\n"); // Friendly linespacing. 
}

calculator.Finish();

void CalculatorApp()
{
    // Declare variables and set to empty.
    // Use Nullable types (with ?) to match type of System.Console.ReadLine
    string? numInput1 = "";
    string? numInput2 = "";
    double result = 0;

    // Ask the user to type the first number.
    Console.Write("Type a number, and then press Enter: ");
    numInput1 = Console.ReadLine();

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
    Console.WriteLine("\te - Exponentiation");
    Console.WriteLine();
    Console.WriteLine("First number is used:");
    Console.WriteLine("\tq - Square root");
    Console.WriteLine("\ti - Sine(°)");
    Console.WriteLine("\to - Cosine(°)");
    Console.WriteLine("\tt - Tangent(°)");
    Console.WriteLine("\tc - Cotangent(°)");
    Console.Write("Your option? ");

    string? op = Console.ReadLine();

    // Validate input is not null, and matches the pattern
    if (op == null || ! Regex.IsMatch(op, "[a|s|m|d|q|e|i|o|t|c]"))
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
}

void ListMenu()
{
    Console.WriteLine("------------------------");
    Console.WriteLine($"{CalculatorAppMenu} - Calculator");
    Console.WriteLine($"{ListHistoryMenu} - List History");
    Console.WriteLine($"{DeleteHistoryMenu} - Delete History");
    Console.WriteLine("------------------------\n");
}