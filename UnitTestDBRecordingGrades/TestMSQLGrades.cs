using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBRecordingGrades;

namespace UnitTestDBRecordingGrades
{
    [TestClass]
    public class TestMSQLGrades
    {
        private const string CONNECTSTRING = @"Data Source=.\SQLEXPRESS;Initial Catalog = AcademicYear2020; Integrated Security = True";

        [TestMethod]
        public void TestInsert()
        {
            MSQLGrades mSQLGrades = new MSQLGrades(CONNECTSTRING);
            Grades grade = new Grades(1, 1, 1, 10);
            Assert.IsTrue(mSQLGrades.Insert(grade));
        }
        [TestMethod]
        public void TestUpdate()
        {
            MSQLGrades mSQLGrades = new MSQLGrades(CONNECTSTRING);
            Grades oldGrade = new Grades(1, 1, 1, 10);
            Grades newGrade = new Grades(1, 2, 2, 2);
            Assert.IsTrue(mSQLGrades.Update(oldGrade, newGrade));
        }
        [TestMethod]
        public void TestDelete()
        {
            MSQLGrades mSQLGrades = new MSQLGrades(CONNECTSTRING);
            Grades grade = new Grades(3, 1, 1, 10);
            Assert.IsTrue(mSQLGrades.Delete(grade));
        }
        [TestMethod]
        public void TestGetAllGrades()
        {
            MSQLGrades mSQLGrades = new MSQLGrades(CONNECTSTRING);
            Grades[] grades =
            {
                new Grades(1, 2, 2, 2),
                new Grades(2, 1, 1, 10)
            };
            CollectionAssert.AreEqual(grades, mSQLGrades.GetAllGrades());
        }
    }
}
