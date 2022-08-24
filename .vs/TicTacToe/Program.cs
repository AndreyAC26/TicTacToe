using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
     class Program
    {
        // Creamos un arreglo bidimensional para el tablero del juego
        static int[,] tablero = new int[3, 3]; //3 filas 3 columnas
        // Creamos un arreglo para los signos del tablero
        static char[] simbolo = {' ','O','X'};

        static void Main(string[] args)
        {
            bool terminado = false;

            //Dibujar el tablero inicial
            DibujarTablero();
            Console.WriteLine("Jugador 1 = 0\nJugador 2 = X");

            do
            {
                //turno Jugador 1
                PreguntarProsicion(1);
                Console.Clear();
                //Dibujar la casilla del jugador1
                DibujarTablero();

                // Comprobar si ha ganado la partida el jugador1
                terminado = ComprobarGanador();

                if(terminado == true)
                {
                    Console.WriteLine("!El jugador 1 ha ganado¡");
                }
                else // de lo contrario comprobamos si hubo un empate
                {
                    terminado = ComprobarEmpate();
                    if(terminado == true)
                    {
                        Console.WriteLine("Esto es un empate");
                    }

                    // Si jugador 1 no gano y tampoco hubo un empate 
                    //sera el turno del jugador 2
                    else
                    {
                        // Turno del jugador 2
                        PreguntarProsicion(2);
                        Console.Clear();
                        // DIBUJAR LA CASILLA DEL JUGADOR 2
                        DibujarTablero();
                        // Comprobar si ha ganado la partida el jugador 2
                        terminado = ComprobarGanador();

                        if(terminado == true)
                        {
                            Console.WriteLine("!El jugador 2 ha ganado¡");
                        }

                    }
                }

                // Se repite asta que este 3 en linea o empate
            } while (terminado == false);

        }//Cierre del Main

        static void DibujarTablero()
        {
            //Variables de conteo del circulo
            int fila = 0;
            int columna = 0;

            Console.WriteLine(); //Espacio antes de dibujar el tablero
            Console.WriteLine("-------------"); //Dibujar la primera linea horizontal
            for(fila = 0; fila < 3 ; fila++)
            {
                Console.Write("|"); // Dibuja la siguiente linea horizontal
                for(columna = 0; columna < 3 ; columna++)
                {
                    //Asigna un: Espacio, O, X, segun corresponda
                    Console.Write(" {0} |", simbolo[tablero[fila,columna]]);
                }
                Console.WriteLine();
                Console.WriteLine("-------------");
            }
        }

        //Se encarga de donde escribir y lo dibuja en el tablero
        static void PreguntarProsicion(int jugador) //1 para jugador1 t 2 para jugador2
        {
            int fila, columna;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Turno del jugador: {0}", jugador);
                // pedimos el numero de fila
                do
                {
                    Console.Write("Selecciona la fila (1 a 3): ");
                    fila = Convert.ToInt32(Console.ReadLine());
                } while ((fila < 1) || (fila >3));

                //Pedimos el numero de columna
                do
                {
                    Console.Write("Selecciona la columna (1 a 3): ");
                    columna = Convert.ToInt32(Console.ReadLine());
                } while ((fila < 1) || (fila > 3));

                if (tablero[fila - 1, columna - 1] != 0)                
                    Console.WriteLine("Casilla Ocupada");
                

            } while (tablero[fila - 1, columna - 1] != 0);

            //Si todo es correcto se le asigna al jugador correspondiente
            tablero[fila - 1, columna - 1] = jugador;
        }

        //Devuelve un "true" si hay 3 en linea
        static bool ComprobarGanador()
        {
            int fila = 0;
            int columna = 0;
            bool tictactoe = false;
            for(fila = 0; fila < 3; fila++)
            {
                if ((tablero[fila, 0] == tablero[fila, 1])
                    && (tablero[fila, 0] == tablero[fila, 2])
                    && (tablero[fila, 0] != 0))
                {
                    tictactoe = true;
                }

            }

            //Si en alguna columna todas las casillas son iguales y no estan vacias
            for (columna = 0; columna < 3; columna++)
            {
                if((tablero[0, columna] == tablero[1, columna])
                    && (tablero[0, columna] == tablero[2, columna])
                    && (tablero[0, columna] != 0))
                {
                    tictactoe = true;
                }
            }

            //Si en alguna diagonal todas las casillas son iguales y no estan vacias
            if ((tablero[0, 0] == tablero[1, 1])
                   && (tablero[0, 0] == tablero[2, 0])
                   && (tablero[0, 0] != 0))
            {
                tictactoe = true;
            }

            if (      (tablero[0, 2] == tablero[1, 1])
                   && (tablero[0, 2] == tablero[2, 0])
                   && (tablero[0, 2] != 0))
            {
                tictactoe = true;
            }

            return tictactoe;

        }

        //Devuelve el valor de "true" si hay empate
        static bool ComprobarEmpate()
        {
            bool hayEspacio = false;
            int fila = 0;
            int columna = 0;

            for(fila = 0; fila < 3; fila ++)
            {
                for(columna = 0; columna < 3; columna ++)
                {
                    if (tablero[fila, columna] == 0)
                    {
                        hayEspacio = true;
                    }
                }
            }

            return !hayEspacio; 
        }

    }
}
