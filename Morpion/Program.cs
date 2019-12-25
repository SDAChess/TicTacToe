using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Morpion
{
    class Program
    {
        private static char currentPlayer;
        static void Main(string[] args)
        {
            Board board = new Board(3, 'X', 'O', false);
            currentPlayer = board.Player1;
            while (!board.IsWon())
            {
                board.PrintBoard();
                Console.WriteLine("X ?");
                int x = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Y ?");
                int y = Int32.Parse(Console.ReadLine());
                board.PutCell(currentPlayer, x, y);
                currentPlayer = currentPlayer == board.Player1 ? board.Player2 : board.Player1;
            }

            Console.WriteLine("Joueur " + currentPlayer + " a gagné la partie !");
        }

    }
}    