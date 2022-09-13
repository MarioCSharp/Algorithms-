private static void BellmanFord()
{
    var d = new double[biggestNode + 1];
    var prev = new int[biggestNode + 1];

    var source = int.Parse(Console.ReadLine());
    var destination = int.Parse(Console.ReadLine());

    for (int i = 0; i < d.Length; i++)
    {
        d[i] = double.PositiveInfinity;
        prev[i] = -1;
    }

    d[source] = 0;

    for (int i = 0; i < n - 1; i++)
    {
        var update = false;

        foreach (var edge in edges)
        {
            if (double.IsPositiveInfinity(edge.First))
            {
                continue;
            }

            var newDistance = d[edge.First] + edge.Weight;

            if (newDistance < d[edge.Second])
            {
                d[edge.Second] = newDistance;
                prev[edge.Second] = edge.First;
                update = true;
            }
        }

        if (!update) // If we didnt update anything that means we dont have any shorter path
        {
            break;
        }
    }

    foreach (var edge in edges)
    {
        var newDistance = d[edge.First] + edge.Weight;

        if (newDistance < d[edge.Second])
        {
            Console.WriteLine("Negative Cycle Detected");
            return;
        }
    }

    Console.WriteLine(string.Join(" ", FindPath(prev, destination)));
    Console.WriteLine(d[destination]);
}