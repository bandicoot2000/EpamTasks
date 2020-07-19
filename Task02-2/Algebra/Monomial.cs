using System;

namespace Algebra
{
    /// <summary>
    /// class monomial.
    /// </summary>
    public class Monomial : IComparable
    {
        /// <summary>
        /// Coefficient of monomial.
        /// </summary>
        public double Coefficient { get; private set; }
        /// <summary>
        /// Degree of monomial.
        /// </summary>
        public int Degree { get; private set; }

        /// <summary>
        /// Construstor monomial.
        /// </summary>
        /// <param name="coefficient">Coefficient monomial.</param>
        /// <param name="degree">Degree monomial.</param>
        public Monomial(double coefficient = 1, int degree = 1)
        {
            Coefficient = coefficient;
            Degree = degree;
        }

        /// <summary>
        /// Sum of two monomial.
        /// </summary>
        /// <param name="monomial1">First monomial.</param>
        /// <param name="monomial2">Second monomial.</param>
        /// <returns>Sum monomial.</returns>
        public static Monomial operator +(Monomial monomial1, Monomial monomial2)
        {
            if (monomial1.Degree != monomial2.Degree) throw new Exception("Degrees of monomials do not match.");
            return new Monomial(monomial1.Coefficient + monomial2.Coefficient, monomial1.Degree);
        }

        /// <summary>
        /// Negative monomial.
        /// </summary>
        /// <param name="monomial">Monomial.</param>
        /// <returns>Negative monomial.</returns>
        public static Monomial operator -(Monomial monomial)
        {
            monomial.Coefficient *= -1;
            return monomial;
        }

        /// <summary>
        /// Composition of two monomial.
        /// </summary>
        /// <param name="monomial1">First monomial.</param>
        /// <param name="monomial2">Second monomial.</param>
        /// <returns>Result monomial.</returns>
        public static Monomial operator *(Monomial monomial1, Monomial monomial2)
        {
            return new Monomial(monomial1.Coefficient * monomial2.Coefficient, monomial1.Degree + monomial2.Degree);
        }

        /// <summary>
        /// Compere objects.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>Comparison result.</returns>
        public int CompareTo(object obj)
        {
            if (!(obj is Monomial)) throw new Exception("The object being compared is not monomial.");
            return Degree.CompareTo(((Monomial)obj).Degree);
        }

        /// <summary>
        /// Override method Equals.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>Comparison result.</returns>
        public override bool Equals(object obj)
        {
            return obj is Monomial monomial &&
                   Coefficient == monomial.Coefficient &&
                   Degree == monomial.Degree;
        }

        /// <summary>
        /// Override method GetHashCode.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            int hashCode = 676337611;
            hashCode = hashCode * -1521134295 + Coefficient.GetHashCode();
            hashCode = hashCode * -1521134295 + Degree.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Override method ToString.
        /// </summary>
        /// <returns>String monomial.</returns>
        public override string ToString()
        {
            return Coefficient.ToString("F") + "X^" + Degree;
        }
    }
}
