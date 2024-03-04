using Battleship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_Game
{
    internal class Player
    {
        Board board;
        Globals gl;
        Utils utils;

        public Player(Board board, Globals gl, Utils utils)
        {
            this.gl = gl;
            this.board = board;
            this.utils = utils;
        }

        public void PlaceShip(int x, int y, string direction, int size)
        {
            Console.Write("  ");
            for (char i = 'A'; i <= 'J'; i++)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            if (gl.currentPlayer == 1)
            {
                for (int i = 0; i < size; i++)
                {

                    if (direction == "poziomo")
                    {
                        board.boardP1[x, y + i] = '#';
                    }
                    else
                    {
                        board.boardP1[x + i, y] = '#';
                    }

                }
            }
            else
            {
                for (int i = 0; i < size; i++)
                {
                    if (direction == "poziomo")
                    {
                        board.boardP2[x, y + i] = '#';
                    }
                    else
                    {
                        board.boardP2[x + i, y] = '#';
                    }
                }
            }

            for (int i = 0; i < 10; i++)
            {
                Console.Write(i);
                for (int j = 0; j < 10; j++)
                {
                    if (gl.currentPlayer == 1)
                    {
                        Console.Write(" " + board.boardP1[i, j]);
                    }
                    else
                    {
                        Console.Write(" " + board.boardP2[i, j]);
                    }
                }
                Console.WriteLine();
            }
        }

        public bool Shoot(int x, int y)
        {
            char[,] activeBoard;
            char[,] activeSBoard;

            if (gl.currentPlayer == 1)
            {
                activeBoard = board.boardP2;
                activeSBoard = board.sBoardP1;
            }
            else
            {
                activeBoard = board.boardP1;
                activeSBoard = board.sBoardP2;
            }

            if (activeSBoard[x, y] == 'x' || activeSBoard[x, y] == 'o')
            {
                Console.WriteLine("Już tu strzelałeś!");
                return false;
            }

            if (activeBoard[x, y] == '#')
            {
                activeBoard[x, y] = 'x';
                activeSBoard[x, y] = 'x';

                bool isSunk = true;

                for (int i = Math.Max(0, x - 1); i <= Math.Min(9, x + 1); i++)
                {
                    for (int j = Math.Max(0, y - 1); j <= Math.Min(9, y + 1); j++)
                    {
                        if (activeBoard[i, j] == '#')
                        {
                            isSunk = false;
                            break;
                        }
                    }

                    if (!isSunk)
                    {
                        break;
                    }
                }

                if (isSunk)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            if (activeSBoard[i, j] == 'x')
                            {
                                for (int k = Math.Max(0, i - 1); k <= Math.Min(9, i + 1); k++)
                                {
                                    for (int l = Math.Max(0, j - 1); l <= Math.Min(9, j + 1); l++)
                                    {
                                        if (activeBoard[k, l] != 'x' && activeSBoard[k, l] != 'x')
                                        {
                                            activeSBoard[k, l] = 'o';
                                        }
                                    }
                                }
                            }
                        }
                    }

                    Console.WriteLine("Trafiony zatopiony!");
                }
                else
                {
                    Console.WriteLine("Trafiony!");
                }
            }
            else
            {
                activeSBoard[x, y] = 'o';
                Console.WriteLine("Pudło!");
            }
            return true;
        }

        public bool CheckWin(Board board, Globals gl)
        {
            for (int i = 0; i < Board.x; i++)
            {
                for (int j = 0; j < Board.y; j++)
                {
                    if (gl.currentPlayer == 1 && board.boardP2[i, j] == '#')
                    {
                        return false;
                    }
                    else if (gl.currentPlayer == 2 && board.boardP1[i, j] == '#')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
