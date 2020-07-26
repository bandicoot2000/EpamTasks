using System;

namespace Figures
{
    /// <summary>
    /// Abstract figure decorator. Cuts a figure out of material.
    /// </summary>
    public abstract class Figure : IMaterial, IFigure
    {
        /// <summary>
        /// Material figure.
        /// </summary>
        protected IMaterial material;

        /// <summary>
        /// Cuts new figure out of material.
        /// </summary>
        /// <param name="material">Material.</param>
        public Figure(IMaterial material)
        {
            this.material = material;
        }

        /// <summary>
        /// Cuts new figure out of figure.
        /// </summary>
        /// <param name="figure">Figure.</param>
        protected Figure(Figure figure)
        {
            material = figure.material;
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

        public string ToString(string format)
        {
            return material.ToString(format);
        }
    }
}
