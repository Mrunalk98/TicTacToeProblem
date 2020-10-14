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
        public int[] corners = { 1, 3, 7, 9 };
        public int[] sides = { 2, 4, 6, 8 };
        public string[] player = { "User", "Computer" };

        public void CreateGameBoard()
        {
            for (int i = 0; i < board.Length; i++)
                board[i] = ' ';
        }

        public void ShowBoard()
        {
            Console.WriteLine(" " + board[1] + " | " + board[2] + " | " + board[3]);
            Console.WriteLine("-----------");
            Console.WriteLine(" " + board[4] + " | " + board[5] + " | " + board[6]);
            Console.WriteLine("-----------");
            Console.WriteLine(" " + board[7] + " | " + board[8] + " | " + board[9]);
            Console.WriteLine();
        }

        public char[] getBoardCopy()
        {
            char[] boardCopy = new char[10];
            Array.Copy(board, boardCopy, board.Length);
            return boardCopy;
        } 

        public void ChooseInput()
        {
            char user = ' ';
            Console.Write("Choose your input 'X' or 'O' : ");
            while (user != 'X' && user != 'O')
            {
                user = Convert.ToChar(Console.ReadLine().ToUpper());
                if (user != 'X' && user != 'O')
                    Console.Write("Please enter input 'X' or 'O' : ");

            }
            userInput = user;
            if (userInput == 'X')
                compInput = 'O';
            else
                compInput = 'X';
            Console.WriteLine("User Input = " + userInput + ",\t Computer Input = " + compInput + "\n");
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

        public bool ChoosePositionOnBoard()
        {
            int userPositon = 0;
            Console.Write("Choose your position on board between 1 and 9 : ");
            while (userPositon < 1 || userPositon > 10 || board[userPositon] != ' ')
            {
                userPositon = Convert.ToInt32(Console.ReadLine());
                if (userPositon < 1 || userPositon > 10)
                    Console.Write("Please enter a position between 1 and 9: ");
                else if (!IfPositionFree(board, userPositon))
                {
                    Console.Write("Position " + userPositon + " is already occupied. Enter some other position : ");
                }
            }
            allotPosition(board, userPositon, userInput);
            return CheckIfPlayerHasWon(board, userInput);
        }

        public string CheckWhoPlaysFirst()
        {
            Random random = new Random();
            int choice = random.Next(0, 2);

            if (choice == HEAD)
                return player[0];
            else
                return player[1];
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
            Console.WriteLine("Computer's Move : ");
            int compWinningMove = WinningMove(compInput);
            if (compWinningMove != 0)
            {
                allotPosition(board, compWinningMove, compInput);
                return compWinningMove;
            }
            int userWinningMove = WinningMove(userInput);
            if (userWinningMove != 0)
            {
                allotPosition(board, userWinningMove, compInput);
                return userWinningMove;
            }
            int cornersMove = RandomMove(corners, compInput);
            if (cornersMove != 0)
                return cornersMove;
            int centreMove = CentreMove(compInput);
            if (centreMove != 0)
                return centreMove;
            int sidesMove = RandomMove(sides, compInput);
            if (sidesMove != 0)
                return sidesMove;
            CheckIfPlayerHasWon(board, compInput);
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

        public int RandomMove(int[] positions, char input)
        {
            for (int i = 0; i < positions.Length; i++)
            {
                if(IfPositionFree(board, positions[i]))
                {
                    allotPosition(board, positions[i], input);
                    return positions[i];
                }
            }
            return 0;
        }

        public int CentreMove(char input)
        {
            if (IfPositionFree(board, 5))
            {
                allotPosition(board, 5, input);
                return 5;
            }
            return 0;
        }

        private bool isBoardFull()
        {
            for (int i = 1; i < board.Length; i++)
            {
                if (IfPositionFree(board, i))
                    return false;
            }
            Console.WriteLine("Game is Tie");
            return true;
        }
        public void PlayTillGameOver(string firstMove)
        {
            bool gameEnd = false;
            bool result = false;
            string playerWon = "";
            int index = -1;

            if (firstMove == player[0])
                index = 0;
            else
                index = 1;

            while(!gameEnd && !isBoardFull())
            {
                for (int  i = 0; i < player.Length; i++)
                {
                    if (index == 0 || i == 1)
                    {
                        ComputerMove();
                        result = CheckIfPlayerHasWon(board, compInput);
                        playerWon = player[1];
                        i++;
                        index = 1;
                    }
                    else
                    {
                        result = ChoosePositionOnBoard();
                        playerWon = player[0];
                    }
                    ShowBoard();
                }
                if (result)
                {
                    gameEnd = true;
                    Console.WriteLine(playerWon + " has won the game !");
                }
            }
        }

    }
}
