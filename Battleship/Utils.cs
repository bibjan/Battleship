using Battleship_Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class Utils
    {

        Board board;
        Globals gl;

        public Utils(Board board, Globals gl)
        {
            this.board = board;
            this.gl = gl;
        }

        char input;


        public void MarkAroundSunkShip(int x, int y, char[,] activeBoard, char[,] activeSBoard)
        {
            for (int i = Math.Max(0, x - 1); i <= Math.Min(9, x + 1); i++)
            {
                for (int j = Math.Max(0, y - 1); j <= Math.Min(9, y + 1); j++)
                {
                    // Jeśli pole nie jest częścią statku, oznaczamy je jako 'o'
                    if (activeBoard[i, j] != '*')
                    {
                        activeSBoard[i, j] = 'o';
                    }
                }
            }
        }

        public void MsgShip1(int ship_, Ship ship, Globals gl)
        {
            Console.WriteLine($"Na jakim polu chciałbyś postawić swój {ship_} 1-masztowiec? (kolumna)");
            try
            {
                input = char.Parse(Console.ReadLine().ToLower());
            }
            catch
            {
                Console.WriteLine("Wprowadzono niepoprawne dane.");
                Console.WriteLine();
                MsgShip1(ship_, ship, gl);
            }

            ship.checkColumn(input);

            Console.WriteLine($"Na jakim polu chciałbyś postawić swój {ship_} 1-masztowiec? (wiersz)");
            try
            {
                gl.y = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Wprowadzono niepoprawne dane.");
                Console.WriteLine();
                MsgShip1(ship_, ship, gl);
            }
            
        }

        public void MsgShip2(int ship_, Ship ship, Globals gl)
        {
            Console.WriteLine($"W którym kierunku chciałbyś postawić swój {ship_} 2-masztowiec? (poziomo/pionowo)");
            gl.direction = Console.ReadLine().ToLower();
            if (gl.direction != "poziomo" && gl.direction != "pionowo")
            {
                Console.WriteLine("Wprowadzono niepoprawne dane.");
                Console.WriteLine();
                MsgShip2(ship_, ship, gl);
            }
            else
            {
                Console.WriteLine($"Na jakim polu chciałbyś postawić początek swojego {ship_} 2-masztowca? (kolumna)");
                try
                {
                    input = char.Parse(Console.ReadLine().ToLower());
                }
                catch
                {
                    Console.WriteLine("Wprowadzono niepoprawne dane.");
                    Console.WriteLine();
                    MsgShip2(ship_, ship, gl);
                }

                ship.checkColumn(input);

                Console.WriteLine($"Na jakim polu chciałbyś postawić początek swojego {ship_} 2-masztowca? (wiersz)");
                try
                {
                    gl.y = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Wprowadzono niepoprawne dane.");
                    Console.WriteLine();
                    MsgShip2(ship_, ship, gl);
                }
            }
        }

        public void MsgShip3(int ship_, Ship ship, Globals gl)
        {
            Console.WriteLine($"W którym kierunku chciałbyś postawić swój {ship_} 3-masztowiec? (poziomo/pionowo)");
            gl.direction = Console.ReadLine().ToLower();
            if (gl.direction != "poziomo" && gl.direction != "pionowo")
            {
                Console.WriteLine("Wprowadzono niepoprawne dane.");
                Console.WriteLine();
                MsgShip3(ship_, ship, gl);
            }
            else
            {
                Console.WriteLine($"Na jakim polu chciałbyś postawić początek swojego {ship_} 3-masztowca? (kolumna)");
                try
                {
                    input = char.Parse(Console.ReadLine().ToLower());
                }
                catch
                {
                    Console.WriteLine("Wprowadzono niepoprawne dane.");
                    Console.WriteLine();
                    MsgShip3(ship_, ship, gl);
                }

                ship.checkColumn(input);

                Console.WriteLine($"Na jakim polu chciałbyś postawić początek swojego {ship_} 3-masztowca? (wiersz)");
                try
                {
                    gl.y = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Wprowadzono niepoprawne dane.");
                    Console.WriteLine();
                    MsgShip3(ship_, ship, gl);
                }
            }
        }

        public void MsgShip4(int ship_, Ship ship, Globals gl)
        {
            Console.WriteLine($"W którym kierunku chciałbyś postawić swój {ship_} 4-masztowiec? (poziomo/pionowo)");
            gl.direction = Console.ReadLine().ToLower();
            if (gl.direction != "poziomo" && gl.direction != "pionowo")
            {
                Console.WriteLine("Wprowadzono niepoprawne dane.");
                Console.WriteLine();
                MsgShip4(ship_, ship, gl);
            }
            else
            {
                Console.WriteLine($"Na jakim polu chciałbyś postawić początek swojego {ship_} 4-masztowca? (kolumna)");
                try
                {
                    input = char.Parse(Console.ReadLine().ToLower());
                }
                catch
                {
                    Console.WriteLine("Wprowadzono niepoprawne dane.");
                    Console.WriteLine();
                    MsgShip4(ship_, ship, gl);
                }

                ship.checkColumn(input);

                Console.WriteLine($"Na jakim polu chciałbyś postawić początek swojego {ship_} 4-masztowca? (wiersz)");
                try
                {
                    gl.y = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Wprowadzono niepoprawne dane.");
                    Console.WriteLine();
                    MsgShip4(ship_, ship, gl);
                }
            }
        }

        public void MsgShoot(Ship ship, Globals gl)
        {
            Console.WriteLine("Wybierz pole do strzału: (kolumna)");
            try
            {
                input = char.Parse(Console.ReadLine().ToLower());
            }
            catch
            {
                Console.WriteLine("Wprowadzono niepoprawne dane.");
                Console.WriteLine();
                MsgShoot(ship, gl);
            }

            ship.checkColumn(input);

            Console.WriteLine("Wybierz pole do strzału: (wiersz)");
            try
            {
                gl.y = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Wprowadzono niepoprawne dane.");
                Console.WriteLine();
                MsgShoot(ship, gl);
            }
        }

        public void MsgPlayAgain(Globals gl)
        {
            Console.WriteLine("Czy chciałbyś zagrać jeszcze raz? (t/n)");
            gl.answer = char.Parse(Console.ReadLine().ToLower());
        }

        public void Rules()
        {
            Console.WriteLine("Gra polega na tym, żeby bez widzenia planszy przeciwnika, zatopić mu wszystkie statki! Po każdym strzale nastąpi 5 sekundowa przerwa na zmianę gracza. Jeśli trafisz dostajesz następną turę");
            Console.WriteLine();
            Console.WriteLine("Jeśli wybierzesz, żeby statek został ułożony poziomo statek zawsze ułoży się w prawą stronę od początku statku (np. początek statku - A1, reszta statku - B1, C1)");
            Console.WriteLine("Jeśli wybierzesz, żeby statek został ułożony pionowo statek zawsze ułoży się w dół od początku statku (np. początek statku - A1, reszta statku - A2, A3)");
            Console.WriteLine();
            Console.WriteLine("Oznaczenia symboli: \n # - statek \n x - trafiony/zatopiony statek \n o - pudło \n . - puste pole, w które można strzelać");
            Console.WriteLine();
            Console.WriteLine("Żeby zacząć grać zamknij aplikacje i uruchom ją ponownie");
        }
    }
}
