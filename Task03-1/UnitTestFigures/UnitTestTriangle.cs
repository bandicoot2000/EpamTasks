using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Figures;

namespace UnitTestFigures
{
    [TestClass]
    public class UnitTestTriangle
    {
        [TestMethod]
        public void TestGetPerimeter()
        {
            double sideA = 3;
            double sideB = 4;
            double sideC = 5;
            Triangle triangle = new Triangle(sideA, sideB, sideC, new Film());
            Assert.AreEqual(sideA + sideB + sideC, triangle.GetPerimeter());
        }

        [TestMethod]
        public void TestGetArea()
        {
            double sideA = 3;
            double sideB = 4;
            double sideC = 5;
            Triangle triangle = new Triangle(sideA, sideB, sideC, new Film());
            double halfPerimeter = (sideA + sideB + sideC) / 2;
            Assert.AreEqual(Math.Sqrt(halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter - sideC)), triangle.GetArea());
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "PaintFigure")]
        public void TestPaintFigure0()
        {
            Triangle triangle = new Triangle(3, 4, 5, new Paper(Color.Black));
            triangle.PaintFigure(Color.Blue);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "PaintFigure")]
        public void TestPaintFigure1()
        {
            Triangle triangle = new Triangle(3, 4, 5, new Film());
            triangle.PaintFigure(Color.Blue);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Circle constructor")]
        public void TestConstructor()
        {
            Square square = new Square(1, new Film());
            Triangle triangle = new Triangle(3, 4, 5, square);
        }
    }
}
