using System;

namespace Figures
{
    /// <summary>
    /// Figure rectangle.
    /// </summary>
    public class Rectangle : Figure
    {
        /// <summary>
        /// Length rectangle.
        /// </summary>
        public double Length { get; private set; }
        /// <summary>
        /// Width rectangle.
        /// </summary>
        public double Width { get; private set; }

        /// <summary>
        /// Cuts new rectangle out of material.  
        /// </summary>
        /// <param name="length">Length.</param>
        /// <param name="width">Width.</param>
        /// <param name="material">Material.</param>
        public Rectangle(double length, double width, IMaterial material) : base(material)
        {
            Length = length;
            Width = width;
        }

        /// <summary>
        /// Cuts new rectangle out of figure.  
        /// </summary>
        /// <param name="length">Length.</param>
        /// <param name="width">Width.</param>
        /// <param name="figure">Figure.</param>
        public Rectangle(double length, double width, Figure figure) : base(figure)
        {
            Length = length;
            Width = width;
            if (this.GetArea() > figure.GetArea()) throw new Exception("This shape cannot be cut");
        }

        public override bool Equals(object obj)
        {
            return obj is Rectangle rectangle &&
                   base.Equals(obj) &&
                   Length == rectangle.Length &&
                   Width == rectangle.Width;
        }

        public override int GetHashCode()
        {
            int hashCode = -704574910;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Length.GetHashCode();
            hashCode = hashCode * -1521134295 + Width.GetHashCode();
            return hashCode;
        }

        public override double GetPerimeter()
        {
            return Length * 2 + Width * 2;
        }

        public override double GetArea()
        {
            return Length * Width;
        }

        public override string ToString()
        {
            return base.ToString() + "Rectangle: Length = " + Length + ", Width = " + Width;
        }
    }
}
