using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Square : Figure
    {
        public double Side { get; private set; }
        public Square(double side, IMaterial material) : base(material)
        {
            Side = side;
        }

        public Square(double side, Figure figure) : base(figure)
        {
            Side = side;
            if (this.GetArea() < figure.GetArea()) throw new Exception("This shape cannot be cut");
        }

        public override bool Equals(object obj)
        {
            return obj is Square square &&
                   base.Equals(obj) &&
                   Side == square.Side;
        }

        public override int GetHashCode()
        {
            int hashCode = -1080891884;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Side.GetHashCode();
            return hashCode;
        }

        public override double GetArea()
        {
            return Side * Side;
        }

        public override double GetPerimeter()
        {
            return Side * 4;
        }

        public override string ToString()
        {
            return base.ToString() + "Square: Side = " + Side;
        }
    }
}
