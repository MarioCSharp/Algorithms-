static void LIS()
{
    var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

    var length = new int[numbers.Length];
    var parent = new int[numbers.Length];

    var ans = 0;
    var bestIdx = 0;

    for (int i = 0; i < numbers.Length; i++)
    {
        var currentNumber = numbers[i];
        var currentSolution = 1;
        var currentParent = -1;

        for (int prev = i - 1; prev >= 0; prev--)
        {
            var prevNumber = numbers[prev];
            var prevLength = length[prev];

            if (currentNumber > prevNumber && prevLength + 1 >= currentSolution)
            {
                currentSolution = prevLength + 1;
                currentParent = prev;
            }
        }

        length[i] = currentSolution;
        parent[i] = currentParent;

        if (ans < currentSolution)
        {
            ans = currentSolution;
            bestIdx = i;
        }
    }

    var lis = new Stack<int>();

    while (bestIdx != -1)
    {
        lis.Push(numbers[bestIdx]);
        bestIdx = parent[bestIdx];
    }

    Console.WriteLine(string.Join(" ", lis));
}