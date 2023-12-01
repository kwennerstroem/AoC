var input = await File.ReadAllLinesAsync("input.txt");
string[] stringNumbers = [ "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" ];
string[] numbers = [ "1", "2", "3", "4", "5", "6", "7", "8", "9" ];

int sum = 0;

foreach (string line in input)
{
    int first = 0, last = 0;

    var lowestIndex = line.Length;
    for (int a = 0; a < line.Length; a++)
    {
        for (int b = 1; b <= 5; b++)
        {
            int foundNumber = -1;
            if ((a+b) <= line.Length)
            {
                if (b == 1)
                {
                    foundNumber = Array.IndexOf(numbers, line.Substring(a, b));
                }else if (b >= 3)
                {
                    foundNumber = Array.IndexOf(stringNumbers, line.Substring(a, b));
                }
            }

            if (a <= lowestIndex && foundNumber != -1)
            {
                lowestIndex = a;
                first = foundNumber+1;
            } 
        }
    }

    var highestIndex = 0;
    for (int a = line.Length; a >= 0; a--)
    {
        for (int b = 1; b <= 5; b++)
        {
            int foundNumber = -1;
            if ((a+b) <= line.Length)
            {
                if (b == 1)
                {
                    foundNumber = Array.IndexOf(numbers, line.Substring(a, b));
                }else if (b >= 3)
                {
                    foundNumber = Array.IndexOf(stringNumbers, line.Substring(a, b));
                }
            }
            
            if (a >= highestIndex && foundNumber != -1)
            {
                highestIndex = a;
                last = foundNumber+1;
            } 
        }
    }

    int number = Convert.ToInt32($"{first}{last}");

    sum += number;
}

Console.WriteLine($"The sum is {sum}");