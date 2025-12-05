// Please dont look at this code

using System.Numerics;

double PartOne(string input)
{
    List<Tuple<double,double>> ranges = [];
    var rangesString = input.Split("\n\n")[0];
    foreach(var line in rangesString.Split("\n"))
    {
        var firstNumber = double.Parse(line.Split("-")[0]);
        var lastNumber = double.Parse(line.Split("-")[1]);

        ranges.Add(new Tuple<double, double>(firstNumber, lastNumber));
    }

    var totalCount = 0;

    var ingredientsString = input.Split("\n\n")[1];
    foreach(var line in ingredientsString.Split("\n"))
    {
        var number = double.Parse(line);

        foreach(var item in ranges)
        {
            if(number >= item.Item1 && number <= item.Item2)
            {
                totalCount++;
                break;
            }
        }
    }

    return totalCount;
}

BigInteger PartTwo(string input)
{
    BigInteger totalCount = 0;
    List<Tuple<BigInteger,BigInteger>> doneRanges = [];
    var rangesString = input.Split("\n\n")[0];
    var rangesfsdf = rangesString.Split("\n").ToList();
    for(int i = 0; i < rangesfsdf.Count; i++)
    {
        var firstNumber = BigInteger.Parse(rangesfsdf[i].Split("-")[0]);
        var lastNumber = BigInteger.Parse(rangesfsdf[i].Split("-")[1]);

        var test = false;
        var edge = false;

        foreach(var range in doneRanges)
        {
            if(firstNumber <= range.Item2 && firstNumber >= range.Item1 && lastNumber <= range.Item2 && lastNumber >= range.Item1)
            {
                test = true;
                break;
            }
            
            if (lastNumber >= range.Item1 && lastNumber <= range.Item2)
            {
                lastNumber = range.Item1-1;
            }

            if (firstNumber >= range.Item1 && firstNumber <= range.Item2)
            {
                firstNumber = range.Item2+1;
            }

            if (range.Item1 >= firstNumber && range.Item1 <= lastNumber)
            {
                rangesfsdf.Add($"{firstNumber}-{range.Item1-1}");
                rangesfsdf.Add($"{range.Item2+1}-{lastNumber}");
                test = true;
                edge = true;
                break;
            }
        }
        if (!test)
        {
            totalCount += lastNumber - firstNumber + 1;
        }

        if (!edge)
        {
            doneRanges.Add(new Tuple<BigInteger, BigInteger>(firstNumber, lastNumber));
        }
        
    }

    return totalCount;
}


var input = await File.ReadAllTextAsync("input.txt");

Console.WriteLine(PartOne(input));
Console.WriteLine(PartTwo(input));
