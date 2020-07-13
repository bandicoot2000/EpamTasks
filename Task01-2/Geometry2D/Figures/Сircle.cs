using System;

namespace Geometry2D
{
    /// <summary>
    /// The circle, all points of the figure are at a certain distance from the center of the figure.
    /// </summary>
    public class Сircle : Figure
    {
        /// <summary>
        /// Circle radius.
        /// </summary>
        protected double radius;

        /// <summary>
        /// Creates a circle along its radius.
        /// </summary>
        /// <param name="radius">Circle radius.</param>
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
