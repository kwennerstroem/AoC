internal class Program
{
    private static void Main(string[] args)
    {
        var input = File.ReadAllLines("input.txt");
        Console.WriteLine(Part1(input));
        Console.WriteLine(Part2(input));
    }

    static long Part2(string[] input)
    {
        Position sPos = new(0, 0);
        char[,] tilemap = new char[input[0].Length, input.Length];
        for (int y = 0; y < input.Length; y++)
        {
            for (int x = 0; x < input[y].Length; x++)
            {
                tilemap[x, y] = input[y][x];
                if (tilemap[x, y] == 'S')
                    sPos = new(x, y);
            }
        }

        Position currentPos;
        Direction lastDirection;

        if (sPos.X != 0 && new[] { '-', 'L', 'F' }.Contains(tilemap[sPos.X - 1, sPos.Y])) // west
        {
            currentPos = new(sPos.X - 1, sPos.Y);
            lastDirection = Direction.West;
        }
        else if (sPos.X != input[0].Length && new[] { '-', 'J', '7' }.Contains(tilemap[sPos.X + 1, sPos.Y])) // east 
        {
            currentPos = new(sPos.X + 1, sPos.Y);
            lastDirection = Direction.East;
        }
        else if (sPos.Y != 0 && new[] { '|', 'F', '7' }.Contains(tilemap[sPos.X, sPos.Y - 1])) // north
        {
            currentPos = new(sPos.X, sPos.Y - 1);
            lastDirection = Direction.North;
        }
        else // south
        {
            currentPos = new(sPos.X, sPos.Y + 1);
            lastDirection = Direction.South;
        }


        List<Position> path = new();
        path.Add(currentPos);
        path.Add(sPos);
        

        while (currentPos != sPos)
        {
            var direction = GetNextDirection(lastDirection, tilemap[currentPos.X, currentPos.Y]);

            if (direction == null) break;

            currentPos = GetNextPosition((Direction)direction, currentPos);

            path.Add(currentPos);
            lastDirection = (Direction)direction;
        }

        tilemap[sPos.X, sPos.Y] = '|'; // Hard coded but will it change later

        var count = 0;

        for (int y = 0; y < input.Length; y++)
        {
            bool isOutside = true;
            bool fStart = false;
            bool lStart = false;
            for (int x = 0; x < input[0].Length; x++)
            {
                if (path.Contains(new Position(x, y)))
                {
                    var tile = tilemap[x,y];
                    if (tile == '|')
                    {
                        isOutside = !isOutside;
                    }

                    if (tile == '-') continue;

                    if (fStart)
                    {
                        if (tile == 'J')
                        {
                            fStart = false;
                            isOutside = !isOutside;
                        }
                        else if (tile == '7')
                        {
                            fStart = false;
                        }
                    }
                    else if (lStart)
                    {
                        if (tile == '7')
                        {
                            lStart = false;
                            isOutside = !isOutside;
                        }
                        else if (tile == 'J')
                        {
                            lStart = false;
                        }
                    }
                    else
                    {
                        if (tile == 'F')
                        {
                            fStart = true;
                        }
                        else if (tile == 'L')
                        {
                            lStart = true;
                        }
                    }
                }
                else{
                    if (!isOutside)
                        count++;
                }
            }
        }

        return count;
    }

    static long Part1(string[] input)
    {
        Position sPos = new(0, 0);
        char[,] tilemap = new char[input[0].Length, input.Length];
        for (int y = 0; y < input.Length; y++)
        {
            for (int x = 0; x < input[y].Length; x++)
            {
                tilemap[x, y] = input[y][x];
                if (tilemap[x, y] == 'S')
                    sPos = new(x, y);
            }
        }

        Position currentPos;
        Direction lastDirection;

        if (sPos.X != 0 && new[] { '-', 'L', 'F' }.Contains(tilemap[sPos.X - 1, sPos.Y])) // west
        {
            currentPos = new(sPos.X - 1, sPos.Y);
            lastDirection = Direction.West;
        }
        else if (sPos.X != input[0].Length && new[] { '-', 'J', '7' }.Contains(tilemap[sPos.X + 1, sPos.Y])) // east 
        {
            currentPos = new(sPos.X + 1, sPos.Y);
            lastDirection = Direction.East;
        }
        else if (sPos.Y != 0 && new[] { '|', 'F', '7' }.Contains(tilemap[sPos.X, sPos.Y - 1])) // north
        {
            currentPos = new(sPos.X, sPos.Y - 1);
            lastDirection = Direction.North;
        }
        else // south
        {
            currentPos = new(sPos.X, sPos.Y + 1);
            lastDirection = Direction.South;
        }


        var distance = 1;

        while (currentPos != sPos)
        {
            var direction = GetNextDirection(lastDirection, tilemap[currentPos.X, currentPos.Y]);

            if (direction == null) break;

            currentPos = GetNextPosition((Direction)direction, currentPos);

            distance++;
            lastDirection = (Direction)direction;
        }

        return distance / 2;
    }

    static Position GetNextPosition(Direction direction, Position currentPosition)
    {
        return direction switch
        {
            Direction.West => new(currentPosition.X - 1, currentPosition.Y),
            Direction.East => new(currentPosition.X + 1, currentPosition.Y),
            Direction.North => new(currentPosition.X, currentPosition.Y - 1),
            Direction.South => new(currentPosition.X, currentPosition.Y + 1),
            _ => throw new NotImplementedException()
        };
    }

    static Direction? GetNextDirection(Direction lastDir, char tile)
    {
        switch (tile)
        {
            case '-':
                if (lastDir == Direction.West)
                    return Direction.West;
                return Direction.East;
            case '|':
                if (lastDir == Direction.North)
                    return Direction.North;
                return Direction.South;
            case 'L':
                if (lastDir == Direction.South)
                    return Direction.East;
                return Direction.North;
            case 'J':
                if (lastDir == Direction.South)
                    return Direction.West;
                return Direction.North;
            case '7':
                if (lastDir == Direction.North)
                    return Direction.West;
                return Direction.South;
            case 'F':
                if (lastDir == Direction.North)
                    return Direction.East;
                return Direction.South;
            default:
                return null;
        }
    }

    enum Direction
    {
        West,
        East,
        North,
        South
    }
    record Position(int X, int Y);
}