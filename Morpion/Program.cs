using System;

namespace Morpion
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(3, 'X', 'O', false);
            board.PrintBoard();
            Console.WriteLine(board.IsWon());
        }
    }
}    