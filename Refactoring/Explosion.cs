using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring
{
    class Explosion
    {
        DateTime up = new DateTime();

        public void Explotar(Jugador j)
        {
            int YTemporal = j.obtenerY();
            int XTemporal = j.obtenerX();


            for (int i = 0; i < 5; i++)
            {
                Console.ForegroundColor = j.color;
                
                Console.SetCursorPosition(j.obtenerX() - 2 + i, j.obtenerY() - 2 + i);
                Console.WriteLine("*");               
                
                Console.SetCursorPosition(j.obtenerX() - 2 + i, j.obtenerY() + 2 - i);
                Console.WriteLine("*");

                if (i<4)
                {
                    Console.SetCursorPosition(j.obtenerX() + i, j.obtenerY());
                    Console.WriteLine("*");
                    Console.SetCursorPosition(j.obtenerX(), j.obtenerY() + i);
                    Console.WriteLine("*");
                    Console.SetCursorPosition(j.obtenerX() - i, j.obtenerY());
                    Console.WriteLine("*");
                    Console.SetCursorPosition(j.obtenerX(), j.obtenerY() - i);
                    Console.WriteLine("*");
                }
             
                Console.ForegroundColor = ConsoleColor.Black;

                up = DateTime.Now;

            }
            

                if ((DateTime.Now - up).TotalSeconds >= 2)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Console.SetCursorPosition(XTemporal + i, YTemporal);
                        Console.WriteLine(" ");
                        Console.SetCursorPosition(XTemporal, YTemporal + i);
                        Console.WriteLine(" ");
                        Console.SetCursorPosition(XTemporal - i, YTemporal);
                        Console.WriteLine(" ");
                        Console.SetCursorPosition(XTemporal, YTemporal - i);
                        Console.WriteLine(" ");


                        for (int e = 0; e < 5; e++)
                        {
                            Console.SetCursorPosition(XTemporal - 2 + e, YTemporal - 2 + e);
                            Console.WriteLine(" ");
                        }

                        for (int e = 0; e < 5; e++)
                        {
                            Console.SetCursorPosition(XTemporal - 2 + e, YTemporal + 2 - e);
                            Console.WriteLine(" ");
                        }
                        up = DateTime.Now;
                    }
                }
                                      
        }
    }
}
