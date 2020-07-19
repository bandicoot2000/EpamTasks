using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algebra
{
    public class Monomial : IComparable
    {
        public double Coefficient { get; private set; }
        public uint Degree { get; private set; }

        public Monomial(double coefficient = 1, uint degree = 1)
        {
            Coefficient = coefficient;
            Degree = degree;
        }

        public static Monomial operator +(Monomial monomial1, Monomial monomial2)
        {
            if (monomial1.Degree != monomial2.Degree) throw new Exception("Degrees of monomials do not match.");
            return new Monomial(monomial1.Coefficient + monomial2.Coefficient, monomial1.Degree);
        }

        public static Monomial operator -(Monomial monomial)
        {
            monomial.Coefficient *= -1;
            return monomial;
        }

        public static Monomial operator *(Monomial monomial1, Monomial monomial2)
        {
            if (monomial1.Degree != monomial2.Degree) throw new Exception("Degrees of monomials do not match.");
            return new Monomial(monomial1.Coefficient * monomial2.Coefficient, monomial1.Degree + 1);
        }

        public int CompareTo(object obj)
        {
            if (!(obj is Monomial)) throw new Exception("The object being compared is not monomial.");
            return Degree.CompareTo(((Monomial)obj).Degree);
        }

        public override bool Equals(object obj)
        {
            return obj is Monomial monomial &&
                   Coefficient == monomial.Coefficient &&
                   Degree == monomial.Degree;
        }

        public override int GetHashCode()
        {
            int hashCode = 676337611;
            hashCode = hashCode * -1521134295 + Coefficient.GetHashCode();
            hashCode = hashCode * -1521134295 + Degree.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return Coefficient.ToString("F") + "X^" + Degree;
        }
    }
}
