using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring
{
    class Escenario
    {

        ConsoleColor color;

        public Escenario(ConsoleColor clr)
        {
            color = clr;
        }

        public void Motrar()
        {

            Console.ForegroundColor = color;

            for (int i = 0; i < 164; i++)
            {              
                Console.SetCursorPosition(i, 0);
                Console.WriteLine("*");
                Console.SetCursorPosition(i, 57);
                Console.WriteLine("*");
                if (i<58)
                {
                    Console.SetCursorPosition(0, i);
                    Console.WriteLine("*");
                    Console.SetCursorPosition(163, i);
                    Console.WriteLine("*");
                    Console.SetCursorPosition(6, i);
                    Console.WriteLine("*");
                    Console.SetCursorPosition(158, i);
                    Console.WriteLine("*");
                }
            }

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