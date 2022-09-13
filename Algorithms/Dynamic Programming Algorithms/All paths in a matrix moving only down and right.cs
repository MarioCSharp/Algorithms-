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