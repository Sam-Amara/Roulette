using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette
{
    public class RouletteNumber
    {
        public Bin Val { get; private set; }
        public string EvenOdd { get; private set; }
        public string Color { get; private set; }
        public string LowHigh { get; private set; }
        public string Dozen { get; private set; }
        public string Column { get; private set; }
        public string Row { get; private set; }
        public string[] DoubleRow { get; private set; }
        public string[] Splits { get; private set; }
        public string[] Corners { get; private set; }
        public string WinningBets { get; private set; }

        private int intVal;
        private bool hasTop;
        private bool hasLeft;
        private bool hasRight;
        private bool hasBottom;

        public RouletteNumber(Bin val)
        {
            Val = val;

            intVal = (int)val;

            if (intVal != 0 && intVal != 37)
            {
                hasTop = (intVal - 3) > 0;
                hasLeft = (intVal - 1) % 3 > 0;
                hasRight = (intVal + 1) % 3 != 1;
                hasBottom = (intVal + 3) < 37;

                EvenOdd = ((int)val % 2 == 0) ? "Even" : "Odd";
                LowHigh = ((int)val < 19) ? "Low (1 - 18)" : "High (19 - 36)";
                Color = SetColor();
                Dozen = SetDozen();
                Column = SetColumn();
                Row = SetRow(intVal);
                SetDoubleRowSplits();
                SetCorners();
                SetWinningBets();
            }
            else
            {
                WinningBets = $"\nWinning bet is Bin number {ToString()}";
            }
        }

        private void SetCorners()
        {
            List<string> corners = new List<string>();

            if (hasTop && hasLeft)
            {
                corners.Add($"{intVal - 4}/{intVal - 3}/{intVal - 1}/{intVal}");
            }
            if (hasTop && hasRight)
            {
                corners.Add($"{intVal - 3}/{intVal - 2}/{intVal}/{intVal + 1}");
            }
            if (hasLeft && hasBottom)
            {
                corners.Add($"{intVal - 1}/{intVal}/{intVal + 2}/{intVal + 3}");
            }
            if (hasRight && hasBottom)
            {
                corners.Add($"{intVal}/{intVal + 1}/{intVal + 3}/{intVal + 4}");
            }

            Corners = corners.ToArray();
        }

        private void SetDoubleRowSplits()
        {
            List<string> doubleRow = new List<string>();
            List<string> splits = new List<string>();

            if (hasTop)
            {
                doubleRow.Add($"{SetRow(intVal - 3)}/{SetRow(intVal)}");
                splits.Add($"{intVal - 3}/{intVal}");
            }
            if (hasLeft)
            {
                splits.Add($"{intVal - 1}/{intVal}");
            }
            if (hasRight)
            {
                splits.Add($"{intVal}/{intVal + 1}");
            }
            if (hasBottom)
            {
                doubleRow.Add($"{SetRow(intVal)}/{SetRow(intVal + 3)}");
                splits.Add($"{intVal}/{intVal + 3}");
            }

            DoubleRow = doubleRow.ToArray();
            Splits = splits.ToArray();
        }

        private string SetRow(int val)
        {
            int firstRowNumber = (((val - 1) / 3) * 3) + 1;
            return $"{firstRowNumber}/{++firstRowNumber}/{++firstRowNumber}";
        }

        private string SetColumn()
        {
            if (intVal % 3 == 1) return "1st Column";
            if (intVal % 3 == 2) return "2nd Column";
            return "3rd Column";
        }

        private string SetDozen()
        {
            if (intVal / 12.0 <= 1) return "1st 12";
            if (intVal / 12.0 <= 2) return "2nd 12";
            return "3rd 12";
        }

        private string SetColor()
        {
            if (intVal <= 10 || (intVal > 18 && intVal <= 28))
                return (EvenOdd == "Even") ? "Black" : "Red";

            return (EvenOdd == "Odd") ? "Black" : "Red";
        }

        public override string ToString() => (intVal == 37) ? "00" : intVal.ToString();

        private void SetWinningBets()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Winning bets are :");
            sb.AppendLine($"\n 1.  Bin number {ToString()}");

            sb.AppendLine($" 2.  {EvenOdd} numbers");
            sb.AppendLine($" 3.  {Color} color");
            sb.AppendLine($" 4.  {LowHigh} numbers");
            sb.AppendLine($" 5.  {Dozen} numbers");
            sb.AppendLine($" 6.  {Column} numbers");
            sb.AppendLine($" 7.  Street: {Row}");
            sb.AppendLine($" 8.  6 Numbers: {String.Join(" | ", DoubleRow)}");
            sb.AppendLine($" 9.  Splits: {String.Join(" | ", Splits)}");
            sb.AppendLine($" 10. Corners: {String.Join(" | ", Corners)}");

            WinningBets = sb.ToString();
        }
    }

    public enum Bin : byte
    {
        Zero,
        One, Two, Three,
        Four, Five, Six,
        Seven, Eight, Nine,
        Ten, Eleven, Twelve,
        Thirteen, Fourteen, Fifteen,
        Sixteen, Seventeen, Eighteen,
        Nineteen, Twenty, TwentyOne,
        TwentyTwo, TwentyThree, TwentyFour,
        TwentyFive, TwentySix, TwentySeven,
        TwentyEight, TwentyNine, Thirty,
        ThirtyOne, ThirtyTwo, ThirthyThree,
        ThirtyFour, ThirtyFive, ThirtySix,
        ZeroZero
    }
}
