bool validInput = false;

Console.WriteLine("Zahl: ");

while (!validInput)
{
    string zahlString = Console.ReadLine();
    if (int.TryParse(zahlString, out int zahl))
    {
        validInput = true;
        int sum = BerechneQuersumme(zahl);
        Console.Write($"Die Quersumme ist {sum}");
    }
}

static int BerechneQuersumme(int zahl)
{
    int sum = 0;
    while (zahl > 0)
    {
        sum = sum + (zahl % 10);
        zahl = zahl / 10;
    }
    return sum;
}
