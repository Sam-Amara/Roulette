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

            DisplayWinningBets(rouletteGame.SpinWheel());
        }

        static void DisplayWinningBets(RouletteNumber winningBin)
        {
            Console.WriteLine($"Winning bets are :");
            Console.WriteLine($"\n 1.  Bin number {winningBin.ToString()}");

            if (winningBin.Val != Bin.Zero && winningBin.Val != Bin.ZeroZero)
            {
                Console.WriteLine($" 2.  {winningBin.EvenOdd} numbers");
                Console.WriteLine($" 3.  {winningBin.Color} color");
                Console.WriteLine($" 4.  {winningBin.LowHigh} numbers");
                Console.WriteLine($" 5.  {winningBin.Dozen} numbers");
                Console.WriteLine($" 6.  {winningBin.Column} numbers");
                Console.WriteLine($" 7.  Street: {winningBin.Row}");
                Console.WriteLine($" 8.  6 Numbers: {String.Join(" or ", winningBin.DoubleRow)}");
                Console.WriteLine($" 9.  Splits: {String.Join(" or ", winningBin.Splits)}");
                Console.WriteLine($" 10. Corners: {String.Join(" or ", winningBin.Corners)}");
            }
            Console.WriteLine();
        }
    }
}
