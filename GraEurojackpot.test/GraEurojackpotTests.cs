using System;
using System.Collections.Generic;
using Xunit;

namespace Eurojackpot.test
{
    public class GraEurojackpotTests : IDisposable
    {
        private GraEurojackpot game;

        public GraEurojackpotTests()
        {
            game = new GraEurojackpot();
        }

        [Fact]
        public void SprawdzCzyTeSameLiczby_TheSameLists()
        {
            List<byte> list1 = new List<byte>() { 1,2,3,4,5};
            List<byte> list2 = new List<byte>() { 1,2,3,4,5};

            var result = game.SprawdzCzyTeSameLiczby(list1, list2);

            Assert.True(result);
        }

        [Fact]
        public void SprawdzCzyTeSameLiczby_DifferentLists()
        {
            List<byte> list1 = new List<byte> { 1, 2, 3, 4, 6 };
            List<byte> list2 = new List<byte> { 1, 2, 3, 4, 5 };

            var result = game.SprawdzCzyTeSameLiczby(list1, list2);

            Assert.False(result);
        }

        [Fact]
        public void SprawdzCzyTeSameLiczby_DifferentSizesLists()
        {
            List<byte> list1 = new List<byte> { 1, 2, 3, 4, 6 };
            List<byte> list2 = new List<byte> { 1, 2, 3, 4 };

            var result = game.SprawdzCzyTeSameLiczby(list1, list2);

            Assert.False(result);
        }

        public void Dispose()
        {
            game = null;
        }
    }
}
