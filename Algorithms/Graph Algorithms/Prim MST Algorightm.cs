private static List<int> spanningTree = new List<int>();
private static void Prim(int node)
{
    spanningTree.Add(node);

    var priorityQueue = new OrderedBag<Edge>(Comparer<Edge>.Create((f, s) => f.Weight - s.Weight));

    priorityQueue.AddMany(edgesByNode[node]);

    while (priorityQueue.Count > 0)
    {
        var min = priorityQueue.RemoveFirst();

        var nonTreeNode = -1;

        if (spanningTree.Contains(min.First) && !spanningTree.Contains(min.Second))
        {
            nonTreeNode = min.Second;
        }

        if (spanningTree.Contains(min.Second) && !spanningTree.Contains(min.First))
        {
            nonTreeNode = min.First;
        }

        if (nonTreeNode == -1)
        {
            continue;
        }

        spanningTree.Add(nonTreeNode);
        priorityQueue.AddMany(edgesByNode[nonTreeNode]);

        Console.WriteLine($"{min.First} - {min.Second}");
    }
}