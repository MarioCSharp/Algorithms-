private static List<int>[] graph;
private static bool[] visited;
private static int[] depth;
private static int[] lowPoint;
private static int[] parent;

private static List<int> articulationPoints = new List<int>();
static void Main()
{
    var nodes = int.Parse(Console.ReadLine());
    var lines = int.Parse(Console.ReadLine());

    graph = new List<int>[nodes];
    visited = new bool[nodes];
    depth = new int[nodes];
    lowPoint = new int[nodes];
    parent = new int[nodes];

    for (int node = 0; node < graph.Length; node++)
    {
        graph[node] = new List<int>();
        parent[node] = -1;
    }

    for (int i = 0; i < lines; i++)
    {
        var line = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

        var node = line[0];

        for (int j = 0; j < line.Length; j++)
        {
            var child = line[j];

            graph[node].Add(child);
            graph[child].Add(node);
        }
    }

    for (int node = 0; node < graph.Length; node++)
    {
        if (visited[node])
        {
            continue;
        }

        FindArticulationPoints(node, 1);
    }

    Console.WriteLine($"Articulation points: {string.Join(", ", articulationPoints)}");
}

private static void FindArticulationPoints(int node, int currentDepth)
{
    visited[node] = true;
    depth[node] = currentDepth;
    lowPoint[node] = currentDepth;

    var children = 0;
    var isArticulationPoint = false;

    foreach (var child in graph[node])
    {
        if (!visited[child])
        {
            parent[child] = node;
            FindArticulationPoints(child, currentDepth + 1);
            children++;

            if (lowPoint[child] >= depth[node])
            {
                isArticulationPoint = true;
            }

            lowPoint[node] = Math.Min(lowPoint[node], lowPoint[child]);
        }
        else if (parent[node] != child)
        {
            lowPoint[node] = Math.Min(lowPoint[node], depth[child]);
        }
    }

    if ((parent[node] == -1 && children > 1) || (isArticulationPoint && parent[node] != -1))
    {
        articulationPoints.Add(node);
    }
}