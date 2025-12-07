ulong PartOne(string[] input)
{
    char[,] grid = new char[input[0].Length, input.Length];
    for(int x = 0; x < input[0].Length; x++)
    {
        for(int y = 0; y < input.Length; y++)
        {
            grid[x,y] = input[y][x];
        }
    }

    ulong count = 0;

    for(int y = 1; y < input.Length; y++)
    {
        for(int x = 0; x < input[0].Length; x++)
        {
            if(grid[x,y] == '.')
            {
                if(grid[x,y-1] == 'I' || grid[x,y-1] == 'S')
                    grid[x,y] = 'I';
            }
            else if(grid[x,y] == '^')
            {
                if(grid[x,y-1] == 'I')
                {
                    grid[x-1,y] = 'I';
                    grid[x+1,y] = 'I';
                    count++;
                }
            }
        }
    }

    return count;
}

double PartTwo(string[] input)
{
    double[,] grid = new double[input[0].Length, input.Length];
    for(int x = 0; x < input[0].Length; x++)
    {
        for(int y = 0; y < input.Length; y++)
        {
            if(input[y][x] == '^')
                grid[x,y] = -1;
            else if (input[y][x] == '.')
                grid[x,y] = 0;
            else if (input[y][x] == 'S')
                grid[x,y] = 1;
        }
    }

    double count = 0;

    for(int y = 1; y < input.Length; y++)
    {
        for(int x = 0; x < input[0].Length; x++)
        {
            if(grid[x,y] == 0)
            {
                if(grid[x,y-1] > 0)
                    grid[x,y] = grid[x,y-1];
            }
        }
        for(int x = 0; x < input[0].Length; x++)
        {
            if(grid[x,y] == -1)
            {
                if(grid[x,y-1] > 0)
                {
                    grid[x-1,y] += grid[x,y-1];
                    grid[x+1,y] += grid[x,y-1];
                }
            }
        }
    }

    for(int i = 0; i < grid.GetLength(0); i++)
    {
        count += grid[i, grid.GetLength(1)-1];
    }
    
    return count;
}

ulong GetCountFromSplitter(char[,] grid, int xStart, int yStart)
{
    ulong count = 0;
    for(int y = yStart+1; y < grid.GetLength(1); y++)
    {
        if(grid[xStart,y] == '^')
        {
            count++;
            count += GetCountFromSplitter(grid, xStart-1, y);
            count += GetCountFromSplitter(grid, xStart+1, y);
            break;
        }
    }

    return count;
}


var input = File.ReadAllLines("input.txt");

Console.WriteLine(PartOne(input));
Console.WriteLine(PartTwo(input));
