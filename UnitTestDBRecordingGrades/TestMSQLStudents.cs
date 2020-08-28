using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBRecordingGrades;

namespace UnitTestDBRecordingGrades
{
    [TestClass]
    public class TestMSQLStudents
    {
        private const string CONNECTSTRING = @"Data Source=.\SQLEXPRESS;Initial Catalog = AcademicYear2020; Integrated Security = True";

        [TestMethod]
        public void TestInsert()
        {
            MSQLStudents mSQLStudents = new MSQLStudents(CONNECTSTRING);
            Students assessmentForm = new Students(1, "Akylich", "Artem", "Pavlovich", "M", new DateTime(2000, 7, 21), 1);
            Assert.IsTrue(mSQLStudents.Insert(assessmentForm));
        }
        [TestMethod]
        public void TestUpdate()
        {
            MSQLStudents mSQLStudents = new MSQLStudents(CONNECTSTRING);
            Students oldAssessmentForm = new Students(1, "Akylich", "Artem", "Pavlovich", "M", new DateTime(2000, 7, 21), 1);
            Students newAssessmentForm = new Students(1, "Akylich", "Yra", "Pavlovich", "M", new DateTime(2002, 10, 14), 2);
            Assert.IsTrue(mSQLStudents.Update(oldAssessmentForm, newAssessmentForm));
        }
        [TestMethod]
        public void TestDelete()
        {
            MSQLStudents mSQLStudents = new MSQLStudents(CONNECTSTRING);
            Students assessmentForm = new Students(3, "Akylich", "Artem", "Pavlovich", "M", new DateTime(2000, 7, 21), 1);
            Assert.IsTrue(mSQLStudents.Delete(assessmentForm));
        }
        [TestMethod]
        public void TestGetAllStudents()
        {
            MSQLStudents mSQLStudents = new MSQLStudents(CONNECTSTRING);
            Students[] sudents =
            {
                new Students(1, "Akylich", "Yra", "Pavlovich", "M", new DateTime(2002, 10, 14), 2),
                new Students(2, "Akylich", "Artem", "Pavlovich", "M", new DateTime(2000, 7, 21), 1)
            };
            CollectionAssert.AreEqual(sudents, mSQLStudents.GetAllStudents());
        }
    }
}
