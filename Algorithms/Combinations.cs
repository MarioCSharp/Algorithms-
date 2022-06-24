namespace ConsoleApp17
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    public class Program
    {
        private static string[] elements;
        private static int k;
        private static string[] combinations;
        private static List<string> allCombinations;
        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split().ToArray();

            k = int.Parse(Console.ReadLine());
            allCombinations = new List<string>();
            combinations = new string[k];

            GenCombinations(0, 0);

            Console.WriteLine(string.Join("\n", allCombinations));
        }
        private static void GenCombinations(int index, int elementsStartIndex)
        {
            if (index >= combinations.Length)
            {
                allCombinations.Add(string.Join(" ", combinations));
                return;
            }

            for (int i = elementsStartIndex; i < elements.Length; i++)
            {
                combinations[index] = elements[i];
                GenCombinations(index + 1, i + 1);
            }
        }
    }
}