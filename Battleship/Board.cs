using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Game
{
    internal class Board
    {
        public static int x = 10;
        public static int y = 10;

        public char[,] boardP1 = new char[x, y];
        public char[,] boardP2 = new char[x, y];

        public char[,] sBoardP1 = new char[x, y];
        public char[,] sBoardP2 = new char[x, y];

        public void createBoard()
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    boardP1[i, j] = '.';
                    boardP2[i, j] = '.';
                    sBoardP1[i, j] = '.';
                    sBoardP2[i, j] = '.';
                }
            }
        }

        public void showBoard(int player)
        {
            Console.Write("  ");
            for (char i = 'A'; i <= 'J'; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < x; i++)
            {
                Console.Write(i);
                for (int j = 0; j < y; j++)
                {
                    if (player == 1)
                    {
                        Console.Write(" " + boardP1[i, j]);
                    }
                    else
                    {
                        Console.Write(" " + boardP2[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }

        public void showSBoard(int player)
        {
            Console.Write("  ");
            for (char i = 'A'; i <= 'J'; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            for (int i = 0; i < x; i++)
            {
                Console.Write(i);
                for (int j = 0; j < y; j++)
                {
                    if (player == 1)
                    {
                        Console.Write(" " + sBoardP1[i, j]);
                    }
                    else
                    {
                        Console.Write(" " + sBoardP2[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
