private static int CutRod(int length, int[] prices)
{
    if (length == 0)
    {
        return prices[length];
    }

    if (bestPrices[length] != 0)
    {
        return bestPrices[length];
    }

    var bestPrice = prices[length];
    var bestCombo = length;

    for (int i = 1; i < length; i++)
    {
        var currentPrice = prices[i] + CutRod(length - i, prices);

        if (currentPrice >= bestPrice)
        {
            bestPrice = currentPrice;
            bestCombo = i;
        }
    }

    bestPrices[length] = bestPrice;
    prev[length] = bestCombo;

    return bestPrice;
}