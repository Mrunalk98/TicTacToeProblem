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
            ticTacToe.ShowBoard();
            ticTacToe.ChooseInput();
            string firstMoveBy = ticTacToe.CheckWhoPlaysFirst();
            if (firstMoveBy == ticTacToe.player[1])
                ticTacToe.ComputerMove();
            else
                ticTacToe.ChoosePositionOnBoard();
            ticTacToe.ShowBoard();
            ticTacToe.PlayTillGameOver(firstMoveBy);
            

        }
    }
}
