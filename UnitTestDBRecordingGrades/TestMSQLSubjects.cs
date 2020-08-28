using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBRecordingGrades;

namespace UnitTestDBRecordingGrades
{
    [TestClass]
    public class TestMSQLSubjects
    {
        private const string CONNECTSTRING = @"Data Source=.\SQLEXPRESS;Initial Catalog = AcademicYear2020; Integrated Security = True";

        [TestMethod]
        public void TestInsert()
        {
            MSQLSubject mSQLSubjects = new MSQLSubject(CONNECTSTRING);
            Subjects subject = new Subjects(1, "Maths");
            Assert.IsTrue(mSQLSubjects.Insert(subject));
        }
        [TestMethod]
        public void TestUpdate()
        {
            MSQLSubject mSQLSubjects = new MSQLSubject(CONNECTSTRING);
            Subjects oldSubject = new Subjects(1, "Maths");
            Subjects newSubject = new Subjects(1, "Сhemistry");
            Assert.IsTrue(mSQLSubjects.Update(oldSubject, newSubject));
        }
        [TestMethod]
        public void TestDelete()
        {
            MSQLSubject mSQLSubjects = new MSQLSubject(CONNECTSTRING);
            Subjects subject = new Subjects(3, null);
            Assert.IsTrue(mSQLSubjects.Delete(subject));
        }
        [TestMethod]
        public void TestGetAllSubjects()
        {
            MSQLSubject mSQLSubjects = new MSQLSubject(CONNECTSTRING);
            Subjects[] subjects =
            {
                new Subjects(1, "Сhemistry"),
                new Subjects(2, "Maths")
            };
            CollectionAssert.AreEqual(subjects, mSQLSubjects.GetAllSubjects());
        }
    }
}
