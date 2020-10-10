using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToeGame
{
    public class TicTacToeGame
    {
        public char[] board = new char[10];
        public void CreateGameBoard()
        {
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = ' ';
            }
            
        }

        public void ShowBoard()
        {
            Console.WriteLine(board[0] + " | " + board[1] + " | " + board[2]);
            Console.WriteLine("_________");
            Console.WriteLine(board[3] + " | " + board[4] + " | " + board[5]);
            Console.WriteLine("_________");
            Console.WriteLine(board[6] + " | " + board[7] + " | " + board[8]);
        }

        public void ChooseInput()
        {
            char playerInput = ' ';
            Console.Write("Choose your input 'X' or 'O' : ");
            while (playerInput != 'X' && playerInput != 'O')
            {
                playerInput = Convert.ToChar(Console.ReadLine().ToUpper());
                if (playerInput != 'X' && playerInput != 'O')
                    Console.Write("Please enter input 'X' or 'O' : ");

            }
            char compInput;
            if (playerInput == 'X')
                compInput = 'O';
            else
                compInput = 'X';
        }
    }
}
