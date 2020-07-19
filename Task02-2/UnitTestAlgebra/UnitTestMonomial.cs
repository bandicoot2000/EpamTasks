using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algebra;

namespace UnitTestAlgebra
{
    [TestClass]
    public class UnitTestMonomial
    {
        [TestMethod]
        public void MonomialSumTest()
        {
            Monomial monomial_1;
            Monomial monomial_2;
            for (int coefficient1 = -200; coefficient1 < 200; coefficient1++)
            {
                for (int coefficient2 = -200; coefficient2 < 200; coefficient2++)
                {
                    monomial_1 = new Monomial(coefficient1);
                    monomial_2 = new Monomial(coefficient2);
                    Assert.AreEqual(new Monomial(coefficient1 + coefficient2), monomial_1 + monomial_2);
                }
            }
        }

        [TestMethod]
        public void MonomialMonomialTest()
        {
            Monomial monomial_1;
            Monomial monomial_2;
            for (int coefficient1 = -20; coefficient1 < 20; coefficient1++)
            {
                for (int coefficient2 = -20; coefficient2 < 20; coefficient2++)
                {
                    for (int degree1 = -10; degree1 < 10; degree1++)
                    {
                        for (int degree2 = -10; degree2 < 10; degree2++)
                        {
                            monomial_1 = new Monomial(coefficient1, degree1);
                            monomial_2 = new Monomial(coefficient2, degree2);
                            Assert.AreEqual(new Monomial(coefficient1 * coefficient2, degree1 + degree2), monomial_1 * monomial_2);
                        }
                    }   
                }
            }
        }

        [TestMethod]
        public void MonomialNegativeTest()
        {
            Monomial monomial_1;
            for (int coefficient1 = -2000; coefficient1 < 2000; coefficient1++)
            {
                monomial_1 = new Monomial(coefficient1);
                Assert.AreEqual(new Monomial(-coefficient1), -monomial_1);
            }
        }
    }
}
