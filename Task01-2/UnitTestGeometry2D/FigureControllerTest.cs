using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Geometry2D;
using Circle = Geometry2D.Сircle;

namespace UnitTestGeometry2D
{
    [TestClass]
    public class FigureControllerTest
    {

        [TestMethod]
        public void SearchFigureSquare()
        {
            Figure[] figuresEpected = new Figure[]
            {
                new Square(4.2),
                new Square(4.2),
                new Square(4.2)
            };
            string file = @"D:\Epam\EpamTasks\Task01-2\Figures10.txt";
            FigureСontroller figureСontroller = new FigureСontroller(file);
            Figure figure = new Square(4.2);
            CollectionAssert.AreEqual(figuresEpected, figureСontroller.SearchFigure(figure));
        }

        [TestMethod]
        public void SearchFigureSquare2()
        {
            Figure[] figuresEpected = new Figure[]
            {
                new Square(4.2),
                new Square(4.2)
            };
            string file = @"D:\Epam\EpamTasks\Task01-2\Figures5.txt";
            FigureСontroller figureСontroller = new FigureСontroller(file);
            Figure figure = new Square(4.2);
            CollectionAssert.AreEqual(figuresEpected, figureСontroller.SearchFigure(figure));
        }

        [TestMethod]
        public void SearchFigurePolygon()
        {
            Figure[] figuresEpected = new Figure[]
            {
                new Polygon(6, 10)
            };
            string file = @"D:\Epam\EpamTasks\Task01-2\Figures10.txt";
            FigureСontroller figureСontroller = new FigureСontroller(file);
            Figure figure = new Polygon(6, 10);
            CollectionAssert.AreEqual(figuresEpected, figureСontroller.SearchFigure(figure));
        }

        [TestMethod]
        public void SearchFigureCircle()
        {
            Figure[] figuresEpected = new Figure[] { };
            string file = @"D:\Epam\EpamTasks\Task01-2\Figures10.txt";
            FigureСontroller figureСontroller = new FigureСontroller(file);
            Figure figure = new Circle(1);
            CollectionAssert.AreEqual(figuresEpected, figureСontroller.SearchFigure(figure));
        }

        [TestMethod]
        public void SearchFigureSquareText()
        {
            Figure[] figuresEpected = new Figure[]
            {
                new Square(4.2),
                new Square(4.2),
                new Square(4.2)
            };
            string file = @"D:\Epam\EpamTasks\Task01-2\Figures10.txt";
            FigureСontroller figureСontroller = new FigureСontroller(file);
            string figure = "Square 4,2";
            CollectionAssert.AreEqual(figuresEpected, figureСontroller.SearchFigure(figure));
        }

        [TestMethod]
        public void SearchFigureSquare2Text()
        {
            Figure[] figuresEpected = new Figure[]
            {
                new Square(4.2),
                new Square(4.2)
            };
            string file = @"D:\Epam\EpamTasks\Task01-2\Figures5.txt";
            FigureСontroller figureСontroller = new FigureСontroller(file);
            string figure = "Square 4,2";
            CollectionAssert.AreEqual(figuresEpected, figureСontroller.SearchFigure(figure));
        }
    }
}
