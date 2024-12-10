var input = File.ReadAllLines("input.txt");
var map = new int[input.Length, input.Length];

for (var row = 0; row < input.Length; row++)
{
    for (var col = 0; col < input.Length; col++)
    {
        map[row, col] = int.Parse(input[row][col].ToString());
    }
}

List<(int, int)> visitedTrailheads = [];

int GetTrailheadsCount(int x, int y, int height, bool multipleAtNine)
{
    if (height == 9 && (multipleAtNine || !visitedTrailheads.Contains((x, y))))
    {
        if (!multipleAtNine)
            visitedTrailheads.Add((x, y));
        return 1;
    }

    var count = 0;

    // Define neighbors (row offset, column offset)
    var neighbors = new (int, int)[]
    {
        (-1, 0), (1, 0), (0, -1), (0, 1)
    };

    foreach (var (dx, dy) in neighbors)
    {
        int nx = x + dx, ny = y + dy;
        if (nx >= 0 && nx < input.Length && ny >= 0 && ny < input[nx].Length)
        {
            if (map[nx, ny] == height + 1)
                count += GetTrailheadsCount(nx, ny, height + 1, multipleAtNine);
        }
    }

    return count;
}

int CalculateSum(bool multipleAtNine)
{
    var sum = 0;

    for (var x = 0; x < input.Length; x++)
    {
        for (var y = 0; y < input[x].Length; y++)
        {
            if (map[x, y] == 0)
            {
                visitedTrailheads.Clear();
                sum += GetTrailheadsCount(x, y, 0, multipleAtNine);
            }
        }
    }

    return sum;
}

Console.WriteLine("Part 1 Sum: " + CalculateSum(false));
Console.WriteLine("Part 2 Sum: " + CalculateSum(true));