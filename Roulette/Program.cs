using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    class Program
    {
        static void Main(string[] args)
        {
            var rouletteGame = new RouletteGame();

            Console.WriteLine(rouletteGame.SpinWheel().GetWinningBets());
            Console.WriteLine();
        }
    }
}
