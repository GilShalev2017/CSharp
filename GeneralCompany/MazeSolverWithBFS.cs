using System;
using System.Collections.Generic;
/*
class MazeSolver
{
    private char[,] maze;
    private bool[,] visited;
    private int[,] distances;
    private int[,] parents;
    private int rows;
    private int columns;
    private int startRow;
    private int startColumn;
    private int exitRow;
    private int exitColumn;
    private int[] dr = { -1, 1, 0, 0 }; // Possible movements: up, down, left, right
    private int[] dc = { 0, 0, -1, 1 };

    public MazeSolver(char[,] maze)
    {
        this.maze = maze;
        rows = maze.GetLength(0);
        columns = maze.GetLength(1);
        visited = new bool[rows, columns];
        distances = new int[rows, columns];
        parents = new int[rows, columns];
    }

    public bool Solve(int startRow, int startColumn, int exitRow, int exitColumn)
    {
        this.startRow = startRow;
        this.startColumn = startColumn;
        this.exitRow = exitRow;
        this.exitColumn = exitColumn;

        // Perform BFS to find the shortest path from start to exit
        return BFS();
    }

    private bool BFS()
    {
        // Initialize distances and parents arrays
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                distances[row, column] = int.MaxValue;
                parents[row, column] = -1;
            }
        }

        // Create a queue for BFS traversal
        Queue<(int, int)> queue = new Queue<(int, int)>();

        // Enqueue the start position and set distance to 0
        queue.Enqueue((startRow, startColumn));
        distances[startRow, startColumn] = 0;

        while (queue.Count > 0)
        {
            var (row, column) = queue.Dequeue();

            // Check if the current position is the exit
            if (row == exitRow && column == exitColumn)
                return true;

            // Explore adjacent cells in all directions
            for (int i = 0; i < 4; i++)
            {
                int newRow = row + dr[i];
                int newColumn = column + dc[i];

                // Check if the new position is within bounds and a valid passage
                if (newRow >= 0 && newRow < rows && newColumn >= 0 && newColumn < columns && maze[newRow, newColumn] != '#' && !visited[newRow, newColumn])
                {
                    // Mark the new position as visited
                    visited[newRow, newColumn] = true;

                    // Update the distance to the new position
                    distances[newRow, newColumn] = distances[row, column] + 1;

                    // Update the parent of the new position
                    parents[newRow, newColumn] = i;

                    // Enqueue the new position
                    queue.Enqueue((newRow, newColumn));
                }
            }
        }

        return false;
    }

    public void PrintShortestPath()
    {
        if (distances[exitRow, exitColumn] == int.MaxValue)
        {
            Console.WriteLine("No solution found.");
            return;
        }

        int row = exitRow;
        int column = exitColumn;

        while (row != startRow || column != startColumn)
        {
            maze[row, column] = 'X'; // Mark the path

            // Find the previous position using the parent array
            int parentIndex = parents[row, column];
            row -= dr[parentIndex];
            column -= dc[parentIndex];
        }

        maze[startRow, startColumn] = 'S'; // Mark the start position

        for (row = 0; row < rows; row++)
        {
            for (column = 0; column < columns; column++)
            {
                Console.Write(maze[row, column]);
            }

            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main()
    {
        char[,] maze = {
            { '#', '#', '#', '#', '#', '#' },
            { '#', ' ', ' ', ' ', ' ', '#' },
            { '#', '#', '#', ' ', '#', '#' },
            { '#', ' ', ' ', ' ', ' ', '#' },
            { '#', '#', '#', '#', '#', '#' }
        };

        MazeSolver solver = new MazeSolver(maze);
        bool canSolve = solver.Solve(1, 1, 3, 4);

        if (canSolve)
        {
            Console.WriteLine("Shortest path found:");
            solver.PrintShortestPath();
        }
        else
        {
            Console.WriteLine("No solution found.");
        }
    }
}
*/