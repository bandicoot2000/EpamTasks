using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algebra
{
    /// <summary>
    /// Class polynomial.
    /// </summary>
    public class Polynomial
    {
        List<Monomial> monomials;

        /// <summary>
        /// Construstor polynomial.
        /// </summary>
        /// <param name="monomials">Monomials.</param>
        public Polynomial(params Monomial[] monomials)
        {
            this.monomials = new List<Monomial>();
            this.monomials.AddRange(monomials);
            Addition();
        }


        /// <summary>
        /// The sum of two polynomial.
        /// </summary>
        /// <param name="polynomial1">First polynomial.</param>
        /// <param name="polynomial2">Second polynomial.</param>
        /// <returns>Result polynomial.</returns>
        public static Polynomial operator +(Polynomial polynomial1, Polynomial polynomial2)
        {
            List<Monomial> monomials = new List<Monomial>();
            monomials.AddRange(polynomial1.monomials);
            monomials.AddRange(polynomial2.monomials);
            Polynomial polynomial = new Polynomial(monomials.ToArray());
            polynomial.Addition();
            return polynomial;
        }

        /// <summary>
        /// Difference of two polynomial.
        /// </summary>
        /// <param name="polynomial1">First polynomial.</param>
        /// <param name="polynomial2">Second polynomial.</param>
        /// <returns>Result polynomial.</returns>
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

        /// <summary>
        /// Composition of two polynomial.
        /// </summary>
        /// <param name="polynomial1">First polynomial.</param>
        /// <param name="polynomial2">Second polynomial.</param>
        /// <returns>Result polynomial.</returns>
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

        /// <summary>
        /// Override method Equals.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>Comparison result.</returns>
        public override bool Equals(object obj)
        {
            return obj is Polynomial polynomial &&
                   EqualityComparer<List<Monomial>>.Default.Equals(monomials, polynomial.monomials);
        }

        /// <summary>
        /// Override method GetHashCode.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            return 546032158 + EqualityComparer<List<Monomial>>.Default.GetHashCode(monomials);
        }

        /// <summary>
        /// Override method ToString.
        /// </summary>
        /// <returns>String monomial.</returns>
        public override string ToString()
        {
            string result = "";
            foreach (Monomial monomial in monomials)
            {
                result += monomial.ToString() + " ";
            }
            return result;
        }
    }
}
