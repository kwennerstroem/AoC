using System.Collections;



internal class Program
{
    private static void Main(string[] args)
    {
        static long Part1(string input)
        {
            var parts = input.Split("\n\n");
            var seedsInput = parts[0][6..].Trim().Split(' ');
            var mapsInput = parts[1..];
            var lowestNumber = long.MaxValue;

            foreach (var seed in seedsInput)
            {
                long currentNumber = long.Parse(seed);

                foreach (string map in mapsInput)
                {
                    var lines = map.Split("\n");

                    for (int i = 1; i < lines.Length; i++)
                    {
                        var lineNumber = lines[i].Split(" ");
                        var destinationRangeStart = long.Parse(lineNumber[0]);
                        var sourceRangeStart = long.Parse(lineNumber[1]);
                        var range = long.Parse(lineNumber[2]);

                        if (currentNumber > sourceRangeStart && currentNumber < sourceRangeStart + range)
                        {
                            currentNumber += destinationRangeStart - sourceRangeStart;
                            break;
                        }
                    }
                }

                if (lowestNumber > currentNumber)
                    lowestNumber = currentNumber;
            }

            return lowestNumber;
        }

        static long Part2(string input)
        {
            var parts = input.Split("\n\n");
            var seedsInput = parts[0][6..].Trim().Split(' ');
            var mapsInput = parts[1..];
            long lowestNumber = long.MaxValue;

            List<HashSet<Mapping>> mappings = new();

            for (int m = 0; m < mapsInput.Length; m++)
            {
                var lines = mapsInput[m].Split("\n");

                HashSet<Mapping> mapMappings = new();

                for (int i = 1; i < lines.Length; i++)
                {
                    var sourceRangeStart = long.Parse(lines[i].Split(" ")[1]);
                    var range = long.Parse(lines[i].Split(" ")[2]);
                    Mapping mapping = new()
                    {
                        SourceRangeStart = sourceRangeStart,
                        Range = range,
                        DestinationRangeStart = long.Parse(lines[i].Split(" ")[0]),
                        SourceRangeEnd = sourceRangeStart + range
                    };

                    mapMappings.Add(mapping);
                }

                mappings.Add(mapMappings);
            }


            var seedsLength = seedsInput.Length;
            for (int y = 0; y < seedsLength - 1; y += 2)
            {
                long seedI = Convert.ToInt64(seedsInput[y]);
                long rangeI = Convert.ToInt64(seedsInput[y + 1]);

                for (long seedJ = seedI; seedJ <= seedI + rangeI; seedJ++)
                {

                    long currentNumber = seedJ;

                    foreach (var mapMapping in mappings)
                    {
                        var mapping = mapMapping.FirstOrDefault(x => currentNumber > x.SourceRangeStart && currentNumber < x.SourceRangeEnd);
                        
                        if (mapping == null) continue;

                        currentNumber += mapping.DestinationRangeStart - mapping.SourceRangeStart;
                    }

                    if (lowestNumber > currentNumber)
                    {
                        lowestNumber = currentNumber;
                    }
                }
                Console.WriteLine("Done");
            }

            return lowestNumber-1;
        }

        var input = File.ReadAllText("input.txt");
        Console.WriteLine("Part 1: " + Part1(input));
        Console.WriteLine("Part 2: " + Part2(input)); // so slow that I had to run it for 1h but it works

        Console.ReadLine();
    }
}

class Mapping
{
    public long SourceRangeStart { get; set; }
    public long Range { get; set; }
    public long SourceRangeEnd { get; set; }
    public long DestinationRangeStart { get; set; }
}
