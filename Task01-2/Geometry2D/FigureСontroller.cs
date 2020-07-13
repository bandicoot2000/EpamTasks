using System.Collections.Generic;

namespace Geometry2D
{
    /// <summary>
    /// Class work with array of figures.
    /// </summary>
    public class FigureСontroller
    {
        private Figure[] figures;

        /// <summary>
        /// Create FigureController and load figures from file.
        /// </summary>
        /// <param name="file">File.</param>
        public FigureСontroller(string file)
        {
            LoadFigures(file);
        }

        /// <summary>
        /// Load figures from file.
        /// </summary>
        /// <param name="file">file.</param>
        public void LoadFigures(string file)
        {
            figures = FigureLoader.LoadFigures(file);
        }

        /// <summary>
        /// Search figures in array for some figure.
        /// </summary>
        /// <param name="figure">Figure.</param>
        /// <returns>Array of figures.</returns>
        public Figure[] SearchFigure(Figure figure)
        {
            List<Figure> figures = new List<Figure>();

            for (int i = 0; i < this.figures.Length; i++)
            {
                if (figure.Equals(this.figures[i])) figures.Add(this.figures[i]);
            }

            return figures.ToArray();
        }

        /// <summary>
        /// Search figures in array for some figure.
        /// </summary>
        /// <param name="figure">Text with figure.</param>
        /// <returns>Array of figures.</returns>
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
