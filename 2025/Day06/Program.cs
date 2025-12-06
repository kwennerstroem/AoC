double PartOne(string[] input)
{
    HashSet<MathItem> numbers = [];
    var firstline = Array.ConvertAll(input[0].Split( [' '], StringSplitOptions.RemoveEmptyEntries ), ulong.Parse);
    for(int x = 0; x < firstline.Length; x++)
    {
        numbers.Add(new(x, [firstline[x]]));
    }

    for(int i = 1; i < input.Length-1; i++)
    {
        var line = Array.ConvertAll(input[i].Split( [' '], StringSplitOptions.RemoveEmptyEntries ), ulong.Parse);
        for(int x = 0; x < firstline.Length; x++)
        {
            numbers.First(it => it.Index == x).Numbers.Add(line[x]);
        }
    }

    var ops = input[input.Length-1].Split( [' '], StringSplitOptions.RemoveEmptyEntries );
    for(int x = 0; x < firstline.Length; x++)
    {
        numbers.First(it => it.Index == x).Op = ops[x][0];
    }

    ulong total = 0;
    foreach(var item in numbers)
    {
        ulong calcultedNumber = 0;
        calcultedNumber = item.Numbers[0];
        for(int i = 1; i < item.Numbers.Count; i++)
        {
            if (item.Op == '+')
            {
                calcultedNumber += item.Numbers[i];
            }
            else
            {
                calcultedNumber *= item.Numbers[i];
            }
        }

        total += calcultedNumber;
    }
    return total;
}

double PartTwo(string[] input)
{
    HashSet<MathItemPart2> numbers = [];

    var lastLine = input[input.Length-1];
    for(int i = 0; i < lastLine.Length; i++)
    {
        if (lastLine[i] == '*' || lastLine[i] == '+')
        {
            var count = 1;
            while(i+count+1 == lastLine.Length || ( i+count+1 <= lastLine.Length && lastLine[i+count+1] == ' '))
            {
                count++;
            }

            numbers.Add(new(i, lastLine[i], count));
            i += count;
        }
    }

    foreach(var item in numbers)
    {
        for(int i = 0; i < input.Length-1; i++)
        {
            item.Numbers.Add(input[i].Substring(item.Index, item.NumberStringCount));
        }
    }

    ulong total = 0;
    foreach(var item in numbers)
    {
        var sortedNumbersByLength = item.Numbers.OrderByDescending(x => x.Length);
        ulong[] newNumbers = new ulong[sortedNumbersByLength.First().Length];
        
        for(int i = sortedNumbersByLength.First().Length; i >= 0; i--)
        {
            var newNumString = "";
            foreach(var num in sortedNumbersByLength)
            {
                try
                {
                    newNumString += num.PadRight(sortedNumbersByLength.First().Length - num.Length).ElementAt(i).ToString();
                }
                catch
                {
                    continue;
                }
            }

            if(newNumString.Length > 0)
                newNumbers[i] = ulong.Parse(newNumString);
        }

        ulong calcultedNumber = 0;
        calcultedNumber = newNumbers[0];
        for(int i = 1; i < newNumbers.Length; i++)
        {
            if (item.Op == '+')
            {
                calcultedNumber += newNumbers[i];
            }
            else
            {
                calcultedNumber *= newNumbers[i];
            }
        }

        total += calcultedNumber;
    }
    return total;
}


var input = File.ReadAllLines("input.txt");

Console.WriteLine(PartOne(input));
Console.WriteLine(PartTwo(input));


public class MathItem(int index, List<ulong> numbers)
{
    public int Index { get; set; } = index;
    public List<ulong> Numbers { get; set; } = numbers;
    public char Op {get; set;}
}

public class MathItemPart2(int index, char op, int count)
{
    public int Index { get; set; } = index;
    public List<string> Numbers {get; set;} = [];
    public char Op { get; set; } = op;
    public int NumberStringCount { get; set; } = count;
}