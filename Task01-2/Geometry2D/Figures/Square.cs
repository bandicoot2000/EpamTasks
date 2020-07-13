namespace Geometry2D
{
    /// <summary>
    /// A square whose quadrangle is equal on all sides.
    /// </summary>
    public class Square : Figure
    {
        private double side;

        /// <summary>
        /// Creates a square by its side.
        /// </summary>
        /// <param name="side">Square side.</param>
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
