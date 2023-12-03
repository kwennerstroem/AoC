var input = await File.ReadAllLinesAsync("input.txt");

var sum = 0;
var gearSum = 0;

List<Tuple<Tuple<int, int>, int>> gearSymbols = new();

for (int y = 0; y < input.Length; y++)
{
    for (int x = 0; x < input.First().Length; x++)
    {
        if (char.IsDigit(input[y][x]))
        {
            int numberLength = 1;
            for (int index = x+1; index < input[y].Length && char.IsDigit(input[y][index]); index++)
            {
                numberLength++;
            }

            bool isValid = false;
            var number = int.Parse(input[y].Substring(x, numberLength));

            // Check if valid
            for (int i = x-1; i <= x + numberLength; i++)
            {
                if (i == -1 || i >= input.First().Length) { continue;}

                if (y != 0 && input[y-1][i] != '.')
                {
                    CheckForGear(y-1, i, number);
                    if (input[y-1][i] == '*') gearSymbols.Add(new (new(y-1, i), number));
                    isValid = true;
                    break;
                }

                if (y != input.Length-1 && input[y+1][i] != '.')
                {
                    CheckForGear(y+1, i, number);
                    if (input[y+1][i] == '*') gearSymbols.Add(new (new(y+1, i), number));
                    isValid = true;
                    break;
                }
            }
            if ((x+numberLength) != input.First().Length && input[y][x+numberLength] != '.')
            {
                CheckForGear(y, x+numberLength, number);
                if (input[y][x+numberLength] == '*') gearSymbols.Add(new (new(y, x+numberLength), number));
                isValid = true;
            }

            if (x != 0 && input[y][x-1] != '.')
            {
                CheckForGear(y, x-1, number);
                if (input[y][x-1] == '*') gearSymbols.Add(new (new(y, x-1), number));
                isValid = true;
            }

            if (isValid)
            {
                sum += number;
            }

            x += numberLength;
        }
    }
}

Console.WriteLine(sum);
Console.WriteLine(gearSum);

void CheckForGear(int y, int x, int number)
{
    var item = gearSymbols.FirstOrDefault(i => i.Item1.Item1 == y && i.Item1.Item2 == x);

    if (item == null) return;

    gearSymbols.Remove(item);

    int gearNumber = item.Item2 * number;
    gearSum += gearNumber;
}
