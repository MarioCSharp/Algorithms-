private static void QuickSort(int[] numbers, int start, int end)
{
    if (start >= end)
    {
        return;
    }

    var pivot = start;
    var left = start + 1;
    var right = end;

    while (left <= right)
    {
        if (numbers[left] > numbers[pivot] && numbers[right] < numbers[pivot])
        {
            Swap(numbers, left, right);
        }

        if (numbers[right] >= numbers[pivot])
        {
            right--;
        }

        if (numbers[left] < numbers[pivot])
        {
            left--;
        }
    }

    Swap(numbers, pivot, right);

    QuickSort(numbers, start, right - 1);
    QuickSort(numbers, right + 1, end);