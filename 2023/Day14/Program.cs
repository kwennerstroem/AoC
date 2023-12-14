
int Part1(string[] input)
{
    char[,] map = new char[input[0].Length, input.Length];
    for (int y = 0; y < input.Length; y++)
    {
        for (int x = 0; x < input[y].Length; x++)
        {
            map[x, y] = input[y][x];
        }
    }

    for (int x = 0; x < input[0].Length; x++)
    {
        for (int y = 0; y < input.Length; y++)
        {
            if (map[x, y] == 'O' && y != 0)
            {
                int i = y;
                do
                {
                    i--;
                    if (i == -1)
                    {
                        i++;
                        break;
                    }
                } while (map[x, i] != 'O' && map[x, i] != '#');

                if (map[x, i] == 'O')
                {
                    if (y - i == 1) continue;
                    map[x, y] = '.';
                    map[x, i + 1] = 'O';
                }
                if (map[x, i] == '.')
                {
                    map[x, y] = '.';
                    map[x, i] = 'O';
                }
                if (map[x, i] == '#')
                {
                    map[x, y] = '.';
                    map[x, i + 1] = 'O';
                }
            }
        }
    }

    int sum = 0;

    for (int i = 0; i < input.Length; i++)
    {
        for (int j = 0; j < input[0].Length; j++)
        {
            if (map[j, i] == 'O')
                sum += input.Length - i;
        }
    }

    return sum;
}

int Part2(string[] input)
{
    char[,] map = new char[input[0].Length, input.Length];
    for (int y = 0; y < input.Length; y++)
    {
        for (int x = 0; x < input[y].Length; x++)
        {
            map[x, y] = input[y][x];
        }
    }

    for (int c = 0; c < 1000; c++)
    {
        for (int x = 0; x < input[0].Length; x++)
        {
            for (int y = 0; y < input.Length; y++)
            {
                if (map[x, y] == 'O' && y != 0)
                {
                    int i = y;
                    do
                    {
                        i--;
                        if (i == -1)
                        {
                            i++;
                            break;
                        }
                    } while (map[x, i] != 'O' && map[x, i] != '#');

                    if (map[x, i] == 'O')
                    {
                        if (y - i == 1) continue;
                        map[x, y] = '.';
                        map[x, i + 1] = 'O';
                    }
                    if (map[x, i] == '.')
                    {
                        map[x, y] = '.';
                        map[x, i] = 'O';
                    }
                    if (map[x, i] == '#')
                    {
                        map[x, y] = '.';
                        map[x, i + 1] = 'O';
                    }
                }
            }
        }

        for (int y = 0; y < input.Length; y++)
        {
            for (int x = 0; x < input[0].Length; x++)
            {
                if (map[x, y] == 'O' && x != 0)
                {
                    int i = x;
                    do
                    {
                        i--;
                        if (i == -1)
                        {
                            i++;
                            break;
                        }
                    } while (map[i, y] != 'O' && map[i, y] != '#');

                    if (map[i, y] == 'O')
                    {
                        if (x - i == 1) continue;
                        map[x, y] = '.';
                        map[i + 1, y] = 'O';
                    }
                    if (map[i, y] == '.')
                    {
                        map[x, y] = '.';
                        map[i, y] = 'O';
                    }
                    if (map[i, y] == '#')
                    {
                        map[x, y] = '.';
                        map[i + 1, y] = 'O';
                    }
                }
            }
        }

        for (int x = 0; x < input[0].Length; x++)
        {
            for (int y = input.Length - 1; y >= 0; y--)
            {
                if (map[x, y] == 'O' && y != input.Length - 1)
                {
                    int i = y;
                    do
                    {
                        i++;
                        if (i == input.Length)
                        {
                            i--;
                            break;
                        }
                    } while (map[x, i] != 'O' && map[x, i] != '#');

                    if (map[x, i] == 'O')
                    {
                        if (i - y == 1) continue;
                        map[x, y] = '.';
                        map[x, i - 1] = 'O';
                    }
                    if (map[x, i] == '.')
                    {
                        map[x, y] = '.';
                        map[x, i] = 'O';
                    }
                    if (map[x, i] == '#')
                    {
                        map[x, y] = '.';
                        map[x, i - 1] = 'O';
                    }
                }
            }
        }

        for (int y = 0; y < input.Length; y++)
        {
            for (int x = input[0].Length - 1; x >= 0; x--)
            {
                if (map[x, y] == 'O' && x != input[0].Length - 1)
                {
                    int i = x;
                    do
                    {
                        i++;
                        if (i == input[0].Length)
                        {
                            i--;
                            break;
                        }
                    } while (map[i, y] != 'O' && map[i, y] != '#');

                    if (map[i, y] == 'O')
                    {
                        if (i - x == 1) continue;
                        map[x, y] = '.';
                        map[i - 1, y] = 'O';
                    }
                    if (map[i, y] == '.')
                    {
                        map[x, y] = '.';
                        map[i, y] = 'O';
                    }
                    if (map[i, y] == '#')
                    {
                        map[x, y] = '.';
                        map[i - 1, y] = 'O';
                    }
                }
            }
        }
    }

    int sum = 0;

    for (int i = 0; i < input.Length; i++)
    {
        for (int j = 0; j < input[0].Length; j++)
        {
            if (map[j, i] == 'O')
                sum += input.Length - i;
        }
    }

    return sum;
}

var input = File.ReadAllLines("input.txt");

Console.WriteLine("Part1: " + Part1(input));
Console.WriteLine("Part2: " + Part2(input));