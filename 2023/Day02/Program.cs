var input = await File.ReadAllLinesAsync("input.txt");

Console.WriteLine("Possible Games: " + GetNumberOfPossibleGames(input));
Console.WriteLine("Sum of powers: " + GetSumOfPowers(input));

// Part 1
int GetNumberOfPossibleGames(string[] input)
{
    var possibleGames = 0;

    foreach (string line in input)
    {
        var gameLists = line[(line.IndexOf(':') + 1)..].Split(";");

        bool isGamePossible = true;

        foreach (string list in gameLists)
        {
            int reds = GetNumber(list, "red");
            int greens = GetNumber(list, "green");
            int blues = GetNumber(list, "blue");

            if (reds > 12
                || greens > 13
                || blues > 14)
            {
                isGamePossible = false;
                break;
            }
        }

        if (isGamePossible)
            possibleGames += int.Parse(line[..line.IndexOf(':')].Split(' ').Last());
    }

    return possibleGames;
}

// Part 2
int GetSumOfPowers(string[] input)
{
    var sum = 0;

    foreach (string line in input)
    {
        var items = line[(line.IndexOf(':') + 1)..].Split(new[] {',', ';'});

        int reds = GetHighestNumber(items, "red");
        int greens = GetHighestNumber(items, "green");
        int blues = GetHighestNumber(items, "blue");

        int power = reds * greens * blues;
        sum += power;
    }

    return sum;
}

#region Helper Methods

int GetNumber(string text, string color)
{
    string? value = text.Split(',').FirstOrDefault(x => x.Contains(color));
    return value == null ? 0 : int.Parse(value.Trim().Split(" ").First());
}

int GetHighestNumber(string[] items, string color)
{
    IEnumerable<string> filteredItems = items.Where(x => x.Contains(color));
    if (!filteredItems.Any())
        return 0;

    var highestNumber = 0;
    foreach(var item in filteredItems)
    {
        var number = int.Parse(item.Trim().Split(" ").First());
        if (number > highestNumber)
            highestNumber = number;
    }

    return highestNumber;
}

#endregion Helper Methods