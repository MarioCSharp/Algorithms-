using System;
using System.Linq;

namespace StabilityCheck_Fast
{
    public class StabilityCheck
    {
        private static int[,] matrix;
        private static int building;

        private static int[,] sumMatrix;

        private static int n;

        static void Main(string[] args)
        {
            building = int.Parse(Console.ReadLine());
            n = int.Parse(Console.ReadLine());
            matrix = new int[n, n];
            sumMatrix = new int[n, n];

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int j = 0; j < line.Length; j++)
                {
                    matrix[i, j] = line[j];

                    if (i == 0 && j == 0)
                    {
                        sumMatrix[i, j] = line[j];
                    }
                    else if (i == 0)
                    {
                        sumMatrix[i, j] = line[j] + sumMatrix[i, j - 1];
                    }
                    else if (j == 0)
                    {
                        sumMatrix[i, j] = line[j] + sumMatrix[i - 1, j];
                    }
                    else
                    {
                        sumMatrix[i, j] = line[j] + sumMatrix[i - 1, j] + sumMatrix[i, j - 1] - sumMatrix[i - 1, j - 1];
                    }
                }
            }

            Console.WriteLine(GetMaxSum());
        }

        private static long CalculateSum(int startRow, int startCol, int endRow, int endCol)
        {
            if (startRow == 0 && startCol == 0)
            {
                return sumMatrix[endRow, endCol];
            }
            else if (startRow == 0)
            {
                return sumMatrix[endRow, endCol] - sumMatrix[endRow, startCol - 1];
            }
            else if (startCol == 0)
            {
                return sumMatrix[endRow, endCol] - sumMatrix[startRow - 1, endCol];
            }
            else
            {
                return sumMatrix[endRow, endCol] - sumMatrix[startRow - 1, endCol] - sumMatrix[endRow, startCol - 1] +
                       sumMatrix[startRow - 1, startCol - 1];
            }
        }

        private static long GetMaxSum()
        {
            int roof = n - building;
            long maxSum = long.MinValue;
            for (int i = 0; i <= roof; i++)
            {
                for (int j = 0; j <= roof; j++)
                {
                    maxSum = Math.Max(maxSum, CalculateSum(i, j, i + building - 1, j + building - 1));
                }
            }

            return maxSum;
        }

    }
}
