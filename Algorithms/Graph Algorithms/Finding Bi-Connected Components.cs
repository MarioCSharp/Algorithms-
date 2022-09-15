private static List<int>[] graph;
private static int[] depth;
private static int[] lowPoint;
private static int[] parent;
private static bool[] visited;
private static Stack<int> stack = new Stack<int>();
private static List<HashSet<int>> components = new List<HashSet<int>>();

static void Main()
{
    var nodes = int.Parse(Console.ReadLine());
    var edges = int.Parse(Console.ReadLine());

    graph = new List<int>[nodes];
    depth = new int[nodes];
    lowPoint = new int[nodes];
    parent = new int[nodes];
    visited = new bool[nodes];

    for (int n = 0; n < graph.Length; n++)
    {
        graph[n] = new List<int>();
        parent[n] = -1;
    }

    for (int edge = 0; edge < edges; edge++)
    {
        var edgeArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();

        var first = edgeArgs[0];
        var second = edgeArgs[1];

        graph[first].Add(second);
        graph[second].Add(first);
    }

    for (int node = 0; node < graph.Length; node++)
    {
        if (visited[node])
        {
            continue;
        }

        FindArticulationPoints(node, 1);

        var lastComponent = stack.ToHashSet();

        components.Add(lastComponent);
    }

    Console.WriteLine($"Number of bi-connected components: {components.Count}");
}

private static void FindArticulationPoints(int node, int currentDepth)
{
    visited[node] = true;
    depth[node] = currentDepth;
    lowPoint[node] = currentDepth;

    var children = 0;

    foreach (var child in graph[node])
    {
        if (!visited[child])
        {
            stack.Push(node);
            stack.Push(child);

            parent[child] = node;
            FindArticulationPoints(child, currentDepth + 1);

            children++;

            if (parent[node] != -1 && lowPoint[child] >= depth[node]
                || parent[node] == -1 && children > 1)
            {
                var component = new HashSet<int>();

                while (true)
                {
                    var stackChild = stack.Pop();
                    var stackNode = stack.Pop();

                    component.Add(stackNode);
                    component.Add(stackChild);

                    if (stackNode == node && stackChild == child)
                    {
                        break;
                    }
                }

                components.Add(component);
            }

            lowPoint[node] = Math.Min(lowPoint[node], lowPoint[child]);
        }
        else if (parent[node] != child && depth[child] < lowPoint[node])
        {
            lowPoint[node] = depth[child];

            stack.Push(node);
            stack.Push(child);
        }
    }
}
