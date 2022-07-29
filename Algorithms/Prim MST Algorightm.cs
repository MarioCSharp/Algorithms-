public class PrimMstAlg
{
    private static HashSet<string> spanningTree = new HashSet<string>();
    private static Dictionary<string, List<Edge>> nodeToEdges = new Dictionary<string, List<Edge>>();
    static void Solve(string[] args)
    {
        var graph = new List<Edge>
            {
                new Edge("A", "B", 4),
                new Edge("A", "D", 9),
                new Edge("A", "C", 5),
                new Edge("B", "D", 2),
                new Edge("C", "D", 20),
                new Edge("C", "E", 7),
                new Edge("D", "E", 8),
                new Edge("E", "F", 12),
                new Edge("H", "G", 8),
                new Edge("H", "I", 7),
                new Edge("G", "I", 10),
            };

        var nodes = graph.Select(x => x.First)
                   .Union(graph.Select(e => e.Second)).Distinct()
                   .OrderBy(x => x)
                   .ToHashSet();

        foreach (var edge in graph)
        {
            if (!nodeToEdges.ContainsKey(edge.First))
            {
                nodeToEdges[edge.First] = new List<Edge>();
            }

            if (!nodeToEdges.ContainsKey(edge.Second))
            {
                nodeToEdges[edge.Second] = new List<Edge>();
            }

            nodeToEdges[edge.First].Add(edge);
            nodeToEdges[edge.Second].Add(edge);
        }

        foreach (var node in nodes)
        {
            if (!spanningTree.Contains(node))
            {
                Prim(node);
            }
        }
    }

    private static void Prim(string startingNode)
    {
        spanningTree.Add(startingNode);

        var priorityQueue = new SortedSet<Edge>
            (Comparer<Edge>.Create((f, s) => f.Weight - s.Weight));

        nodeToEdges[startingNode].ForEach(x => priorityQueue.Add(x));

        while (priorityQueue.Count != 0)
        {
            var minEdge = priorityQueue.Min;
            priorityQueue.Remove(minEdge);

            var firstNode = minEdge.First;
            var secondNode = minEdge.Second;

            var nonTreeNode = string.Empty;

            if (spanningTree.Contains(firstNode) && !spanningTree.Contains(secondNode))
            {
                nonTreeNode = secondNode;
            }

            if (!spanningTree.Contains(firstNode) && spanningTree.Contains(secondNode))
            {
                nonTreeNode = firstNode;
            }

            if (nonTreeNode == string.Empty)
            {
                continue;
            }

            spanningTree.Add(nonTreeNode);

            Console.WriteLine($"{firstNode} - {secondNode}");

            nodeToEdges[nonTreeNode].ForEach(x => priorityQueue.Add(x));
        }
    }
    public class Edge
    {
        public Edge(string first, string second, int weight)
        {
            First = first;
            Second = second;
            Weight = weight;
        }

        public string First { get; set; }
        public string Second { get; set; }
        public int Weight { get; set; }
    }
}