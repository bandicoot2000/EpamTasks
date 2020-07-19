using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algebra
{
    class Polynomial
    {
        List<Monomial> monomials;

        public Polynomial(params Monomial[] monomials)
        {
            this.monomials = new List<Monomial>();
            this.monomials.AddRange(monomials);
            Addition();
        }

        public static Polynomial operator +(Polynomial polynomial1, Polynomial polynomial2)
        {
            List<Monomial> monomials = new List<Monomial>();
            monomials.AddRange(polynomial1.monomials);
            monomials.AddRange(polynomial2.monomials);
            Polynomial polynomial = new Polynomial(monomials.ToArray());
            polynomial.Addition();
            return polynomial;
        }

        public static Polynomial operator -(Polynomial polynomial1, Polynomial polynomial2)
        {
            for (int i = 0; i < polynomial2.monomials.Count; i++)
            {
                Monomial monomial = -polynomial2.monomials.ElementAt(i);
                polynomial2.monomials.RemoveAt(i);
                polynomial2.monomials.Insert(i, monomial);
            }
            return polynomial1 + polynomial2;
        }

        public static Polynomial operator *(Polynomial polynomial1, Polynomial polynomial2)
        {
            List<Monomial> monomials = new List<Monomial>();
            foreach (Monomial monomial1 in polynomial1.monomials)
            {
                foreach (Monomial monomial2 in polynomial2.monomials)
                {
                    monomials.Add(monomial1 * monomial2);
                }
            }
            Polynomial polynomial = new Polynomial(monomials.ToArray());
            polynomial.Addition();
            return polynomial;
        }

        private void Addition()
        {
            monomials.Sort();
            for (int i = 0; i < monomials.Count - 1; i++)
            {
                if(monomials.ElementAt(i).Degree == monomials.ElementAt(i+1).Degree)
                {
                    Monomial monomial = monomials.ElementAt(i) + monomials.ElementAt(i + 1);
                    monomials.RemoveAt(i+1);
                    monomials.RemoveAt(i);
                    monomials.Insert(i, monomial);
                    i--;
                }
            }
        }

    }
}
