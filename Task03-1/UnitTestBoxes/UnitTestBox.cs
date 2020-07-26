using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Boxes;
using Figures;
using System.IO;

namespace UnitTestBoxes
{
    [TestClass]
    public class UnitTestBox
    {
        [TestMethod]
        public void TestAddFigure0()
        {
            Box box = new Box();
            Circle circle = new Circle(4.5, new Film());
            Polygon polygon = new Polygon(5, 10, new Paper(Color.Blue));
            Square square = new Square(10, new Paper(Color.None));
            Rectangle rectangle = new Rectangle(6, 8.8, new Film());
            Triangle triangle = new Triangle(3, 4, 5, new Paper(Color.Red));
            box.AddFigure(circle);
            box.AddFigure(polygon);
            box.AddFigure(square);
            box.AddFigure(rectangle);
            box.AddFigure(triangle);
            Figure[] figures =
            {
                new Circle(4.5, new Film()),
                new Polygon(5,10, new Paper(Color.Blue)),
                new Square(10, new Paper(Color.None)),
                new Rectangle(6, 8.8, new Film()),
                new Triangle(3,4,5, new Paper(Color.Red))
            };
            Figure[] figuresTest = box.GetAllFigures();
            CollectionAssert.AreEqual(figures, figuresTest);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "AddFigure")]
        public void TestAddFigureReiteration()
        {
            Box box = new Box();
            Circle circle1 = new Circle(4.5, new Film());
            Circle circle2 = new Circle(4.5, new Film());
            box.AddFigure(circle1);
            box.AddFigure(circle2);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "AddFigure")]
        public void TestAddFigureFullBox()
        {
            Box box = new Box();
            for (int i = 1; i < 25; i++)
            {
                box.AddFigure(new Circle(i, new Film()));
            }
        }

        [TestMethod]
        public void TestLookFigure()
        {
            Box box = new Box();
            Circle circle = new Circle(4.5, new Film());
            Polygon polygon = new Polygon(5, 10, new Paper(Color.Blue));
            Square square = new Square(10, new Paper(Color.None));
            Rectangle rectangle = new Rectangle(6, 8.8, new Film());
            Triangle triangle = new Triangle(3, 4, 5, new Paper(Color.Red));
            box.AddFigure(circle);
            box.AddFigure(polygon);
            box.AddFigure(square);
            box.AddFigure(rectangle);
            box.AddFigure(triangle);
            Figure[] figures =
            {
                new Circle(4.5, new Film()),
                new Polygon(5,10, new Paper(Color.Blue)),
                new Square(10, new Paper(Color.None)),
                new Rectangle(6, 8.8, new Film()),
                new Triangle(3,4,5, new Paper(Color.Red))
            };
            int index = 2;
            Assert.AreEqual(figures[index], box.LookFigure(index));
        }


        [TestMethod]
        public void TestExtractFigureEquals()
        {
            Box box = new Box();
            Circle circle = new Circle(4.5, new Film());
            Polygon polygon = new Polygon(5, 10, new Paper(Color.Blue));
            Square square = new Square(10, new Paper(Color.None));
            Rectangle rectangle = new Rectangle(6, 8.8, new Film());
            Triangle triangle = new Triangle(3, 4, 5, new Paper(Color.Red));
            box.AddFigure(circle);
            box.AddFigure(polygon);
            box.AddFigure(square);
            box.AddFigure(rectangle);
            box.AddFigure(triangle);
            Figure[] figures =
            {
                new Circle(4.5, new Film()),
                new Polygon(5,10, new Paper(Color.Blue)),
                new Square(10, new Paper(Color.None)),
                new Rectangle(6, 8.8, new Film()),
                new Triangle(3,4,5, new Paper(Color.Red))
            };
            int index = 2;
            Assert.AreEqual(figures[index], box.ExtractFigure(index));
        }

        [TestMethod]
        public void TestExtractFigureExtracting()
        {
            Box box = new Box();
            Circle circle = new Circle(4.5, new Film());
            Polygon polygon = new Polygon(5, 10, new Paper(Color.Blue));
            Square square = new Square(10, new Paper(Color.None));
            Rectangle rectangle = new Rectangle(6, 8.8, new Film());
            Triangle triangle = new Triangle(3, 4, 5, new Paper(Color.Red));
            box.AddFigure(circle);
            box.AddFigure(polygon);
            box.AddFigure(square);
            box.AddFigure(rectangle);
            box.AddFigure(triangle);
            Figure[] figures =
            {
                new Circle(4.5, new Film()),
                new Polygon(5,10, new Paper(Color.Blue)),
                new Square(10, new Paper(Color.None)),
                new Rectangle(6, 8.8, new Film()),
                new Triangle(3,4,5, new Paper(Color.Red))
            };
            box.ExtractFigure(2);
            Assert.AreEqual(figures.Length - 1, box.CountFigures());
        }

        [TestMethod]
        public void TestReplace()
        {
            Box box = new Box();
            Circle circle = new Circle(4.5, new Film());
            Polygon polygon = new Polygon(5, 10, new Paper(Color.Blue));
            box.AddFigure(circle);
            box.Replace(polygon, 0);
            Figure[] figures =
            {
                new Polygon(5,10, new Paper(Color.Blue)),
            };
            box.ExtractFigure(2);
            CollectionAssert.AreEqual(figures, box.GetAllFigures());
        }

        [TestMethod]
        public void TestFindFigure()
        {
            Box box = new Box();
            Circle circle = new Circle(4.5, new Film());
            Polygon polygon = new Polygon(5, 10, new Paper(Color.Blue));
            Square square = new Square(10, new Paper(Color.None));
            Polygon polygonFind = new Polygon(5, 10, new Paper(Color.Blue));
            box.AddFigure(circle);
            box.AddFigure(polygon);
            box.AddFigure(square);
            Assert.AreEqual(1, box.FindFigure(polygonFind));
        }

        [TestMethod]
        public void TestCountFigures()
        {
            Box box = new Box();
            Circle circle = new Circle(4.5, new Film());
            Polygon polygon = new Polygon(5, 10, new Paper(Color.Blue));
            Square square = new Square(10, new Paper(Color.None));
            Rectangle rectangle = new Rectangle(6, 8.8, new Film());
            Triangle triangle = new Triangle(3, 4, 5, new Paper(Color.Red));
            Rectangle rectangle1 = new Rectangle(2, 8.8, new Film());
            Triangle triangle1 = new Triangle(6, 4, 5, new Paper(Color.Red));
            box.AddFigure(circle);
            box.AddFigure(polygon);
            box.AddFigure(square);
            box.AddFigure(rectangle);
            box.AddFigure(triangle);
            box.AddFigure(rectangle1);
            box.AddFigure(triangle1);
            Assert.AreEqual(7, box.CountFigures());
        }

        [TestMethod]
        public void TestGetTotalArea()
        {
            Box box = new Box();
            Circle circle = new Circle(4.5, new Film());
            Polygon polygon = new Polygon(5, 10, new Paper(Color.Blue));
            Square square = new Square(10, new Paper(Color.None));
            Rectangle rectangle = new Rectangle(6, 8.8, new Film());
            Triangle triangle = new Triangle(3, 4, 5, new Paper(Color.Red));
            box.AddFigure(circle);
            box.AddFigure(polygon);
            box.AddFigure(square);
            box.AddFigure(rectangle);
            box.AddFigure(triangle);
            double totalArea = circle.GetArea() + polygon.GetArea() + square.GetArea() + rectangle.GetArea() + triangle.GetArea();
            Assert.AreEqual(totalArea, box.GetTotalArea());
        }

        [TestMethod]
        public void TestGetTotalPerimeter()
        {
            Box box = new Box();
            Circle circle = new Circle(4.5, new Film());
            Polygon polygon = new Polygon(5, 10, new Paper(Color.Blue));
            Square square = new Square(10, new Paper(Color.None));
            Rectangle rectangle = new Rectangle(6, 8.8, new Film());
            Triangle triangle = new Triangle(3, 4, 5, new Paper(Color.Red));
            box.AddFigure(circle);
            box.AddFigure(polygon);
            box.AddFigure(square);
            box.AddFigure(rectangle);
            box.AddFigure(triangle);
            double totalArea = circle.GetPerimeter() + polygon.GetPerimeter() + square.GetPerimeter() + rectangle.GetPerimeter() + triangle.GetPerimeter();
            Assert.AreEqual(totalArea, box.GetTotalPerimeter());
        }

        [TestMethod]
        public void TestGetAllCircles()
        {
            Box box = new Box();
            Circle circle1 = new Circle(4.5, new Film());
            Polygon polygon = new Polygon(5, 10, new Paper(Color.Blue));
            Circle circle2 = new Circle(3, new Paper());
            Rectangle rectangle = new Rectangle(6, 8.8, new Film());
            Circle circle3 = new Circle(1, new Film());
            box.AddFigure(circle1);
            box.AddFigure(polygon);
            box.AddFigure(circle2);
            box.AddFigure(rectangle);
            box.AddFigure(circle3);
            Figure[] figures =
            {
                new Circle(4.5, new Film()),
                new Circle(3, new Paper()),
                new Circle(1, new Film())
            };
            CollectionAssert.AreEqual(figures, box.GetAllCircles());
        }

        [TestMethod]
        public void TestGetAllFilmFigures()
        {
            Box box = new Box();
            Circle circle1 = new Circle(4.5, new Film());
            Polygon polygon = new Polygon(5, 10, new Paper(Color.Blue));
            Circle circle2 = new Circle(3, new Paper());
            Rectangle rectangle = new Rectangle(6, 8.8, new Film());
            Circle circle3 = new Circle(1, new Film());
            box.AddFigure(circle1);
            box.AddFigure(polygon);
            box.AddFigure(circle2);
            box.AddFigure(rectangle);
            box.AddFigure(circle3);
            Figure[] figures =
            {
                new Circle(4.5, new Film()),
                new Rectangle(6, 8.8, new Film()),
                new Circle(1, new Film())
            };
            CollectionAssert.AreEqual(figures, box.GetAllFilmFigures());
        }

        [TestMethod]
        public void TestGetAllFigures()
        {
            Box box = new Box();
            Circle circle1 = new Circle(4.5, new Film());
            Polygon polygon = new Polygon(5, 10, new Paper(Color.Blue));
            Circle circle2 = new Circle(3, new Paper());
            Rectangle rectangle = new Rectangle(6, 8.8, new Film());
            Circle circle3 = new Circle(1, new Film());
            box.AddFigure(circle1);
            box.AddFigure(polygon);
            box.AddFigure(circle2);
            box.AddFigure(rectangle);
            box.AddFigure(circle3);
            Figure[] figures =
            {
                new Circle(4.5, new Film()),
                new Polygon(5, 10, new Paper(Color.Blue)),
                new Circle(3, new Paper()),
                new Rectangle(6, 8.8, new Film()),
                new Circle(1, new Film())
            };
            CollectionAssert.AreEqual(figures, box.GetAllFigures());
        }

        [TestMethod]
        public void TestSaveAllFiguresXml()
        {
            Box box = new Box();
            Circle circle = new Circle(4.5, new Film());
            Polygon polygon = new Polygon(5, 10, new Paper(Color.Blue));
            Square square = new Square(10, new Paper(Color.None));
            Rectangle rectangle = new Rectangle(6, 8.8, new Film());
            Triangle triangle = new Triangle(3, 4, 5, new Paper(Color.Red));
            box.AddFigure(circle);
            box.AddFigure(polygon);
            box.AddFigure(square);
            box.AddFigure(rectangle);
            box.AddFigure(triangle);
            box.SaveAllFiguresXml();
            StreamReader streamReader = new StreamReader(@"..\..\..\Figures.xml");
            string actual = streamReader.ReadToEnd();
            streamReader.Close();
            streamReader = new StreamReader(@"..\..\..\ExpectedFigures.xml");
            string expected = streamReader.ReadToEnd();
            streamReader.Close();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSaveFilmFiguresXml()
        {
            Box box = new Box();
            Circle circle = new Circle(4.5, new Film());
            Polygon polygon = new Polygon(5, 10, new Paper(Color.Blue));
            Square square = new Square(10, new Paper(Color.None));
            Rectangle rectangle = new Rectangle(6, 8.8, new Film());
            Triangle triangle = new Triangle(3, 4, 5, new Paper(Color.Red));
            box.AddFigure(circle);
            box.AddFigure(polygon);
            box.AddFigure(square);
            box.AddFigure(rectangle);
            box.AddFigure(triangle);
            box.SaveFilmFiguresXml();
            StreamReader streamReader = new StreamReader(@"..\..\..\Figures.xml");
            string actual = streamReader.ReadToEnd();
            streamReader.Close();
            streamReader = new StreamReader(@"..\..\..\ExpectedFiguresFilm.xml");
            string expected = streamReader.ReadToEnd();
            streamReader.Close();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSavePaperFiguresXml()
        {
            Box box = new Box();
            Circle circle = new Circle(4.5, new Film());
            Polygon polygon = new Polygon(5, 10, new Paper(Color.Blue));
            Square square = new Square(10, new Paper(Color.None));
            Rectangle rectangle = new Rectangle(6, 8.8, new Film());
            Triangle triangle = new Triangle(3, 4, 5, new Paper(Color.Red));
            box.AddFigure(circle);
            box.AddFigure(polygon);
            box.AddFigure(square);
            box.AddFigure(rectangle);
            box.AddFigure(triangle);
            box.SavePaperFiguresXml();
            StreamReader streamReader = new StreamReader(@"..\..\..\Figures.xml");
            string actual = streamReader.ReadToEnd();
            streamReader.Close();
            streamReader = new StreamReader(@"..\..\..\ExpectedFiguresPaper.xml");
            string expected = streamReader.ReadToEnd();
            streamReader.Close();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSaveAllFiguresStream()
        {
            Box box = new Box();
            Circle circle = new Circle(4.5, new Film());
            Polygon polygon = new Polygon(5, 10, new Paper(Color.Blue));
            Square square = new Square(10, new Paper(Color.None));
            Rectangle rectangle = new Rectangle(6, 8.8, new Film());
            Triangle triangle = new Triangle(3, 4, 5, new Paper(Color.Red));
            box.AddFigure(circle);
            box.AddFigure(polygon);
            box.AddFigure(square);
            box.AddFigure(rectangle);
            box.AddFigure(triangle);
            box.SaveAllFiguresStream();
            StreamReader streamReader = new StreamReader(@"..\..\..\Figures.xml");
            string actual = streamReader.ReadToEnd();
            streamReader.Close();
            streamReader = new StreamReader(@"..\..\..\ExpectedFigures.xml");
            string expected = streamReader.ReadToEnd();
            streamReader.Close();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSaveFilmFiguresStream()
        {
            Box box = new Box();
            Circle circle = new Circle(4.5, new Film());
            Polygon polygon = new Polygon(5, 10, new Paper(Color.Blue));
            Square square = new Square(10, new Paper(Color.None));
            Rectangle rectangle = new Rectangle(6, 8.8, new Film());
            Triangle triangle = new Triangle(3, 4, 5, new Paper(Color.Red));
            box.AddFigure(circle);
            box.AddFigure(polygon);
            box.AddFigure(square);
            box.AddFigure(rectangle);
            box.AddFigure(triangle);
            box.SaveFilmFiguresStream();
            StreamReader streamReader = new StreamReader(@"..\..\..\Figures.xml");
            string actual = streamReader.ReadToEnd();
            streamReader.Close();
            streamReader = new StreamReader(@"..\..\..\ExpectedFiguresFilm.xml");
            string expected = streamReader.ReadToEnd();
            streamReader.Close();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestSavePaperFiguresStream()
        {
            Box box = new Box();
            Circle circle = new Circle(4.5, new Film());
            Polygon polygon = new Polygon(5, 10, new Paper(Color.Blue));
            Square square = new Square(10, new Paper(Color.None));
            Rectangle rectangle = new Rectangle(6, 8.8, new Film());
            Triangle triangle = new Triangle(3, 4, 5, new Paper(Color.Red));
            box.AddFigure(circle);
            box.AddFigure(polygon);
            box.AddFigure(square);
            box.AddFigure(rectangle);
            box.AddFigure(triangle);
            box.SavePaperFiguresStream();
            StreamReader streamReader = new StreamReader(@"..\..\..\Figures.xml");
            string actual = streamReader.ReadToEnd();
            streamReader.Close();
            streamReader = new StreamReader(@"..\..\..\ExpectedFiguresPaper.xml");
            string expected = streamReader.ReadToEnd();
            streamReader.Close();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestLoadFiguresXml()
        {
            Box box = new Box(@"..\..\..\ExpectedFigures.xml");
            box.LoadFiguresXml();
            Figure[] figures =
{
                new Circle(4.5, new Film()),
                new Polygon(5,10, new Paper(Color.Blue)),
                new Square(10, new Paper(Color.None)),
                new Rectangle(6, 8.8, new Film()),
                new Triangle(3,4,5, new Paper(Color.Red))
            };
            CollectionAssert.AreEqual(figures, box.GetAllFigures());
        }

        [TestMethod]
        public void TestLoadFiguresStream()
        {
            Box box = new Box(@"..\..\..\ExpectedFigures.xml");
            box.LoadFiguresXml();
            Figure[] figures =
{
                new Circle(4.5, new Film()),
                new Polygon(5,10, new Paper(Color.Blue)),
                new Square(10, new Paper(Color.None)),
                new Rectangle(6, 8.8, new Film()),
                new Triangle(3,4,5, new Paper(Color.Red))
            };
            CollectionAssert.AreEqual(figures, box.GetAllFigures());
        }
    }
}
