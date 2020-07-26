using System;
using Figures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestFigures
{
    [TestClass]
    public class UnitTestSquare
    {
        [TestMethod]
        public void TestGetPerimeter()
        {
            double side = 2;
            Square square = new Square(side, new Film());
            Assert.AreEqual(side * 4, square.GetPerimeter());
        }

        [TestMethod]
        public void TestGetArea()
        {
            double side = 2;
            Square square = new Square(side, new Film());
            Assert.AreEqual(side * side, square.GetArea());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "PaintFigure")]
        public void TestPaintFigure0()
        {
            Square square = new Square(2, new Paper(Color.Black));
            square.PaintFigure(Color.Blue);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "PaintFigure")]
        public void TestPaintFigure1()
        {
            Square square = new Square(2, new Film());
            square.PaintFigure(Color.Blue);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Circle constructor")]
        public void TestConstructor()
        {
            Circle circle = new Circle(1, new Film());
            Square square = new Square(3, circle);
        }
    }
}
