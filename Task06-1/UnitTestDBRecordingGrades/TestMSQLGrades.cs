using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBRecordingGrades;

namespace UnitTestDBRecordingGrades
{
    [TestClass]
    public class TestMSQLGrades
    {
        private const string CONNECTSTRING = @"Data Source=.\SQLEXPRESS;Initial Catalog = AcademicYear2020_t7; Integrated Security = True";

        [TestMethod]
        public void Test1Insert()
        {
            MSQLGrades mSQLGrades = new MSQLGrades(CONNECTSTRING);
            Grades grade = new Grades(1, 1, 1, 10);
            Assert.IsTrue(mSQLGrades.Insert(grade));
        }
        [TestMethod]
        public void Test2Update()
        {
            MSQLGrades mSQLGrades = new MSQLGrades(CONNECTSTRING);
            Grades oldGrade = new Grades(1, 1, 1, 10);
            Grades newGrade = new Grades(1, 1, 1, 2);
            Assert.IsTrue(mSQLGrades.Update(oldGrade, newGrade));
        }
        [TestMethod]
        public void Test4Delete()
        {
            MSQLGrades mSQLGrades = new MSQLGrades(CONNECTSTRING);
            Grades grade = new Grades(1, 1, 1, 10);
            Assert.IsTrue(mSQLGrades.Delete(grade));
        }
        [TestMethod]
        public void Test3GetAllGrades()
        {
            MSQLGrades mSQLGrades = new MSQLGrades(CONNECTSTRING);
            Grades[] grades =
            {
                new Grades(1, 1, 1, 2),
            };
            CollectionAssert.AreEqual(grades, mSQLGrades.GetAllGrades());
        }
    }
}
