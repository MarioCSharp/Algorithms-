private static List<int>[] graph;
private static int end;
private static HashSet<int> visited = new HashSet<int>();
private static int[] parents;

private static void Bfs(int startNode)
{
    var queue = new Queue<int>();
    queue.Enqueue(startNode);
    visited.Add(startNode);

    while (queue.Count > 0)
    {
        var node = queue.Dequeue();

        if (node == end)
        {
            var path = GetPath(end);
            Console.WriteLine($"Shortest path length is: {path.Count - 1}");
            Console.WriteLine(string.Join(" ", path));
            return;
        }

        foreach (var child in graph[node])
        {
            if (!visited.Contains(child))
            {
                queue.Enqueue(child);
                visited.Add(child);
                parents[child] = node;
            }
        }
    }
}

private static Stack<int> GetPath(int end)
{
    var path = new Stack<int>();
    var index = end;

    while (index != -1)
    {
        path.Push(index);
        index = parents[index];
    }

    return path;
}