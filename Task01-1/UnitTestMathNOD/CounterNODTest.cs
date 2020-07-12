using System;
using System.Security.Cryptography;
using MathNOD;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestMathNOD
{
    [TestClass]
    public class CounterNODTest
    {

        private static int GCD(int numberFirst, int numberSecond)
        {
            if(numberFirst == 0)
            {
                return numberSecond;
            }
            else
            {
                int min = Math.Min(numberFirst, numberSecond);
                int max = Math.Max(numberFirst, numberSecond);
                return GCD(max % min, min);
            }
        }


        [TestMethod]
        public void GetNOD2NumberTest()
        {
            CounterNOD counterNOD = new CounterNOD(1, 1);
            for (int numberFirst = 1; numberFirst < 1000; numberFirst++)
            {
                for (int numberSecond = 1; numberSecond < 1000; numberSecond++)
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
            for (int numberFirst = 1; numberFirst < 1000; numberFirst++)
            {
                for (int numberSecond = 1; numberSecond < 1000; numberSecond++)
                {
                    for (int numberThird = 1; numberThird < 1000; numberThird++)
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
            for (int numberFirst = 1; numberFirst < 100; numberFirst++)
            {
                for (int numberSecond = 1; numberSecond < 100; numberSecond++)
                {
                    for (int numberThird = 1; numberThird < 100; numberThird++)
                    {
                        for (int numberFourth = 1; numberFourth < 100; numberFourth++)
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
            for (int numberFirst = 1; numberFirst < 50; numberFirst++)
            {
                for (int numberSecond = 1; numberSecond < 50; numberSecond++)
                {
                    for (int numberThird = 1; numberThird < 50; numberThird++)
                    {
                        for (int numberFourth = 1; numberFourth < 50; numberFourth++)
                        {
                            for (int numberFifth = 1; numberFifth < 50; numberFifth++)
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
    }
}
