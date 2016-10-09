using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring
{
    abstract class ObjetoFisico
    {
        static Random rnd = new Random();

        long proximo, delta;

        public ObjetoFisico()
        {
            proximo = 1 + rnd.Next(10);
            delta = 100 + rnd.Next(400);
        }

        public ObjetoFisico(long p, long d)
        {
            proximo = p;
            delta = d;
        }

        public abstract void mover();

        public void Tick(long t)
        {
            if (t >= proximo)
            {
                mover();
                proximo += delta;
            }
        }
    }
}
