Console.Write("Wie lang soll die Linie sein?: ");

var input  = Console.ReadLine();

if (int.TryParse(input, out int number))
{
    string[,] array = new string[number, number];
    for (int i = 0; i < number; i++)
    {
        for (int j = 0; j < number; j++)
        {
            if (i != j)
            {
                array[i, j] = "*";
            }
        }
        
    }
    // Printing out the array
    for (int i = 0; i < number; i++)
    {
        for (int j = 0; j < number; j++)
        {
            // Print "*" or empty space if no "*" was assigned
            Console.Write(array[i, j] ?? " ");
        }
        Console.WriteLine(); // Move to the next line after each row
    }
}

