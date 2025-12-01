int PartOne(string[] input)
{
    var currentPosition = 50;
    var positionZeroCount = 0;

    foreach (var item in input)
    {
        var isRightToLeft = item[..1] == "L";
        if (isRightToLeft)
        {
            currentPosition -= int.Parse(item[1..]);
        }
        else
        {
            currentPosition += int.Parse(item[1..]);
        }

        currentPosition = ((currentPosition % 100) + 100) % 100;

        if (currentPosition == 0)
        {
            positionZeroCount++;
        }
    }

    return positionZeroCount;
}

int PartTwo(string[] input)
{
    var currentPosition = 50;
    var positionZeroCount = 0;

    foreach (var item in input)
    {
        var isRightToLeft = item[..1] == "L";
        var fullSpins = int.Parse(item[1..]) / 100;
        var restSpin = int.Parse(item[1..]) % 100;

        positionZeroCount += fullSpins;

        if (isRightToLeft)
        {
            if (currentPosition != 0 && currentPosition - restSpin <= 0)
            {
                positionZeroCount++;
            }

            currentPosition -= int.Parse(item[1..]);
        }
        else
        {
            if (currentPosition != 0 && currentPosition + restSpin >= 100)
            {
                positionZeroCount++;
            }

            currentPosition += int.Parse(item[1..]);
        }

        currentPosition = ((currentPosition % 100) + 100) % 100;
    }

    return positionZeroCount;
}

var input = File.ReadAllLines("input.txt");

Console.WriteLine(PartOne(input));
Console.WriteLine(PartTwo(input));
