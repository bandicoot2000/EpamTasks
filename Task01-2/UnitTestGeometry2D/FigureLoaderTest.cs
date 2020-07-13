using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geometry2D;
using Circle = Geometry2D.Сircle;

namespace UnitTestGeometry2D
{
    [TestClass]
    public class FigureLoaderTest
    {

        [TestMethod]
        public void LoadFigures2Figures()
        {
            Figure[] figuresEpected = new Figure[]
            {
                new Triangle(3, 4, 5),
                new Circle(6)
            };
            string file = @"D:\Epam\EpamTasks\Task01-2\Figures2.txt";
            CollectionAssert.AreEqual(figuresEpected, FigureLoader.LoadFigures(file));
        }

        [TestMethod]
        public void LoadFigures5Figures()
        {
            Figure[] figuresEpected = new Figure[]
            {
                new Square(4.2),
                new Circle(5),
                new Triangle(9.1, 8.2, 5),
                new Square(4.2),
                new Polygon(6, 10)
            };
            string file = @"D:\Epam\EpamTasks\Task01-2\Figures5.txt";
            CollectionAssert.AreEqual(figuresEpected, FigureLoader.LoadFigures(file));
        }

        [TestMethod]
        public void LoadFigures10Figures()
        {
            Figure[] figuresEpected = new Figure[]
            {
                new Square(4.2),
                new Circle(5),
                new Triangle(9.1, 8.2, 5),
                new Square(4.2),
                new Polygon(6, 10),
                new Polygon(8, 6),
                new Rectangle(4, 5),
                new Circle(4.4),
                new Circle(8),
                new Square(4.2)
            };
            string file = @"D:\Epam\EpamTasks\Task01-2\Figures10.txt";
            CollectionAssert.AreEqual(figuresEpected, FigureLoader.LoadFigures(file));
        }

        [TestMethod]
        public void ParseFigureCircle()
        {
            Figure figureEpected = new Circle(6.5);
            string text = "Circle 6,5";
            Assert.AreEqual(figureEpected, FigureLoader.ParseFigure(text));
        }

        [TestMethod]
        public void ParseFigureSquare()
        {
            Figure figureEpected = new Square(1.5);
            string text = "Square 1,5";
            Assert.AreEqual(figureEpected, FigureLoader.ParseFigure(text));
        }

        [TestMethod]
        public void ParseFigureTriangle()
        {
            Figure figureEpected = new Triangle(3, 4, 5);
            string text = "Triangle 3 4 5";
            Assert.AreEqual(figureEpected, FigureLoader.ParseFigure(text));
        }

        [TestMethod]
        public void ParseFigureRectangle()
        {
            Figure figureEpected = new Rectangle(2.2, 3.4);
            string text = "Rectangle 2,2 3,4";
            Assert.AreEqual(figureEpected, FigureLoader.ParseFigure(text));
        }

        [TestMethod]
        public void ParseFigurePolygon()
        {
            Figure figureEpected = new Polygon(4.1, 6);
            string text = "Polygon 4,1 6";
            Assert.AreEqual(figureEpected, FigureLoader.ParseFigure(text));
        }
    }
}
