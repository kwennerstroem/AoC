internal class Program
{
    private static void Main(string[] args)
    {
        int Part1(string input)
        {
            var sequences = input.Split(',');
            var sum = 0;

            foreach (var sequence in sequences)
            {
                sum += GetHashValue(sequence);
            }

            return sum;
        }

        int Part2(string input)
        {
            Box[] boxes = new Box[256];
            for (int i = 0; i < 256; i++) boxes[i] = new Box();
            foreach (var sequence in input.Split(','))
            {
                var boxString = sequence.Substring(0, sequence.IndexOfAny(new char[]{ '-', '=' }));
                var box = GetHashValue(boxString);
                var operation = sequence[sequence.IndexOfAny(new char[]{ '-', '=' })];
                var focalLength = sequence[(sequence.IndexOfAny(new char[]{ '-', '=' })+1)..];

                if (operation == '=')
                {
                    int index = boxes[box].Lenses.FindIndex(x => x.Name == boxString);
                    if (index != -1)
                        boxes[box].Lenses[index] = new Lense(boxString, focalLength);
                    else
                        boxes[box].Lenses.Add(new Lense(boxString, focalLength));
                }
                else
                {
                    int index = boxes[box].Lenses.FindIndex(x => x.Name == boxString);
                    if (index != -1)
                        boxes[box].Lenses.RemoveAt(index);
                }

            }

            var sum = 0;

            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < boxes[i].Lenses.Count; j++)
                {
                    sum += (i+1) * (j+1) * int.Parse(boxes[i].Lenses[j].FocalLength);
                }
            }

            return sum;
        }

        int GetHashValue(string value)
        {
            int[] asciCodes = new int[value.Length];
            for (int i = 0; i < value.Length; i++)
                asciCodes[i] = value[i];

            var currentValue = 0;
            foreach (var code in asciCodes)
            {
                currentValue = (currentValue + code) * 17 % 256;
            }

            return currentValue;
        }

        var input = File.ReadAllText("input.txt");

        Console.WriteLine("Part1: " + Part1(input));
        Console.WriteLine("Part2: " + Part2(input));
    }
}

class Box
{
    public List<Lense> Lenses { get; set; } = new();
}

record struct Lense(string Name, string FocalLength);
