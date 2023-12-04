var input = await File.ReadAllLinesAsync("input.txt");
string[] stringNumbers = {"one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};
string[] numbers = {"1", "2", "3", "4", "5", "6", "7", "8", "9"};

var sumPart1 = GetSum(1);
var sumPart2 = GetSum(5);

Console.WriteLine($"The sum for part 1 is {sumPart1}");
Console.WriteLine($"The sum for part 2 is {sumPart2}");

int GetSum(int maxCharacters)
{
    var sum = 0;
    foreach (string line in input)
    {
        int first = 0, last = 0;

        var lowestIndex = line.Length;
        for (int a = 0; a < line.Length; a++)
        {
            for (int b = 1; b <= maxCharacters; b++)
            {
                int foundNumber = -1;
                if ((a + b) <= line.Length)
                {
                    if (b == 1)
                    {
                        foundNumber = Array.IndexOf(numbers, line.Substring(a, b));
                    }
                    else if (b >= 3)
                    {
                        foundNumber = Array.IndexOf(stringNumbers, line.Substring(a, b));
                    }
                }

                if (a <= lowestIndex && foundNumber != -1)
                {
                    lowestIndex = a;
                    first = foundNumber + 1;
                }
            }
        }

        var highestIndex = 0;
        for (int a = line.Length; a >= 0; a--)
        {
            for (int b = 1; b <= maxCharacters; b++)
            {
                int foundNumber = -1;
                if ((a + b) <= line.Length)
                {
                    if (b == 1)
                    {
                        foundNumber = Array.IndexOf(numbers, line.Substring(a, b));
                    }
                    else if (b >= 3)
                    {
                        foundNumber = Array.IndexOf(stringNumbers, line.Substring(a, b));
                    }
                }

                if (a >= highestIndex && foundNumber != -1)
                {
                    highestIndex = a;
                    last = foundNumber + 1;
                }
            }
        }

        int number = Convert.ToInt32($"{first}{last}");

        sum += number;
    }
    
    return sum;
}