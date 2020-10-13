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

        public char[] getBoardCopy()
        {
            char[] boardCopy = new char[10];
            Array.Copy(board, boardCopy, board.Length);
            return boardCopy;
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

        private bool IfPositionFree(char[] b, int position)
        {
            if (b[position] == ' ')
            {
                return true;
            }
            else
                return false;
        }

        private void allotPosition(char[] b, int position, char playerInput)
        {
            b[position] = playerInput;
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
                else if (!IfPositionFree(board, userPositon))
                {
                    Console.Write("Position " + userPositon + " is already occupied. Enter some other position : ");
                }
            }
            allotPosition(board, userPositon, userInput);
            ShowBoard();
            CheckIfPlayerHasWon(board, userInput);
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

        public bool CheckIfPlayerHasWon(char [] b,  char input)
        {
            bool topRow = (b[1] == input && b[2] == input && b[3] == input);
            bool middleRow = (b[4] == input && b[5] == input && b[6] == input);
            bool bottomRow = (b[7] == input && b[8] == input && b[9] == input);
            bool leftCol = (b[1] == input && b[4] == input && b[7] == input);
            bool middleCol = (b[2] == input && b[5] == input && b[8] == input);
            bool rightCol = (b[3] == input && b[6] == input && b[9] == input);
            bool firstDiagonal = (b[1] == input && b[5] == input && b[9] == input);
            bool secondDiagonal = (b[3] == input && b[5] == input && b[7] == input);
            return topRow || middleRow || bottomRow || leftCol || rightCol || middleCol || firstDiagonal || secondDiagonal;
        }

        public int ComputerMove()
        {
            int winningMove = WinningMove(compInput);
            if (winningMove != 0)
                return winningMove;
            return 0;
        }

        public int WinningMove(char input)
        {
            for (int i = 1; i < board.Length; i++)
            {
                char[] boardCopy = getBoardCopy();
                if (IfPositionFree(boardCopy, i))
                {
                    allotPosition(boardCopy, i, input);
                    if (CheckIfPlayerHasWon(boardCopy, input))
                        return i;
                }
            }
            return 0;
        }

    }
}
