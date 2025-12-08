ulong PartOne(string[] input)
{
    Vector3D[] vectors = new Vector3D[input.Length];
    for (int i = 0; i < input.Length; i++)
    {
        var posValues = input[i].Split(",");
        ulong xPos = ulong.Parse(posValues[0]);
        ulong yPos = ulong.Parse(posValues[1]);
        ulong zPos = ulong.Parse(posValues[2]);
        vectors[i] = new(xPos, yPos, zPos, 0);
    }
    ulong highestCircuitId = 0;
    List<Distance> distances = [];

    for (int i = 0; i < vectors.Length; i++)
    {
        for (int j = i + 1; j < vectors.Length; j++)
        {
            if (vectors[j] == vectors[i])
                continue;
            var distance = Math.Sqrt(
                ((vectors[i].X - vectors[j].X) * (vectors[i].X - vectors[j].X)) +
                ((vectors[i].Y - vectors[j].Y) * (vectors[i].Y - vectors[j].Y)) +
                ((vectors[i].Z - vectors[j].Z) * (vectors[i].Z - vectors[j].Z))
            );
            distances.Add(new(vectors[i], vectors[j], distance));
        }
    }

    var newDistances = distances.ToList();

    var values = newDistances.OrderBy(x => x.Length).ToArray();
    var max = 1000;
    for (int t = 0; t < max; t++)
    {
        var aPos = Array.IndexOf(vectors, vectors.First(x => x.X == values[t].A.X && x.Y == values[t].A.Y && x.Z == values[t].A.Z));
        var bPos = Array.IndexOf(vectors, vectors.First(x => x.X == values[t].B.X && x.Y == values[t].B.Y && x.Z == values[t].B.Z));

        if (vectors[bPos].CircuitId != 0 && vectors[bPos].CircuitId == vectors[aPos].CircuitId)
            continue;
        
        if (vectors[aPos].CircuitId != 0 && vectors[bPos].CircuitId == 0)
        {
            vectors[bPos] = new(values[t].B.X, values[t].B.Y, values[t].B.Z, vectors[aPos].CircuitId);
        }
        else if (vectors[bPos].CircuitId != 0 && vectors[aPos].CircuitId == 0)
        {
            vectors[aPos] = new(values[t].A.X, values[t].A.Y, values[t].A.Z, vectors[bPos].CircuitId);
        }
        else if (vectors[aPos].CircuitId == 0 && vectors[bPos].CircuitId == 0)
        {
            highestCircuitId++;
            vectors[aPos] = new(values[t].A.X, values[t].A.Y, values[t].A.Z, highestCircuitId);
            vectors[bPos] = new(values[t].B.X, values[t].B.Y, values[t].B.Z, highestCircuitId);
        }
        else
        {
            vectors.Where(x => x.CircuitId == vectors[bPos].CircuitId).ToList().ForEach(n => vectors[vectors.ToList().IndexOf(n)] = new(n.X, n.Y, n.Z, vectors[aPos].CircuitId));
        }
    }

    List<ulong> cir = [];

    for (ulong i = 1; i <= highestCircuitId; i++)
    {
        cir.Add((ulong)vectors.Where(x => x.CircuitId == i).Count());
    }
    cir = cir.OrderByDescending(x => x).ToList();
    ulong count = cir[0];
    for (int i = 1; i < 3; i++)
    {
        count *= cir[i];
    }
    return count;
}


double PartTwo(string[] input)
{
    Vector3D[] vectors = new Vector3D[input.Length];
    for (int i = 0; i < input.Length; i++)
    {
        var posValues = input[i].Split(",");
        ulong xPos = ulong.Parse(posValues[0]);
        ulong yPos = ulong.Parse(posValues[1]);
        ulong zPos = ulong.Parse(posValues[2]);
        vectors[i] = new(xPos, yPos, zPos, 0);
    }
    ulong highestCircuitId = 0;
    List<Distance> distances = [];

    for (int i = 0; i < vectors.Length; i++)
    {
        for (int j = i + 1; j < vectors.Length; j++)
        {
            if (vectors[j] == vectors[i])
                continue;
            var distance = Math.Sqrt(
                ((vectors[i].X - vectors[j].X) * (vectors[i].X - vectors[j].X)) +
                ((vectors[i].Y - vectors[j].Y) * (vectors[i].Y - vectors[j].Y)) +
                ((vectors[i].Z - vectors[j].Z) * (vectors[i].Z - vectors[j].Z))
            );
            distances.Add(new(vectors[i], vectors[j], distance));
        }
    }

    var newDistances = distances.ToList();
    ulong last = 0;
    ulong first = 0;
    var values = newDistances.OrderBy(x => x.Length).ToArray();

    for (int t = 0; t < values.Length; t++)
    {
        var aPos = Array.IndexOf(vectors, vectors.First(x => x.X == values[t].A.X && x.Y == values[t].A.Y && x.Z == values[t].A.Z));
        var bPos = Array.IndexOf(vectors, vectors.First(x => x.X == values[t].B.X && x.Y == values[t].B.Y && x.Z == values[t].B.Z));

        if (vectors[bPos].CircuitId != 0 && vectors[bPos].CircuitId == vectors[aPos].CircuitId)
        {
            continue;
        }
        
        if (vectors[aPos].CircuitId != 0 && vectors[bPos].CircuitId == 0)
        {
            vectors[bPos] = new(values[t].B.X, values[t].B.Y, values[t].B.Z, vectors[aPos].CircuitId);
        }
        else if (vectors[bPos].CircuitId != 0 && vectors[aPos].CircuitId == 0)
        {
            vectors[aPos] = new(values[t].A.X, values[t].A.Y, values[t].A.Z, vectors[bPos].CircuitId);
        }
        else if (vectors[aPos].CircuitId == 0 && vectors[bPos].CircuitId == 0)
        {
            highestCircuitId++;
            vectors[aPos] = new(values[t].A.X, values[t].A.Y, values[t].A.Z, highestCircuitId);
            vectors[bPos] = new(values[t].B.X, values[t].B.Y, values[t].B.Z, highestCircuitId);
        }
        else
        {
            vectors.Where(x => x.CircuitId == vectors[bPos].CircuitId).ToList().ForEach(n => vectors[vectors.ToList().IndexOf(n)] = new(n.X, n.Y, n.Z, vectors[aPos].CircuitId));
            
        }
        first = values[t].A.X;
        last = values[t].B.X;
    }


    return last * first;
}



var input = File.ReadAllLines("input.txt");


Console.WriteLine(PartOne(input));
Console.WriteLine(PartTwo(input));



public record Vector3D(ulong X, ulong Y, ulong Z, double CircuitId);


public record Distance(Vector3D A, Vector3D B, double Length);