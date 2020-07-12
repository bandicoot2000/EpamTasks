using System;
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
        public void GetNODTest()
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
    }
}
