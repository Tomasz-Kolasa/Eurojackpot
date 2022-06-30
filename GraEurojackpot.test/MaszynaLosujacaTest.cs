using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Eurojackpot.test
{
    public class MaszynaLosujacaTest
    {
        [Theory]
        [InlineData(1,50,5)]
        [InlineData(1, 12, 2)]
        public void CzyPrawidloweKryteriaLosowania_TypoweKryteriaLosowania(byte min, byte max, byte iloscLosowanych)
        {
            // Act
            var maszynaLosujaca = new MaszynaLosujaca(min, max, iloscLosowanych);
            bool actual = maszynaLosujaca.CzyPrawidloweKryteriaLosowania();

            // Assert
            Assert.True(actual);
        }

        [Fact]
        public void CzyPrawidloweKryteriaLosowania_IloscLosowanychRownaIliosciDostepnych()
        {
            // Arrange
            byte min = 1;
            byte max = 10;
            byte iloscLosowanych = 10;

            // Act
            var maszynaLosujaca = new MaszynaLosujaca(min, max, iloscLosowanych);
            bool actual = maszynaLosujaca.CzyPrawidloweKryteriaLosowania();

            // Assert
            Assert.True(actual);
        }

        [Fact]
        public void CzyPrawidloweKryteriaLosowania_MaxTakiSamJakMin()
        {
            // Arrange
            byte min = 10;
            byte max = 10;
            byte iloscLosowanych = 1;

            // Act
            var maszynaLosujaca = new MaszynaLosujaca(min, max, iloscLosowanych);
            bool actual = maszynaLosujaca.CzyPrawidloweKryteriaLosowania();

            // Assert
            Assert.True(actual);
        }

        [Fact]
        public void CzyPrawidloweKryteriaLosowania_IloscLosowanychWiekszaNizIloscDostepnych()
        {
            // Arrange
            byte min = 1;
            byte max = 10;
            byte iloscLosowanych = 11;

            // Act
            var maszynaLosujaca = new MaszynaLosujaca(min, max, iloscLosowanych);
            bool actual = maszynaLosujaca.CzyPrawidloweKryteriaLosowania();

            // Assert
            Assert.False(actual);
        }

        [Fact]
        public void CzyPrawidloweKryteriaLosowania_MinWiekszeOdMax()
        {
            // Arrange
            byte min = 10;
            byte max = 1;
            byte iloscLosowanych = 3;

            // Act
            var maszynaLosujaca = new MaszynaLosujaca(min, max, iloscLosowanych);
            bool actual = maszynaLosujaca.CzyPrawidloweKryteriaLosowania();

            // Assert
            Assert.False(actual);
        }

        [Fact]
        public void CzyPrawidloweKryteriaLosowania_IloscLosowanychZero()
        {
            // Arrange
            byte min = 1;
            byte max = 10;
            byte iloscLosowanych = 0;

            // Act
            var maszynaLosujaca = new MaszynaLosujaca(min, max, iloscLosowanych);
            bool actual = maszynaLosujaca.CzyPrawidloweKryteriaLosowania();

            // Assert
            Assert.False(actual);
        }

        [Fact]
        public void CzyPrawidloweKryteriaLosowania_WszystkieParametryZero()
        {
            // Arrange
            byte min = 0;
            byte max = 0;
            byte iloscLosowanych = 0;

            // Act
            var maszynaLosujaca = new MaszynaLosujaca(min, max, iloscLosowanych);
            bool actual = maszynaLosujaca.CzyPrawidloweKryteriaLosowania();

            // Assert
            Assert.False(actual);
        }

        [Fact]
        public void CzyPrawidloweKryteriaLosowania_MinMaxZeroOrazIloscLosowanych1()
        {
            // Arrange
            byte min = 0;
            byte max = 0;
            byte iloscLosowanych = 1;

            // Act
            var maszynaLosujaca = new MaszynaLosujaca(min, max, iloscLosowanych);
            bool actual = maszynaLosujaca.CzyPrawidloweKryteriaLosowania();

            // Assert
            Assert.True(actual);
        }

        [Theory]
        [InlineData(1, 50, 5)]
        [InlineData(1, 12, 2)]
        public void Losuj_TypoweKryteriaLosowania(byte min, byte max, byte iloscLosowanych)
        {
            // Act
            var maszynaLosujaca = new MaszynaLosujaca(min, max, iloscLosowanych);
            List<byte> actual = maszynaLosujaca.Losuj();

            // Assert
            Assert.True(CzyPrawidlowaLista( min,  max, iloscLosowanych, actual));
        }

        [Fact]
        public void Losuj_IloscLosowanychRownaIliosciDostepnych()
        {
            // Arrange
            byte min = 1;
            byte max = 10;
            byte iloscLosowanych = 10;

            // Act
            var maszynaLosujaca = new MaszynaLosujaca(min, max, iloscLosowanych);
            List<byte> actual = maszynaLosujaca.Losuj();

            // Assert
            Assert.True(CzyPrawidlowaLista(min, max, iloscLosowanych, actual));
        }

        [Fact]
        public void Losuj_MaxTakiSamJakMin()
        {
            // Arrange
            byte min = 10;
            byte max = 10;
            byte iloscLosowanych = 1;

            // Act
            var maszynaLosujaca = new MaszynaLosujaca(min, max, iloscLosowanych);
            List<byte> actual = maszynaLosujaca.Losuj();

            // Assert
            Assert.True(CzyPrawidlowaLista(min, max, iloscLosowanych, actual));
        }

        [Fact]
        public void Losuj_IloscLosowanychWiekszaNizIloscDostepnych()
        {
            // Arrange
            byte min = 1;
            byte max = 10;
            byte iloscLosowanych = 11;

            // Act
            var maszynaLosujaca = new MaszynaLosujaca(min, max, iloscLosowanych);

            // Assert
            Assert.Throws<ArgumentException>( () => maszynaLosujaca.Losuj() );
        }

        [Fact]
        public void Losuj_MinWiekszeOdMax()
        {
            // Arrange
            byte min = 10;
            byte max = 1;
            byte iloscLosowanych = 3;

            // Act
            var maszynaLosujaca = new MaszynaLosujaca(min, max, iloscLosowanych);

            // Assert
            Assert.Throws<ArgumentException>(() => maszynaLosujaca.Losuj());
        }

        [Fact]
        public void Losuj_IloscLosowanychZero()
        {
            // Arrange
            byte min = 1;
            byte max = 10;
            byte iloscLosowanych = 0;

            // Act
            var maszynaLosujaca = new MaszynaLosujaca(min, max, iloscLosowanych);

            // Assert
            Assert.Throws<ArgumentException>(() => maszynaLosujaca.Losuj());
        }

        [Fact]
        public void Losuj_MinMaxZero_MinMaxZeroOrazIloscLosowanych1()
        {
            // Arrange
            byte min = 0;
            byte max = 0;
            byte iloscLosowanych = 1;

            // Act
            var maszynaLosujaca = new MaszynaLosujaca(min, max, iloscLosowanych);
            List<byte> actual = maszynaLosujaca.Losuj();

            // Assert
            Assert.True(CzyPrawidlowaLista(min, max, iloscLosowanych, actual));
        }



        public bool CzyPrawidlowaLista(byte min, byte max, byte iloscLosowanych, List<byte> actual )
        {
            var distincts = new List<byte>();

            if(actual.Count != iloscLosowanych ) return false;

            foreach(var item in actual)
            {
                if (item >= min && item <= max && !distincts.Contains(item))
                {
                    distincts.Add(item);
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
