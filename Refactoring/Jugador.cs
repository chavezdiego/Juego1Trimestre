using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring
{
    class Jugador
    {       
        protected Punto pos=new Punto ();

        static Random rnd = new Random();

        ConsoleKey izq,der,up,down;

        string imagen;

        public ConsoleColor color;

        int w = 3;
        int h = 3;

        public Jugador(ConsoleKey tecla_izq, ConsoleKey tecla_der, ConsoleKey tecla_up, ConsoleKey tecla_down, string img, ConsoleColor clr)
        {
            izq = tecla_izq;
            der = tecla_der;
            up = tecla_up;
            down = tecla_down;
            color = clr;
            imagen = img;

            pos.x = 2;
            pos.y = 1+rnd.Next(50);
        }

        public int obtenerH()
        {
            return h;
        }

        public int obtenerW()
        {
            return w;
        }

        public int obtenerX()
        {
            return pos.x;
        }

        public int obtenerY()
        {
            return pos.y;
        }
        public void ReiniciarJug()
        {
            pos.x = 2;
            pos.y = 1 + rnd.Next(50);
        }

        public void mover(ConsoleKeyInfo tecla)
        {                 
                //Borrar            
                for (int i = 0; i < 3; i++)
                {
                    Console.SetCursorPosition(pos.x + i, pos.y);
                    Console.WriteLine(" ");
                    Console.SetCursorPosition(pos.x + i, pos.y+1);
                    Console.WriteLine(" ");
                    Console.SetCursorPosition(pos.x + i, pos.y+2);
                    Console.WriteLine(" ");
                }
                //Teclas
                if (tecla.Key == izq) pos.x--;

                if (tecla.Key == up) pos.y--;

                if (tecla.Key == down) pos.y++;

                if (tecla.Key == der) pos.x++;
                
                //Imprimir     

                Imprimir();
             
                //Limites
                if (pos.x < 2) pos.x = 2;
                if (pos.x >= 160) pos.x = 160;
                if (pos.y < 1) pos.y = 1;
                if (pos.y + h>= 57) pos.y = 57-h;

        }
        
        public void intersectaObs(Obstaculos obs)
        {
            if (pos.x + w == obs.ObtenerX() && (pos.y >= obs.ObtenerY()) && (pos.y <= obs.ObtenerY()+obs.ObtenerH()) ) pos.x = obs.ObtenerX() - w-1;

            if (  ( (pos.y + h) == obs.ObtenerY() ) && (pos.x >= obs.ObtenerX()) && ( pos.x <= obs.ObtenerX() + obs.ObtenerW() )  ) pos.y = obs.ObtenerY() - h-1;

            if ((pos.y == obs.ObtenerY() + obs.ObtenerH()) && (pos.x >= obs.ObtenerX()) && (pos.x <= obs.ObtenerX() + obs.ObtenerW())) pos.y = obs.ObtenerY() + obs.ObtenerH()+1;

            if ((pos.x == obs.ObtenerX() + obs.ObtenerW()) && (pos.y >= obs.ObtenerY()) && (pos.y <= obs.ObtenerY() + obs.ObtenerH())) pos.x = obs.ObtenerX() + obs.ObtenerW() + 1 ;                                    
        }


        public void Imprimir()
        {
            Console.ForegroundColor = color;

            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(pos.x + i, pos.y);
                Console.WriteLine(imagen);
                Console.SetCursorPosition(pos.x + i, pos.y + 1);
                Console.WriteLine(imagen);
                Console.SetCursorPosition(pos.x + i, pos.y + 2);
                Console.WriteLine(imagen);
            }

            Console.ForegroundColor = ConsoleColor.Black;
        }

        public void Personalizar(int x, int jug)
        {
            int w = 20, h = 20,  y = 15;

            Console.ForegroundColor = color;

            for (int i = 0; i < w; i++)
            {
                for (int e = 0; e < h; e++)
                {
                    Console.SetCursorPosition(x + i, y + e);
                    Console.WriteLine("*");
                }
            }

            Console.SetCursorPosition(x + 5, y + 25);
            Console.WriteLine("Jugador {0}", jug);

        }

        public void CambiarColor(int e)
        {

            if (e <= 0) e = 0;
            if (e >= 14) e = 14;

            switch (e)
            {
                case 0: color = ConsoleColor.Blue;
                    break;
                case 1: color = ConsoleColor.Cyan;
                    break;
                case 2: color = ConsoleColor.DarkBlue;
                    break;
                case 3: color = ConsoleColor.DarkCyan;
                    break;
                case 4: color = ConsoleColor.DarkGray;
                    break;
                case 5: color = ConsoleColor.DarkGreen;
                    break;
                case 6: color = ConsoleColor.DarkMagenta;
                    break;
                case 7: color = ConsoleColor.DarkRed;
                    break;
                case 8: color = ConsoleColor.DarkYellow;
                    break;
                case 9: color = ConsoleColor.Gray;
                    break;
                case 10: color = ConsoleColor.Green;
                    break;
                case 11: color = ConsoleColor.Magenta;
                    break;
                case 12: color = ConsoleColor.Red;
                    break;
                case 13: color = ConsoleColor.White;
                    break;
                case 14: color = ConsoleColor.Yellow;
                    break;
            }

        }
        
    }
}
