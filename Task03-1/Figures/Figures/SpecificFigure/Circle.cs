using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Circle : Figure
    {
        public double Radius { get; private set; }

        public Circle(double radius, IMaterial material) : base(material)
        {
            Radius = radius;
        }

        public Circle(double radius, Figure figure) : base(figure)
        {
            Radius = radius;
            if (this.GetArea() < figure.GetArea()) throw new Exception("This shape cannot be cut");
        }

        public override double GetArea()
        {
            return Math.PI * Radius * Radius;
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * Radius;
        }

        public override bool Equals(object obj)
        {
            return obj is Circle circle &&
                   base.Equals(obj) &&
                   Radius == circle.Radius;
        }

        public override int GetHashCode()
        {
            int hashCode = 1605559401;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Radius.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return base.ToString() + "Circle: Radius = " + Radius;
        }
    }
}
