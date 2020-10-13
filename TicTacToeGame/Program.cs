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
            Console.WriteLine(firstMoveBy + " will play first");
            if (firstMoveBy == "Computer")
                Console.WriteLine("Computer Move : " + ticTacToe.ComputerMove());
            else
                ticTacToe.ChoosePositionOnBoard();
            
        }
    }
}
