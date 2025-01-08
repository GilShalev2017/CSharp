using System;
using System.Collections.Generic;
/*
class Graph
{
    private Dictionary<string, Dictionary<string, int>> adjacencyList;

    public Graph()
    {
        adjacencyList = new Dictionary<string, Dictionary<string, int>>();
    }

    public void AddEdge(string source, string destination, int weight)
    {
        if (!adjacencyList.ContainsKey(source))
        {
            adjacencyList[source] = new Dictionary<string, int>();
        }

        if (!adjacencyList.ContainsKey(destination))
        {
            adjacencyList[destination] = new Dictionary<string, int>();
        }

        adjacencyList[source][destination] = weight;
    }

    public List<string> FindShortestPath(string start, string end)
    {
        Dictionary<string, int> distances = new Dictionary<string, int>();
        Dictionary<string, string> previousNodes = new Dictionary<string, string>();
        List<string> path = new List<string>();

        foreach (var node in adjacencyList.Keys)
        {
            distances[node] = int.MaxValue;
            previousNodes[node] = null;
        }

        distances[start] = 0;

        var nodes = new List<string>(adjacencyList.Keys);

        while (nodes.Count != 0)
        {
            nodes.Sort((x, y) => distances[x] - distances[y]);
            var smallest = nodes[0];
            nodes.Remove(smallest);

            if (distances[smallest] == int.MaxValue || smallest == end)
            {
                break;
            }

            foreach (var neighbor in adjacencyList[smallest])
            {
                var alt = distances[smallest] + neighbor.Value;
                if (alt < distances[neighbor.Key])
                {
                    distances[neighbor.Key] = alt;
                    previousNodes[neighbor.Key] = smallest;
                }
            }
        }

        while (previousNodes[end] != null)
        {
            path.Insert(0, end);
            end = previousNodes[end];
        }

        path.Insert(0, start);

        return distances[end] == int.MaxValue ? new List<string>() : path;
    }
}

class Program
{
    static void Main()
    {
        Graph graph = new Graph();
        graph.AddEdge("A", "B", 1);
        graph.AddEdge("A", "C", 3);
        graph.AddEdge("B", "C", 1);
        graph.AddEdge("B", "D", 4);
        graph.AddEdge("C", "D", 1);
        graph.AddEdge("D", "E", 2);
        graph.AddEdge("E", "A", 1);

        string startNode = "A";
        string endNode = "D";

        List<string> shortestPath = graph.FindShortestPath(startNode, endNode);

        if (shortestPath.Count > 0)
        {
            Console.WriteLine("Shortest path from " + startNode + " to " + endNode + ": " + string.Join(" -> ", shortestPath));
        }
        else
        {
            Console.WriteLine("No path found from " + startNode + " to " + endNode);
        }
    }
}
*/