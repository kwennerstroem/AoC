static int Part1(string[] input)
{
    var timeStrings = input[0][11..].Trim().Split("   ");
    var recordStrings = input[1][11..].Trim().Split("   ");

    var length = timeStrings.Length;

    var times = new int[length];
    var records = new int[length];
    for (int i = 0; i < length; i++)
    {
        times[i] = int.Parse(timeStrings[i]);
        records[i] = int.Parse(recordStrings[i]);
    }

    var sum = 1;

    for (int timeIndex = 0; timeIndex < length; timeIndex++)
    {
        int record = records[timeIndex];
        int time = times[timeIndex];

        var winCount = 0;

        for (int i = Math.Abs((time - 1) / 2); i >= 0; i--)
        {
            var distance = i * (time - i);
            if (distance > record)
            {
                winCount++;
            }
            else
            {
                break;
            }
        }

        winCount *= 2;

        if ((time - 1) / 2d % 1 != 0)
            winCount++;

        sum *= winCount;
    }
    return sum;
}

static int Part2(string[] input)
{
    long time = long.Parse(input[0][11..].Replace(" ", ""));
    long record = long.Parse(input[1][11..].Replace(" ", ""));

    var sum = 1;
    var winCount = 0;

    for (long i = Math.Abs((time - 1) / 2); i >= 0; i--)
    {
        var distance = i * (time - i);
        if (distance > record)
        {
            winCount++;
        }
        else
        {
            break;
        }
    }

    winCount *= 2;

    if ((time - 1) / 2d % 1 != 0)
        winCount++;

    sum *= winCount;
    return sum;
}

string[] input = File.ReadAllLines("input.txt");

Console.WriteLine($"Part 1: {Part1(input)}");
Console.WriteLine($"Part 2: {Part2(input)}");