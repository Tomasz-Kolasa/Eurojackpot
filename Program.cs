using System;

namespace Eurojackpot
{
    class Program
    {
        static void Main(string[] args)
        {
            int wybor;
             
            do
            {
                Konsola.Wyczysc();
                Console.WriteLine("Co chcesz zrobić?:");
                Console.WriteLine("1. Zagraj w Eurojackpot");
                Console.WriteLine("2. Wygeneruj n kombinacji Eurojackpot");
                Console.Write("Wybierz: ");

                var odpowiedz = Console.ReadLine();

                if (Int32.TryParse(odpowiedz, out wybor) && (wybor==1 || wybor==2))
                {
                    if (wybor == 1)
                    {
                        zagrajEurojackpot();
                    }
                    else
                    {
                        wygenerujKombinacjeEurojackpot();
                    }
                }

            } while(true);
        }

        static private void zagrajEurojackpot()
        {
            var eurojackpot = new GraEurojackpot();
            eurojackpot.zagraj();
        }

        static private void wygenerujKombinacjeEurojackpot()
        {
            var kombinacje = new KombinacjeEurojackpot();
            kombinacje.wygeneruj();
        }
    }
}
