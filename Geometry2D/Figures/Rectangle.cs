using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry2D
{
    public class Rectangle : Figure
    {
        private double length;
        private double width;

        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }

        public override bool Equals(object obj)
        {
            return obj is Rectangle rectangle &&
                   length == rectangle.length &&
                   width == rectangle.width;
        }

        public override double GetArea()
        {
            return length * width;
        }

        public override int GetHashCode()
        {
            int hashCode = 1372459132;
            hashCode = hashCode * -1521134295 + length.GetHashCode();
            hashCode = hashCode * -1521134295 + width.GetHashCode();
            return hashCode;
        }

        public override double GetPerimeter()
        {
            return length * 2 + width * 2;
        }

        public override string ToString()
        {
            return "Rectangle " + length + " " + width;
        }
    }
}
