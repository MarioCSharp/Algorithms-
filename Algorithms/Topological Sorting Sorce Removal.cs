class Solution
{
    private static void Solve()
    {
        private static Dictionary<string, List<string>> graph = new Dictionary<string, List<string>>();
        private static Dictionary<string, int> dependencies = new Dictionary<string, int>();
        private static HashSet<string> visited = new HashSet<string>();
        static void Main(string[] args)
        {
            ReadGraph();
            GetDepenencies();
            GetTop();
        }
        private static void GetDepenencies()
        {
            foreach (var node in graph.Keys)
            {
                if (!dependencies.ContainsKey(node))
                {
                    dependencies[node] = 0;
                }
                foreach (var child in graph[node])
                {
                    if (!dependencies.ContainsKey(child))
                    {
                        dependencies[child] = 1;
                    }
                    else
                    {
                        dependencies[child]++;
                    }
                }
            }
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

                dependencies[preStory] = 0;
            }
        }
        private static void GetTop()
        {
            var top = new List<string>();

            while (dependencies.Any())
            {
                var node = dependencies.LastOrDefault(x => x.Value == 0).Key;

                if (string.IsNullOrEmpty(node))
                {
                    return;
                }

                top.Add(node);

                foreach (var child in graph[node])
                {
                    dependencies[child]--;
                }

                dependencies.Remove(node);
            }

            Console.WriteLine(string.Join(" ", top));
        }
    }
}
