using System;
using System.ComponentModel;

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
        

        #endregion

        #region Getters and Setters

        

        #endregion


    }
}