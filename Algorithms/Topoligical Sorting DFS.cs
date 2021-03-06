class Solution
{
    private static void Solve()
    {
        private static Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
        private static HashSet<string> visited = new HashSet<string>();
        private static Stack<string> result = new Stack<string>();

        static void Main(string[] args)
        {
            ReadGraph();

            foreach (var node in graph.Keys)
            {
                DFS(node);
            }

            Console.WriteLine(string.Join(" ", result));
        }
        private static void DFS(string node)
        {
            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);

            foreach (var child in graph[node])
            {
                DFS(child);
            }

            result.Push(node);
        }
        private static void ReadGraph()
        {
            var input = "";

            while ((input = Console.ReadLine()) != "End")
            {
                var split = input.Split("->", StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();

                var preStory = split[0];

                if (split.Count > 1)
                {
                    var postStories = split[1].Split(' ').ToList();
                    graph[preStory] = postStories;
                }
                else
                {
                    graph[preStory] = new List<string>();
                }
            }
        }
    }
}
