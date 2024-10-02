namespace Aufgabe_18;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("Bitte gib dein Geburtsdatum ein: ");
            DateTime geburtsDatum = Convert.ToDateTime(Console.ReadLine());
            DateTime today = DateTime.Today;
            TimeSpan interval = today - geburtsDatum;

            Console.WriteLine($"Alter in jahren: {interval.Days / 366}");
            Console.WriteLine($"Alter in monaten: {interval.Days / 31}");
            Console.WriteLine($"Alter in wochen: {interval.Days / 7}");
            Console.WriteLine($"Alter in tagen: {interval.Days}");
        }
    }
}