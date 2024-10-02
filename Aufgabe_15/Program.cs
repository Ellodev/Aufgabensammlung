namespace Aufgabe_15;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Random random = new Random();
            int randomNumber = random.Next(1, 100);
            bool incorrectNumber = true;
            Console.WriteLine("Deine Zahl: (1-100)");
            int tries = 1;
            
            while (incorrectNumber)
            {
                byte userChoice = Convert.ToByte(Console.ReadLine());
                if (userChoice == randomNumber)
                {
                    var userInput = WriteAndGetInput($"You got the right number! It took you {tries} tries to get the right number. Press q to exit or enter to play again.");
                    CheckForExit(inputText: userInput);
                    incorrectNumber = false;

                }
                else if (userChoice > randomNumber)
                {
                    Console.WriteLine("Your number was too high. Please try again.");
                    tries++;
                }
                else if (userChoice < randomNumber)
                {
                    Console.WriteLine("Your number was too low. Please try again.");
                    tries++;
                }
            }

        }
    }
    private static string WriteAndGetInput(string textToOutput)
    {
        Console.WriteLine(textToOutput);
        return Console.ReadLine();  
    }
    
    private static void CheckForExit(string inputText)
    {
        if (inputText.Equals("q"))
        {
            Console.WriteLine("You chose to exit. Goodbye!");
            System.Environment.Exit(0); 
        }
    }
}