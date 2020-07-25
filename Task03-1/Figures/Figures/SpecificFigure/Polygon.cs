using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Polygon : Figure
    {
        public double Side { get; private set; }
        public int AmountSides { get; private set; }

        public Polygon(double side, int amountSides, IMaterial material) : base(material)
        {
            if (amountSides < 5) throw new Exception("The number of parties must be more than four.");
            Side = side;
            AmountSides = amountSides;
        }

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
