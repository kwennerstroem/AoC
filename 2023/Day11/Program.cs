
internal class Program
{
    public record Position(int x, int y);
    private static void Main(string[] args)
    {
        var input = File.ReadAllLines("input.txt");

        Console.WriteLine("Part1: " + Part1(input));
        Console.WriteLine("Part2: " + Part2(input));
    }

    static long Part1(string[] input)
    {
        return GetSum(input, 1);
    }

    static long Part2(string[] input)
    {
        return GetSum(input, 1000000);
    }

    static long GetSum(string[] input, int emptySpace)
    {
        List<Position> galaxies = new();
        for (int y = 0; y < input.Length; y++)
            for (int x = 0; x < input[y].Length; x++)
            {
                if (input[y][x] == '#')
                    galaxies.Add(new(x, y));
            }

        long sum = 0;

        var expandCols = GetColsWithoutGalaxy(input);
        var expandRows = GetRowsWithoutGalaxy(input);

        for (int i = 0; i < galaxies.Count; i++)
        {
            for (int j = galaxies.Count - 1; j >= 0 + i; j--)
            {
                int cols = expandCols.Where(x => x > Math.Min(galaxies[i].x, galaxies[j].x) && x < Math.Max(galaxies[i].x, galaxies[j].x)).Count();
                int rows = expandRows.Where(y => y > Math.Min(galaxies[i].y, galaxies[j].y) && y < Math.Max(galaxies[i].y, galaxies[j].y)).Count();
                long xDis = Math.Abs(galaxies[i].x - galaxies[j].x) + (emptySpace * cols);
                long yDis = Math.Abs(galaxies[i].y - galaxies[j].y) + (emptySpace * rows);

                if (emptySpace != 1)
                {
                    xDis -= 1 * cols;
                    yDis -= 1 * rows;
                }

                sum += xDis + yDis;
            }
        }

        return sum;
    }

    static int[] GetColsWithoutGalaxy(string[] input)
    {
        List<int> cols = new();
        for (int c = 0; c < input[0].Length; c++)
        {
            bool isEmpty = true;
            for (int r = 0; r < input.Length; r++)
            {
                if (input[r][c] == '#')
                {
                    isEmpty = false;
                    break;
                }
            }

            if (isEmpty)
            {
                cols.Add(c);
            }
        }

        return cols.ToArray();
    }

    static int[] GetRowsWithoutGalaxy(string[] input)
    {
        List<int> rows = new();
        for (int r = 0; r < input.Length; r++)
        {
            bool isEmpty = true;
            for (int c = 0; c < input[r].Length; c++)
            {
                if (input[r][c] == '#')
                {
                    isEmpty = false;
                    break;
                }
            }

            if (isEmpty)
            {
                rows.Add(r);
            }
        }

        return rows.ToArray();
    }
}