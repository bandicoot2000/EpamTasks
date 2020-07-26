using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Figures;

namespace UnitTestFigures
{
    [TestClass]
    public class UnitTestRectangle
    {
        [TestMethod]
        public void TestGetPerimeter()
        {
            double length = 2;
            double width = 4;
            Rectangle rectangle = new Rectangle(length, width, new Film());
            Assert.AreEqual(length * 2 + width * 2, rectangle.GetPerimeter());
        }

        [TestMethod]
        public void TestGetArea()
        {
            double length = 2;
            double width = 4;
            Rectangle rectangle = new Rectangle(length, width, new Film());
            Assert.AreEqual(length *  width , rectangle.GetArea());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "PaintFigure")]
        public void TestPaintFigure0()
        {
            Rectangle rectangle = new Rectangle(2, 3, new Paper(Color.Black));
            rectangle.PaintFigure(Color.Blue);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "PaintFigure")]
        public void TestPaintFigure1()
        {
            Rectangle rectangle = new Rectangle(2, 3, new Film());
            rectangle.PaintFigure(Color.Blue);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Rectangle constructor")]
        public void TestConstructor()
        {
            Square square = new Square(1, new Film());
            Rectangle rectangle = new Rectangle(2, 4, square);
        }
    }
}
