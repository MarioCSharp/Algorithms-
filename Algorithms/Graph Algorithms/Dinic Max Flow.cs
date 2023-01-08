private static int[,] graph;

private static int[] BFSDist;

private static int[] childCounter;

private static int end;

private static int[] paths;

private static int nodes;

static int Dinic(int source, int target)
{
    int result = 0;

    while (BFS(source, target))
    {
        for (int i = 0; i < childCounter.Length; i++)
        {
            childCounter[i] = 0;
        }

        int delta;

        do
        {
            delta = DFS(source, int.MaxValue);
            result += delta;
        } while (delta != 0);
    }

    return result;
}

static int DFS(int source, int flow)
{
    if (source == end)
    {
        return flow;
    }
    for (int i = childCounter[source]; i < graph.GetLength(0); i++, childCounter[source]++)
    {
        var child = i;
        if (graph[source, child] > 0)
        {
            if (BFSDist[child] == BFSDist[source] + 1)
            {

                int augPath = DFS(child, Math.Min(flow, graph[source, child]));
                if (augPath > 0)
                {
                    if (source < nodes && source != 1)
                    {
                        paths[source] = child;
                    }
                    graph[source, child] -= augPath;
                    graph[child, source] += augPath;
                    return augPath;
                }
            }
        }
    }

    return 0;
}

static bool BFS(int start, int end)
{
    for (int i = 0; i < BFSDist.Length; i++)
    {
        BFSDist[i] = -1;
    }

    BFSDist[start] = 0;

    Queue<int> q = new Queue<int>();

    q.Enqueue(start);

    while (q.Count > 0)
    {
        var curr = q.Dequeue();

        for (int i = 0; i < graph.GetLength(0); i++)
        {
            if (graph[curr, i] > 0 && BFSDist[i] == -1)
            {
                BFSDist[i] = BFSDist[curr] + 1;
                q.Enqueue(i);
            }
        }
    }

    return BFSDist[end] >= 0;
}