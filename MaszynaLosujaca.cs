using System;
using System.Collections.Generic;

namespace Eurojackpot
{
    class MaszynaLosujaca
    {
        private byte min;
        private byte max;
        private byte iloscLosowanych;

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
                        wylosowanaLiczba = (byte)random.Next((int)this.min, (int)this.max);

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

        private bool CzyPrawidloweKryteriaLosowania()
        {
            if (this.max < this.min) return false;
            if (this.iloscLosowanych > (this.max - this.min)) return false;
            return true;
        }
    }
}
