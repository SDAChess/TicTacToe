using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Morpion
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(true);
            bool executed = false;
            do
            {
                board.PrintBoard();
                board.currentPlayer = board.currentPlayer == board.Player2 ? board.Player1 : board.Player2;
                if (board.ai && board.currentPlayer == board.Player2)
                {
                    var (x, y) = board.ComputeBestMove();
                    board.PutCell(board.Player2, x, y);

                }
                else
                {
                    while (!executed)
                    {
                        Console.WriteLine("X ?");
                        int x = Int32.Parse(Console.ReadLine());
                        Console.WriteLine("Y ?");
                        int y = Int32.Parse(Console.ReadLine());
                        executed = board.PutCell(board.Player1, x, y);
                    }

                }
                executed = false;

            } while (board.IsWon() == 0 && !board.isFull());

            if (board.isFull())
            {
                board.PrintBoard();
                Console.WriteLine("Its a tie !!");
            }
            else
            {
                board.PrintBoard();
                Console.WriteLine("Joueur " + board.currentPlayer + " a gagné la partie !");
            }
        }

    }
}    