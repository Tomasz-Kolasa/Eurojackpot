using PicoXLSX;
using System;
using System.Collections.Generic;

namespace Eurojackpot
{
    class KombinacjeEurojackpot
    {
        private Workbook Workbook;
        public void Wygeneruj()
        {
            int wybor;

            do
            {
                Konsola.Wyczysc();
                Console.WriteLine("Ile kombinacji wygenerować (1-1000)?:");
                Console.WriteLine("0 - anuluj");
                Console.Write("\nWybierz: ");

                var odpowiedz = Console.ReadLine();

                if (Int32.TryParse(odpowiedz, out wybor) && (wybor>=0 && wybor<=1000))
                {
                    if (wybor == 0)
                    {
                        return;
                    }
                    else
                    {
                        GenerujKombinacje(wybor);
                    }
                }
                else
                {
                    Console.WriteLine("Nieprawidłowy wybór!\nWciśnij dowolny klawisz...");
                    Console.ReadKey();
                }

            } while (true);
        }

        private void GenerujKombinacje(int iloscKobinacji)
        {
            Workbook = new Workbook("kombinacje_Eurojackpot.xlsx", "kombinacje");

            List<byte> zestaw1 = new List<byte>();
            List<byte> zestaw2 = new List<byte>();

            MaszynaLosujaca maszynaLosujaca1 = new MaszynaLosujaca(1, 50, 5);
            MaszynaLosujaca maszynaLosujaca2 = new MaszynaLosujaca(1, 12, 2);

            Konsola.Wyczysc();
            Console.WriteLine("Generuję kombinacje...\n");

            for (var i=0; i<iloscKobinacji; i++)
            {
                zestaw1 = maszynaLosujaca1.Losuj();
                zestaw2 = maszynaLosujaca2.Losuj();

                WpiszWierszKombinacjiDoArkusza(zestaw1, zestaw2);
            }

            Workbook.Save();

            Console.WriteLine("\nKombinacje zostały zapisane w pliku \"kombinacje_Eurojackpot.xlsx\"");
            Console.WriteLine("Naciśnij dowolny klawisz...");
            Console.ReadKey();
        }

        private void WpiszWierszKombinacjiDoArkusza(List<byte> zestaw1, List<byte> zestaw2)
        {
            foreach(byte liczba in zestaw1 )
            {
                Workbook.WS.Value(liczba);
            }
            Workbook.WS.Value(" ");
            Workbook.WS.Value(zestaw2[0]);
            Workbook.WS.Value(zestaw2[1]);

            Workbook.WS.Down();
        }
    }
}
