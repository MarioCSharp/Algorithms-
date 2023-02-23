namespace AlgorithmsNetCore6
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Program
    {
        private static List<Item> items = new List<Item>();
        static void Main()
        {
            var maxCapacity = int.Parse(Console.ReadLine());

            var line = string.Empty;


            while ((line = Console.ReadLine()) != "end")
            {
                var args = line.Split();

                var name = args[0];
                var weight = int.Parse(args[1]);
                var value = int.Parse(args[2]);

                items.Add(new Item(name, weight, value));
            }

            var dp = new int[items.Count + 1, maxCapacity + 1];
            var used = new bool[items.Count + 1, maxCapacity + 1];

            for (int row = 1; row < dp.GetLength(0); row++)
            {
                var itemIndex = row - 1;
                var item = items[itemIndex];

                for (int capacity = 1; capacity < dp.GetLength(1); capacity++)
                {
                    var excluding = dp[row - 1, capacity];

                    if (item.Weight > capacity)
                    {
                        dp[row, capacity] = excluding;
                        continue;
                    }

                    var including = dp[row - 1, capacity - item.Weight] + item.Value;

                    if (including > excluding)
                    {
                        dp[row, capacity] = including;
                        used[row, capacity] = true;
                    }
                    else
                    {
                        dp[row, capacity] = excluding;
                    }
                }
            }

            var currentCapacity = maxCapacity;

            var totalWeight = 0;

            var res = new List<string>();

            for (int row = dp.GetLength(0) - 1; row > 0; row--)
            {
                if (!used[row, currentCapacity])
                {
                    continue;
                }

                var item = items[row - 1];
                currentCapacity -= item.Weight;
                totalWeight += item.Weight;

                res.Add(item.Name);

                if (currentCapacity == 0)
                {
                    break;
                }
            }

            Console.WriteLine($"Total Weight: {totalWeight}");
            Console.WriteLine($"Total Value: {dp[items.Count, maxCapacity]}");
            Console.WriteLine(string.Join("\n", res.OrderBy(x => x)));
        }
    }

    public class Item
    {
        public Item(string name, int weight, int value)
        {
            Name = name;
            Weight = weight;
            Value = value;
        }

        public string Name { get; set; }
        public int Weight { get; set; }
        public int Value { get; set; }
    }
}