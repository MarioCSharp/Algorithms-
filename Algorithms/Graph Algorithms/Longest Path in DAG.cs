private static void LongestPathInDAG()
{
    var sorted = ToppologicalSort();
    var d = new double[biggest + 1];
    var prev = new int[biggest + 1];

    Array.Fill(prev, -1);

    var start = int.Parse(Console.ReadLine());
    var end = int.Parse(Console.ReadLine());

    Array.Fill(d, double.NegativeInfinity);
    d[start] = 0;

    while (sorted.Count > 0)
    {
        var node = sorted.Pop();

        foreach (var edge in graph[node])
        {
            var newDistance = d[edge.First] + edge.Weight;

            if (newDistance > d[edge.Second])
            {
                d[edge.Second] = newDistance;
                prev[edge.Second] = edge.First;
            }
        }
    }

    Console.WriteLine(d[end]);
    Console.WriteLine(string.Join(" ", FindPath(end, prev)));
}

private static Stack<int> FindPath(int end, int[] prev)
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

private static Stack<int> ToppologicalSort()
{
    var result = new Stack<int>();
    var visited = new HashSet<int>();

    foreach (var node in graph.Keys)
    {
        Dfs(node, result, visited);
    }

    return result;
}

private static void Dfs(int node, Stack<int> result, HashSet<int> visited)
{
    if (visited.Contains(node))
    {
        return;
    }

    visited.Add(node);

    foreach (var child in graph[node])
    {
        Dfs(child.Second, result, visited);
    }

    result.Push(node);
}