using Microsoft.VisualStudio.TestTools.UnitTesting;
using Roulette;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette.Tests
{
    [TestClass()]
    public class RouletteNumberTests
    {
        [TestMethod()]
        public void RouletteNumberTest()
        {
            // test Zero 
            var ott = new RouletteNumber(Bin.Zero);
            Assert.AreEqual("0", ott.ToString());

            // test ZeroZero 
            ott = new RouletteNumber(Bin.ZeroZero);
            Assert.AreEqual("00", ott.ToString());

            // test top left corner
            {
                ott = new RouletteNumber(Bin.One);
                Assert.AreEqual("1", ott.ToString());
                Assert.AreEqual("Odd", ott.EvenOdd);
                Assert.AreEqual("Red", ott.Color);
                Assert.AreEqual("Low (1 - 18)", ott.LowHigh);
                Assert.AreEqual("1st 12 (1 - 12)", ott.Dozen);
                Assert.AreEqual("1st Column", ott.Column);
                Assert.AreEqual("1/2/3", ott.Row);
                CollectionAssert.AreEquivalent(new string[] { "1/2/3/4/5/6" }, ott.DoubleRow);
                CollectionAssert.AreEquivalent(new string[] { "1/2", "1/4" }, ott.Splits);
                CollectionAssert.AreEquivalent(new string[] { "1/2/4/5" }, ott.Corners);
            }

            // test top middle
            {
                ott = new RouletteNumber(Bin.Two);
                Assert.AreEqual("2", ott.ToString());
                Assert.AreEqual("Even", ott.EvenOdd);
                Assert.AreEqual("Black", ott.Color);
                Assert.AreEqual("Low (1 - 18)", ott.LowHigh);
                Assert.AreEqual("1st 12 (1 - 12)", ott.Dozen);
                Assert.AreEqual("2nd Column", ott.Column);
                Assert.AreEqual("1/2/3", ott.Row);
                CollectionAssert.AreEquivalent(new string[] { "1/2/3/4/5/6" }, ott.DoubleRow);
                CollectionAssert.AreEquivalent(new string[] { "1/2", "2/3", "2/5" }, ott.Splits);
                CollectionAssert.AreEquivalent(new string[] { "1/2/4/5", "2/3/5/6" }, ott.Corners);
            }

            // test top right corner
            {
                ott = new RouletteNumber(Bin.Three);
                Assert.AreEqual("3", ott.ToString());
                Assert.AreEqual("Odd", ott.EvenOdd);
                Assert.AreEqual("Red", ott.Color);
                Assert.AreEqual("Low (1 - 18)", ott.LowHigh);
                Assert.AreEqual("1st 12 (1 - 12)", ott.Dozen);
                Assert.AreEqual("3rd Column", ott.Column);
                Assert.AreEqual("1/2/3", ott.Row);
                CollectionAssert.AreEquivalent(new string[] { "1/2/3/4/5/6" }, ott.DoubleRow);
                CollectionAssert.AreEquivalent(new string[] { "2/3", "3/6" }, ott.Splits);
                CollectionAssert.AreEquivalent(new string[] { "2/3/5/6" }, ott.Corners);
            }

            // test middle Left
            {
                ott = new RouletteNumber(Bin.Thirteen);
                Assert.AreEqual("13", ott.ToString());
                Assert.AreEqual("Odd", ott.EvenOdd);
                Assert.AreEqual("Black", ott.Color);
                Assert.AreEqual("Low (1 - 18)", ott.LowHigh);
                Assert.AreEqual("2nd 12 (13 - 24)", ott.Dozen);
                Assert.AreEqual("1st Column", ott.Column);
                Assert.AreEqual("13/14/15", ott.Row);
                CollectionAssert.AreEquivalent(new string[] { "10/11/12/13/14/15", "13/14/15/16/17/18" }, ott.DoubleRow);
                CollectionAssert.AreEquivalent(new string[] { "10/13", "13/14", "13/16" }, ott.Splits);
                CollectionAssert.AreEquivalent(new string[] { "10/11/13/14", "13/14/16/17" }, ott.Corners);
            }

            // test middle middle
            {
                ott = new RouletteNumber(Bin.Twenty);
                Assert.AreEqual("20", ott.ToString());
                Assert.AreEqual("Even", ott.EvenOdd);
                Assert.AreEqual("Black", ott.Color);
                Assert.AreEqual("High (19 - 36)", ott.LowHigh);
                Assert.AreEqual("2nd 12 (13 - 24)", ott.Dozen);
                Assert.AreEqual("2nd Column", ott.Column);
                Assert.AreEqual("19/20/21", ott.Row);
                CollectionAssert.AreEquivalent(new string[] { "16/17/18/19/20/21", "19/20/21/22/23/24" }, ott.DoubleRow);
                CollectionAssert.AreEquivalent(new string[] { "17/20", "19/20", "20/21", "20/23" }, ott.Splits);
                CollectionAssert.AreEquivalent(new string[] { "16/17/19/20", "17/18/20/21", "19/20/22/23", "20/21/23/24" }, ott.Corners);
            }

            // test bottom right
            {
                ott = new RouletteNumber(Bin.ThirtySix);
                Assert.AreEqual("36", ott.ToString());
                Assert.AreEqual("Even", ott.EvenOdd);
                Assert.AreEqual("Red", ott.Color);
                Assert.AreEqual("High (19 - 36)", ott.LowHigh);
                Assert.AreEqual("3rd 12 (25 - 36)", ott.Dozen);
                Assert.AreEqual("3rd Column", ott.Column);
                Assert.AreEqual("34/35/36", ott.Row);
                CollectionAssert.AreEquivalent(new string[] { "31/32/33/34/35/36" }, ott.DoubleRow);
                CollectionAssert.AreEquivalent(new string[] { "33/36", "35/36" }, ott.Splits);
                CollectionAssert.AreEquivalent(new string[] { "32/33/35/36" }, ott.Corners);
            }
        }
    }
}