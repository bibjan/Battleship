using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Battleship;

namespace Battleship_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Globals gl = new Globals();
            Board board = new Board();
            Utils utils = new Utils(board, gl);
            Player player = new Player(board, gl, utils);
            Ship ship = new Ship(board, gl);

            int p1Wins = 0;
            int p2Wins = 0;

            bool playingAgain = false;

            Console.WriteLine("Witaj w grze w statki!");
            Console.WriteLine("Czy chcesz zagrać (g), czy zobaczyć zasady (z)? (g/z)");
            gl.answer = char.Parse(Console.ReadLine().ToLower());
            if (gl.answer == 'z')
            {
                utils.Rules();
            }
            else if (gl.answer == 'g')
            {
                do
                {
                    Console.Clear();
                    Console.Write("\x1b[3J");

                    int ship1 = 1, ship2 = 1, ship3 = 1, ship4 = 1;
                    gl.currentPlayer = 1;
                    bool gameRunning = true;

                    board.createBoard();

                    Console.WriteLine($"Kolej gracza {gl.currentPlayer}");

                    board.showBoard(gl.currentPlayer);

                    while (ship1 < 5)
                    {
                        utils.MsgShip1(ship1, ship, gl);

                        if (ship.IsSpaceFree(gl.y, ship.x, gl.currentSize, null))
                        {
                            player.PlaceShip(gl.y, ship.x, null, gl.currentSize);
                            ship1++;
                        }
                        else
                        {
                            Console.WriteLine("Nie możesz tu postawić statku!");
                            Console.WriteLine();
                        }
                    }

                    while (ship2 < 4)
                    {
                        gl.currentSize = 2;

                        utils.MsgShip2(ship2, ship, gl);

                        if (ship.IsSpaceFree(gl.y, ship.x, gl.currentSize, gl.direction))
                        {
                            player.PlaceShip(gl.y, ship.x, gl.direction, gl.currentSize);
                            ship2++;
                        }
                        else
                        {
                            Console.WriteLine("Nie możesz tu postawić statku!");
                            Console.WriteLine();
                        }
                    }

                    while (ship3 < 3)
                    {
                        gl.currentSize = 3;

                        utils.MsgShip3(ship3, ship, gl);

                        if (ship.IsSpaceFree(gl.y, ship.x, gl.currentSize, gl.direction))
                        {
                            player.PlaceShip(gl.y, ship.x, gl.direction, gl.currentSize);
                            ship3++;
                        }
                        else
                        {
                            Console.WriteLine("Nie możesz tu postawić statku!");
                            Console.WriteLine();
                        }
                    }

                    while (ship4 < 2)
                    {
                        gl.currentSize = 4;

                        utils.MsgShip4(ship4, ship, gl);

                        if (ship.IsSpaceFree(gl.y, ship.x, gl.currentSize, gl.direction))
                        {
                            player.PlaceShip(gl.y, ship.x, gl.direction, gl.currentSize);
                            ship4++;
                        }
                        else
                        {
                            Console.WriteLine("Nie możesz tu postawić statku!");
                            Console.WriteLine();
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine($"Oto plansza gracza {gl.currentPlayer}:");
                    board.showBoard(gl.currentPlayer);
                    Console.WriteLine("Wyczyszczenie konsoli nastąpi za 5 sekund...");

                    Thread.Sleep(5000);

                    Console.Clear();
                    Console.Write("\x1b[3J");

                    Console.WriteLine("Teraz czas na drugiego gracza!");
                    gl.currentPlayer = 2;
                    ship1 = 1;
                    ship2 = 1;
                    ship3 = 1;
                    ship4 = 1;
                    gl.currentSize = 1;

                    board.showBoard(gl.currentPlayer);

                    while (ship1 < 5)
                    {
                        utils.MsgShip1(ship1, ship, gl);

                        if (ship.IsSpaceFree(gl.y, ship.x, gl.currentSize, null))
                        {
                            player.PlaceShip(gl.y, ship.x, null, gl.currentSize);
                            ship1++;
                        }
                        else
                        {
                            Console.WriteLine("Nie możesz tu postawić statku!");
                            Console.WriteLine();
                        }
                    }

                    while (ship2 < 4)
                    {
                        gl.currentSize = 2;

                        utils.MsgShip2(ship2, ship, gl);

                        if (ship.IsSpaceFree(gl.y, ship.x, gl.currentSize, gl.direction))
                        {
                            player.PlaceShip(gl.y, ship.x, gl.direction, gl.currentSize);
                            ship2++;
                        }
                        else
                        {
                            Console.WriteLine("Nie możesz tu postawić statku!");
                            Console.WriteLine();
                        }
                    }

                    while (ship3 < 3)
                    {
                        gl.currentSize = 3;

                        utils.MsgShip3(ship3, ship, gl);

                        if (ship.IsSpaceFree(gl.y, ship.x, gl.currentSize, gl.direction))
                        {
                            player.PlaceShip(gl.y, ship.x, gl.direction, gl.currentSize);
                            ship3++;
                        }
                        else
                        {
                            Console.WriteLine("Nie możesz tu postawić statku!");
                            Console.WriteLine();
                        }
                    }

                    while (ship4 < 2)
                    {
                        gl.currentSize = 4;

                        utils.MsgShip4(ship4, ship, gl);

                        if (ship.IsSpaceFree(gl.y, ship.x, gl.currentSize, gl.direction))
                        {
                            player.PlaceShip(gl.y, ship.x, gl.direction, gl.currentSize);
                            ship4++;
                        }
                        else
                        {
                            Console.WriteLine("Nie możesz tu postawić statku!");
                            Console.WriteLine();
                        }
                    }

                    Console.WriteLine();
                    Console.WriteLine($"Oto plansza gracza {gl.currentPlayer}:");
                    board.showBoard(gl.currentPlayer);
                    Console.WriteLine("Wyczyszczenie konsoli nastąpi za 5 sekund...");

                    Thread.Sleep(5000);

                    Console.Clear();
                    Console.Write("\x1b[3J");
                    gl.currentPlayer = 1;


                    while (gameRunning)
                    {
                        Console.Clear();
                        Console.Write("\x1b[3J");
                        Console.WriteLine($"Kolej gracza {gl.currentPlayer}!");
                        Console.WriteLine();
                        Console.WriteLine("Oto twoja plansza: ");
                        board.showBoard(gl.currentPlayer);
                        Console.WriteLine();
                        Console.WriteLine("Oto plansza przeciwnika do sztrzałów: ");

                        board.showSBoard(gl.currentPlayer);

                        Console.WriteLine();

                        bool validShot;

                        do
                        {
                            utils.MsgShoot(ship, gl);
                            validShot = player.Shoot(gl.y, ship.x);
                        } while (!validShot);


                        if (player.CheckWin(board, gl))
                        {
                            gameRunning = false;
                            if (gl.currentPlayer == 1)
                            {
                                p1Wins++;
                                if (p1Wins <= 1)
                                {
                                    Console.WriteLine($"Gracz {gl.currentPlayer} wygrywa!");
                                }
                                else
                                {
                                    Console.WriteLine($"Gracz {gl.currentPlayer} wygrywa! Ma {p1Wins} zwycięstw(a).");

                                }
                            }
                            else
                            {
                                p2Wins++;
                                if (p2Wins <= 1)
                                {
                                    Console.WriteLine($"Gracz {gl.currentPlayer} wygrywa!");
                                }
                                else
                                {
                                    Console.WriteLine($"Gracz {gl.currentPlayer} wygrywa! Ma {p2Wins} zwycięstw(a).");
                                }
                            }
                        }
                        else
                        {
                            if (board.sBoardP1[gl.y, ship.x] == 'x' && gl.currentPlayer == 1)
                            {
                                gl.currentPlayer = 1;
                            }
                            else if (board.sBoardP2[gl.y, ship.x] == 'x' && gl.currentPlayer == 2)
                            {
                                gl.currentPlayer = 2;
                            }
                            else
                            {
                                if (gl.currentPlayer == 1)
                                {
                                    gl.currentPlayer = 2;
                                }
                                else
                                {
                                    gl.currentPlayer = 1;
                                }
                            }
                            Thread.Sleep(5000);
                        }
                    }


                    utils.MsgPlayAgain(gl);
                    if (gl.answer == 't')
                    {
                        playingAgain = true;
                    }
                    else
                    {
                        playingAgain = false;
                    }
                }
                while (playingAgain);
            }
            else
            {
                Console.WriteLine("Błędna odpowiedź!");
                Console.WriteLine("Zamknij aplikacje i uruchom ją ponownie");
            }

            
            

            Console.ReadKey();
        }
    }
}
