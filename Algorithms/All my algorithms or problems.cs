using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    internal class Right_Down_Problem
    {
        static void Solve()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var matrix = new int[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                var input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int c = 0; c < cols; c++)
                {
                    matrix[r, c] = input[c];
                }
            }

            var dp = new int[rows, cols];
            dp[0, 0] = matrix[0, 0];

            for (int c = 1; c < cols; c++)
            {
                dp[0, c] = dp[0, c - 1] + matrix[0, c];
            }

            for (int r = 1; r < rows; r++)
            {
                dp[r, 0] = dp[r - 1, 0] + matrix[r, 0];
            }

            for (int r = 1; r < rows; r++)
            {
                for (int c = 1; c < cols; c++)
                {
                    var left = dp[r, c - 1];
                    var up = dp[r - 1, c];

                    dp[r, c] = Math.Max(left, up) + matrix[r, c];
                }
            }

            var stack = new Stack<string>();
            var row = rows - 1;
            var col = cols - 1;

            while (row > 0 && col > 0)
            {
                stack.Push($"[{row}, {col}]");
                var left = dp[row, col - 1];
                var up = dp[row - 1, col];

                if (left >= up)
                {
                    col--;
                }
                else
                {
                    row--;
                }
            }

            while (row > 0)
            {
                stack.Push($"[{row}, {col}]");
                row--;
            }

            while (col > 0)
            {
                stack.Push($"[{row}, {col}]");
                col--;
            }

            stack.Push($"[{row}, {col}]");
            Console.WriteLine(string.Join(" ", stack));
        }
    }
    class LCS
    {
        private static void Solve()
        {
            var str1 = Console.ReadLine().Split();
            var str2 = Console.ReadLine().Split();

            var lcs = new int[str1.Length + 1, str2.Length + 1];

            for (int r = 1; r < lcs.GetLength(0); r++)
            {
                for (int c = 1; c < lcs.GetLength(1); c++)
                {
                    if (str1[r - 1] == str2[c - 1])
                    {
                        lcs[r, c] = lcs[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        lcs[r, c] = Math.Max(lcs[r - 1, c], lcs[r, c - 1]);
                    }
                }
            }

            var lcsLetters = new Stack<string>();

            var row = str1.Length;
            var col = str2.Length;

            while (row > 0 && col > 0)
            {
                if (str1[row - 1] == str2[col - 1])
                {
                    lcsLetters.Push(str1[row - 1]);
                    row--;
                    col--;
                }
                else if (lcs[row - 1, col] > lcs[row, col - 1])
                {
                    row--;
                }
                else
                {
                    col--;
                }
            }


            Console.WriteLine(string.Join(" ", lcsLetters));
            Console.WriteLine(lcs[str1.Length, str2.Length]);
        }
    }

    class BionomialCoefOrPascalsTriangle
    {
        private static int GetBinom(int row, int col)
        {
            if (row == 0 || col == 0 || col == row)
            {
                return 1;
            }

            return GetBinom(row - 1, col) + GetBinom(row - 1, col - 1);
        }
    }

    class PermutationsWithRepetitions
    {
        private static char[] elements;
        private static void GetPerm(int idx)
        {
            if (idx == elements.Length)
            {
                Console.WriteLine(string.Join(' ', elements));
                return;
            }

            GetPerm(idx + 1);

            var used = new HashSet<char>() { elements[idx] };

            for (int i = idx + 1; i < elements.Length; i++)
            {
                if (!used.Contains(elements[i]))
                {
                    Swap(idx, i);
                    GetPerm(idx + 1);
                    Swap(idx, i);

                    used.Add(elements[i]);
                }
            }
        }

        private static void Swap(int idx, int i)
        {
            var temp = elements[i];
            elements[i] = elements[idx];
            elements[idx] = temp;
        }
    }
    class FindAllOperationsToMakeTwoStringsSameWithDeletionsAndInsertions
    {
        private static void Solve()
        {
            var str1 = Console.ReadLine();
            var str2 = Console.ReadLine();

            var dp = new int[str1.Length + 1, str2.Length + 1];

            for (int r = 0; r < dp.GetLength(0); r++)
            {
                dp[r, 0] = r;
            }

            for (int c = 0; c < dp.GetLength(1); c++)
            {
                dp[0, c] = c;
            }

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                for (int col = 1; col < dp.GetLength(1); col++)
                {
                    if (str1[row - 1] == str2[col - 1])
                    {
                        dp[row, col] = dp[row - 1, col - 1];
                    }
                    else
                    {
                        dp[row, col] = Math.Min(dp[row - 1, col], dp[row, col - 1]) + 1;
                    }
                }
            }

            Console.WriteLine($"Deletions and Insertions: {dp[str1.Length, str2.Length]}");
        }
    }
    class FindAllPathsFromTheTopLeftToTheBottomRightMovingOnlyDownAndUp
    {
        public static int UniquePaths(int m, int n)
        {
            var dp = new int[m, n];

            for (int r = 0; r < dp.GetLength(0); r++)
            {
                dp[r, 0] = 1;
            }

            for (int c = 0; c < dp.GetLength(1); c++)
            {
                dp[0, c] = 1;
            }

            for (int r = 1; r < dp.GetLength(0); r++)
            {
                for (int c = 1; c < dp.GetLength(1); c++)
                {
                    dp[r, c] = dp[r - 1, c] + dp[r, c - 1];
                }
            }

            return dp[m - 1, n - 1];
        }
    }

    class WordCruncher
    {
        private static string target;

        private static Dictionary<string, int> wordsCount = new Dictionary<string, int>();
        private static Dictionary<int, List<string>> wordsIdx = new Dictionary<int, List<string>>();
        private static LinkedList<string> usedWords = new LinkedList<string>();
        static void Method(string[] args)
        {
            var words = Console.ReadLine().Split(", ");
            target = Console.ReadLine();

            Generate(words);

            GenerateSolutions(0);
        }

        private static void GenerateSolutions(int idx)
        {
            if (idx == target.Length)
            {
                Console.WriteLine(string.Join(' ', usedWords));
                return;
            }

            if (!wordsIdx.ContainsKey(idx))
            {
                return;
            }

            foreach (var word in wordsIdx[idx])
            {
                if (wordsCount[word] == 0)
                {
                    continue;
                }

                wordsCount[word]--;
                usedWords.AddLast(word);

                GenerateSolutions(idx + word.Length);

                wordsCount[word]++;
                usedWords.RemoveLast();
            }
        }


        private static void Generate(string[] words)
        {
            foreach (var word in words)
            {
                var idx = target.IndexOf(word);

                if (idx == -1)
                {
                    continue;
                }

                if (wordsCount.ContainsKey(word))
                {
                    wordsCount[word]++;
                    continue;
                }

                wordsCount[word] = 1;

                while (idx != -1)
                {
                    if (!wordsIdx.ContainsKey(idx))
                    {
                        wordsIdx[idx] = new List<string>();
                    }

                    wordsIdx[idx].Add(word);

                    idx = target.IndexOf(word, idx + 1);
                }
            }
        }
    }

    public class QuickSortAlg
    {
        private static void QuickSort(int[] numbers, int start, int end)
        {
            if (start >= end)
            {
                return;
            }

            var pivot = start;
            var left = start + 1;
            var right = end;

            while (left <= right)
            {
                if (numbers[left] > numbers[pivot] && numbers[right] < numbers[pivot])
                {
                    Swap(numbers, left, right);
                }

                if (numbers[right] >= numbers[pivot])
                {
                    right--;
                }

                if (numbers[left] < numbers[pivot])
                {
                    left--;
                }
            }

            Swap(numbers, pivot, right);

            QuickSort(numbers, start, right - 1);
            QuickSort(numbers, right + 1, end);
        }

        private static void Swap(int[] arr, int first, int second)
        {
            var temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
        }
    }

    public class MergeSortAlg
    {
        private static int[] MergeSort(int[] numbers)
        {
            if (numbers.Length == 1)
            {
                return numbers;
            }

            var left = numbers.Take(numbers.Length / 2).ToArray();
            var right = numbers.Skip(numbers.Length / 2).ToArray();

            return Merge(MergeSort(left), MergeSort(right));
        }

        private static int[] Merge(int[] left, int[] right)
        {
            var merged = new int[left.Length + right.Length];

            var mergeIdx = 0;
            var leftIdx = 0;
            var rightIdx = 0;

            while (leftIdx < left.Length && rightIdx < right.Length)
            {
                if (left[leftIdx] < right[rightIdx])
                {
                    merged[mergeIdx++] = left[leftIdx++];
                }
                else
                {
                    merged[mergeIdx++] = right[rightIdx++];
                }
            }

            for (int i = rightIdx; i < right.Length; i++)
            {
                merged[mergeIdx++] = right[i];
            }

            for (int i = leftIdx; i < left.Length; i++)
            {
                merged[mergeIdx++] = left[i];
            }

            return merged;
        }

        private class SubSetSumAlg
        {
            private static List<int> FindSubset(Dictionary<int, int> allSums, int target)
            {
                var subset = new List<int>();

                while (target != 0)
                {
                    var element = allSums[target];
                    subset.Add(element);

                    target -= element;
                }

                return subset;
            }

            private static Dictionary<int, int> SubSetSum(int[] elements)
            {
                var res = new Dictionary<int, int>() { { 0, 0 } };

                foreach (var element in elements)
                {
                    var currSums = res.Keys.ToArray();

                    foreach (var sum in currSums)
                    {
                        var newSum = sum + element;

                        if (res.ContainsKey(newSum))
                        {
                            continue;
                        }

                        res[newSum] = element;
                    }
                }

                return res;
            }
        }
    }
    class ruffleSortAlg // This algorithm shuffles the elements in the array and then sort it.
                        // Thats made to bait the tests if they made tests to test if we sort it correctly
    {
        private static void ruffleSort(int[] a)
        {
            var n = a.Length;
            var rnd = new Random();

            for (int i = 0; i < n; i++)
            {
                var oi = rnd.Next(n);
                var temp = a[oi];
                a[oi] = a[i];
                a[i] = temp;
            }

            Array.Sort(a);
        }
    }

    class GetLenghtOfBiggestSubarrayBetweenTwoSubarraysAlg
    {
        public static int GetLenghtOfBiggestSubarrayBetweenTwoSubarrays(int[] nums1, int[] nums2)
        {
            var dp = new int[nums1.Length + 1, nums2.Length + 1];

            for (int r = 1; r < dp.GetLength(0); r++)
            {
                for (int c = 1; c < dp.GetLength(1); c++)
                {
                    if (nums1[r - 1] == nums2[c - 1])
                    {
                        dp[r, c] = dp[r - 1, c - 1] + 1;
                    }
                    else
                    {
                        dp[r, c] = Math.Max(dp[r - 1, c], dp[r, c - 1]);
                    }
                }
            }

            return dp[nums1.Length, nums2.Length];
        }
    }

    class KnapknacsProblem
    {
        void Solve()
        {
            int stamina = int.Parse(Console.ReadLine());

            List<string> trackNames = Console.ReadLine().Split(' ').ToList();
            List<int> trackStaminaNeeded = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            List<int> trackChallenges = Console.ReadLine().Split(' ').Select(int.Parse).ToList();

            List<Track> tracks = new List<Track>();

            for (int i = 0; i < trackChallenges.Count; i++)
            {
                tracks.Add(new Track(trackNames[i], trackStaminaNeeded[i], trackChallenges[i]));
            }

            tracks = tracks.OrderByDescending(x => x.Stamina).ToList();

            var dp = new int[tracks.Count + 1, stamina + 1];
            var tracksUsed = new bool[tracks.Count + 1, stamina + 1];

            for (int trackIndex = 0; trackIndex < tracks.Count; trackIndex++)
            {
                var track = tracks[trackIndex];
                var rowIndex = trackIndex + 1;

                for (int s = 0; s <= stamina; s++)
                {
                    if (track.Stamina > s)
                    {
                        continue;
                    }

                    var excluding = dp[rowIndex - 1, s]; // Checking what will the value be if we dont get it
                    var including = track.Challenges + dp[rowIndex - 1, s - track.Stamina]; // Checking what the value be if we get

                    if (including > excluding)
                    {
                        dp[rowIndex, s] = including;
                        tracksUsed[rowIndex, s] = true;
                    }
                    else
                    {
                        dp[rowIndex, s] = excluding;
                    }
                }
            }

            var res = new List<Track>();
            var currentStamina = stamina;

            for (int trackIndex = tracks.Count; trackIndex >= 0; trackIndex--)
            {
                if (tracksUsed[trackIndex, currentStamina])
                {
                    res.Add(tracks[trackIndex - 1]);

                    currentStamina -= tracks[trackIndex - 1].Stamina;
                }
            }

            Console.WriteLine(string.Join(" ", res.Select(x => x.Name).OrderBy(x => x)));
            Console.WriteLine(dp[tracks.Count, stamina]);
            Console.WriteLine(stamina - res.Sum(x => x.Stamina));

        }
        public class Track
        {
            public Track(string name, int stamina, int challenges)
            {
                this.Name = name;
                this.Stamina = stamina;
                this.Challenges = challenges;
            }
            public string Name { get; set; }
            public int Stamina { get; set; }
            public int Challenges { get; set; }
        }
    }
    class LumberSolution
    {
        public class Program
        {
            private static List<int>[] graph;
            private static bool[] visited;
            private static int label = 1;
            private static int[] labels;
            static void Solve(string[] args)
            {
                var input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var logsCount = input[0];
                var tests = input[1];

                var logs = new List<Log>();

                graph = new List<int>[logsCount + 1];

                for (int i = 0; i <= logsCount; i++)
                {
                    graph[i] = new List<int>();
                }

                for (int l = 1; l <= logsCount; l++)
                {
                    var arguments = Console.ReadLine().Split().Select(int.Parse).ToArray();

                    var newLog = new Log(l, arguments[0], arguments[2], arguments[1], arguments[3]);

                    foreach (var log in logs)
                    {
                        if (newLog.Cross(log))
                        {
                            graph[l].Add(log.Id);
                            graph[log.Id].Add(l);
                        }
                    }

                    logs.Add(newLog);
                }

                visited = new bool[logsCount + 1];
                labels = new int[logsCount + 1];

                for (int i = 1; i <= logsCount; i++)
                {
                    if (!visited[i])
                    {
                        Dfs(i);
                        label++;
                    }
                }

                for (int i = 0; i < tests; i++)
                {
                    var inp = Console.ReadLine().Split().Select(int.Parse).ToArray();

                    var start = inp[0];
                    var target = inp[1];

                    Console.WriteLine(labels[start] == labels[target] ? "YES" : "NO");
                }
            }

            private static void Dfs(int node)
            {
                if (visited[node])
                {
                    return;
                }

                visited[node] = true;
                labels[node] = label;


                foreach (var child in graph[node])
                {
                    Dfs(child);
                }
            }
        }

        class Log
        {
            public Log(int id, int x1, int x2, int y1, int y2)
            {
                Id = id;
                X1 = x1;
                X2 = x2;
                Y1 = y1;
                Y2 = y2;
            }

            public int Id { get; set; }
            public int X1 { get; set; }
            public int X2 { get; set; }
            public int Y1 { get; set; }
            public int Y2 { get; set; }

            public bool Cross(Log log) // Check if two figures in a coordinate system are crossing
            {
                var line = this.X1 <= log.X2 && this.X2 >= log.X1;
                var down = this.Y1 >= log.Y2 && log.Y1 >= this.Y2;

                return line && down;
            }
        }
    }
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
}


