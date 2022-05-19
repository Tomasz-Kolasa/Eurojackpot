using System;
using System.Collections.Generic;

namespace Eurojackpot
{
    class Konsola
    {
        static public void Wyczysc()
        {
            Console.Clear();
        }

        static public void WyswietLiczby(List<byte> liczby, string naglowek="")
        {
            if(naglowek.Length>0)
            {
                Console.WriteLine($"{naglowek}\n");
            }

            foreach (byte liczba in liczby)
            {
                Console.Write($"{liczba}\t");
            }

            Console.WriteLine();
        }
    }
}
