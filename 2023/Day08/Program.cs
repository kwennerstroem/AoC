int Part1(string[] input)
{
    string instructions = input[0];

    int step = 0;

    var currentLocation = "AAA";

    while (currentLocation != "ZZZ")
    {
        foreach (char instruction in instructions)
        {
            string line = input.First(x => x.StartsWith(currentLocation));

            if (instruction == 'L')
                currentLocation = line.Substring(7, 3);
            else
                currentLocation = line.Substring(12, 3);

            step++;
        }
    }

    return step;
}

long Part2(string[] input)
{
    string instructions = input[0];

    int GetSteps(string currentLocation)
    {
        int step = 0;
        while (!currentLocation.EndsWith('Z'))
        {
            foreach (char instruction in instructions)
            {
                string line = input.First(x => x.StartsWith(currentLocation));

                if (instruction == 'L')
                    currentLocation = line.Substring(7, 3);
                else
                    currentLocation = line.Substring(12, 3);

                step++;
            }
        }

        return step;
    }

    long LcmArray(long[] numbers)
    {
        return numbers.Aggregate(Lcm);
    }
    long Lcm(long a, long b)
    {
        return Math.Abs(a * b) / Gdc(a, b);
    }
    long Gdc(long a, long b)
    {
        return b == 0 ? a : Gdc(b, a % b);
    }

    var startingLocations = input[2..].Where(x => x.ElementAt(2) == 'A');

    List<long> lengths = new();

    foreach (var startingLocation in startingLocations)
    {
        lengths.Add(GetSteps(startingLocation[..3]));
    }

    return LcmArray(lengths.ToArray());
}

var input = File.ReadAllLines("input.txt");

Console.WriteLine("Part1: " + Part1(input));
Console.WriteLine("Part2: " + Part2(input));
