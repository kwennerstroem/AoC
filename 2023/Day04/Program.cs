string[] input = File.ReadLines("input.txt").ToArray();

var sumPart1 = 0;
var sumPart2 = 0;

int[] cardCounts = new int[input.Length];

for (int i = 0; i < cardCounts.Length; i++)
    cardCounts[i] = 1;

for (int i = 0; i < input.Length; i++)
{
    var lists = input[i][(input[i].IndexOf(':') + 1)..].Split('|');

    string[] winningNumbers = lists[0].Trim().Replace("  ", " ").Split(' ');
    string[] numbers = lists[1].Trim().Replace("  ", " ").Split(' ');

    var lineSum = 0;
    var winningNumbersCount = 0;

    foreach(string number in numbers)
    {
        if (winningNumbers.Contains(number))
        {
            winningNumbersCount++;
            lineSum *= 2;
            if (lineSum == 0) lineSum = 1;
        }
    }

    for (int copy = i+1; copy <= i + winningNumbersCount && copy < cardCounts.Length; copy++)
    {
        cardCounts[copy] += cardCounts[i];
    }

    sumPart2 += winningNumbersCount * cardCounts[i]+1;
    sumPart1 += lineSum;
}

Console.WriteLine(sumPart1);
Console.WriteLine(sumPart2);
