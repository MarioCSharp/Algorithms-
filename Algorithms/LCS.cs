class LcsClass
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
