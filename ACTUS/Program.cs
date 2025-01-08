using System.Diagnostics;

class Program
{
    class MazeSolver
    {
        private int[,] maze;
        private bool[,] visited;
        private int rows;
        private int columns;
        private int startRow;
        private int startColumn;
        private int exitRow;
        private int exitColumn;
        private int[] dr = { -1, 1, 0, 0 }; // Possible movements: N(up), S(down), E(left), W(right)
        private int[] dc = { 0, 0, -1, 1 }; // Possible movements: N(up), S(down), E(left), W(right)

        public MazeSolver(int[,] maze)
        {
            this.maze = maze;
            rows = maze.GetLength(0);
            columns = maze.GetLength(1);
            visited = new bool[rows, columns];
        }

        public bool Solve(int startRow, int startColumn, int exitRow, int exitColumn)
        {
            this.startRow = startRow;
            this.startColumn = startColumn;
            this.exitRow = exitRow;
            this.exitColumn = exitColumn;

            //Perform DFS to find a path from start to exit
            return DFS(startRow, startColumn);
        }
        private bool DFS(int row, int column)
        {
            // Check if the current position is out of bounds or a wall
            if (row < 0 || row >= rows || column < 0 || column >= columns || maze[row, column] == 1)
                return false;

            // Check if the current position is the exit
            if (row == exitRow && column == exitColumn)
                return true;

            // Mark the current position as visited
            visited[row, column] = true;

            // Explore adjacent cells in all directions
            for (int i = 0; i < 4; i++)
            {
                int newRow = row + dr[i];
                int newColumn = column + dc[i];

                if (!visited[newRow, newColumn])
                {
                    if (DFS(newRow, newColumn))
                        return true;
                }
            }

            // Backtrack: mark the current position as unvisited
            visited[row, column] = false;

            return false;
        }

        public void PrintMaze()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    Console.ForegroundColor = ConsoleColor.White;

                    if (row == startRow && column == startColumn)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write('S'); // Start position
                    }
                    else if (row == exitRow && column == exitColumn)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write('E'); // Exit position
                    }
                    else if (visited[row, column])
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('X'); // Path
                    }
                    else
                    {
                        if (maze[row, column] == 0)
                            Console.Write(' ');
                        else
                            Console.Write('W');
                    }
                }

                Console.WriteLine();
            }
        }
    }

    static int[,] ReadMazeInput(string filePath,out int startRow, out int startCol, out int endRow, out int endCol)
    {
        string[] lines = File.ReadAllLines(filePath);

        var width_height_line_splits = lines[0].Split(' ');
        var start_col_row_line_splits = lines[1].Split(' ');
        var end_col_row_line_splits = lines[2].Split(' ');

        int width = Convert.ToInt32(width_height_line_splits[0]);//columns
        int height = Convert.ToInt32(width_height_line_splits[1]);//rows
        startCol = Convert.ToInt32(start_col_row_line_splits[0]);
        startRow = Convert.ToInt32(start_col_row_line_splits[1]);
        endCol = Convert.ToInt32(end_col_row_line_splits[0]);
        endRow = Convert.ToInt32(end_col_row_line_splits[1]);

        int[,] maze = new int[height, width];
        
        for (int i = 3; i < lines.Length; i++)
        {
            var currentLineSplits = lines[i].Split(' ');
            for (int j = 0; j < width; j++)
            {
                maze[i - 3, j] = Convert.ToInt32(currentLineSplits[j]);
            }
        }

        return maze;
    }
    static void Main()
    {
        string[] filePaths = { "input.txt", "large_input.txt", "medium_input.txt", "small.txt", "sparse_medium.txt" };

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        
        foreach(string filePath in filePaths)
        {
            try
            {
                int startRow, startCol, endRow, endCol;

                var maze = ReadMazeInput(filePath, out startRow, out startCol, out endRow, out endCol);

                MazeSolver solver = new(maze);

                bool canSolve = solver.Solve(startRow, startCol, endRow, endCol);

                Console.WriteLine(canSolve ? $"\nMaze, based on input file: {filePath}, solved!\n" : "No solution found.");

                solver.PrintMaze();
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error reading file {filePath}: {ex.Message}");
            }
        };

        stopwatch.Stop();

        Console.WriteLine($"\nAll files processed. Elapsed time (hh:mm:ss:miliseconds): {stopwatch.Elapsed}");

        Console.ReadLine();
    }
}
