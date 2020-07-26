using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Figures;

namespace UnitTestFigures
{
    [TestClass]
    public class UnitTestCircle
    {
        [TestMethod]
        public void TestGetPerimeter()
        {
            double radius = 2;
            Circle circle = new Circle(radius, new Film());
            Assert.AreEqual(2 * radius * Math.PI, circle.GetPerimeter());
        }

        [TestMethod]
        public void TestGetArea()
        {
            double radius = 2;
            Circle circle = new Circle(radius, new Film());
            Assert.AreEqual(radius * radius * Math.PI, circle.GetArea());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "PaintFigure")]
        public void TestPaintFigure0()
        {
            Circle circle = new Circle(2, new Paper(Color.Black));
            circle.PaintFigure(Color.Blue);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "PaintFigure")]
        public void TestPaintFigure1()
        {
            Circle circle = new Circle(2, new Film());
            circle.PaintFigure(Color.Blue);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Circle constructor")]
        public void TestConstructor()
        {
            Square square = new Square(1, new Film());
            Circle circle = new Circle(2, square);
        }
    }
}
