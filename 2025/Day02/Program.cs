using System.Text.RegularExpressions;

double PartOne(string[] input)
{
    var result = 0d;

    foreach(var item in input)
    {
        var first = double.Parse(item.Split("-")[0]);
        var last = double.Parse(item.Split("-")[1]);

        for(double i = first; i <= last; i++)
        {
            var numberAsString = i.ToString();
            if (numberAsString[..(numberAsString.Length / 2)] == numberAsString[(numberAsString.Length / 2)..])
            {
                var number = double.Parse(numberAsString);
                result += number;
            }
        }
    }
    return result;
}

double PartTwo(string[] input)
{
    var result = 0d;

    foreach(var item in input)
    {
        var first = double.Parse(item.Split("-")[0]);
        var last = double.Parse(item.Split("-")[1]);

        for(double i = first; i <= last; i++)
        {
            var numberAsString = i.ToString();
            for(int y = 1; y <= numberAsString.Length / 2; y++)
            {
                var number = int.Parse(numberAsString.Substring(0, y));

                if (number == 0) break;

                for (int b = y; b <= numberAsString.Length - number.ToString().Length; b += number.ToString().Length)
                {
                    if (int.Parse(numberAsString.Substring(b, number.ToString().Length)) == number)
                    {
                        if (b == numberAsString.Length - number.ToString().Length)
                        {
                            result += double.Parse(numberAsString);
                            y = numberAsString.Length;
                            break;
                        }
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }
    return result;
}

var input = await File.ReadAllTextAsync("input.txt");

Console.WriteLine(PartOne(input.Split(",")));
Console.WriteLine(PartTwo(input.Split(",")));
