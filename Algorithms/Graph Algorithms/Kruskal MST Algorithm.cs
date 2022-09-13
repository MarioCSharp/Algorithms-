public class KruskalAlgMST
{
    private static Dictionary<string, string> parents = new Dictionary<string, string>();
    private static void Solve()
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
                   .ToHashSet(); // Getting all the nodes in the graph

        foreach (var edge in nodes)
        {
            parents[edge] = edge; // setting their parrent to them
        }

        var edges = graph.OrderBy(x => x.Weight).ToList(); // ordering them by weight

        while (edges.Count != 0)
        {
            var edge = edges.First();
            edges.Remove(edge);

            var firstNode = edge.First;
            var secondNode = edge.Second;

            var firstRoot = FindRoot(firstNode);
            var secondRoot = FindRoot(secondNode);

            if (firstRoot != secondRoot)
            {
                Console.WriteLine($"{firstNode} - {secondNode}");
                parents[firstRoot] = secondRoot;
            }
        }
    }

    private static string FindRoot(string node)
    {
        while (parents[node] != node)
        {
            node = parents[node];
        }

        return node;
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