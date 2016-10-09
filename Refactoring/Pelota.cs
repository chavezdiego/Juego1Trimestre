using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring
{
    abstract class Pelota:ObjetoFisico
    {
        protected Punto pos=new Punto ();

        static Random rnd = new Random();

        protected int m;

        protected ConsoleColor color= ConsoleColor.Red;

        //Los constructures no llevan Void

        public Pelota():base ()
        {
            pos.x = 7 + rnd.Next(145);
            pos.y = 2 + rnd.Next(50);
        }

        public int obtenerX()
        {
            return pos.x;
        }

        public int obtenerY()
        {
            return pos.y;
        }

        public Pelota(int proximo, int delta) : base(proximo, delta) 
        {
        }
      
        public Pelota(List<Obstaculos> LObstaculos) : base()
        {
            int b = 0;

            do
            {
                b = 0;
                
                pos.x = 7 + rnd.Next(145);
                pos.y = 2 + rnd.Next(50);
                
                foreach (var Obs in LObstaculos)
	            {
                    if (Verificar(Obs))
	                {
		                b=1;
	                }
	            }
            } while (b==1);              
        }

        public bool intersecta (Jugador j)
        {
            return (j.obtenerX() <= pos.x && pos.x < (j.obtenerX() + j.obtenerW()) && pos.y >= j.obtenerY() && pos.y < (j.obtenerY() + j.obtenerH()));             
        }

        abstract public void Intersecta(Obstaculos obs);

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

        public bool Verificar(Obstaculos obs)
        {
            return (pos.x >= obs.ObtenerX() && pos.x < (obs.ObtenerX() + obs.ObtenerW()) && pos.y >= obs.ObtenerY() && pos.y < (obs.ObtenerY() + obs.ObtenerH()));          
        
        }
    }
}
