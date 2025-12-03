using System.Globalization;

double PartOne(string[] input)
{
    var totalJoltage = 0;

    for (var i = 0; i < input.Length; i++)
    {
        var maxNumber = 0;
        for (int a = 0; a < input[i].Length; a++)
        {
            for (int b = a + 1; b < input[i].Length; b++)
            {
                var number = int.Parse(string.Concat(input[i][a].ToString(), input[i][b].ToString()));
                if (number > maxNumber)
                {
                    maxNumber = number;
                }
            }
        }

        totalJoltage += maxNumber;
    }

    return totalJoltage;
}

double PartTwo(string[] input)
{
    var finalCount = 0d;
    foreach (var line in input)
    {
        var currentLine = line;
        string finalNumberString = string.Empty;
        while (finalNumberString.Length != 12)
        {
            for (int j = 9; j > 0; j--)
            {
                for (int i = 0; i < currentLine.Length; i++)
                {
                    var jSting = j.ToString();
                    if (currentLine[i].ToString() == jSting)
                    {
                        if(currentLine.Length - i >= 12 - finalNumberString.Length)
                        {
                            finalNumberString += jSting;
                            currentLine = currentLine.Remove(0, i+1);
                            j = 10;
                            break;
                        }
                    }
                }
                if (finalNumberString.Length == 12)
                {
                    break;
                }
            }
        }

        finalCount += double.Parse(finalNumberString);
    }
    return finalCount;
}

var input = File.ReadAllLines("input.txt");

Console.WriteLine(PartOne(input));
Console.WriteLine(PartTwo(input));
