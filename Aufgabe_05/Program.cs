Console.WriteLine("Wie viele Kilometer möchtest du rennen?");

bool validInput = false;
string input = Console.ReadLine();
int kilometer = 0;
int bahnrunde = 0;

while (!validInput)
{
    if (int.TryParse(input, out kilometer))
    {
        validInput = true;
    }
    else
    {
        Console.WriteLine("Eingabefehler: Gebe eine Zahl ein.");
        input = Console.ReadLine();  // Ask for input again
    }
}

if (kilometer > 42)
{
    Console.WriteLine("Stop the cap");
    System.Environment.Exit(0);
}

bahnrunde = kilometer * 1000 / 400;

Console.Write($"Das sind {bahnrunde} Runden, Bereit? (Ja/Nein) [Standard: Ja]: ");
input = Console.ReadLine();  

bool bereit = string.IsNullOrWhiteSpace(input) ||
              input.Equals("Ja", StringComparison.OrdinalIgnoreCase) ||
              input.Equals("Yes", StringComparison.OrdinalIgnoreCase);

if (!bereit)
{
    Console.WriteLine("Loser");
    System.Environment.Exit(0);
}
else
{
    for (int i = 1; i <= bahnrunde; i++)
    {
        Console.WriteLine($"Du läufst Runde {i}");
    }

    Console.WriteLine("Du hast es geschafft!");
}
