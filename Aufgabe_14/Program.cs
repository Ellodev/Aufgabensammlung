namespace Aufgabe_14;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Breite des Stammes?");
        string breiteInput = Console.ReadLine();
        Console.WriteLine("Höhe des Stammes?");
        string hoeheInput = Console.ReadLine();
        Console.WriteLine("Höhe der Krone?");
        string kroneInput = Console.ReadLine();

        byte stammBreite = Convert.ToByte(breiteInput);
        byte stammHöhe = Convert.ToByte(hoeheInput);
        byte kroneHöhe = Convert.ToByte(kroneInput); 
        
        // Krone
        for (int i = 1; i <= kroneHöhe; i++)
        {
            // Leere felder
            int j = kroneHöhe - i;
            while (j > 0) {
                Console.Write(" ");
                j--;
            }
            // Krone / Blätter
            int k = i * 2 - 1;
            while (k > 0)
            {
                Console.Write("*");
                k--;
            }
            Console.WriteLine();
        }
        // Stamm
        for (int i = 1; i <= stammHöhe; i++)
        {
            int j = (kroneHöhe * 2 - 1 - stammBreite ) / 2 - stammBreite / 2;
            while (j >= 0)
            {
                Console.Write(" ");
                j--;
            }

            for (int k = stammBreite; k > 0; k--)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }

    }
}