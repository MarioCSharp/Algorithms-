namespace ConsoleApp17
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var items = new List<Item>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();

                items.Add(new Item(input[0], int.Parse(input[1]), int.Parse(input[2])));
            }

            var bagCapacity = int.Parse(Console.ReadLine());

            var dp = new int[items.Count + 1, bagCapacity + 1];
            var used = new bool[items.Count + 1, bagCapacity + 1];

            for (int itemIndex = 0; itemIndex < items.Count; itemIndex++)
            {
                var rowIndex = itemIndex + 1;
                var item = items[itemIndex];

                for (int capacity = 0; capacity <= bagCapacity; capacity++)
                {
                    if (item.Weight > capacity)
                    {
                        continue;
                    }

                    var notAdd = dp[rowIndex - 1, capacity];
                    var add = item.Value + dp[rowIndex - 1, capacity - item.Weight];

                    if (add > notAdd)
                    {
                        dp[rowIndex, capacity] = add;
                        used[rowIndex, capacity] = true;
                    }
                    else
                    {
                        dp[rowIndex, capacity] = notAdd;
                    }
                }
            }

            Console.WriteLine(dp[items.Count, bagCapacity]);
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
}