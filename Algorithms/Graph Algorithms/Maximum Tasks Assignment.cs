public class Program
{
    private static bool[,] graph;
    private static int[] parent;
    static void Main() // First we have to build a graph and then start max flow
    {
        // 0, 1, 2, 3, 4, 5, 6, 7  index
        // S, A, B, C, 1, 2, 3, T  = graph[index]

        var people = int.Parse(Console.ReadLine());
        var tasks = int.Parse(Console.ReadLine());

        var nodes = people + tasks + 2;

        graph = new bool[nodes, nodes];
        parent = new int[nodes];

        Array.Fill(parent, -1);

        for (int person = 1; person <= people; person++) // Connecting the start node with every person
        {
            graph[0, person] = true;
        }

        for (int task = people + 1; task <= people + tasks; task++) // Connecting the task with the target node
        {
            graph[task, nodes - 1] = true;
        }

        for (int person = 1; person <= people; person++)
        {
            var line = Console.ReadLine();

            for (int task = 0; task < line.Length; task++)
            {
                if (line[task] == 'Y')
                {
                    graph[person, people + task + 1] = true; // Connecting the person with the task he can do
                }
            }
        }

        var source = 0;
        var target = nodes - 1;

        while (BFS(source, target)) // Max flow
        {
            ApplyFlow(target);
        }

        for (int task = people + 1; task <= people + tasks; task++)
        {
            for (int idx = 0; idx < graph.GetLength(1); idx++)
            {
                if (graph[task, idx])
                {
                    Console.WriteLine($"{(char)(64 + idx)}-{task - people}");
                }
            }
        }
    }

    private static void ApplyFlow(int target) // Reverse the edges of the path, so we dont get the same path again
    {
        var node = target;

        while (parent[node] != -1)
        {
            var prev = parent[node];

            graph[prev, node] = false;
            graph[node, prev] = true;

            node = prev;
        }
    }

    private static bool BFS(int source, int target) // Checking if there is a path from the source to the target
    {
        var visited = new HashSet<int>();
        visited.Add(source);

        var queue = new Queue<int>();
        queue.Enqueue(source);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            for (int child = 0; child < graph.GetLength(1); child++)
            {
                if (!visited.Contains(child) && graph[node, child])
                {
                    parent[child] = node;
                    visited.Add(child);
                    queue.Enqueue(child);
                }
            }
        }

        return visited.Contains(target);
    }