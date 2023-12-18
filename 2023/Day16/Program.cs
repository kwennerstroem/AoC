
int Part1(string[] input)
{
    var tilemap = new char[input[0].Length, input.Length];
    for (var y = 0; y < input.Length; y++)
    {
        for (var x = 0; x < input[y].Length; x++)
        {
            tilemap[x, y] = input[y][x];
        }
    }

    var direction = Direction.Right;
    var position = new Position(0, 0);
    var visited = new bool[input[0].Length, input.Length];
    Move(position, direction);


    void Move(Position pos, Direction direction)
    {
        while (true)
        {
            if (pos.X < 0 || pos.Y < 0)
                return;
            if (pos.X >= input[0].Length || pos.Y >= input.Length)
                return;

            switch (tilemap[pos.X, pos.Y])
            {
                case '.':
                    break;
                case '/':
                    switch (direction)
                    {
                        case Direction.Left:
                            direction = Direction.Down;
                            break;
                        case Direction.Up:
                            direction = Direction.Right;
                            break;
                        case Direction.Right:
                            direction = Direction.Up;
                            break;
                        case Direction.Down:
                            direction = Direction.Left;
                            break;
                    }
                    break;
                case '\\':
                    switch (direction)
                    {
                        case Direction.Left:
                            direction = Direction.Up;
                            break;
                        case Direction.Up:
                            direction = Direction.Left;
                            break;
                        case Direction.Right:
                            direction = Direction.Down;
                            break;
                        case Direction.Down:
                            direction = Direction.Right;
                            break;
                    }
                    break;
                case '-':
                    switch (direction)
                    {
                        case Direction.Left:
                            direction = Direction.Left;
                            break;
                        case Direction.Up:
                            if (visited[pos.X, pos.Y] == true) return;
                            visited[pos.X, pos.Y] = true;
                            Move(new Position(pos.X - 1, pos.Y), Direction.Left);
                            Move(new Position(pos.X + 1, pos.Y), Direction.Right);
                            return;
                        case Direction.Right:
                            direction = Direction.Right;
                            break;
                        case Direction.Down:
                            if (visited[pos.X, pos.Y] == true) return;
                            visited[pos.X, pos.Y] = true;
                            Move(new Position(pos.X - 1, pos.Y), Direction.Left);
                            Move(new Position(pos.X + 1, pos.Y), Direction.Right);
                            return;
                    }
                    break;
                case '|':
                    switch (direction)
                    {
                        case Direction.Left:
                            if (visited[pos.X, pos.Y] == true) return;
                            visited[pos.X, pos.Y] = true;
                            Move(new Position(pos.X, pos.Y - 1), Direction.Up);
                            Move(new Position(pos.X, pos.Y + 1), Direction.Down);
                            return;
                        case Direction.Up:
                            direction = Direction.Up;
                            break;
                        case Direction.Right:
                            if (visited[pos.X, pos.Y] == true) return;
                            visited[pos.X, pos.Y] = true;
                            Move(new Position(pos.X, pos.Y - 1), Direction.Up);
                            Move(new Position(pos.X, pos.Y + 1), Direction.Down);
                            return;
                        case Direction.Down:
                            direction = Direction.Down;
                            break;
                    }
                    break;
            }

            visited[pos.X, pos.Y] = true;
            pos.Move(direction);
        }
    }

    var sum = 0;

    for (var y = 0; y < input.Length; y++)
    {
        for (var x = 0; x < input[y].Length; x++)
        {
            if (visited[x, y] == true)
            {
                sum++;
                Console.Write('#');
            }
            else
            {
                Console.Write('.');
            }
        }
        Console.Write("\n");
    }

    return sum;
}

int Part2(string[] input)
{
    var tilemap = new char[input[0].Length, input.Length];
    for (var y = 0; y < input.Length; y++)
    {
        for (var x = 0; x < input[y].Length; x++)
        {
            tilemap[x, y] = input[y][x];
        }
    }

    var bestSum = 0;

    for (int x = 0; x < input[0].Length; x++)
    {
        for (int y = 0; y < input.Length; y++)
        {
            foreach (Direction dir in Enum.GetValues(typeof(Direction)))
            {
                var direction = dir;
                var position = new Position(x, y);
                var startPos = position;
                var visited = new bool[input[0].Length, input.Length];
                Move(position, direction);

                void Move(Position pos, Direction direction)
                {
                    while (true)
                    {
                        if (pos.X < 0 || pos.Y < 0)
                            return;
                        if (pos.X >= input[0].Length || pos.Y >= input.Length)
                            return;

                        switch (tilemap[pos.X, pos.Y])
                        {
                            case '.':
                                break;
                            case '/':
                                switch (direction)
                                {
                                    case Direction.Left:
                                        direction = Direction.Down;
                                        break;
                                    case Direction.Up:
                                        direction = Direction.Right;
                                        break;
                                    case Direction.Right:
                                        direction = Direction.Up;
                                        break;
                                    case Direction.Down:
                                        direction = Direction.Left;
                                        break;
                                }
                                break;
                            case '\\':
                                switch (direction)
                                {
                                    case Direction.Left:
                                        direction = Direction.Up;
                                        break;
                                    case Direction.Up:
                                        direction = Direction.Left;
                                        break;
                                    case Direction.Right:
                                        direction = Direction.Down;
                                        break;
                                    case Direction.Down:
                                        direction = Direction.Right;
                                        break;
                                }
                                break;
                            case '-':
                                switch (direction)
                                {
                                    case Direction.Left:
                                        direction = Direction.Left;
                                        break;
                                    case Direction.Up:
                                        if (visited[pos.X, pos.Y] == true) return;
                                        visited[pos.X, pos.Y] = true;
                                        Move(new Position(pos.X - 1, pos.Y), Direction.Left);
                                        Move(new Position(pos.X + 1, pos.Y), Direction.Right);
                                        return;
                                    case Direction.Right:
                                        direction = Direction.Right;
                                        break;
                                    case Direction.Down:
                                        if (visited[pos.X, pos.Y] == true) return;
                                        visited[pos.X, pos.Y] = true;
                                        Move(new Position(pos.X - 1, pos.Y), Direction.Left);
                                        Move(new Position(pos.X + 1, pos.Y), Direction.Right);
                                        return;
                                }
                                break;
                            case '|':
                                switch (direction)
                                {
                                    case Direction.Left:
                                        if (visited[pos.X, pos.Y] == true) return;
                                        visited[pos.X, pos.Y] = true;
                                        Move(new Position(pos.X, pos.Y - 1), Direction.Up);
                                        Move(new Position(pos.X, pos.Y + 1), Direction.Down);
                                        return;
                                    case Direction.Up:
                                        direction = Direction.Up;
                                        break;
                                    case Direction.Right:
                                        if (visited[pos.X, pos.Y] == true) return;
                                        visited[pos.X, pos.Y] = true;
                                        Move(new Position(pos.X, pos.Y - 1), Direction.Up);
                                        Move(new Position(pos.X, pos.Y + 1), Direction.Down);
                                        return;
                                    case Direction.Down:
                                        direction = Direction.Down;
                                        break;
                                }
                                break;
                        }

                        visited[pos.X, pos.Y] = true;
                        pos.Move(direction);
                        if (pos.X == startPos.X && pos.Y == startPos.Y) return;
                    }
                }

                var sum = 0;

                for (var a = 0; a < input.Length; a++)
                {
                    for (var b = 0; b < input[a].Length; b++)
                    {
                        if (visited[a, b] == true)
                        {
                            sum++;
                        }
                    }
                }

                if (sum > bestSum)
                    bestSum = sum;
            }
        }
    }

    return bestSum;
}


var input = File.ReadAllLines("input.txt");

Console.WriteLine(Part1(input));
Console.WriteLine(Part2(input));

enum Direction { Left, Up, Right, Down }

struct Position(int x, int y)
{
    public int X { get; private set; } = x;
    public int Y { get; private set; } = y;

    public void Move(Direction direction)
    {
        switch (direction)
        {
            case Direction.Left:
                X -= 1;
                break;
            case Direction.Right:
                X += 1;
                break;
            case Direction.Up:
                Y -= 1;
                break;
            case Direction.Down:
                Y += 1;
                break;
        }
    }
};