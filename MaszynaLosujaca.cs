using System;
using System.Collections.Generic;

namespace Eurojackpot
{
    public class MaszynaLosujaca
    {
        private byte min;
        private byte max;
        private byte iloscLosowanych;

        /*
         * min - included
         * max - included
         */
        public MaszynaLosujaca(byte min, byte max, byte iloscLosowanych)
        {
            this.min = min;
            this.max = max;
            this.iloscLosowanych = iloscLosowanych;
        }

        public List<byte> Losuj()
        {
            List<byte> wylosowaneLiczby = new List<byte>();
            byte wylosowanaLiczba;
            var random = new Random();

            if (CzyPrawidloweKryteriaLosowania())
            {
                for (byte i = 0; i < this.iloscLosowanych; i++)
                {
                    do
                    {
                        wylosowanaLiczba = (byte)random.Next((int)this.min, (int)this.max+1);

                    }
                    while( wylosowaneLiczby.Contains(wylosowanaLiczba) );

                    wylosowaneLiczby.Add(wylosowanaLiczba);
                }
            }
            else
            {
                throw new ArgumentException("Podano nieprawidłowe kryteria losowania!");
            }

            return wylosowaneLiczby;
        }

        public bool CzyPrawidloweKryteriaLosowania()
        {
            if (this.max < this.min) return false;

            if (this.iloscLosowanych > 0 && this.iloscLosowanych <= (this.max - this.min + 1)) return true;

            return false;
        }
    }
}
