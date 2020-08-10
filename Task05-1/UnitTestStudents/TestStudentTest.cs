using System;
using Students;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestStudents
{
    [TestClass]
    public class TestStudentTest
    {
        [TestMethod]
        public void TestCompareToEqually()
        {
            StudentTest studentTestFirst = new StudentTest("Oleg", "test", DateTime.Now, 10);
            StudentTest studentTestSecond = new StudentTest("Oleg", "test", DateTime.Now, 10);
            Assert.AreEqual(0, studentTestFirst.CompareTo(studentTestSecond));
        }
        [TestMethod]
        public void TestCompareToMore()
        {
            StudentTest studentTestFirst = new StudentTest("Oleg", "test", DateTime.Now, 10);
            StudentTest studentTestSecond = new StudentTest("Oleg", "test", DateTime.Now, 1);
            Assert.AreEqual(1, studentTestFirst.CompareTo(studentTestSecond));
        }
        [TestMethod]
        public void TestCompareToLess()
        {
            StudentTest studentTestFirst = new StudentTest("Oleg", "test", DateTime.Now, 1);
            StudentTest studentTestSecond = new StudentTest("Oleg", "test", DateTime.Now, 10);
            Assert.AreEqual(-1, studentTestFirst.CompareTo(studentTestSecond));
        }
    }
}
