using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace General
{
    //ctrl + k + f // to indent
    using System;
    /*
    public class Program
    {
        //Nested class to represent a single cell in the Minesweeper game.
        public class Cell
        {
            //Whether the cell contains a mine
            public bool IsMine { get; set; }
            //Number of mines in surrounding cells
            public int SurroundingMines { get; set; }
        }

        //public static void Main()
        //{
        //    //Create the board array
        //    Cell[,] board = new Cell[8, 8];

        //    //Populate the board with cells
        //    for (int row = 0; row < board.GetLength(0); row++)
        //    {
        //        for (int col = 0; col < board.GetLength(1); col++)
        //        {
        //            board[row, col] = new Cell();
        //        }
        //    }

        //    //Populate the board with mines
        //    PopulateBoardWithMines(board);

        //    //Calculate the number of surrounding mines for each cell
        //    CalculateSurroundingMines(board);

        //    //Print the board
        //    PrintBoard(board);
        //}

        //Function to populate the board with mines
        public static void PopulateBoardWithMines(Cell[,] board)
        {
            Random rand = new Random();

            //Generate random positions for the mines
            for (int i = 0; i < 10; i++)
            {
                int row = rand.Next(0, board.GetLength(0));
                int col = rand.Next(0, board.GetLength(1));

                board[row, col].IsMine = true;
            }
        }

        //Function to calculate the number of surrounding mines for each cell
        public static void CalculateSurroundingMines(Cell[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col].SurroundingMines = GetSurroundingMines(board, row, col);
                }
            }
        }

        //Function to get the number of surrounding mines for a given cell
        //Function to get the number of surrounding mines for a given cell
        public static int GetSurroundingMines(Cell[,] board, int row, int col)
        {
            int count = 0;

            //Check each cell in the 3x3 grid surrounding the given cell
            for (int r = row - 1; r <= row + 1; r++)
            {
                for (int c = col - 1; c <= col + 1; c++)
                {
                    //Make sure the cell is within the bounds of the board
                    if (r >= 0 && r < board.GetLength(0) && c >= 0 && c < board.GetLength(1))
                    {
                        if (board[r, c].IsMine)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }

        //Function to print the board
        public static void PrintBoard(Cell[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col].IsMine)
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write(board[row, col].SurroundingMines + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        //Create a class to represent the Minesweeper game board

        public class GameBoard
        {
            public int Width { get; set; }
            public int Height { get; set; }
            public int[,] Cells { get; set; }

            public GameBoard(int width, int height)
            {
                this.Width = width;
                this.Height = height;

                Cells = new int[width, height];
            }

            public void PlaceMines(int numOfMines)
            {
                // generate random locations for mines
                var random = new Random();
                for (var i = 0; i < numOfMines; i++)
                {
                    // generate random position
                    var x = random.Next(0, Width);
                    var y = random.Next(0, Height);

                    // check if position is empty
                    if (Cells[x, y] == 0)
                    {
                        Cells[x, y] = -1; // -1 is a mine
                    }
                    else
                    {
                        // position occupied, try again
                        i--;
                    }
                }
            }

            public void CalculateMineCounts()
            {
                // loop through each cell
                for (var x = 0; x < Width; x++)
                {
                    for (var y = 0; y < Height; y++)
                    {
                        // skip cells that are mines
                        if (Cells[x, y] == -1)
                        {
                            continue;
                        }

                        // count mines around current cell
                        var mineCount = 0;
                        for (var i = -1; i <= 1; i++)
                        {
                            for (var j = -1; j <= 1; j++)
                            {
                                // skip current cell
                                if (i == 0 && j == 0)
                                {
                                    continue;
                                }

                                // check if cell is in bounds
                                if (x + i >= 0 && x + i < Width && y + j >= 0 && y + j < Height)
                                {
                                    // check if cell is a mine
                                    if (Cells[x + i, y + j] == -1)
                                    {
                                        mineCount++;
                                    }
                                }
                            }
                        }

                        // set mine count
                        Cells[x, y] = mineCount;
                    }
                }
            }
        }
        public class MinesweeperGame
        {
            //Declare private variables to represent the board and user input
            private string[,] board;
            private int userInputRow;
            private int userInputCol;

            //Constructor to initialize the game board and user input
            public MinesweeperGame(string[,] board, int userInputRow, int userInputCol)
            {
                this.board = board;
                this.userInputRow = userInputRow;
                this.userInputCol = userInputCol;
            }

            //Method to execute the user turn
            public void UserTurn()
            {
                //Check if the user input is valid
                if (IsValidInput())
                {
                    //Check if the user input is a mine
                    if (IsAMine())
                    {
                        //Game over
                        Console.WriteLine("Game Over!");
                    }
                    else
                    {
                        //Reveal the user input
                        RevealInput();

                        //Check for winning
                        if (CheckForWin())
                        {
                            //Game won
                            Console.WriteLine("You Won!");
                        }
                    }
                }
            }

            //Method to check if the user input is valid
            private bool IsValidInput()
            {
                //Check if the user input is within the board boundary
                if (userInputRow >= 0 && userInputRow < board.GetLength(0) && userInputCol >= 0 && userInputCol < board.GetLength(1))
                {
                    return true;
                }

                return false;
            }

            //Method to check if the user input is a mine
            private bool IsAMine()
            {
                //Check if the user input is a mine
                if (board[userInputRow, userInputCol] == "*")
                {
                    return true;
                }

                return false;
            }

            //Method to reveal the user input
            private void RevealInput()
            {
                //Reveal the user input
                board[userInputRow, userInputCol] = CountMines().ToString();
            }

            //Method to count the number of mines around the user input
            private int CountMines()
            {
                int count = 0;

                //Check the 8 adjacent cells for mines
                for (int i = userInputRow - 1; i <= userInputRow + 1; i++)
                {
                    for (int j = userInputCol - 1; j <= userInputCol + 1; j++)
                    {
                        //Check if the adjacent cell is valid
                        if (i >= 0 && i < board.GetLength(0) && j >= 0 && j < board.GetLength(1))
                        {
                            //Check if the adjacent cell is a mine
                            if (board[i, j] == "*")
                            {
                                count++;
                            }
                        }
                    }
                }

                return count;
            }

            //Method to check for winning
            private bool CheckForWin()
            {
                //Loop through the board
                for (int i = 0; i < board.GetLength(0); i++)
                {
                    for (int j = 0; j < board.GetLength(1); j++)
                    {
                        //Check if there are unrevealed cells
                        if (board[i, j] == "#")
                        {
                            return false;
                        }
                    }
                }

                return true;
            }

            //Main method to start the Minesweeper game
            public static void Main(string[] args)
            {
                //Declare and initialize the game board
                string[,] board = new string[,] { { "#", "#", "#", "#", "#" },
                                      { "#", "#", "#", "#", "#" },
                                      { "#", "#", "*", "#", "#" },
                                      { "#", "#", "#", "#", "#" },
                                      { "#", "#", "#", "#", "#" } };

                //Declare and initialize user input
                int userInputRow = 0;
                int userInputCol = 0;

                //Create a new MinesweeperGame object
                MinesweeperGame game = new MinesweeperGame(board, userInputRow, userInputCol);

                //Loop until the game ends
                while (true)
                {
                    //Get user input
                    Console.WriteLine("Enter row: ");
                    userInputRow = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter column: ");
                    userInputCol = int.Parse(Console.ReadLine());

                    //Execute the user turn
                    game.UserTurn();

                    //Check if the game is over
                    if (game.CheckForWin() || game.IsAMine())
                    {
                        break;
                    }
                }
            }

            public void RevealCell(int x, int y)
            {
                // check if cell is in bounds
                if (x < 0 || x >= Board.Width || y < 0 || y >= Board.Height)
                {
                    // cell is out of bounds
                    return;
                }

                // check if cell is already revealed
                if (RevealedCells[x, y])
                {
                    // cell is already revealed
                    return;
                }

                // reveal cell
                RevealedCells[x, y] = true;

                // check if cell is a mine
                if (Board.Cells[x, y] == -1)
                {
                    // cell is a mine, game over
                    return;
                }

                // check if cell is empty
                if (Board.Cells[x, y] == 0)
                {
                    // reveal all 8 surrounding cells
                    RevealCell(x - 1, y - 1);
                    RevealCell(x - 1, y);
                    RevealCell(x - 1, y + 1);
                    RevealCell(x, y - 1);
                    RevealCell(x, y + 1);
                    RevealCell(x + 1, y - 1);
                    RevealCell(x + 1, y);
                    RevealCell(x + 1, y + 1);
                }
            }
            //This algorithm assumes the user has selected a cell which is empty, and that the size of the minesweeper game board is known.
            public void RevealAdjacentCells(int x, int y)
            {
                int[,] gameBoard = GetGameBoard();
                int boardSize = gameBoard.GetLength(0);

                //Check if cell is within bounds of board
                if (x < 0 || x >= boardSize || y < 0 || y >= boardSize)
                    return;

                //Check if cell has already been revealed
                if (gameBoard[x, y] != 0)
                    return;

                //Reveal cell and get number of adjacent bombs
                int adjacentBombs = RevealCell(x, y);

                //If no adjacent bombs, recursively reveal adjacent cells
                if (adjacentBombs == 0)
                {
                    //Reveal cell up
                    RevealAdjacentCells(x - 1, y);

                    //Reveal cell down
                    RevealAdjacentCells(x + 1, y);

                    //Reveal cell left
                    RevealAdjacentCells(x, y - 1);

                    //Reveal cell right
                    RevealAdjacentCells(x, y + 1);

                    //Reveal cell up-left
                    RevealAdjacentCells(x - 1, y - 1);

                    //Reveal cell up-right
                    RevealAdjacentCells(x - 1, y + 1);

                    //Reveal cell down-left
                    RevealAdjacentCells(x + 1, y - 1);

                    //Reveal cell down-right
                    RevealAdjacentCells(x + 1, y + 1);
                }
            }
        }


        public class Minesweeper
        {
            public GameBoard Board { get; set; }
            public bool[,] RevealedCells { get; set; }

            public Minesweeper(int width, int height, int numOfMines)
            {
                Board = new GameBoard(width, height);
                Board.PlaceMines(numOfMines);
                Board.CalculateMineCounts();

                RevealedCells = new bool[width, height];
            }

            public void RevealCell(int x, int y)
            {
                // check if cell is in bounds
                if (x < 0 || x >= Board.Width || y < 0 || y >= Board.Height)
                {
                    // cell is out of bounds
                    return;
                }

                // check if cell is already revealed
                if (RevealedCells[x, y])
                {
                    // cell is already revealed
                    return;
                }

                // reveal cell
                RevealedCells[x, y] = true;

                // check if cell is a mine
                if (Board.Cells[x, y] == -1)
                {
                    // cell is a mine, game over
                    return;
                }

                // check if cell is empty
                if (Board.Cells[x, y] == 0)
                {
                    // reveal all 8 surrounding cells
                    RevealCell(x - 1, y - 1);
                    RevealCell(x - 1, y);
                    RevealCell(x - 1, y + 1);
                    RevealCell(x, y - 1);
                    RevealCell(x, y + 1);
                    RevealCell(x + 1, y - 1);
                    RevealCell(x + 1, y);
                    RevealCell(x + 1, y + 1);
                }
            }
        }
    }
    */
}
