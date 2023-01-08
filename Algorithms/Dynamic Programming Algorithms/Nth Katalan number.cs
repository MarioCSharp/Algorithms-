// A recursive function to find
// nth catalan number
static int catalan(int n)
{
    int res = 0;

    // Base case
    if (n <= 1)
    {
        return 1;
    }
    for (int i = 0; i < n; i++)
    {
        res += catalan(i) * catalan(n - i - 1);
    }
    return res;
}

// Driver Code
public static void Main()
{
    for (int i = 0; i < 10; i++)
        Console.Write(catalan(i) + " ");
}