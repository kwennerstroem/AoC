double PartOne(string[] input)
{
    var totalCount = 0;
    for (int x = 0; x < input[0].Length; x++)
    {
        for (int y = 0; y < input.Length; y++)
        {
            if (CheckPosition(input, x, y))
                totalCount++;
        }
    }
    return totalCount;
}

double PartTwo(string[] input)
{
    var totalCount = 0;
    for (int x = 0; x < input[0].Length; x++)
    {
        for (int y = 0; y < input.Length; y++)
        {
            var isRemoveable = CheckPosition(input, x, y);
            if (isRemoveable)
            {
                input[y] = input[y].Remove(x, 1).Insert(x, ".");
                totalCount++;
                x = 0;
                y = 0;
            }
        }
    }

    return totalCount;
}

bool CheckPosition(string[] input, int x, int y)
{
    if (input[y][x] == '.')
        return false;

    var count = 0;
    // Top Left
    if (x > 0 && y > 0 && input[y - 1][x - 1] == '@')
        count++;

    // Top middle
    if (y > 0 && input[y - 1][x] == '@')
        count++;

    // Top right
    if (x < input[0].Length - 1 && y > 0 && input[y - 1][x + 1] == '@')
        count++;

    // Middle Left
    if (x > 0 && input[y][x - 1] == '@')
        count++;

    // Middle right
    if (x < input[0].Length - 1 && input[y][x + 1] == '@')
        count++;

    // Bottom Left
    if (x > 0 && y < input.Length - 1 && input[y + 1][x - 1] == '@')
        count++;

    // Bottom middle
    if (y < input.Length - 1 && input[y + 1][x] == '@')
        count++;

    // Bottom right
    if (x < input[0].Length - 1 && y < input.Length - 1 && input[y + 1][x + 1] == '@')
        count++;

    if (count < 4)
        return true;
    
    return false;
}

var input = File.ReadAllLines("input.txt");

Console.WriteLine(PartOne(input));
Console.WriteLine(PartTwo(input));
