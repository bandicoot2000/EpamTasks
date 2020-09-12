using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBRecordingGrades;

namespace UnitTestDBRecordingGrades
{
    [TestClass]
    public class TestDataBaseManager
    {
        private const string CONNECTSTRING_INIT = @"Data Source=.\SQLEXPRESS;Initial Catalog = {0}; Integrated Security = True";
        private const string CONNECTSTRING = @"Data Source=.\SQLEXPRESS;Initial Catalog = AcademicYear2020; Integrated Security = True";
        [TestMethod]
        public void TestInitialize()
        {
            Assert.IsTrue(DataBaseManager.DBInitialize(CONNECTSTRING_INIT));
        }
        [TestMethod]
        public void TestFilling()
        {
            Assert.IsTrue(DataBaseManager.DBFilling(CONNECTSTRING));
        }
    }
}
