using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tic_Tac_Toe
{
    internal class Program
    {
        public static char[,] board = new char[3, 3];
        public static char player;
        public static char compChoice;
        static void Main(string[] args)
        {
            Getij();
            PlayerChoice();

            while (!CheckWin()&&!IsFull()) {
                DisplayBoard();
                PlayerTurn();
                DisplayBoard();
                ComputerTurn();
            }
            Console.WriteLine("Press any key to stop the game");
            Console.ReadKey();

        }
        public static void Getij()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }
        public static void DisplayBoard()
        {
            Console.WriteLine(" 0  1  2");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j]);
                    if (j < 2)
                        Console.Write("|");
                }
                Console.WriteLine();
                if (i < 2)
                    Console.WriteLine("--------");
            }
        }
        public static void PlayerChoice()
        {
            string input;
            Console.WriteLine("What you want \"X\" or \"O\" ");
            input = Console.ReadLine().Trim().ToUpper();
            while (input != "X"|| input!="O")
            {
                if (input == "X")
                {
                    player = 'X';
                    break;
                }
                else if (input == "O")
                {
                    player = 'O';
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong choice try again");
                }
            }
        }

        public static void PlayerTurn()
        {
            int row, col;

            while(true) 
            {
                Console.WriteLine("Now your turn");
                Console.WriteLine($"Player choose the row and column between 0 and 2 to play \"{player}\"");
                Console.WriteLine("Select Row");
                row = int.Parse( Console.ReadLine() );
                Console.WriteLine("Select Column");
                col = int.Parse( Console.ReadLine() );
                if(row>=0 && row< 3 && col>=0 && col< 3 && board[row,col]==' ')
                {
                    board[row, col] = player;
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong move, try again");
                }
            }
        }

        public static void ComputerTurn()
        {
            Console.WriteLine("Wait Now it's my turn player");
            Thread.Sleep(1000);
            
            if(player=='X')
            {
                compChoice = 'O';
            }
            else
            {
                compChoice = 'X';
            }
            Random rand = new Random();
            while (true)
            {
                int row = rand.Next(0, 3);
                int col = rand.Next(0, 3);
                if (board[row, col] == ' ')
                {
                    board[row, col] = compChoice;   
                    break;
                }
            }
        }
        public static bool CheckWin()
        {
            for(int i = 0; i < 3; i++) 
            {
                if ((board[i, 0] == player && board[i, 1] == player && board[i, 2] == player) || (board[0, i] == player && board[1, i] == player && board[2,i]==player))
                {
                    Console.WriteLine("Player wins!");
                    return true;
                }
                else if((board[i, 0] == compChoice && board[i, 1] == compChoice && board[i, 2] == compChoice) || (board[0, i] == compChoice && board[1, i] == compChoice && board[2, i] == compChoice))
                {
                    Console.WriteLine("Computer wins!");
                    return true;
                }
            }
            if ((board[0, 0]==player&& board[1, 1] == player && board[2, 2] == player) || (board[0,2]==player&& board[1,1]==player&& board[2,0]==player))
            {
                Console.WriteLine("Player wins!");
                return true;
            }
            else if((board[0, 0] == compChoice && board[1, 1] == compChoice && board[2, 2] == compChoice) || (board[0, 2] == compChoice && board[1, 1] == compChoice && board[2, 0] == compChoice))
            {
                Console.WriteLine("Computer wins!");
                return true;
            }
            return false;
            
        }
        public static bool IsFull()
        {
            for (int i = 0;i<3;i++) 
            { 
                for(int j = 0;j<3;j++)
                {
                    if (board[i,j] == ' ')
                    { return false; }
                }
            }
            Console.WriteLine("Board is full re-start to play again!");
            return true;
        }
    }
}
