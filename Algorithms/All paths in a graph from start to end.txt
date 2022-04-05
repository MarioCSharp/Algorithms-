namespace ConsoleApp17
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        private static List<int>[] graph;
        private static LinkedList<int> path;
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            graph = new List<int>[n];
            path = new LinkedList<int>();

            for (int i = 0; i < n - 1; i++)
            {
                var children = Console.ReadLine().Split().Select(int.Parse).ToList();

                graph[i] = children;
            }

            graph[n - 1] = new List<int>();

            for (int i = 0; i < n - 1; i++)
            {
                DFS(i);
                path = new LinkedList<int>();
            }
        }
        private static void DFS(int node)
        {
            path.AddLast(node);

            if (node == graph.Length - 1)
            {
                Console.WriteLine(string.Join(" ", path));
            }

            foreach (var child in graph[node])
            {
                DFS(child);
            }

            path.RemoveLast();
        }
    }
}