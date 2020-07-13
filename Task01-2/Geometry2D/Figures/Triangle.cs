using System;

namespace Geometry2D
{
    public class Triangle : Figure
    {
        private double sideA;
        private double sideB;
        private double sideC;

        public Triangle(double sideA, double sideB, double sideC)
        {
            if (sideA >= sideB + sideC ||
                sideB >= sideA + sideC ||
                sideC >= sideA + sideB)
                throw new Exception("Such triangle not exist");

            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
        }

        public override bool Equals(object obj)
        {
            return obj is Triangle triangle &&
                   sideA == triangle.sideA &&
                   sideB == triangle.sideB &&
                   sideC == triangle.sideC;
        }

        public override double GetArea()
        {
            double halfPerimeter = GetPerimeter() / 2;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter - sideC));
        }

        public override int GetHashCode()
        {
            int hashCode = 2087084792;
            hashCode = hashCode * -1521134295 + sideA.GetHashCode();
            hashCode = hashCode * -1521134295 + sideB.GetHashCode();
            hashCode = hashCode * -1521134295 + sideC.GetHashCode();
            return hashCode;
        }

        public override double GetPerimeter()
        {
            return sideA + sideB + sideC; 
        }

        public override string ToString()
        {
            return "Triangle " + sideA + " " + sideB + " " + sideC;
        }
    }
}
