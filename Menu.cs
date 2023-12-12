using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dispetcher
{
    internal class Menu
    {
        private int minStrelochka;
        private int maxStrelochka;

        public Menu(int min, int max)
        {
            minStrelochka = min;
            maxStrelochka = max;
        }

        public static int Show(int minstrelochka, int maxstrelochka)
        {
            int pos = minstrelochka;
            ConsoleKeyInfo key;
            do
            {
                Console.SetCursorPosition(0, pos);
                Console.WriteLine("->");


                key = Console.ReadKey();

                Console.SetCursorPosition(0, pos);
                Console.WriteLine("  ");
                if (key.Key == ConsoleKey.UpArrow)
                {
                    pos--;
                    if (pos == minstrelochka - 1)
                    {
                        pos = maxstrelochka;
                    }

                }

                if (key.Key == ConsoleKey.DownArrow)
                {
                    pos++;
                    if (pos == maxstrelochka + 1)
                    {
                        pos = minstrelochka;
                    }
                }

                if (key.Key == ConsoleKey.Backspace)
                {
                    pos = (int)Knopki.BackSpace;
                    return pos;
                }

                if (key.Key == ConsoleKey.D)
                {
                    pos = (int)Knopki.D;
                    return pos;
                }

                if (key.Key == ConsoleKey.Delete)
                {
                    pos = (int)Knopki.Delete;
                    return pos;
                }

            } while (key.Key != ConsoleKey.Enter);
            return pos;

        }
    }
}
