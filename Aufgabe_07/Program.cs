for (int i = 1; i <= 30; i++)
{
    if (i % 5 == 0 || i % 3 == 0)
    {
        if (i == 30)
        {
            Console.Write($"{i}");
        } else
        {
            Console.Write($"{i}, ");
        }
        
    }
}