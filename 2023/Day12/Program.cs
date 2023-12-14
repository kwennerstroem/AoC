using System.Drawing;
using System.Text.RegularExpressions;

var input = File.ReadAllLines("input.txt");

var sum = 0;

foreach (var line in input)
{
    var springs = line.Split(' ')[0];
    var lengths = line.Split(' ')[1].Split(',');
    List<int> unknown = [];
    for (var i = 0; i < springs.Length; i++)
    {
        if (springs[i] == '?')
            unknown.Add(i);
    }

    List<char[]> combinations = [];
    for (int i = 0; i <= Math.Pow(2, unknown.Count)-1; i++)
    {
        var number = Convert.ToString(i, 2).PadLeft(unknown.Count, '0');

        var text = springs.ToCharArray();
        for (var e = 0; e < unknown.Count; e++)
        {
            if (number[e] == '0')
                text[unknown[e]] = '.';
            else
                text[unknown[e]] = '#';
        }
        
        combinations.Add(text);
    }

    var count = 0;
    
    foreach (var combination in combinations)
    {
        var comb = new string(combination);
        if (comb == null) continue;

        string defectRegexString = "[#]{x}";
        string notDefectRegexString = "[.]+";

        string regexString = "[.]*";

        foreach (var l in lengths)
        {
            regexString += defectRegexString.Replace("x", l);
            regexString += notDefectRegexString;
        }

        regexString = regexString[..^1];
        regexString += "*";

        Regex regex = new(regexString);

        if (regex.Match(comb).Length == comb.Length)
        {
            count++;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(comb);
            Console.ForegroundColor = ConsoleColor.White;
        }
        else{
            Console.WriteLine(comb);
        }
    }
    sum += count;

    Console.WriteLine();
}

Console.WriteLine(sum);