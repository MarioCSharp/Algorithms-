class Solution
{
    private static void Solve()
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
