using System.Runtime.CompilerServices;

namespace Aufgabe_19;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Make your calculation (or press q to quit): ");
            var inputText = Console.ReadLine();
            CheckForExit(inputText);
            Calculate(inputText);
            
        }
        
    }
    //method to check if user typed exit
    private static void CheckForExit(string inputText)
    {
        if (inputText.Equals("q"))
        {
            Console.WriteLine("You chose to exit.   Goodbye!");
            System.Environment.Exit(0); 
        }
    }

    private static void Calculate(string inputText)
    {
        if (inputText.Contains("+") || inputText.Contains("-") || inputText.Contains("*") || inputText.Contains("/"))
        {

            if (inputText.Contains("+"))
            {
                string[] inputArray = inputText.Split("+");
                
                if (inputArray.Length == 2)
                {
                    if (int.TryParse(inputArray[0], out int number1) && int.TryParse(inputArray[1], out int number2))
                    {
                        int result = number1 + number2;
                        Console.WriteLine($"Result: {result}");
                    }
                    else
                    {
                        Console.WriteLine("Error: Invalid number format.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Input does not contain exactly two numbers.");
                }
            }
            else if (inputText.Contains("-"))
            {
                string[] inputArray = inputText.Split("-");
                
                if (inputArray.Length == 2)
                {
                    if (int.TryParse(inputArray[0], out int number1) && int.TryParse(inputArray[1], out int number2))
                    {
                        int result = number1 - number2;
                        Console.WriteLine($"Result: {result}");
                    }
                    else
                    {
                        Console.WriteLine("Error: Invalid number format.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Input does not contain exactly two numbers.");
                }
            }
            else if (inputText.Contains("*"))
            {
                string[] inputArray = inputText.Split("*");
                
                if (inputArray.Length == 2)
                {
                    if (int.TryParse(inputArray[0], out int number1) && int.TryParse(inputArray[1], out int number2))
                    {
                        int result = number1 * number2;
                        Console.WriteLine($"Result: {result}");
                    }
                    else
                    {
                        Console.WriteLine("Error: Invalid number format.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Input does not contain exactly two numbers.");
                }
            }
            else if (inputText.Contains("/"))
            {
                string[] inputArray = inputText.Split("/");
                
                if (inputArray.Length == 2)
                {
                    if (int.TryParse(inputArray[0], out int number1) && int.TryParse(inputArray[1], out int number2))
                    {
                        int result = number1 / number2;
                        Console.WriteLine($"Result: {result}");
                    }
                    else
                    {
                        Console.WriteLine("Error: Invalid number format.");
                    }
                }
                else
                {
                    Console.WriteLine("Error: Input does not contain exactly two numbers.");
                }
            }

        }
        else
        {
            Console.WriteLine("Error: No operand.");
        }
    }
}