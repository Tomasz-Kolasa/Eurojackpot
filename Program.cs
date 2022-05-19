using System;

namespace Eurojackpot
{
    class Program
    {
        static void Main(string[] args)
        {
            // test Maszyna losujaca
            var ml = new MaszynaLosujaca(1, 50, 5);
            var liczby = ml.Losuj();
            foreach(byte liczba in liczby)
            {
                Console.WriteLine($"{liczba}");
            }
        }
    }
}
