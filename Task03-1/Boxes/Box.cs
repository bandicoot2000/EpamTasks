using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figures;
using XMLFigures();

namespace Boxes
{
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

        public Figure LookFigure(int index)
        {
            return figures[index] == null ? null : (Figure)figures[index];
        }

        public Figure ExtractFigure(int index)
        {
            Figure figure = LookFigure(index);
            figures[index] = null;
            return figure;
        }

        public void Replace(Figure figure, int index)
        {
            figures[index] = figure;
        }

        public int FindFigure(Figure figure)
        {
            for (int i = 0; i < figures.Length; i++)
            {
                if (figures[i] != null && figures[i].Equals(figure)) return i;
            }
            return -1;
        }

        public int CountFigures()
        {
            int result = 0;
            for (int i = 0; i < figures.Length; i++)
            {
                if (figures[i] != null) result++;
            }
            return result;
        }

        public double GetTotalArea()
        {
            double result = 0;
            for (int i = 0; i < figures.Length; i++)
            {
                if (figures[i] != null) result += ((Figure)figures[i]).GetArea();
            }
            return result;
        }

        public double GetTotalPerimeter()
        {
            double result = 0;
            for (int i = 0; i<figures.Length; i++)
            {
                if (figures[i] != null) result += ((Figure) figures[i]).GetPerimeter();
            }
            return result;
        }

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

        public void SaveAllFiguresXml()
        {
            XmlFiguresWorker.XmlFiguresWrite(GetAllFigures());
        }

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

        public void SaveAllFiguresStream()
        {
            XmlFiguresWorker.StreamFiguresWrite(GetAllFigures());
        }

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
        
        public void LoadFiguresXml()
        {
            figures = new IMaterial[20];
            Figure[] loadFigures = XmlFiguresWorker.XmlFiguresRead();
            for (int i = 0; i < loadFigures.Length; i++)
            {
                AddFigure(loadFigures[i]);
            }
        }

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
