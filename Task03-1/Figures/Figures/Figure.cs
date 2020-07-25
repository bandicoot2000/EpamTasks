using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public abstract class Figure : IMaterial, IFigure
    {
        private IMaterial material;

        public Figure(IMaterial material)
        {
            this.material = material;
        }

        protected Figure(Figure figure)
        {
            if (this.GetArea() < figure.GetArea()) throw new Exception("This shape cannot be cut");
        }

        public void PaintFigure(Color color)
        {
            if (material is Film) throw new Exception("Film cannot be painted");
            else ((Paper)material).Color = color;
        }

        public virtual double GetArea()
        {
            return -1;
        }

        public virtual double GetPerimeter()
        {
            return -1;
        }

        public IMaterial GetMaterial()
        {
            return material;
        }

        public override bool Equals(object obj)
        {
            return obj is Figure figure &&
                   material.Equals(figure.material);
        }

        public override int GetHashCode()
        {
            return -810205344 + material.GetHashCode();
        }

        public override string ToString()
        {
            return material.ToString() + " Figure ";
        }
    }
}
