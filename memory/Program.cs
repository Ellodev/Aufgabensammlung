namespace memory;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        while (true)
        {
            int memorySize = 4;
            string[,] memory = new string[memorySize, memorySize];
            string[,] userCopy = new string[memorySize, memorySize];
            string[] emojis =
                ["🐶 ", "🐶 ", "🦋 ", "🦋 ", "🍎 ", "🍎 ", "🚗 ", "🚗 ", "🎈 ", "🎈 ", "🌟 ", "🌟 ", "🍕 ", "🍕 ", "🏀 ", "🏀 "];
            bool[,] isTemp = new bool[memorySize, memorySize];
            bool gameRunning = true;
            int field1 = 0;
            int field2 = 0;
            int turns = 0;
        
            generateMemory(memory, emojis);
            firstTimeUserCopy(memory, userCopy);
            printMemory(userCopy);
            while (gameRunning)
            {
                revertTempCopy(userCopy, isTemp);
                checkWin(userCopy, memory, gameRunning, turns);
                int userFields = convertToInt(getUserInput("Please select a field: "));
                if (userFields != 0)
                {
                    turns = checkUserFields(field1, field2, userFields, memory, userCopy, isTemp, turns);
                    printMemory(userCopy);
                }
            }
        }
        
    }

    static string getUserInput(string input)
    {
        Console.WriteLine(input);
        string output = Console.ReadLine();
        return output;
    }
    static int convertToInt(string input)
    {
        if (input.Length == 4 && int.TryParse(input, out var result))
        {
            return result;
        } else
        {
            Console.WriteLine("Please input a 4digit number that does not contain spaces");
            return 0;
        }
    }
    static void generateMemory(string[,] memory, string[] emojis)
    {
        for (int i = 0; i < memory.GetLength(0); i++)
        {
            for (int j = 0; j < memory.GetLength(0); j++)
            {
                Random rnd = new Random();
                int num = rnd.Next(0, emojis.GetLength(0));
                while (emojis[num] == "0")
                {
                    num = rnd.Next(0, emojis.GetLength(0));
                }
                memory[i, j] =  emojis[num];
                emojis[num] = "0";
            }
        }
    }
    static void printMemory(string[,] userCopy)
    {
        int times = 0;
        int numberY = 1;
        for (int i = 0; i < userCopy.GetLength(0); i++)
        {
            int timesY = 0;
            if (times == 0)
            {
                Console.WriteLine("   1   2   3   4");
                times++;
            }
            for (int j = 0; j < userCopy.GetLength(1); j++)
            {
                if (timesY == 0)
                {
                    Console.Write($"{numberY} ");
                    timesY++;
                    numberY++;
                }
                Console.Write($"{userCopy[i, j]} ");
            }
            Console.WriteLine();
        }
    }
    static void revertTempCopy(string[,] userCopy, bool[,] isTemp)
    {
        for (int i = 0; i < isTemp.GetLength(0); i++)
        {
            for (int j = 0; j < isTemp.GetLength(1); j++)
            {
                if (isTemp[i, j] == true)
                {
                    userCopy[i, j] = " ? ";
                    isTemp[i, j] = false;
                }
            }
        }
    }
    static void firstTimeUserCopy(string[,] userCopy, string[,] memory)
    {
        userCopy = memory;
        for (int i = 0; i < userCopy.GetLength(0); i++)
        {
            for (int j = 0; j < userCopy.GetLength(1); j++)
            {
                userCopy[i, j] = " ? ";
            }
        }
    }
    static int checkUserFields(int field1, int field2, int userFields, string[,] memory,string[,] userCopy, bool[,] isTemp, int turns)
    {
        field1 = userFields / 100;
        field2 = userFields % 100;

        int field1num1 = field1 / 10 - 1;
        int field1num2 = field1 % 10 - 1;

        int field2num1 = field2 / 10 - 1;
        int field2num2 = field2 % 10 - 1;

        if (field1 != field2 && field1num1 < 5 && field1num2 < 5 && field2num1 < 5 && field2num2 < 5 )
        {
            if (memory[field1num1, field1num2] != userCopy[field1num1, field1num2] ||
                memory[field2num1, field2num2] != userCopy[field2num1, field2num2])
            {
                if (memory[field1num1, field1num2] == memory[field2num1, field2num2])
                {
                    userCopy[field1num1, field1num2] = memory[field1num1, field1num2];
                    userCopy[field2num1, field2num2] = memory[field2num1, field2num2];
                    Console.WriteLine("Treffer!");
                }
                else
                {
                    userCopy[field1num1, field1num2] = memory[field1num1, field1num2];
                    userCopy[field2num1, field2num2] = memory[field2num1, field2num2];

                    isTemp[field1num1, field1num2] = true;
                    isTemp[field2num1, field2num2] = true;
                    Console.WriteLine("Leider kein treffer.");
                }
                turns += 1;
            }
            else
            {
                Console.WriteLine("Ungültiger Versuch! An mindestens einer Position wurde das Symbol  bereits aufgedeckt.");
            }
        }
        else
        {
            Console.WriteLine("Ungültige Eingabe! 2x die gleiche Position.");
        }
        return turns;
    }
    static void checkWin(string[,] userCopy, string[,] memory, bool gameRunning, int turns)
    {
        bool win = true;
        for (int i = 0; i < userCopy.GetLength(0); i++)
        {
            for (int j = 0; j < userCopy.GetLength(1); j++)
            {
                if (userCopy[i, j] == memory[i, j])
                {
                    
                }
                else
                {
                    win = false;
                }
            }
        }

        if (win)
        {
            gameRunning = false;
            Console.WriteLine($"Congrats! You win in {turns} turns.");
        }
    }
}