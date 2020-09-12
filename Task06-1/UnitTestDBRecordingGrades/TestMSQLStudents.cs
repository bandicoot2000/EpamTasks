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
        public void Test1Insert()
        {
            MSQLStudents mSQLStudents = new MSQLStudents(CONNECTSTRING);
            Students assessmentForm = new Students(1, "Akylich", "Artem", "Pavlovich", "M", new DateTime(2000, 7, 21), 1);
            Assert.IsTrue(mSQLStudents.Insert(assessmentForm));
        }
        [TestMethod]
        public void Test2Update()
        {
            MSQLStudents mSQLStudents = new MSQLStudents(CONNECTSTRING);
            Students oldAssessmentForm = new Students(1, "Akylich", "Artem", "Pavlovich", "M", new DateTime(2000, 7, 21), 1);
            Students newAssessmentForm = new Students(1, "Akylich", "Yra", "Pavlovich", "M", new DateTime(2002, 10, 14), 1);
            Assert.IsTrue(mSQLStudents.Update(oldAssessmentForm, newAssessmentForm));
        }
        [TestMethod]
        public void Test4Delete()
        {
            MSQLStudents mSQLStudents = new MSQLStudents(CONNECTSTRING);
            Students assessmentForm = new Students(1, "Akylich", "Artem", "Pavlovich", "M", new DateTime(2000, 7, 21), 1);
            Assert.IsTrue(mSQLStudents.Delete(assessmentForm));
        }
        [TestMethod]
        public void Test3GetAllStudents()
        {
            MSQLStudents mSQLStudents = new MSQLStudents(CONNECTSTRING);
            Students[] sudents =
            {
                new Students(1, "Akylich", "Yra", "Pavlovich", "M", new DateTime(2002, 10, 14), 1)
            };
            CollectionAssert.AreEqual(sudents, mSQLStudents.GetAllStudents());
        }
    }
}
