using Battleship_Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class Ship
    {
        public int x = 0;

        Globals gl;
        Board board;

        public Ship(Board board, Globals gl)
        {
            this.gl = gl;
            this.board = board;
        }

        public void checkColumn(char col)
        {
            switch (col)
            {
                case 'a':
                    x = 0;
                    break;
                case 'b':
                    x = 1;
                    break;
                case 'c':
                    x = 2;
                    break;
                case 'd':
                    x = 3;
                    break;
                case 'e':
                    x = 4;
                    break;
                case 'f':
                    x = 5;
                    break;
                case 'g':
                    x = 6;
                    break;
                case 'h':
                    x = 7;
                    break;
                case 'i':
                    x = 8;
                    break;
                case 'j':
                    x = 9;
                    break;
                default:
                    Console.WriteLine("Nie ma takiego pola");
                    break;
            }
        }

        public bool IsSpaceFree(int x, int y, int size, string direction)
        {
            for (int i = 0; i < size; i++)
            {
                int newX = x;
                int newY = y;

                if (direction == "poziomo")
                {
                    newY += i;
                }
                else if (direction == "pionowo")
                {
                    newX += i;
                }

                if (newX < 0 || newX >= 10 || newY < 0 || newY >= 10)
                {
                    return false;
                }

                for (int j = -1; j <= 1; j++)
                {
                    for (int k = -1; k <= 1; k++)
                    {
                        int checkX = newX + j;
                        int checkY = newY + k;

                        if (checkX >= 0 && checkX < 10 && checkY >= 0 && checkY < 10)
                        {
                            if (gl.currentPlayer == 1)
                            {
                                if (board.boardP1[checkX, checkY] == '#')
                                {
                                    return false;
                                }
                            }
                            else
                            {
                                if (board.boardP2[checkX, checkY] == '#')
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }

            return true;
        }
    }
}
