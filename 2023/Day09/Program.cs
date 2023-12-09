long Part1(string[] input)
{
    long sum = 0;

    foreach (var line in input)
    {
        List<List<long>> values = new()
        {
            new()
        };
        foreach (var item in line.Split(' '))
        {
            values.First().Add(long.Parse(item));
        }

        while (!values.Last().All(x => x == 0))
        {
            var currentList = values.Last();
            values.Add(new());
            for (int i = 0; i < currentList.Count-1; i++)
            {
                values.Last().Add(currentList[i+1] - currentList[i]);
            }
        }

        long addValue = 0;

        for (int i = values.Count-2; i >= 0; i--)
        {
            addValue += values[i].Last();
        }

        sum += addValue;
    }

    return sum;
}

long Part2(string[] input)
{
    for (int i = 0; i < input.Length; i++)
    {
        input[i] = string.Join(" ", input[i].Split(' ').Reverse());
    }
    return Part1(input);
}

var inputf = File.ReadAllLines("input.txt");

Console.WriteLine("Part1: " + Part1(inputf));
Console.WriteLine("Part2: " + Part2(inputf));