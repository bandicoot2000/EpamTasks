using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry2D
{
    class FigureСontroller
    {
        Figure[] figures;

        public FigureСontroller(string file)
        {
            LoadFigures(file);
        }

        public void LoadFigures(string file)
        {
            figures = FigureLoader.LoadFigures(file);
        }

        public Figure[] SearchFigure(Figure figure)
        {
            List<Figure> figures = new List<Figure>();

            for (int i = 0; i < this.figures.Length; i++)
            {
                if (figure.Equals(this.figures[i])) figures.Add(this.figures[i]);
            }

            return figures.ToArray();
        }

        public Figure[] SearchFigure(string text)
        {
            Figure figure = FigureLoader.ParseFigure(text);
            List<Figure> figures = new List<Figure>();

            for (int i = 0; i < this.figures.Length; i++)
            {
                if (figure.Equals(this.figures[i])) figures.Add(this.figures[i]);
            }

            return figures.ToArray();
        }
    }
}
