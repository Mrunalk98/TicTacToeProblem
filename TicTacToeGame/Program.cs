using System;

namespace TicTacToeGame
{
    class Program
    {
        public static TicTacToeGame ticTacToe = new TicTacToeGame();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to TicTacToe Game !");
            ticTacToe.CreateGameBoard();
        }
    }
}
