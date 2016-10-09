using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring
{
    class Decoraciones
    {
        ConsoleColor color;

        public void ImprimirFlechaDer(int x, int y, int w, int h, int c)
        {

            CambiarColor(c+1);
            Console.ForegroundColor = color;

            for (int i = 0; i < w; i++)
            {
                for (int e = 0; e < h; e++)
                {
                    Console.SetCursorPosition(x + i, y + e);
                    Console.WriteLine("*");
                }
            }
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(x + 5, y - 3 + i);
                Console.WriteLine("*");
                if (i < 8)
                {
                    Console.SetCursorPosition(x + 6, y - 2 + i);
                    Console.WriteLine("*");
                    if (i < 6)
                    {
                        Console.SetCursorPosition(x + 7, y - 1 + i);
                        Console.WriteLine("*");
                        if (i < 2)
                        {
                            Console.SetCursorPosition(x + 9, y + 1 + i);
                            Console.WriteLine("*");
                        }
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public void ImprimirFlechaIzq(int x, int y, int w, int h, int c)
        {

            CambiarColor(c - 1);
            Console.ForegroundColor = color;

            for (int i = 0; i < w; i++)
            {
                for (int e = 0; e < h; e++)
                {
                    Console.SetCursorPosition(x + i, y + e);
                    Console.WriteLine("*");
                }
            }
            for (int i = 0; i < 10; i++)
            {
                Console.SetCursorPosition(x + 3, y - 3 + i);
                Console.WriteLine("*");
                if (i < 8)
                {
                    Console.SetCursorPosition(x + 2, y - 2 + i);
                    Console.WriteLine("*");
                    if (i < 6)
                    {
                        Console.SetCursorPosition(x + 1, y - 1 + i);
                        Console.WriteLine("*");
                        if (i < 2)
                        {
                            Console.SetCursorPosition(x -1, y + 1 + i);
                            Console.WriteLine("*");
                        }
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Black;
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
