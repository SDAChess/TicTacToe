using System;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace Morpion
{
    public class Board
    {
        #region Attributes

        private int size { get;  }
        private char player1 { get; }
        private char player2 { get; }
        private int[,] board { get; }

        private bool random;

        #endregion

        #region Constructor

        public Board(int size, char player1, char player2, bool random)
        {
            this.size = size;
            this.player1 = player1;
            this.player2 = player2;
            board = new int[size,size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (random)
                    {
                        Random randomGenerator = new Random();
                        board[i, j] = randomGenerator.Next(size);
                    }
                    else
                    {
                        board[i, j] = 0;
                    }
                }
            }
            
        }

        #endregion

        #region Methods

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
                            line += player1;
                            break;
                        case 2:
                            line += player2;
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

        public bool IsWon()
        {
            bool returnValue = true;
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - 1; j++)
                {
                    if (board[i, j] != board[i, j+1] || board[i, j] == 0)
                    {
                        returnValue = false;
                    }
                    else
                    {
                        returnValue = true;
                    }
                }
            }

            if (returnValue)
            {
                return true;
            }
            
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = 0; j < size - 1; j++)
                {
                    if (board[j, i] != board[j + 1, i] || board[j, i] == 0)
                    {
                        returnValue = false;
                    }
                    else
                    {
                        returnValue = true;
                    }
                }
            }
            if (returnValue)
            {
                return true;
            }
            for (int i = 0; i < size - 1; i++)
            {
                if (board[i, i] != board[i+1, i+1] || board[i, i] == 0)
                {
                    returnValue = false;
                }
                else
                {
                    returnValue = true;
                }
            }
            return returnValue;
        }
        #endregion



    }
}