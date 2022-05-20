using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eurojackpot
{
    class GraEurojackpot
    {
        public void zagraj()
        {
            Konsola.Wyczysc();

            var ml = new MaszynaLosujaca(1, 50, 5);
            var liczby = ml.Losuj();

            Konsola.WyswietLiczby(liczby, "Wylosowane liczby:");
            Console.ReadKey();
        }
    }
}
