using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Figures;

namespace UnitTestFigures
{
    [TestClass]
    public class UnitTestPaper
    {
        [TestMethod]
        [ExpectedException(typeof(Exception), "This shape is already painted")]
        public void TestPaperColor()
        {
            Paper paper = new Paper(Color.Black);
            paper.Color = Color.Blue;
        }
    }
}
