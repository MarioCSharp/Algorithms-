private static int[,] graph;
private static int[] parent;
static void Main()
{
    var nodes = int.Parse(Console.ReadLine());

    graph = new int[nodes, nodes];

    for (int node = 0; node < nodes; node++)
    {
        var row = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

        for (int child = 0; child < row.Length; child++)
        {
            graph[node, child] = row[child];
        }
    }

    var source = int.Parse(Console.ReadLine());
    var target = int.Parse(Console.ReadLine());

    parent = new int[nodes];
    Array.Fill(parent, -1);

    var flow = 0;

    while (BFS(source, target))
    {
        var minFlow = FindMinFlow(target);

        ApplyFlow(target, minFlow);

        flow += minFlow;
    }

    Console.WriteLine($"Max flow = {flow}");
}

private static void ApplyFlow(int node, int minFlow)
{
    while (parent[node] != -1)
    {
        var prev = parent[node];

        graph[prev, node] -= minFlow;

        node = prev;
    }
}

private static int FindMinFlow(int node)
{
    var minFlow = int.MaxValue;

    while (parent[node] != -1)
    {
        var prev = parent[node];

        var flow = graph[prev, node];

        if (flow < minFlow)
        {
            minFlow = flow;
        }

        node = prev;
    }

    return minFlow;
}

private static bool BFS(int source, int target)
{
    var visited = new bool[graph.GetLength(0)];
    visited[source] = true;

    var queue = new Queue<int>();
    queue.Enqueue(source);

    while (queue.Count > 0)
    {
        var node = queue.Dequeue();

        for (int child = 0; child < graph.GetLength(1); child++)
        {
            if (!visited[child] && graph[node, child] > 0)
            {
                visited[child] = true;
                queue.Enqueue(child);
                parent[child] = node;
            }
        }
    }

    return visited[target];
}