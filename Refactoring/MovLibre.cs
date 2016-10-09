using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring
{
    class MovLibre : Pelota
    {
        static Random rnd = new Random();


        public MovLibre(int proximo, int delta, int x, int y) : base(proximo, delta) 
        {
            pos.x = x;
            pos.y = y;
        }

        public MovLibre():base()
        {
            m = rnd.Next(3);
        }

        public MovLibre(List<Obstaculos> LObstaculos) : base(LObstaculos)
        {
            m = rnd.Next(3);
        }

        public int ObtenerDir()
        {
            return m;
        }

        public override void mover()
        {

            Console.SetCursorPosition(pos.x, pos.y);
            Console.WriteLine(" ");

            switch (m) //Direccion
            {
                case 0:
                    pos.x++;
                    pos.y++;
                    break;

                case 1:
                    pos.x--;
                    pos.y--;
                    break;

                case 2:
                    pos.x++;
                    pos.y--;
                    break;

                case 3:
                    pos.x--;
                    pos.y++;
                    break;

            }

            Imprimir();

            //Limites

            if (pos.x <= 8 && m == 1) m = 2;
            if (pos.x <= 8 && m == 3) m = 0;
            if (pos.x == 157 && m == 2) m = 1;
            if (pos.x == 157 && m == 0) m = 3;


            if (pos.y <= 1 && m == 1) m = 3;
            if (pos.y <= 1 && m == 2) m = 0;
            if (pos.y == 56 && m == 3) m = 1;
            if (pos.y == 56 && m == 0) m = 2;
        }

        public override void Intersecta(Obstaculos obs)
        {
            

                if (pos.x == (obs.ObtenerX() + obs.ObtenerW()+1) && (pos.y >= obs.ObtenerY()) && (pos.y <= obs.ObtenerY() + obs.ObtenerH()) && m == 1) m = 2;

                if ( (pos.x == (obs.ObtenerX() + obs.ObtenerW()+1) ) && (pos.y >= obs.ObtenerY() )&& (pos.y <= obs.ObtenerY() + obs.ObtenerH()) && m == 3) m = 0;

                if (pos.x == obs.ObtenerX()-1 && (pos.y >= obs.ObtenerY()) && (pos.y <= obs.ObtenerY() + obs.ObtenerH()) && m == 2) m = 1;
                if (pos.x == obs.ObtenerX() -1&& (pos.y >= obs.ObtenerY()) && (pos.y <= obs.ObtenerY() + obs.ObtenerH()) && m == 0) m = 3;

                if (pos.y == obs.ObtenerY()+1 + obs.ObtenerH() && (pos.x >= obs.ObtenerX()) && (pos.x <= obs.ObtenerX() + obs.ObtenerW()) && m == 1) m = 3;
                if (pos.y == obs.ObtenerY() +1+ obs.ObtenerH() && (pos.x >= obs.ObtenerX()) && (pos.x <= obs.ObtenerX() + obs.ObtenerW()) && m == 2) m = 0;

                if (pos.y == obs.ObtenerY()-1 && pos.x >= obs.ObtenerX() && pos.x <= obs.ObtenerX() + obs.ObtenerW() && m == 3) m = 1;
                if (pos.y == obs.ObtenerY() -1&& pos.x >= obs.ObtenerX() && pos.x <= obs.ObtenerX() + obs.ObtenerW() && m == 0) m = 2;  
           
        }

        public void Imprimir()
        {
            Console.ForegroundColor = color;

            Console.SetCursorPosition(pos.x, pos.y);
            Console.WriteLine("*");

            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
