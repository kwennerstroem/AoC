int PartOne(string[] input)
{
    List<int> list1 = [], list2 = [];

    foreach (var line in input)
    {
        var parts = line.Split("   ");
        list1.Add(int.Parse(parts[0]));
        list2.Add(int.Parse(parts[1]));
    }

    list1.Sort();
    list2.Sort();

    return list1.Select((t, i) => Math.Abs(t - list2[i])).Sum();
}

int PartTwo(string[] input)
{
    List<int> list1 = [], list2 = [];

    foreach (var line in input)
    {
        var parts = line.Split("   ");
        list1.Add(int.Parse(parts[0]));
        list2.Add(int.Parse(parts[1]));
    }

    return (from item in list1 let count = list2.Count(x => x == item) select item * count).Sum();
}

var input = File.ReadAllLines("input.txt");

Console.WriteLine(PartOne(input));
Console.WriteLine(PartTwo(input));