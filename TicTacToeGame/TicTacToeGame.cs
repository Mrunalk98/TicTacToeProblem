using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeGame
{
    public class TicTacToeGame
    {
        public char[] board = new char[10];
        char userInput = ' ';
        char compInput = ' ';
        public const int HEAD = 0;
        public const int TAIL= 1;

        public void CreateGameBoard()
        {
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = ' ';
            }
            
        }

        public void ShowBoard()
        {
            Console.WriteLine(" " + board[1] + " | " + board[2] + " | " + board[3]);
            Console.WriteLine("-----------");
            Console.WriteLine(" " + board[4] + " | " + board[5] + " | " + board[6]);
            Console.WriteLine("-----------");
            Console.WriteLine(" " + board[7] + " | " + board[8] + " | " + board[9]);
        }

        public void ChooseInput()
        {
            Console.Write("Choose your input 'X' or 'O' : ");
            while (userInput != 'X' && userInput != 'O')
            {
                userInput = Convert.ToChar(Console.ReadLine().ToUpper());
                if (userInput != 'X' && userInput != 'O')
                    Console.Write("Please enter input 'X' or 'O' : ");

            }
            if (userInput == 'X')
                compInput = 'O';
            else
                compInput = 'X';
        }

        public void ChoosePositionOnBoard()
        {
            int userPositon = 0;
            Console.Write("Choose the location on board from position 1 to 9 : ");
            while (userPositon < 1 || userPositon > 10 || board[userPositon] != ' ')
            {
                userPositon = Convert.ToInt32(Console.ReadLine());
                if (userPositon < 1 || userPositon > 10)
                    Console.Write("Please enter a position from 1 to 9: ");
                else if (board[userPositon] != ' ')
                {
                    Console.Write("Position " + userPositon + " is already occupied. Enter some other position : ");
                }                    
            }
            board[userPositon] = userInput;
            ShowBoard();
            CheckIfPlayerHasWon(userInput);
        }

        public string CheckWhoPlaysFirst()
        {
            Random random = new Random();
            int choice = random.Next(0, 2);

            if (choice == HEAD)
                return "User";
            else
                return "Computer";
        }

        public bool CheckIfPlayerHasWon(char input)
        {
            bool topRow = (board[1] == input && board[2] == input && board[3] == input);
            bool middleRow = (board[4] == input && board[5] == input && board[6] == input);
            bool bottomRow = (board[7] == input && board[8] == input && board[9] == input);
            bool leftCol = (board[1] == input && board[4] == input && board[7] == input);
            bool middleCol = (board[2] == input && board[5] == input && board[8] == input);
            bool rightCol = (board[3] == input && board[6] == input && board[9] == input);
            bool firstDiagonal = (board[1] == input && board[5] == input && board[9] == input);
            bool secondDiagonal = (board[3] == input && board[5] == input && board[7] == input);
            return topRow || middleRow || bottomRow || leftCol || rightCol || middleCol || firstDiagonal || secondDiagonal;
        }

    }
}
