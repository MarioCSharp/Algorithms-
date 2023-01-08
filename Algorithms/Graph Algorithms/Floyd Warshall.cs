public static int[,] FloydWarshall(IDictionary<int, IList<(int to, int weight)>> graph, int verticesCount)
{
    int[,] distance = new int[verticesCount + 1, verticesCount + 1];

    for (int i = 0; i < verticesCount; i++)
    {
        for (int j = 0; j < verticesCount; j++)
        {
            distance[i, j] = int.MaxValue;
            if (i == j)
            {
                distance[i, j] = 0;
            }
        }
    }

    foreach (var p in graph)
    {
        foreach (var data in p.Value)
        {
            distance[p.Key, data.to] = data.weight;
        }
    }

    for (int k = 0; k < verticesCount; k++)
    {
        for (int i = 0; i < verticesCount; i++)
        {
            for (int j = 0; j < verticesCount; j++)
            {
                if (distance[i, k] != int.MaxValue && distance[k, j] != int.MaxValue && distance[i, k] + distance[k, j] < distance[i, j])
                {
                    distance[i, j] = distance[i, k] + distance[k, j];
                }
            }
        }
    }

    return distance;
}