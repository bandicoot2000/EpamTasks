using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Figures;

namespace UnitTestFigures
{
    [TestClass]
    public class UnitTestPolygon
    {
        [TestMethod]
        public void TestGetPerimeter()
        {
            double side = 2;
            int amountSides = 10;
            Polygon polygon = new Polygon(side, amountSides, new Film());
            Assert.AreEqual(side * amountSides, polygon.GetPerimeter());
        }

        [TestMethod]
        public void TestGetArea()
        {
            double side = 2;
            int amountSides = 10;
            Polygon polygon = new Polygon(side, amountSides, new Film());
            Assert.AreEqual(side * amountSides, polygon.GetPerimeter());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "PaintFigure")]
        public void TestPaintFigure0()
        {
            Polygon polygon = new Polygon(2, 10, new Paper(Color.Black));
            polygon.PaintFigure(Color.Blue);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "PaintFigure")]
        public void TestPaintFigure1()
        {
            Polygon polygon = new Polygon(2, 10, new Film());
            polygon.PaintFigure(Color.Blue);
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Polygon constructor")]
        public void TestConstructor()
        {
            Square square = new Square(1, new Film());
            Polygon circle = new Polygon(2, 5, square);
        }
    }
}
