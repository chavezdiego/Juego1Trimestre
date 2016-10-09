using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace Refactoring
{
    class Program
    {   
        static void Main(string[] args)
        {
            Console.SetBufferSize(165, 59);

            Console.SetWindowSize(164, 58);

            Random rnd = new Random();

            var lp = new List<ObjetoFisico>();

            UdpClient cli = new UdpClient(8001);
            
            Console.CursorVisible = false;
             
            Jugador j1 = new Jugador(ConsoleKey.A, ConsoleKey.D, ConsoleKey.W, ConsoleKey.S,"*",ConsoleColor.Blue);

            Jugador j2 = new Jugador(ConsoleKey.LeftArrow, ConsoleKey.RightArrow, ConsoleKey.UpArrow, ConsoleKey.DownArrow,"*",ConsoleColor.Yellow);

            var Objeto = new Decoraciones();

            var Fin = new Explosion();

            var LObstaculos = new List<Obstaculos>();

            LObstaculos.Add(new Obstaculos(8, 40, 20, 17,ConsoleColor.Blue));
            LObstaculos.Add(new Obstaculos(8, 40, 70, 17, ConsoleColor.Blue));
            LObstaculos.Add(new Obstaculos(8, 40, 120, 17, ConsoleColor.Blue));

            LObstaculos.Add(new Obstaculos(8, 40, 45, 1, ConsoleColor.Blue));
            LObstaculos.Add(new Obstaculos(8, 40, 95, 1, ConsoleColor.Blue));
            LObstaculos.Add(new Obstaculos(8, 40, 145, 1, ConsoleColor.Blue));

            for (int i = 0; i < 5; i++)
            {
                lp.Add(new MovLibre(LObstaculos));
                lp.Add(new MovHorizontal(LObstaculos));
                lp.Add(new MovVertical(LObstaculos));
            }
           
            var Escenario = new Escenario(ConsoleColor.Red);

            DateTime up = DateTime.Now;

            DateTime start = DateTime.Now;

            //--------------------Interfaz----------------
            
            ConsoleKeyInfo tecla2;
            int g=0, e=0,f=0;

            while(g==0)
            {

                j1.Personalizar(40,1);

                j2.Personalizar(100,2);


                if (f==0)
                {
                    Objeto.ImprimirFlechaDer(65, 24, 9, 4, e);

                    Objeto.ImprimirFlechaIzq(26, 24, 9, 4, e);
                }

                if (f==1)
                {
                    Objeto.ImprimirFlechaDer(125, 24, 9, 4, e);

                    Objeto.ImprimirFlechaIzq(85, 24, 9, 4, e);
                }
                
                //Condicion para Salir
                if (Console.KeyAvailable)
                {
                    tecla2 = Console.ReadKey(true);

                    if (tecla2.Key == ConsoleKey.LeftArrow) e--;

                    if (tecla2.Key == ConsoleKey.RightArrow) e++;

                    if (f == 0) j1.CambiarColor(e);

                    if (f == 1) j2.CambiarColor(e);

                    if (tecla2.Key == ConsoleKey.Enter && f == 1)
                    {
                        Console.Clear();
                        g = 1;
                    }
                    if (tecla2.Key == ConsoleKey.Enter)
                    {
                        f = 1;
                        e = 0;
                        Console.Clear();                      
                    }

                    if (tecla2.Key == ConsoleKey.Escape) g = 1;
                
                }
            //----------------------------------------
            }

            Console.Clear();

            //-----------------------------------------------

            g = 0;
            e = 0;
            f = 0;
            int ObsColor=0;
            int EscColor = 0;
            int PelColor = 0;

            var PreObs = new Obstaculos(8, 40, 79, 17, ConsoleColor.Blue);

            var PreEscenario = new Escenario(ConsoleColor.Red);

            var Prelp = new List<ObjetoFisico>();

            Prelp.Add(new MovLibre());
            Prelp.Add(new MovHorizontal());
            Prelp.Add(new MovVertical());

            ConsoleKeyInfo tecla3;

            while(g==0)
            {
                PreEscenario.Motrar();

                if(f==0)
                {
                    PreObs.Dibujar();

                    Objeto.ImprimirFlechaDer(98, 24, 9, 4, e);

                    Objeto.ImprimirFlechaIzq(60, 24, 9, 4, e);
                }

                if (f==1)
                {
                    PreEscenario.Motrar();
                }

                if (f==2)
                {
                    foreach (Pelota p in Prelp)
                    {           
                        p.mover();
                    }
                }

                if (Console.KeyAvailable)
                {
                    tecla3 = Console.ReadKey(true);

                    if (tecla3.Key == ConsoleKey.LeftArrow) e--;

                    if (tecla3.Key == ConsoleKey.RightArrow) e++;

                    if (f == 0)
                    {
                        PreObs.CambiarColor(e);
                        ObsColor = e;
                    }

                    if (f == 1)
                    {
                        PreEscenario.CambiarColor(e);
                        EscColor = e;                       
                    }

                    if (f==2)
                    {
                        foreach (Pelota p in Prelp)
                        {
                            p.CambiarColor(e);
                        }
                        PelColor = e;
                    }
                 
                    if (tecla3.Key == ConsoleKey.Enter && f == 2)
                    {
                        Console.Clear();
                        g = 1;
                    }
                    if (tecla3.Key == ConsoleKey.Enter && f == 1)
                    {
                        Console.Clear();
                        f = 2;                      
                    }
                    if (tecla3.Key == ConsoleKey.Enter && f==0 )
                    {
                        f = 1;
                        e = 0;
                        Console.Clear();
                    }
                    if (tecla3.Key == ConsoleKey.Escape) g = 1;
                }
            } 

            //---------------------------------------------------------

            foreach (Obstaculos Obs in LObstaculos)
            {
                Obs.CambiarColor(ObsColor);
                Obs.Dibujar();
            }

            Escenario.CambiarColor(EscColor);

            Escenario.Motrar();

            Console.ForegroundColor = ConsoleColor.Black;
            
            j1.Imprimir();

            j2.Imprimir();

            while(true)
            {   

                StringBuilder sb = new StringBuilder();
                
                //Mover Jugadores
                
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo tecla = Console.ReadKey(true);
                    j1.mover(tecla);
                    j2.mover(tecla);
                    Escenario.Motrar();
                }

                //Mover pelotas
                
                foreach (Pelota p in lp)
                {
                    p.CambiarColor(PelColor);

                    if (p.intersecta(j1))
                    {
                        Fin.Explotar(j1);
                        j1.ReiniciarJug();
                        j1.Imprimir();                       
                    }
                    if (p.intersecta(j2))
                    {
                        Fin.Explotar(j2);
                        j2.ReiniciarJug();
                        j2.Imprimir();
                    }

                    p.mover();

                    sb.Append(p.obtenerX() + "," + p.obtenerY() + ";");
                }

                foreach (Obstaculos obs in LObstaculos)
                {
                    foreach (Pelota p in lp)
                    {
                        p.Intersecta(obs);
                    }
                    
                    j1.intersectaObs(obs);

                    j2.intersectaObs(obs);
                    
                    
                }

                //byte[] pocket = Encoding.ASCII.GetBytes(sb.ToString());
                //cli.Send(pocket, pocket.Length);

                //Condicion de ganador

                if (j1.obtenerX() == 160)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;                 
                    Console.SetCursorPosition(80, 30);
                    Console.WriteLine("El ganador es el jugador 1");
                    Console.ReadLine();
                    break;
                }
                if (j2.obtenerX() == 160)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;                 
                    Console.SetCursorPosition(80, 30);
                    Console.WriteLine("El ganador es el jugador 2");
                    Console.ReadLine();
                    break;

                }

                //Agregar pelotas por segundo
                
                if ((DateTime.Now-up).TotalSeconds>=20)
                {                   
                    switch (rnd.Next(3))
                    {
                        case 0: lp.Add(new MovHorizontal(LObstaculos));
                            break;
                        case 1: lp.Add(new MovVertical(LObstaculos));
                            break;
                        case 2: lp.Add(new MovLibre(LObstaculos));
                            break;
                    }
                    up = DateTime.Now;
                }
                
                //Velocidad
                /*
                long t = (long)(DateTime.Now - start).TotalMilliseconds;

                foreach (ObjetoFisico o in lp)
                {
                    o.Tick(t);
                } 
                 */
                Thread.Sleep(45);
            }
        }
    }
}