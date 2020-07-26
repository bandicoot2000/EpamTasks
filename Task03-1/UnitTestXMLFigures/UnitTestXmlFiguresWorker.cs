using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XMLFigures;
using Figures;
using System.IO;

namespace UnitTestXMLFigures
{
    [TestClass]
    public class UnitTestXmlFiguresWorker
    {
        [TestMethod]
        public void TestXmlFiguresWrite()
        {
            XmlFiguresWorker xmlFiguresWorker = new XmlFiguresWorker();
            Figure[] figures =
            {
                new Circle(4.5, new Film()),
                new Polygon(5,10, new Paper(Color.Blue)),
                new Square(10, new Paper(Color.None)),
                new Rectangle(6, 8.8, new Film()),
                new Triangle(3,4,5, new Paper(Color.Red))
            };
            xmlFiguresWorker.XmlFiguresWrite(figures);
            StreamReader streamReader = new StreamReader(@"..\..\..\Figures.xml");
            string actual = streamReader.ReadToEnd();
            streamReader.Close();
            streamReader = new StreamReader(@"..\..\..\ExpectedFigures.xml");
            string expected = streamReader.ReadToEnd();
            streamReader.Close();
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void TestStreamFiguresWrite()
        {
            XmlFiguresWorker xmlFiguresWorker = new XmlFiguresWorker();
            Figure[] figures =
            {
                new Circle(4.5, new Film()),
                new Polygon(5,10, new Paper(Color.Blue)),
                new Square(10, new Paper(Color.None)),
                new Rectangle(6, 8.8, new Film()),
                new Triangle(3,4,5, new Paper(Color.Red))
            };
            xmlFiguresWorker.StreamFiguresWrite(figures);
            StreamReader streamReader = new StreamReader(@"..\..\..\Figures.xml");
            string actual = streamReader.ReadToEnd();
            streamReader.Close();
            streamReader = new StreamReader(@"..\..\..\ExpectedFigures.xml");
            string expected = streamReader.ReadToEnd();
            streamReader.Close();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestXmlFiguresRead()
        {
            XmlFiguresWorker xmlFiguresWorker = new XmlFiguresWorker();
            Figure[] figures =
            {
                new Circle(4.5, new Film()),
                new Polygon(5,10, new Paper(Color.Blue)),
                new Square(10, new Paper(Color.None)),
                new Rectangle(6, 8.8, new Film()),
                new Triangle(3,4,5, new Paper(Color.Red))
            };
            Figure[] figuresLoad = xmlFiguresWorker.XmlFiguresRead();
            CollectionAssert.AreEqual(figures, figuresLoad);
        }

        [TestMethod]
        public void TestStreamFiguresRead()
        {
            XmlFiguresWorker xmlFiguresWorker = new XmlFiguresWorker();
            Figure[] figures =
            {
                new Circle(4.5, new Film()),
                new Polygon(5,10, new Paper(Color.Blue)),
                new Square(10, new Paper(Color.None)),
                new Rectangle(6, 8.8, new Film()),
                new Triangle(3,4,5, new Paper(Color.Red))
            };
            Figure[] figuresLoad = xmlFiguresWorker.StreamFiguresRead();
            CollectionAssert.AreEqual(figures, figuresLoad);
        }
    }
}
