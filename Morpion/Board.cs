using System;
using System.Collections;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace Morpion
{
    public class Board
    {
        #region Attributes
        
        private int size = 3; 
        
        public char currentPlayer { get; set; }
        public char Player1 { get; }
        public char Player2 { get; }
        private int[,] board { get; }

        public bool ai { get; }

        #endregion

        #region Constructor

        public Board(bool ai)
        {
            this.Player1 = 'X';
            this.Player2 = 'O';
            this.currentPlayer = Player2;
            this.ai = ai;
            board = new int[3,3];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    board[i, j] = 0;
                }
            }
            
        }

        #endregion

        #region Methods

        public bool PutCell(char player, int x, int y)
        {
            if (x <= 2 && x >= 0 && y <= 2 && y >= 0)
            {
                if (board[x, y] == 0)
                {
                    board[x, y] = player == Player1 ? 1 : 2;
                    return true;
                }
                Console.WriteLine("This spot is already taken by a player.");
                return false;
            }
            Console.WriteLine("Theses coordinates are not valid, please enter numbers between 0 and 2");
            return false;
        }
        public void PrintBoard()
        {
            var separator = " ¦ ";
            string verticalSeparator = "";
            for (int i = 0; i < 4 * size - 2; i++)
            {
                verticalSeparator += "-";
            }
            for (int i = 0; i < size; i++)
            {
                var line = "";
                for (int j = 0; j < size; j++)
                {
                    switch (board[i, j])
                    {
                        case 0:
                            line += " ";
                            break;
                        case 1:
                            line += Player1;
                            break;
                        case 2:
                            line += Player2;
                            break;
                    }

                    if (j != size - 1)
                    {
                        line += separator;
                    }
                }
                Console.WriteLine(verticalSeparator);
                Console.WriteLine(line);
            }
            Console.WriteLine(verticalSeparator);
        }

        public int IsWon()
        {
            int returnValue = 0;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size - 1; j++)
                {
                    if (board[i, j] != board[i, j+1] || board[i, j] == 0)
                    {
                        returnValue = 0;
                        break;
                    }
                    returnValue = board[i,j];
                }
                if (returnValue != 0)
                {
                    return returnValue;
                }
            }


            
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size - 1; j++)
                {
                    if (board[j, i] != board[j + 1, i] || board[j, i] == 0)
                    {
                        returnValue = 0;
                        break;
                    }

                    returnValue = board[i,j];
                }
                if (returnValue != 0)
                {
                    return returnValue;
                }
            }
            
            for (int i = 0; i < size - 1; i++)
            {
                if (board[i, i] != board[i+1, i+1] || board[i, i] == 0)
                {
                    return 0;
                }
            }

            return board[2,2];
        }
        #endregion

        public (int, int) ComputeBestMove()
        {
            var bestmove = (0,0);
            var bestScore = -Int32.MaxValue;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (board[i, j] == 0)
                    {
                        board[i, j] = 2;
                        var score = EvaluateBoard(true);
                        board[i, j] = 0;
                        if (score >= bestScore)
                        {
                            bestmove = (i, j) ;
                            bestScore = score;
                        }
                    }
                }   
            }

            if (bestmove == (0,0))
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (board[i, j] == 0)
                        {
                            return (i, j);
                        }
                    }
                }
            }

            return bestmove;
        }

        private int EvaluateBoard(bool maximising)
        {
            if (isFull())
            {
                return 0;
            }
            if (IsWon() == 1)
            {
                return -1;
            } if (IsWon() == 2)
            {
                return 1;
            }

            int bestScore;
            if (maximising)
            {
                bestScore = -Int32.MaxValue;
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (board[i, j] == 0)
                        {
                            board[i, j] = 2;
                            var score = EvaluateBoard(false);
                            board[i, j] = 0;
                            bestScore = Math.Max(score, bestScore);
                        }
                    }
                }
            }
            else
            {
                bestScore = Int32.MaxValue;
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (board[i, j] == 0)
                        {
                            board[i, j] = 1;
                            var score = EvaluateBoard(true);
                            board[i, j] = 0;
                            bestScore = Math.Min(score, bestScore);
                        }
                    }
                }
            }

            return bestScore;
        }

        public bool isFull()
        {
            foreach (var number in board)
            {
                if (number == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}