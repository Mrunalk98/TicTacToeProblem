using System;

namespace TicTacToeGame
{
    class Program
    {
        public static TicTacToeGame ticTacToe = new TicTacToeGame();
        public static bool CONTINUE = true;
        static void Main(string[] args)
        {

            while (CONTINUE)
            {
                Console.WriteLine("\nWelcome to TicTacToe Game !");
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
                playAgain();
            }            

        }

        public static bool playAgain()
        {
            Console.Write("\nDo you want to play again? (Y/N) : ");
            string choice = Convert.ToString(Console.ReadLine().ToUpper());
            if (choice == "Y")
               return CONTINUE = true;

            return CONTINUE = false;
        }
    }
}
