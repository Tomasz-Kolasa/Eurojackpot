using System;
using System.Collections.Generic;

namespace Eurojackpot
{
    class Konsola
    {
        static public void Wyczysc()
        {
            var textPowitalny = "********* Eurojackpot *********";

            Console.Clear();
            Console.Write(new string(' ', (Console.WindowWidth - textPowitalny.Length) / 2));
            Console.WriteLine(textPowitalny);
            Console.WriteLine();
        }

        static public void WyswietLiczby(List<byte> liczby, int czasMiedzyLiczbami=0)
        {
            foreach (byte liczba in liczby)
            {
                if(czasMiedzyLiczbami>0)
                {
                    System.Threading.Thread.Sleep(czasMiedzyLiczbami);
                }
                Console.Write($"{liczba}\t");
            }

            Console.WriteLine();
        }
    }
}
