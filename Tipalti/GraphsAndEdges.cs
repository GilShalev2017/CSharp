/*
using System;
using System.Collections.Generic;

class Graph
{
    private Dictionary<int, List<int>> adjList;

    public Graph(int numNodes)
    {
        adjList = new Dictionary<int, List<int>>();
        for (int i = 0; i < numNodes; i++)
        {
            adjList[i] = new List<int>();
        }
    }

    public void AddEdge(int u, int v)
    {
        adjList[u].Add(v);
        adjList[v].Add(u); // Undirected graph, so add edges in both directions
    }

    public int FindShortestPathSum(int start, int end)
    {
        if (!adjList.ContainsKey(start) || !adjList.ContainsKey(end))
        {
            throw new ArgumentException("Start or end node not found in the graph.");
        }

        int[] distance = new int[adjList.Count];
        for (int i = 0; i < distance.Length; i++)
        {
            distance[i] = -1; // Initialize distances to -1 (unvisited)
        }

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(start);
        distance[start] = 0;

        while (queue.Count > 0)
        {
            int current = queue.Dequeue();

            if (current == end)
            {
                // Found the shortest path
                int sum = 0;
                while (current != start)
                {
                    foreach (int neighbor in adjList[current])
                    {
                        if (distance[neighbor] == distance[current] - 1)
                        {
                            sum += 1; // Adding 1 for each edge in the path
                            current = neighbor;
                            break;
                        }
                    }
                }
                return sum;
            }

            foreach (int neighbor in adjList[current])
            {
                if (distance[neighbor] == -1)
                {
                    distance[neighbor] = distance[current] + 1;
                    queue.Enqueue(neighbor);
                }
            }
        }

        // No path found
        return -1;
    }
}

class Program
{
    static void Main()
    {
        Graph graph = new Graph(6);

        // Define the edges of the graph
        graph.AddEdge(0, 1);
        graph.AddEdge(1, 2);
        graph.AddEdge(2, 0);
        graph.AddEdge(3, 4);
        graph.AddEdge(4, 5);

        int shortestPathSum = graph.FindShortestPathSum(0, 2);
        Console.WriteLine("Shortest path sum between nodes 0 and 2: " + shortestPathSum);
    }
}
/*
In this code, the Graph class represents the undirected cyclic and not connected graph, 
and it provides methods to add edges and find the shortest path sum between two nodes
using BFS.The FindShortestPathSum method calculates the sum of edges in the shortest 
path between two nodes.
*/