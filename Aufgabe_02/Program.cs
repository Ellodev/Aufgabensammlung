Console.WriteLine("Berechnung von Sekunden eines Monats in Abhängigkeit seiner anzahl Tage.");

int days = 0;
bool validInput = false;

while (!validInput)
{
    Console.WriteLine("Wie viele Tage hat der Monat?");

    string input = Console.ReadLine();
    if (int.TryParse(input, out days) == true)
    {
        if (days == 28 || days == 29 || days == 30 || days == 31)
        {
            validInput = true;
        } else
        {
            Console.WriteLine("Eingabefehler: Geben sie einen gültigen Monat ein.");
        }

    }
    else
    {
        Console.WriteLine("Eingabefehler: Bitte geben sie eine Zahl ein.");
    }
}

int seconds = days * 24 * 60 * 60;

Console.WriteLine("Der Monat hat " + seconds + " Sekunden.");

