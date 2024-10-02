namespace Aufgabe_13;

class Program
{
    static void Main(string[] args)
    {
        bool validInput = false;
        string input = string.Empty;
        int jahr = 0;

        while (true)
        {
            validInput = false;
            
            Console.WriteLine("Gib ein jahr an: (or press q to quit)"); 
            input = Console.ReadLine();
            
            if (input.ToLower() == "q")
            {
                break;
            }
            
            while (!validInput)
            {
                if (int.TryParse(input, out jahr))
                {
                    validInput = true;
                    input = string.Empty;
                }
                else
                {
                    Console.Write("Error: Gib eine Zahl ein.");
                }
            }
            
            bool istSchaltjahr = ValidateYear(jahr);

            if (istSchaltjahr)
            {
                Console.WriteLine($"Das jahr {jahr} ist ein Schaltjahr.");
            }
            else
            {
                Console.WriteLine($"Das jahr {jahr} ist kein Schaltjahr.");
                
            }
        }
    }
    
    static bool ValidateYear(int jahr)
    {
        if (jahr % 4 == 0)
        {
            if (jahr % 100 == 0)
            {
                if (jahr % 400 == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
            
        }
        else
        {
            return false;
        }
    }
}