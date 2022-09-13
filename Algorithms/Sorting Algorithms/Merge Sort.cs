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