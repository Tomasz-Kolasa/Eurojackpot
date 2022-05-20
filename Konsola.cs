using System;
using System.Collections.Generic;

namespace Eurojackpot
{
    class Konsola
    {
        static public void Wyczysc()
        {
            var textPowitalny = "*** Eurojackpot ***";

            Console.Clear();
            Console.Write(new string(' ', (Console.WindowWidth - textPowitalny.Length) / 2));
            Console.WriteLine(textPowitalny);
            Console.WriteLine();
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
