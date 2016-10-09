using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring
{
    class MovHorizontal:Pelota
    {
        static Random rnd = new Random();

        public MovHorizontal(int proximo, int delta, int x, int y) : base(proximo, delta) 
        {
            pos.x = x;
            pos.y = y;
        }

        public MovHorizontal():base()
        {

        }

        public int ObtenerDir()
        {
            return m;
        }

        public void CambiarDir()
        {
            if (m == 0) m=1;
            else m=0;          
        }

        public MovHorizontal(List<Obstaculos> LObstaculos)
            : base(LObstaculos)
        {
            
        }

        public override void mover()
        {

            Console.SetCursorPosition(pos.x, pos.y);
            Console.WriteLine(" ");

            switch (m) //Direccion
            {
                case 0:
                    pos.x--;
                    break;

                case 1:
                    pos.x++;
                    break;

            }

            Imprimir();

            //Limites

            if (pos.x <= 7 && m == 0) m = 1;
            if (pos.x == 157 && m == 1) m = 0;
        }

        public override void Intersecta(Obstaculos obs)
        {
            if (pos.x >= obs.ObtenerX()-1 && pos.x < 1+(obs.ObtenerX() + obs.ObtenerW()) && pos.y >= obs.ObtenerY() && pos.y < (obs.ObtenerY() + obs.ObtenerH()))
            {
                if (m == 0) m = 1;
                else m = 0;
            }
        
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
