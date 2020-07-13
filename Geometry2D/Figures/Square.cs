using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry2D
{
    public class Square : Figure
    {
        private double side;
        
        public Square(double side)
        {
            this.side = side;
        }

        public override bool Equals(object obj)
        {
            return obj is Square square &&
                   side == square.side;
        }

        public override double GetArea()
        {
            return side * side;
        }

        public override int GetHashCode()
        {
            return -1721478386 + side.GetHashCode();
        }

        public override double GetPerimeter()
        {
            return side * 4;
        }

        public override string ToString()
        {
            return "Square " + side;
        }
    }
}
