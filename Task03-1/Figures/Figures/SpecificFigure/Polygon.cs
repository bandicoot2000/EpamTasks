using System;
namespace Figures
{
    /// <summary>
    /// Figure Polugon.
    /// </summary>
    public class Polygon : Figure
    {
        /// <summary>
        /// Polygone side.
        /// </summary>
        public double Side { get; private set; }
        /// <summary>
        /// Amount sides in polygone.
        /// </summary>
        public int AmountSides { get; private set; }

        /// <summary>
        /// Cuts new polygone out of material.  
        /// </summary>
        /// <param name="side">Side.</param>
        /// <param name="amountSides">Amount sides.</param>
        /// <param name="material">Material.</param>
        public Polygon(double side, int amountSides, IMaterial material) : base(material)
        {
            if (amountSides < 5) throw new Exception("The number of parties must be more than four.");
            Side = side;
            AmountSides = amountSides;
        }

        /// <summary>
        /// Cuts new polygone out of fiure.  
        /// </summary>
        /// <param name="side">Side.</param>
        /// <param name="amountSides">Amount sides.</param>
        /// <param name="figure">Figure.</param>
        public Polygon(double side, int amountSides, Figure figure) : base(figure)
        {
            if (amountSides < 5) throw new Exception("The number of parties must be more than four.");
            Side = side;
            AmountSides = amountSides;
            if (this.GetArea() < figure.GetArea()) throw new Exception("This shape cannot be cut");
        }

        public override bool Equals(object obj)
        {
            return obj is Polygon polygon &&
                   base.Equals(obj) &&
                   Side == polygon.Side &&
                   AmountSides == polygon.AmountSides;
        }


        public override int GetHashCode()
        {
            int hashCode = 1621643095;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Side.GetHashCode();
            hashCode = hashCode * -1521134295 + AmountSides.GetHashCode();
            return hashCode;
        }
        public override double GetArea()
        {
            return Side * Side * AmountSides / (4 * Math.Tan(Math.PI / AmountSides));
        }

        public override double GetPerimeter()
        {
            return Side * AmountSides;
        }

        public override string ToString()
        {
            return base.ToString() + "Polygon: Side = " + Side + ", AmountSides = " + AmountSides;
        }
    }
}
