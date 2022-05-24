using System;

namespace Eurojackpot
{
    class Program
    {
        static void Main(string[] args)
        {
            byte wybor;
             
            do
            {
                Konsola.Wyczysc();
                Console.WriteLine("Co chcesz zrobić?:");
                Console.WriteLine("\n1. Zagraj w Eurojackpot");
                Console.WriteLine("2. Wygeneruj n kombinacji Eurojackpot do pliku .xlsx");
                Console.Write("\nWybierz: ");

                var odpowiedz = Console.ReadLine();

                if (Byte.TryParse(odpowiedz, out wybor) && (wybor==1 || wybor==2))
                {
                    if (wybor == 1)
                    {
                        ZagrajEurojackpot();
                    }
                    else
                    {
                        WygenerujKombinacjeEurojackpot();
                    }
                }

            } while(true);
        }

        static private void ZagrajEurojackpot()
        {
            var eurojackpot = new GraEurojackpot();
            eurojackpot.Zagraj();
        }

        static private void WygenerujKombinacjeEurojackpot()
        {
            var kombinacje = new KombinacjeEurojackpot();
            kombinacje.Wygeneruj();
        }
    }
}
