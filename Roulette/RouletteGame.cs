using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    public class RouletteGame
    {
        public RouletteNumber[] RouletteNumbers { get; private set; }
        private Random randomBin;

        public RouletteGame()
        {
            var bins = Enum.GetValues(typeof(Bin));
            RouletteNumbers = new RouletteNumber[bins.Length];

            for(int i = 0; i < RouletteNumbers.Length; i++)
            {
                RouletteNumbers[i] = new RouletteNumber((Bin)bins.GetValue(i));
            }

            randomBin = new Random();
        }

        public RouletteNumber SpinWheel()
        {
            return RouletteNumbers[randomBin.Next(38)];
        }
    }
}
