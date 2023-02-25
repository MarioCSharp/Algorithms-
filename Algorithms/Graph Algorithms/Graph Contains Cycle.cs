// with union by rank and path compression
using System;
using System.Collections.Generic;

class GFG
{
    static int MAX_VERTEX = 101;

    // Arr to represent parent of index i
    static int[] Arr = new int[MAX_VERTEX];

    // Size to represent the number of nodes
    // in subgraph rooted at index i
    static int[] size = new int[MAX_VERTEX];

    // set parent of every node to itself
    // and size of node to one
    static void initialize(int n)
    {
        for (int i = 0; i <= n; i++)
        {
            Arr[i] = i;
            size[i] = 1;
        }
    }

    // Each time we follow a path,
    // find function compresses it further
    // until the path length is greater than
    // or equal to 1.
    static int find(int i)
    {
        // while we reach a node whose
        // parent is equal to itself
        while (Arr[i] != i)
        {
            Arr[i] = Arr[Arr[i]]; // Skip one level
            i = Arr[i]; // Move to the new level
        }
        return i;
    }

    // A function that does union of
    // two nodes x and y where xr is
    // root node of x and yr is root node of y
    static void _union(int xr, int yr)
    {
        if (size[xr] < size[yr]) // Make yr parent of xr
        {
            Arr[xr] = Arr[yr];
            size[yr] += size[xr];
        }
        else // Make xr parent of yr
        {
            Arr[yr] = Arr[xr];
            size[xr] += size[yr];
        }
    }

    // The main function to check whether
    // a given graph contains cycle or not
    static int isCycle(List<int>[] adj, int V)
    {
        // Iterate through all edges of graph,
        // find nodes connecting them.
        // If root nodes of both are same,
        // then there is cycle in graph.
        for (int i = 0; i < V; i++)
        {
            for (int j = 0; j < adj[i].Count; j++)
            {
                int x = find(i); // find root of i

                // find root of adj[i][j]
                int y = find(adj[i][j]);

                if (x == y)
                    return 1; // If same parent
                _union(x, y); // Make them connect
            }
        }
        return 0;
    }

    // Driver Code
    public static void Main(String[] args)
    {
        int V = 3;

        // Initialize the values for
        // array Arr and Size
        initialize(V);

        /* Let us create following graph
            0
            | \
            | \
            1-----2 */

        // Adjacency list for graph
        List<int>[] adj = new List<int>[V];
        for (int i = 0; i < V; i++)
            adj[i] = new List<int>();

        adj[0].Add(1);
        adj[0].Add(2);
        adj[1].Add(2);

        // call is_cycle to check if it contains cycle
        if (isCycle(adj, V) == 1)
            Console.Write("Graph contains Cycle.\n");
        else
            Console.Write("Graph does not contain Cycle.\n");
    }
}