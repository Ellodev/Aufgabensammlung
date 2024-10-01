string[] monate = { "Januar", "Februar", "März", "April", "Mai", "Juni",
                    "Juli", "August", "September", "Oktober", "November", "Dezember" };

bool validInput  = false;
int monatsZahl = 0;


while ( validInput == false )
{
    Console.WriteLine("Zahl eingeben von 1-12:");
    string input = Console.ReadLine();

    if (int.TryParse(input, out monatsZahl) == true)
    {
        if (monatsZahl >= 1 && monatsZahl <= 12)
        {
            validInput = true;
        }
        else
        {
            Console.WriteLine("Eingabefehler: Bitte gib eine Zahl zwischen 1 und 12 ein.");
        }
    }
    else
    {
        Console.WriteLine("Eingabefehler: Bitte gib eine Zahl ein.");
    }
}

Console.WriteLine("Dein Monat ist: " + monate[monatsZahl - 1]);