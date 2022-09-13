var nodes = int.Parse(Console.ReadLine());
var lines = int.Parse(Console.ReadLine());

var graph = new List<int>[nodes];
var reversedGraph = new List<int>[nodes];

for (int node = 0; node < graph.Length; node++)
{
    graph[node] = new List<int>();
    reversedGraph[node] = new List<int>();
}

for (int i = 0; i < lines; i++)
{
    var line = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

    var node = line[0];

    for (int j = 1; j < line.Length; j++)
    {
        graph[node].Add(line[j]);
        reversedGraph[line[j]].Add(node);
    }
}

var visited = new HashSet<int>();
var sorted = new Stack<int>();

for (int node = 0; node < graph.Length; node++)
{
    DFS(node, graph, visited, sorted);
}

visited = new HashSet<int>();

Console.WriteLine("Strongly Connected Components:");

while (sorted.Count > 0)
{
    var node = sorted.Pop();
    var component = new Stack<int>();

    if (visited.Contains(node))
    {
        continue;
    }

    DFS(node, reversedGraph, visited, component);

    Console.WriteLine($"{{{string.Join(", ", component)}}}");
}
        }

        private static void DFS(int node, List<int>[] graph, HashSet<int> visited, Stack<int> sorted)
{
    if (visited.Contains(node))
    {
        return;
    }

    visited.Add(node);

    foreach (var child in graph[node])
    {
        DFS(child, graph, visited, sorted);
    }

    sorted.Push(node);
}