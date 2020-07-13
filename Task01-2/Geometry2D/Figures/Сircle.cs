using System;

namespace Geometry2D
{
    public class Сircle : Figure
    {
        protected double radius;

        public Сircle(double radius)
        {
            this.radius = radius;
        }

        public override bool Equals(object obj)
        {
            return obj is Сircle сircle &&
                   radius == сircle.radius;
        }

        public override double GetArea()
        {
            return Math.PI * radius * radius;
        }

        public override int GetHashCode()
        {
            return -457394261 + radius.GetHashCode();
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public override string ToString()
        {
            return "Circle " + radius;
        }
    }
}
