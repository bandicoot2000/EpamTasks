using System;
using System.Security.Cryptography;
using MathNOD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestMathNOD
{
    [TestClass]
    public class CounterNODTest
    {

        private static uint GCD(uint numberFirst, uint numberSecond)
        {
            if(numberFirst == 0)
            {
                return numberSecond;
            }
            else
            {
                uint min = Math.Min(numberFirst, numberSecond);
                uint max = Math.Max(numberFirst, numberSecond);
                return GCD(max % min, min);
            }
        }


        [TestMethod]
        public void GetNOD2NumberTest()
        {
            CounterNOD counterNOD = new CounterNOD(1, 1);
            for (uint numberFirst = 1; numberFirst < 1000; numberFirst++)
            {
                for (uint numberSecond = 1; numberSecond < 1000; numberSecond++)
                {
                    counterNOD.NumberFirst = numberFirst;
                    counterNOD.NumberSecond = numberSecond;
                    Assert.AreEqual(GCD(numberFirst, numberSecond), counterNOD.GetNOD());
                }
            }
        }

        [TestMethod]
        public void GetNOD3NumberTest()
        {
            CounterNOD counterNOD = new CounterNOD(1, 1);
            for (uint numberFirst = 1; numberFirst < 100; numberFirst++)
            {
                for (uint numberSecond = 1; numberSecond < 100; numberSecond++)
                {
                    for (uint numberThird = 1; numberThird < 100; numberThird++)
                    {
                        counterNOD.NumberFirst = numberFirst;
                        counterNOD.NumberSecond = numberSecond;
                        Assert.AreEqual(GCD(GCD(numberFirst, numberSecond), numberThird), counterNOD.GetNOD(numberThird));
                    }
                }
            }
        }

        [TestMethod]
        public void GetNOD4NumberTest()
        {
            CounterNOD counterNOD = new CounterNOD(1, 1);
            for (uint numberFirst = 1; numberFirst < 90; numberFirst++)
            {
                for (uint numberSecond = 1; numberSecond < 90; numberSecond++)
                {
                    for (uint numberThird = 1; numberThird < 90; numberThird++)
                    {
                        for (uint numberFourth = 1; numberFourth < 90; numberFourth++)
                        {
                            counterNOD.NumberFirst = numberFirst;
                            counterNOD.NumberSecond = numberSecond;
                            Assert.AreEqual(GCD(GCD(GCD(numberFirst, numberSecond), numberThird), numberFourth), 
                                counterNOD.GetNOD(numberThird, numberFourth));
                        }
                    }
                }
            }
        }

        [TestMethod]
        public void GetNOD5NumberTest()
        {
            CounterNOD counterNOD = new CounterNOD(1, 1);
            for (uint numberFirst = 1; numberFirst < 40; numberFirst++)
            {
                for (uint numberSecond = 1; numberSecond < 40; numberSecond++)
                {
                    for (uint numberThird = 1; numberThird < 40; numberThird++)
                    {
                        for (uint numberFourth = 1; numberFourth < 40; numberFourth++)
                        {
                            for (uint numberFifth = 1; numberFifth < 40; numberFifth++)
                            {
                                counterNOD.NumberFirst = numberFirst;
                                counterNOD.NumberSecond = numberSecond;
                                Assert.AreEqual(GCD(GCD(GCD(GCD(numberFirst, numberSecond), numberThird), numberFourth), numberFifth),
                                    counterNOD.GetNOD(numberThird, numberFourth, numberFifth));
                            }
                        }
                    }
                }
            }
        }


        [TestMethod]
        public void GetNOD2NumberWithTimerTest()
        {
            CounterNOD counterNOD = new CounterNOD(1, 1);
            for (uint numberFirst = 1; numberFirst < 1000; numberFirst++)
            {
                for (uint numberSecond = 1; numberSecond < 1000; numberSecond++)
                {
                    counterNOD.NumberFirst = numberFirst;
                    counterNOD.NumberSecond = numberSecond;
                    long time;
                    Assert.AreEqual(GCD(numberFirst, numberSecond), counterNOD.GetNOD(out time));
                }
            }
        }

        [TestMethod]
        public void GetNODSteinTest()
        {
            CounterNOD counterNOD = new CounterNOD(1, 1);
            for (uint numberFirst = 1; numberFirst < 1000; numberFirst++)
            {
                for (uint numberSecond = 1; numberSecond < 1000; numberSecond++)
                {
                    counterNOD.NumberFirst = numberFirst;
                    counterNOD.NumberSecond = numberSecond;
                    long time;
                    Assert.AreEqual(GCD(numberFirst, numberSecond), counterNOD.GetNODStein(out time));
                }
            }
        }

    }
}
