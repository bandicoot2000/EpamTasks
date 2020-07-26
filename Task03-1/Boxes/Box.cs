using System;
using System.Collections.Generic;
using Figures;
using XMLFigures;

namespace Boxes
{
    /// <summary>
    /// Box with 20 figures.
    /// </summary>
    public class Box
    {
        private IMaterial[] figures;
        private XmlFiguresWorker XmlFiguresWorker;

        public Box(string file = null)
        {
            figures = new IMaterial[20];
            if(file != null) XmlFiguresWorker = new XmlFiguresWorker(file);
                else XmlFiguresWorker = new XmlFiguresWorker();
        }

        /// <summary>
        /// Add new figure.
        /// </summary>
        /// <param name="figure">Figure.</param>
        public void AddFigure(Figure figure)
        {
            int i = 0;
            while (figures[i] != null)
            {
                if (figures[i].Equals(figure)) throw new Exception("Such a figure already exists");
                if (i == figures.Length) throw new Exception("The box is full");
            }
            figures[i] = figure;
        }

        /// <summary>
        /// Look figure in box.
        /// </summary>
        /// <param name="index">Index figure.</param>
        /// <returns>Figure.</returns>
        public Figure LookFigure(int index)
        {
            return figures[index] == null ? null : (Figure)figures[index];
        }

        /// <summary>
        /// Extract figure from box.
        /// </summary>
        /// <param name="index">Index figure.</param>
        /// <returns>Figure.</returns>
        public Figure ExtractFigure(int index)
        {
            Figure figure = LookFigure(index);
            figures[index] = null;
            return figure;
        }

        /// <summary>
        /// Replace figures in box.
        /// </summary>
        /// <param name="figure">Figure.</param>
        /// <param name="index">Index figure.</param>
        public void Replace(Figure figure, int index)
        {
            figures[index] = figure;
        }

        /// <summary>
        /// Find figure in box.
        /// </summary>
        /// <param name="figure">Figure.</param>
        /// <returns>Figure.</returns>
        public int FindFigure(Figure figure)
        {
            for (int i = 0; i < figures.Length; i++)
            {
                if (figures[i] != null && figures[i].Equals(figure)) return i;
            }
            return -1;
        }

        /// <summary>
        /// Count figures in box.
        /// </summary>
        /// <returns>Count figures.</returns>
        public int CountFigures()
        {
            int result = 0;
            for (int i = 0; i < figures.Length; i++)
            {
                if (figures[i] != null) result++;
            }
            return result;
        }

        /// <summary>
        /// Calculation total perimeter figures.
        /// </summary>
        /// <returns>Tatal perimeter.</returns>
        public double GetTotalArea()
        {
            double result = 0;
            for (int i = 0; i < figures.Length; i++)
            {
                if (figures[i] != null) result += ((Figure)figures[i]).GetArea();
            }
            return result;
        }

        /// <summary>
        /// Calculation total area figures.
        /// </summary>
        /// <returns>Total area.</returns>
        public double GetTotalPerimeter()
        {
            double result = 0;
            for (int i = 0; i<figures.Length; i++)
            {
                if (figures[i] != null) result += ((Figure) figures[i]).GetPerimeter();
            }
            return result;
        }

        /// <summary>
        /// Get all circle in box.
        /// </summary>
        /// <returns>Circles.</returns>
        public Circle[] GetAllCircles()
        {
            List<Circle> circles = new List<Circle>();
            for (int i = 0; i < figures.Length; i++)
            {
                if(figures[i] != null && figures[i] is Circle)
                {
                    circles.Add((Circle)figures[i]);
                    figures[i] = null;
                }    
            }
            return circles.ToArray();
        }

        /// <summary>
        /// Get all film figures.
        /// </summary>
        /// <returns>Film figures.</returns>
        public Figure[] GetAllFilmFigures()
        {
            List<Figure> figures = new List<Figure>();
            for (int i = 0; i < this.figures.Length; i++)
            {
                if (this.figures[i] != null && ((Figure)this.figures[i]).GetMaterial() is Film)
                {
                    figures.Add((Figure)this.figures[i]);
                    figures[i] = null;
                }
            }
            return figures.ToArray();
        }


        private Figure[] GetAllFigures()
        {
            List<Figure> figures = new List<Figure>();
            for (int i = 0; i < this.figures.Length; i++)
            {
                if (this.figures[i] != null) figures.Add((Figure)this.figures[i]);
            }
            return figures.ToArray();
        }

        /// <summary>
        /// Save all figures xmlWriter.
        /// </summary>
        public void SaveAllFiguresXml()
        {
            XmlFiguresWorker.XmlFiguresWrite(GetAllFigures());
        }

        /// <summary>
        /// Save film figures xmlWriter.
        /// </summary>
        public void SaveFilmFiguresXml()
        {
            Figure[] figures = GetAllFigures();
            List<Figure> filmFigures = new List<Figure>();
            for (int i = 0; i < figures.Length; i++)
            {
                if (figures[i].GetMaterial() is Film) filmFigures.Add(figures[i]);        
            }
            XmlFiguresWorker.XmlFiguresWrite(filmFigures.ToArray());
        }

        /// <summary>
        /// Save paper figures xmlWriter.
        /// </summary>
        public void SavePaperFiguresXml()
        {
            Figure[] figures = GetAllFigures();
            List<Figure> filmFigures = new List<Figure>();
            for (int i = 0; i < figures.Length; i++)
            {
                if (figures[i].GetMaterial() is Paper) filmFigures.Add(figures[i]);
            }
            XmlFiguresWorker.XmlFiguresWrite(filmFigures.ToArray());
        }

        /// <summary>
        /// Save all figures streamWriter.
        /// </summary>
        public void SaveAllFiguresStream()
        {
            XmlFiguresWorker.StreamFiguresWrite(GetAllFigures());
        }

        /// <summary>
        /// Save film figures streamWriter.
        /// </summary>
        public void SaveFilmFiguresStream()
        {
            Figure[] figures = GetAllFigures();
            List<Figure> filmFigures = new List<Figure>();
            for (int i = 0; i < figures.Length; i++)
            {
                if (figures[i].GetMaterial() is Film) filmFigures.Add(figures[i]);
            }
            XmlFiguresWorker.StreamFiguresWrite(filmFigures.ToArray());
        }

        /// <summary>
        /// Save paper figures streamWriter.
        /// </summary>
        public void SavePaperFiguresStream()
        {
            Figure[] figures = GetAllFigures();
            List<Figure> filmFigures = new List<Figure>();
            for (int i = 0; i < figures.Length; i++)
            {
                if (figures[i].GetMaterial() is Paper) filmFigures.Add(figures[i]);
            }
            XmlFiguresWorker.StreamFiguresWrite(filmFigures.ToArray());
        }
        
        /// <summary>
        /// Load figures xmlReader.
        /// </summary>
        public void LoadFiguresXml()
        {
            figures = new IMaterial[20];
            Figure[] loadFigures = XmlFiguresWorker.XmlFiguresRead();
            for (int i = 0; i < loadFigures.Length; i++)
            {
                AddFigure(loadFigures[i]);
            }
        }

        /// <summary>
        /// Load figures streamReader.
        /// </summary>
        public void LoadFiguresStream()
        {
            figures = new IMaterial[20];
            Figure[] loadFigures = XmlFiguresWorker.StreamFiguresRead();
            for (int i = 0; i < loadFigures.Length; i++)
            {
                AddFigure(loadFigures[i]);
            }
        }
    }
}
