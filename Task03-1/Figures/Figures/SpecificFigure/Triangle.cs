using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Triangle : Figure
    {
        public double SideA { get; private set; }
        public double SideB { get; private set; }
        public double SideC { get; private set; }

        public Triangle(double sideA, double sideB, double sideC, IMaterial material) : base(material)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        public Triangle(double sideA, double sideB, double sideC, Figure figure) : base(figure)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
            if (this.GetArea() < figure.GetArea()) throw new Exception("This shape cannot be cut");
        }

        public override double GetArea()
        {
            double halfPerimeter = GetPerimeter() / 2;
            return Math.Sqrt(halfPerimeter * (halfPerimeter - SideA) * (halfPerimeter - SideB) * (halfPerimeter - SideC));
        }

        public override double GetPerimeter()
        {
            return SideA + SideB + SideC;
        }

        public override bool Equals(object obj)
        {
            return obj is Triangle triangle &&
                   base.Equals(obj) &&
                   SideA == triangle.SideA &&
                   SideB == triangle.SideB &&
                   SideC == triangle.SideC;
        }

        public override int GetHashCode()
        {
            int hashCode = 791833358;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + SideA.GetHashCode();
            hashCode = hashCode * -1521134295 + SideB.GetHashCode();
            hashCode = hashCode * -1521134295 + SideC.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return base.ToString() + "Triangle: SideA = " + SideA + ", SideB = " + SideB +
                ", SideC = " + SideC;
        }
    }
}
