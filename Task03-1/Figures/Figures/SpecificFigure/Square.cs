using System;
namespace Figures
{
    /// <summary>
    /// Figure square.
    /// </summary>
    public class Square : Figure
    {
        /// <summary>
        /// Square side.
        /// </summary>
        public double Side { get; private set; }

        /// <summary>
        /// Cuts new square out of material.  
        /// </summary>
        /// <param name="side">Side.</param>
        /// <param name="material">Material.</param>
        public Square(double side, IMaterial material) : base(material)
        {
            Side = side;
        }

        /// <summary>
        /// Cuts new square out of figure.  
        /// </summary>
        /// <param name="side">Side.</param>
        /// <param name="figure">Figure.</param>
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
