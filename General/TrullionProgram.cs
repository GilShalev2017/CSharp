using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace General
{
    //ctrl + k + f // to indent
   
    
    internal class TrullionProgram
    {
        static Cell [,] board;

        class Cell
        {
            public bool IsOpened { get; set; }
            public int Value { get; set; }
            public Cell()
            {
                IsOpened= false;
                Value=0;
            }
        }
        static void InitBoard(int numberOfMines, int size)
        {
            int currentNumberOfMines = 0;
            
            //-1 means a mine!
            while (true)
            {
                var rndXPosition = new Random().Next(0, size-1); //rows
                var rndYPosition = new Random().Next(0, size-1); //columns

                if (board[rndXPosition,rndYPosition].Value == -1) //Don't count cells of Bombs!
                {
                    continue;
                }
                else
                {
                    board[rndXPosition,rndYPosition].Value = -1;
                    currentNumberOfMines++;
                    if (currentNumberOfMines == numberOfMines)
                    {
                        break;
                    }
                }
            }
        }

        static void AddCounts()
        {
            int rowColSize = board.GetLength(0);

            for (int i = 0; i < rowColSize; i++)
            {
                for (int j = 0; j < rowColSize; j++)
                {
                    int counter = 0;

                    if (board[i, j].Value == -1) //In case of a bomb - don't count the cells around it - leave it as is
                    {
                        continue;
                    }

                    //current square is board[i][j]
                    if ((j + 1) < rowColSize && board[i,j + 1].Value == -1) //same row
                    {
                        counter++;
                    }
                    if ((j - 1) >= 0 && board[i,j - 1].Value == -1) //same row
                    {
                        counter++;
                    }

                    if ((i - 1) >= 0 && (j - 1) >= 0 && board[i - 1,j - 1].Value == -1) //row above
                    {
                        counter++;
                    }

                    if ((i - 1) >= 0 && board[i - 1,j].Value == -1) //row above
                    {
                        counter++;
                    }

                    if ((i - 1) >= 0 && (j + 1) < rowColSize && board[i - 1,j + 1].Value == -1) //row above
                    {
                        counter++;
                    }

                    if ((i + 1) < rowColSize && (j - 1) >= 0 && board[i + 1,j - 1].Value == -1) //row below
                    {
                        counter++;
                    }

                    if ((i + 1) < rowColSize && board[i + 1,j].Value == -1) //row below
                    {
                        counter++;
                    }

                    if ((i + 1) < rowColSize && (j + 1) < rowColSize && board[i + 1,j + 1].Value == -1) //row below
                    {
                        counter++;
                    }

                    board[i,j].Value = counter;
                }
            }
        }

        static void Dig(int x, int y)
        {
            //Pressing a key should explode if its a bomb, or display the number if it contains a numeric number or empty
            //in case if its empty - open all the other adjacent empty (in a recurrsive) or numeric cells
            int rowColSize = board.GetLength(0);

            if (x < 0 || y < 0 || x >= rowColSize || y >= rowColSize)
            {
                throw new Exception("Illegal indices. Outside the bounds of the array!!!");
            }

            if (board[x, y].IsOpened) //Stop condition to prevent endless recurssion! if the adjacent cell is already opened don't continue the recurrsion!
                return;

            if (board[x,y].Value == -1) //In case of a bomb
            {
                board[x,y].IsOpened = true;
                throw new Exception("Game Over - player chose: x: " + x + "y: " + y);
            }
            else if (board[x,y].Value > 0) //In case of a cell with a numberOfMines
            {
                board[x,y].IsOpened = true;
                return;
            }
            else if (board[x,y].Value == 0) //In case of an empty cell <- recurrsive
            {
                //x - rows
                //y - col
                board[x, y].IsOpened = true;

                if ((y + 1) < rowColSize && board[x,y + 1].Value >= 0) //same row
                {
                    board[x,y + 1].IsOpened = true;
                    if(board[x, y + 1].Value == 0)
                         Dig(x, y + 1);
                }

                if ((y - 1) >= 0 && board[x,y - 1].Value >= 0) //same row
                {
                    board[x,y - 1].IsOpened = true;
                    if(board[x, y - 1].Value == 0)
                         Dig(x, y - 1);
                }

                if ((x - 1) >= 0 && (y - 1) >= 0 && board[x - 1,y - 1].Value >= 0) //row above
                {
                    board[x - 1,y - 1].IsOpened = true;
                    if(board[x - 1, y - 1].Value == 0)
                         Dig(x - 1, y - 1);
                }

                if ((x - 1) >= 0 && board[x - 1,y].Value >= 0) //row above
                {
                    board[x - 1,y].IsOpened = true;
                    if(board[x - 1, y].Value == 0)
                         Dig(x - 1, y);
                }

                if ((x - 1) >= 0 && (y + 1) < rowColSize && board[x - 1,y + 1].Value >= 0) //row above
                {
                    board[x - 1,y + 1].IsOpened = true;
                    if(board[x - 1, y + 1].Value == 0)
                         Dig(x - 1, y + 1);
                }

                if ((x + 1) < rowColSize && (y - 1) >= 0 && board[x + 1,y - 1].Value >= 0) //row below
                {
                    board[x + 1,y - 1].IsOpened = true;
                    if(board[x + 1, y - 1].Value == 0)
                         Dig(x + 1, y - 1);
                }

                if ((x + 1) < rowColSize && board[x + 1,y].Value >= 0) //row below
                {
                    board[x + 1,y].IsOpened = true;
                    if(board[x + 1, y].Value == 0)
                         Dig(x + 1, y);
                }

                if ((x + 1) < rowColSize && (y + 1) < rowColSize && board[x + 1,y + 1].Value >= 0) //row below
                {
                    board[x + 1,y + 1].IsOpened = true;
                    if(board[x + 1, y + 1].Value == 0)
                         Dig(x + 1, y + 1);
                }
            }
        }

        static void PrintBoardToUser()
        {
            int rowColSize = board.GetLength(0);

            for (int i = 0; i < rowColSize; i++)
            {
                var line = "";
                
                for (int j = 0; j < rowColSize; j++)
                {
                    if (!board[i, j].IsOpened)
                    {
                        line += "C"; //C for closed
                        continue;
                    }

                    if (board[i, j].Value == 0)
                    {
                        line += "E"; //E for Empty
                    }
                    else if (board[i, j].Value == -1)
                    {
                        line += "B"; //B for Bomb
                    }
                    else
                    {
                        line += board[i, j].Value; //number
                    }

                }
                Console.WriteLine(line);
            }
        }

        static void PrintBoard()
        {
            int rowColSize = board.GetLength(0);

            for (int i=0; i< rowColSize; i++)
            {
                var line = "";
                for (int j = 0; j < rowColSize; j++)
                {
                    if(board[i, j].Value == 0)
                    {
                        line += "E"; //E for Empty
                    }
                    else if(board[i, j].Value == -1)
                    {
                        line += "B"; //B for Bomb
                    }
                    else
                    {
                        line += board[i, j].Value; //number
                    }
                    
                }
                Console.WriteLine(line);
            }
        }
     /*
        static void Main(string[] args)
        {
            //https://minesweeperonline.com/
            //Minesweeper game
            int boardSize = 4;

            board = new Cell[boardSize, boardSize];
            for(int i=0; i<boardSize; i++)
            {
                for(int j=0; j<boardSize; j++)
                {
                    board[i,j] = new Cell();
                }
            }
           
            InitBoard(2, boardSize);
            Console.WriteLine("After init - show bombs");
            PrintBoard();

            AddCounts();
            Console.WriteLine("After Counts - show counts");
            PrintBoard();

            Console.WriteLine("Before DIG - Show User board");
            PrintBoardToUser();

            try
            {
                Console.WriteLine("After DIG 2,2 - Explode or show exapnded!");
                Dig(2, 2);
                PrintBoardToUser();

                Console.WriteLine("After DIG 3,3 - Explode or show exapnded!");
                Dig(3, 3);
                PrintBoardToUser();

                Console.WriteLine("After DIG 0,0- Explode or show exapnded!");
                Dig(0, 0);
                PrintBoardToUser();
            }
            catch(Exception xcp)
            {
                Console.WriteLine(xcp.Message);
            }
            
        }*/
    }
    
}
