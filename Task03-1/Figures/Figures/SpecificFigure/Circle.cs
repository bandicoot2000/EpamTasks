using System;

namespace Figures
{
    /// <summary>
    /// Figure circle.
    /// </summary>
    public class Circle : Figure
    {
        /// <summary>
        /// Radius circle.
        /// </summary>
        public double Radius { get; private set; }

        /// <summary>
        /// Cuts new circle out of material. 
        /// </summary>
        /// <param name="radius">Radius.</param>
        /// <param name="material">Material.</param>
        public Circle(double radius, IMaterial material) : base(material)
        {
            Radius = radius;
        }

        /// <summary>
        /// Cuts new circle out of figure.
        /// </summary>
        /// <param name="radius">Radius.</param>
        /// <param name="figure">Figure.</param>
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
