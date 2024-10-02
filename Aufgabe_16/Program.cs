namespace Aufgabe_16;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your sentence:");
        char[] vocals = ['a', 'e', 'i', 'o', 'u', 'ä', 'ö', 'ü'];
        int[] vocalCounter = new int[vocals.Length];
        char[] input = Console.ReadLine().ToLower().ToCharArray();
        int numberOfVocals = 0;

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == vocals[0] || input[i] == vocals[1] || input[i] == vocals[2] || input[i] == vocals[3] ||
                input[i] == vocals[4] || input[i] == vocals[5] || input[i] == vocals[6] || input[i] == vocals[7])
            {
                numberOfVocals++;
                int vocalLocation = Array.FindIndex(vocals, v => v == input[i]);
                vocalCounter[vocalLocation]++;
            }

        }
        
        Console.WriteLine($"Vokale: {numberOfVocals}");
        for (int i = 0; i < vocalCounter.Length; i++)
        {
            if (vocalCounter[i] != 0)
            {
                Console.WriteLine($"Der Vokal {vocals[i]} kommt {vocalCounter[i]} mal vor.");
            }
        }

    }

}