using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algebra;

namespace UnitTestAlgebra
{
    [TestClass]
    public  class UnitTestPolynomial
    {
        [TestMethod]
        public void PolynomialSumTest1()
        {
            Monomial[] monomials_1 = {
                new Monomial(),
            };

            Monomial[] monomials_2 = {
                new Monomial(),
            };

            Monomial[] monomials_3 = {
                new Monomial(2),
            };

            Polynomial polynomial_1 = new Polynomial(monomials_1);
            Polynomial polynomial_2 = new Polynomial(monomials_2);

            Assert.AreEqual(new Polynomial(monomials_3), polynomial_1 + polynomial_2);
        }

        [TestMethod]
        public void PolynomialSumTest2()
        {
            Monomial[] monomials_1 = {
                new Monomial(2, 2),
                new Monomial(-1, 3),
            };

            Monomial[] monomials_2 = {
                new Monomial(9),
                new Monomial(2, 2),
                new Monomial(-1, 4),
                new Monomial(8,0)
            };

            Monomial[] monomials_3 = {
                new Monomial(9),
                new Monomial(4, 2),
                new Monomial(-1, 3),
                new Monomial(-1, 4),
                new Monomial(8,0)
            };

            Polynomial polynomial_1 = new Polynomial(monomials_1);
            Polynomial polynomial_2 = new Polynomial(monomials_2);

            Assert.AreEqual(new Polynomial(monomials_3), polynomial_1 + polynomial_2);
        }

        [TestMethod]
        public void PolynomialSumTest3()
        {
            Monomial[] monomials_1 = {
                new Monomial(-6),
                new Monomial(2, 2),
                new Monomial(-1, 3),
            };

            Monomial[] monomials_2 = {
                new Monomial(-1, 3),
                new Monomial(9),
                new Monomial(2, 2),
            };

            Monomial[] monomials_3 = {
                new Monomial(3),
                new Monomial(4, 2),
                new Monomial(-2, 3),
            };

            Polynomial polynomial_1 = new Polynomial(monomials_1);
            Polynomial polynomial_2 = new Polynomial(monomials_2);

            Assert.AreEqual(new Polynomial(monomials_3), polynomial_1 + polynomial_2);
        }

        [TestMethod]
        public void PolynomialDefTest1()
        {
            Monomial[] monomials_1 = {
                new Monomial(),
            };

            Monomial[] monomials_2 = {
                new Monomial(),
            };

            Monomial[] monomials_3 = {
                new Monomial(0),
            };

            Polynomial polynomial_1 = new Polynomial(monomials_1);
            Polynomial polynomial_2 = new Polynomial(monomials_2);

            Assert.AreEqual(new Polynomial(monomials_3), polynomial_1 - polynomial_2);
        }

        [TestMethod]
        public void PolynomialDefTest2()
        {
            Monomial[] monomials_1 = {
                new Monomial(2, 2),
                new Monomial(-1, 3),
            };

            Monomial[] monomials_2 = {
                new Monomial(9),
                new Monomial(2, 2),
                new Monomial(-1, 4),
                new Monomial(8,0)
            };

            Monomial[] monomials_3 = {
                new Monomial(-9),
                new Monomial(0, 2),
                new Monomial(-1, 3),
                new Monomial(1, 4),
                new Monomial(-8,0)
            };

            Polynomial polynomial_1 = new Polynomial(monomials_1);
            Polynomial polynomial_2 = new Polynomial(monomials_2);

            Assert.AreEqual(new Polynomial(monomials_3), polynomial_1 - polynomial_2);
        }

        [TestMethod]
        public void PolynomialDefTest3()
        {
            Monomial[] monomials_1 = {
                new Monomial(-6),
                new Monomial(2, 2),
                new Monomial(-1, 3),
            };

            Monomial[] monomials_2 = {
                new Monomial(-1, 3),
                new Monomial(9),
                new Monomial(2, 2),
            };

            Monomial[] monomials_3 = {
                new Monomial(-15),
                new Monomial(0, 2),
                new Monomial(0, 3),
            };

            Polynomial polynomial_1 = new Polynomial(monomials_1);
            Polynomial polynomial_2 = new Polynomial(monomials_2);

            Assert.AreEqual(new Polynomial(monomials_3), polynomial_1 - polynomial_2);
        }

        [TestMethod]
        public void PolynomialComTest1()
        {
            Monomial[] monomials_1 = {
                new Monomial(),
            };

            Monomial[] monomials_2 = {
                new Monomial(),
            };

            Monomial[] monomials_3 = {
                new Monomial(1,2),
            };

            Polynomial polynomial_1 = new Polynomial(monomials_1);
            Polynomial polynomial_2 = new Polynomial(monomials_2);

            Assert.AreEqual(new Polynomial(monomials_3), polynomial_1 * polynomial_2);
        }

        [TestMethod]
        public void PolynomialComTest2()
        {
            Monomial[] monomials_1 = {
                new Monomial(2, 2),
                new Monomial(-1, 3),
            };

            Monomial[] monomials_2 = {
                new Monomial(9),
                new Monomial(2, 2),
                new Monomial(-1, 4),
                new Monomial(8,0)
            };

            Monomial[] monomials_3 = {
                new Monomial(16, 2),
                new Monomial(10, 3),
                new Monomial(-5, 4),
                new Monomial(-2, 5),
                new Monomial(-2, 6),
                new Monomial(1, 7),
            };

            Polynomial polynomial_1 = new Polynomial(monomials_1);
            Polynomial polynomial_2 = new Polynomial(monomials_2);

            Assert.AreEqual(new Polynomial(monomials_3), polynomial_1 * polynomial_2);
        }

        [TestMethod]
        public void PolynomialComTest3()
        {
            Monomial[] monomials_1 = {
                new Monomial(-6),
                new Monomial(2, 2),
            };

            Monomial[] monomials_2 = {
                new Monomial(9),
                new Monomial(2, 2),
            };

            Monomial[] monomials_3 = {
                new Monomial(-54, 2),
                new Monomial(6, 3),
                new Monomial(4, 4),
            };

            Polynomial polynomial_1 = new Polynomial(monomials_1);
            Polynomial polynomial_2 = new Polynomial(monomials_2);

            Assert.AreEqual(new Polynomial(monomials_3), polynomial_1 * polynomial_2);
        }
    }
}
