using System;
using System.Collections.Generic;
using System.Linq;

namespace Eurojackpot
{
    public class GraEurojackpot
    {
        public void Zagraj()
        {
            Konsola.Wyczysc();
            List<byte> zaklad5liczb = PoprosUzytkownikaOliczby(1, 50, 5);

            Konsola.Wyczysc();
            List<byte> zaklad2liczby = PoprosUzytkownikaOliczby(1, 12, 2);

            Konsola.Wyczysc();
            Console.WriteLine("Wytypowane liczby:");
            Konsola.WyswietLiczby(zaklad5liczb);
            Konsola.WyswietLiczby(zaklad2liczby);

            Console.WriteLine("\n\n\nLosuję 5 liczb z 50. Wylosowane liczby to...");
            MaszynaLosujaca maszynaLosujaca = new MaszynaLosujaca(1, 50, 5);
            var wylosowane5liczb = maszynaLosujaca.Losuj();
            Konsola.WyswietLiczby(wylosowane5liczb, 1500);

            Console.WriteLine("\n\nLosuję 2 liczby 12. Wylosowane liczby to...");
            maszynaLosujaca = new MaszynaLosujaca(1, 12, 2);
            var wylosowane2liczby = maszynaLosujaca.Losuj();
            Konsola.WyswietLiczby(wylosowane2liczby, 1500);

            if ( SprawdzCzyTeSameLiczby(zaklad5liczb, wylosowane5liczb) &&
                SprawdzCzyTeSameLiczby(zaklad2liczby, wylosowane2liczby) )
            {
                Console.WriteLine("\n\n\nWygrana pierwszego stopnia !!!");
            }
            else
            {
                Console.WriteLine("\n\n\nNiestety nie udało się tym wygrać tym razem :(");
            }

            Console.WriteLine("Naciśnij dowolny klawisz...");
            Console.ReadKey();
        }

        public bool SprawdzCzyTeSameLiczby(List<byte> wytypowaneLiczby, List<byte> wylosowaneliczby)
        {
            List<byte> listaRoznic = wytypowaneLiczby.Except(wylosowaneliczby).ToList();
            return (listaRoznic.Count > 0) ? false : true;
        }

        private List<byte> PoprosUzytkownikaOliczby(byte min, byte max, byte ilosc)
        {
            byte liczba;
            List<byte> wybraneLiczby = new List<byte>();

            Console.WriteLine($"Wprowadź {ilosc} liczb(y) z zakresu {min}-{max}");

            for (byte i=0; i<ilosc; i++)
            {
                do
                {
                    Console.WriteLine($"Wprowadź liczbę {i+1}/{ilosc}: ");
                    var wprowadzonaWartosc = Console.ReadLine();

                    if (byte.TryParse(wprowadzonaWartosc, out liczba) && (liczba >= min && liczba <= max))
                    {
                        if(wybraneLiczby.Contains(liczba))
                        {
                            Console.WriteLine("Ta liczba została już wybrana!");
                        }
                        else
                        {
                            wybraneLiczby.Add(liczba);
                            break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidłowa wartość!");
                    }

                } while (true);
            }

            return wybraneLiczby;
        }
    }
}
