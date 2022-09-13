private static double[] d; // need to initialize
private static int[] prev; // need to initialize

public static void Dijkstra(int start, int end)
{
    var priorityQueue = new OrderedBag<int>(Comparer<int>.Create((f, s) => (int)(d[f] - d[s])));

    priorityQueue.Add(start);

    while (priorityQueue.Count > 0)
    {
        var min = priorityQueue.RemoveFirst();

        if (double.IsPositiveInfinity(d[min]))
        {
            break;
        }

        if (min == end)
        {
            break;
        }

        foreach (var e in Program.end[min])
        {
            var other = e.First == min ? e.Second : e.First;

            if (double.IsPositiveInfinity(d[other]))
            {
                priorityQueue.Add(other);
            }

            var newDistance = d[min] + e.Weight;

            if (newDistance < d[other])
            {
                prev[other] = min;
                d[other] = newDistance;

                priorityQueue = new OrderedBag<int>(priorityQueue,
                    Comparer<int>.Create((f, s) => (int)(d[f] - d[s])));
            }
        }
    }
}

private static Stack<int> FindPath(int start, int end)
{
    var path = new Stack<int>();
    var node = end;

    while (node != -1)
    {
        path.Push(node);

        node = prev[node];
    }

    return path;
}