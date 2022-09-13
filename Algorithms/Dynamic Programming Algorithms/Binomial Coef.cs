private static int GetBinom(int row, int col)
{
    if (row == 0 || col == 0 || col == row)
    {
        return 1;
    }

    return GetBinom(row - 1, col) + GetBinom(row - 1, col - 1);
}