namespace Aufgabe_10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Erste Zahl: ");
            if (int.TryParse(Console.ReadLine(), out int zahl1))
            {
                Console.WriteLine("Zweite Zahl: ");
                if (int.TryParse(Console.ReadLine(), out int zahl2))
                {
                    Console.WriteLine("{0,10} {1,10} {2,10}", "Zahl", "Quersumme", "Division");
                    for (int i = zahl1; i <= zahl2; i++)
                    {
                        int quersumme = BerechneQuersumme(i);
                        if (i % quersumme == 0)
                        {
                            Console.WriteLine("{0,10} {1,10} {2,10}", i, quersumme, i / quersumme);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Bitte gib eine gültige Zahl ein.");
                }
            }
            else
            {
                Console.WriteLine("Bitte gib eine gültige Zahl ein.");
            }
        }

        static int BerechneQuersumme(int zahl)
        {
            int quersumme = 0;
            while (zahl > 0)
            {
                quersumme += zahl % 10;
                zahl /= 10;
            }
            return quersumme;
        }
    }
}