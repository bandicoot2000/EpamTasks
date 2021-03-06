﻿using System;

namespace Geometry2D
{
    /// <summary>
    /// A polygon whose shape has many identical sides.
    /// </summary>
    public class Polygon : Figure
    {
        private double side;
        private int amountSides;

        /// <summary>
        /// Creates a polygon based on the staron and their number.
        /// </summary>
        /// <param name="side">Size side in polygon.</param>
        /// <param name="amountSides">Number of sides in polygon.</param>
        public Polygon(double side, int amountSides)
        {
            if (amountSides < 5) throw new Exception("The number of parties must be more than four.");
            this.side = side;
            this.amountSides = amountSides;
        }

        public override bool Equals(object obj)
        {
            return obj is Polygon polygon &&
                   side == polygon.side &&
                   amountSides == polygon.amountSides;
        }

        public override double GetArea()
        {
            return side * side * amountSides / (4 * Math.Tan(Math.PI / amountSides));
        }

        public override int GetHashCode()
        {
            int hashCode = 165728977;
            hashCode = hashCode * -1521134295 + side.GetHashCode();
            hashCode = hashCode * -1521134295 + amountSides.GetHashCode();
            return hashCode;
        }

        public override double GetPerimeter()
        {
            return side * amountSides;
        }

        public override string ToString()
        {
            return "Polygon " + side + " " + amountSides;
        }
    }
}
