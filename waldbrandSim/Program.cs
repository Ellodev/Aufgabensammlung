using System.Text;

namespace waldbrandSim;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        int mapWidth = getMapWidth();
        int mapHeight = getMapHeight();
        int treeChance = getRateOfTrees();
        int fireChance = getRateOfFire();
        int time = 0;
        
        string[,] map = new string[mapWidth,mapHeight];
        int[,] mapTime = new int[mapWidth,mapHeight];
        string[] materials = ["🌲", "🪨", "🟫", "🔥", "🔺"];
        
        generateMap(mapWidth, mapHeight, map, materials);
        string[,] oldMap = map;
        
        Task.Run(() => TimeKeeper(time, mapTime, mapWidth, mapHeight, oldMap, map));
        while (true)
        {   
            randomGrowth(map, materials, mapHeight, mapWidth, mapTime, treeChance);
            backToSoil(mapHeight, mapWidth, materials, map, mapTime, oldMap);
            neighbourFire(map, materials, mapHeight, mapWidth, mapTime);
            burnedTree(map, mapWidth, mapHeight, materials);
            randomFire(map, materials, mapHeight, mapWidth, mapTime, fireChance);
            PrintMap(map, mapWidth, mapHeight); 
        }
        
    }

    static int getMapWidth()
    {
        Console.WriteLine("How wide should the map be?");
        return int.Parse(Console.ReadLine());
    }
    static int getMapHeight()
    {
        Console.WriteLine("How tall should the map be?");
        return int.Parse(Console.ReadLine());
    }

    static int getRateOfTrees()
    {
        Console.WriteLine("How often should Trees spawn? (1 is 100% of the time)");
        return int.Parse(Console.ReadLine());
    }

    static int getRateOfFire()
    {
        Console.WriteLine("How often should Fires happen? (1 is 100% of the time)");
        return int.Parse(Console.ReadLine());
    }
    static void generateMap(int mapWidth, int mapHeight, string[,] map, string[] materials)
    {
        Random rnd = new Random();
        for (int i = 0; i < mapHeight; i++)
        {
            for (int j = 0; j < mapWidth; j++)
            {
                int randomNum = rnd.Next(0, 3);
                map[j,i] = materials[randomNum];
            }
        }
    }
    static void PrintMap(string[,] map, int mapWidth, int mapHeight )
    {
        StringBuilder printMap = new StringBuilder();
        
        for (int i = 0; i < mapHeight; i++)
        {
            for (int j = 0; j < mapWidth; j++)
            {
                printMap.Append(map[j,i]);
            }
            printMap.AppendLine();
        }
        Console.Clear();
        Console.Write(printMap.ToString());
    }
    static void randomFire(string[,] map, string[] materials, int mapWidth, int mapHeight, int[,] mapTime, int fireChance)
    {
        for (int i = 0; i < mapHeight; i++)
        {
            for (int j = 0; j < mapWidth; j++)
            {
                if (map[i,j] == materials[0])
                {
                        Random rnd = new Random();
                        int randomNum = rnd.Next(0, fireChance);
                        if (randomNum == 1)
                        {
                            map[i,j] = materials[3];
                        }

                        mapTime[i, j] = 1;

                }
            }
        }
        System.Threading.Thread.Sleep(1000);
    }
    static void TimeKeeper(int time, int[,]mapTime, int mapWidth, int mapHeight, string[,] map, string[,] oldMap)
    {
        while (true)
        {
            time++;
            oldMap = map;
            for (int i = 0; i < mapWidth; i++)
            {
                for (int j = 0; j < mapHeight; j++)
                {
                    if (mapTime[i, j] != 0)
                    {
                        mapTime[i, j]++;
                    }
                    
                }
            }

            System.Threading.Thread.Sleep(500);
        }
    }
    static void neighbourFire(string[,] map, string[] materials, int mapWidth, int mapHeight,  int[,] mapTime)
    {
        for (int i = 0; i < mapHeight; i++)
        {
            for (int j = 0; j < mapWidth; j++)
            {
                if (map[i,j] == materials[3])
                {
                    if (mapTime[i, j] >= 2)
                    {
                        // Check each surrounding position and update accordingly
                        // Top-Left
                        if (i - 1 >= 0 && j - 1 >= 0 && map[i - 1, j - 1] == materials[0])
                        {
                            map[i - 1, j - 1] = materials[3];
                            mapTime[i - 1, j - 1] = 1;
                        }

                        // Top
                        if (i - 1 >= 0 && map[i - 1, j] == materials[0])
                        {
                            map[i - 1, j] = materials[3];
                            mapTime[i - 1, j] = 1;
                        }

                        // Top-Right
                        if (i - 1 >= 0 && j + 1 < map.GetLength(1) && map[i - 1, j + 1] == materials[0])
                        {
                            map[i - 1, j + 1] = materials[3];
                            mapTime[i - 1, j + 1] = 1;
                        }

                        // Left
                        if (j - 1 >= 0 && map[i, j - 1] == materials[0])
                        {
                            map[i, j - 1] = materials[3];
                            mapTime[i, j - 1] = 1;
                        }

                        // Right
                        if (j + 1 < map.GetLength(1) && map[i, j + 1] == materials[0])
                        {
                            map[i, j + 1] = materials[3];
                            mapTime[i, j + 1] = 1;
                        }

                        // Bottom-Left
                        if (i + 1 < map.GetLength(0) && j - 1 >= 0 && map[i + 1, j - 1] == materials[0])
                        {
                            map[i + 1, j - 1] = materials[3];
                            mapTime[i + 1, j - 1] = 1;
                        }

                        // Bottom
                        if (i + 1 < map.GetLength(0) && map[i + 1, j] == materials[0])
                        {
                            map[i + 1, j] = materials[3];
                            mapTime[i + 1, j] = 1;
                        }

                        // Bottom-Right
                        if (i + 1 < map.GetLength(0) && j + 1 < map.GetLength(1) && map[i + 1, j + 1] == materials[0])
                        {
                            map[i + 1, j + 1] = materials[3];
                            mapTime[i + 1, j + 1] = 1;
                        }
                    }

                }
            }
        }
    }
    static void backToSoil(int mapHeight, int mapWidth, string[] materials, string[,] map, int[,] mapTime, string[,] oldMap)
    {
        for (int i = 0; i < mapWidth; i++)
        {
            for (int j = 0; j < mapHeight; j++)
            {
                if (map[i,j] == materials[4])
                {
                    if (oldMap[i, j] == map[i, j])
                    {
                        map[i, j] = materials[2];
                    
                    }

                }
                
                
            }
        }
    }
    static void burnedTree(string[,] map, int mapWidth, int mapHeight, string[] materials)
    {
        for (int i = 0; i < mapWidth; i++)
        {
            for (int j = 0; j < mapHeight; j++)
            {
                if (map[i, j] == materials[3])
                {
                    bool allEqual = true;

                    if (i > 0 && j > 0 && map[i - 1, j - 1] != materials[3] && map[i - 1, j - 1] != materials[1] && map[i - 1, j - 1] != materials[2] && map[i - 1, j - 1] != materials[4])
                        allEqual = false;

                    if (i > 0 && map[i - 1, j] != materials[3] && map[i - 1, j] != materials[1] && map[i - 1, j] != materials[2] && map[i - 1, j] != materials[4])
                        allEqual = false;

                    if (i > 0 && j < map.GetLength(1) - 1 && map[i - 1, j + 1] != materials[3] && map[i - 1, j + 1] != materials[1] && map[i - 1, j + 1] != materials[2] && map[i - 1, j + 1] != materials[4])
                        allEqual = false;

                    if (j > 0 && map[i, j - 1] != materials[3] && map[i, j - 1] != materials[1] && map[i, j - 1] != materials[2] && map[i, j - 1] != materials[4])
                        allEqual = false;

                    if (j < map.GetLength(1) - 1 && map[i, j + 1] != materials[3] && map[i, j + 1] != materials[1] && map[i, j + 1] != materials[2] && map[i, j + 1] != materials[4])
                        allEqual = false;

                    if (i < map.GetLength(0) - 1 && j > 0 && map[i + 1, j - 1] != materials[3] && map[i + 1, j - 1] != materials[1] && map[i + 1, j - 1] != materials[2] && map[i + 1, j - 1] != materials[4])
                        allEqual = false;

                    if (i < map.GetLength(0) - 1 && map[i + 1, j] != materials[3] && map[i + 1, j] != materials[1] && map[i + 1, j] != materials[2] && map[i + 1, j] != materials[4])
                        allEqual = false;

                    if (i < map.GetLength(0) - 1 && j < map.GetLength(1) - 1 && map[i + 1, j + 1] != materials[3] && map[i + 1, j + 1] != materials[1] && map[i + 1, j + 1] != materials[2] && map[i + 1, j + 1] != materials[4])
                        allEqual = false;
                    
                    if (allEqual)
                    {
                        map[i,j] = materials[4];
                    }
                }

                    
            }
        }
    }
    static void randomGrowth(string[,] map, string[] materials, int mapWidth, int mapHeight, int[,] mapTime,  int treeChance)
    {
        for (int i = 0; i < mapHeight; i++)
        {
            for (int j = 0; j < mapWidth; j++)
            {
                if (map[i,j] == materials[2])
                {
                    Random rnd = new Random();
                    int randomNum = rnd.Next(0, treeChance);
                    if (randomNum == 1)
                    {
                        map[i,j] = materials[0];
                    }

                    mapTime[i, j] = 1;

                }
            }
        }
        System.Threading.Thread.Sleep(500);
    }
}
    