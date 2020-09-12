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
        public void Test1Insert()
        {
            MSQLSubject mSQLSubjects = new MSQLSubject(CONNECTSTRING);
            Subjects subject = new Subjects(1, "Maths");
            Assert.IsTrue(mSQLSubjects.Insert(subject));
        }
        [TestMethod]
        public void Test2Update()
        {
            MSQLSubject mSQLSubjects = new MSQLSubject(CONNECTSTRING);
            Subjects oldSubject = new Subjects(1, "Maths");
            Subjects newSubject = new Subjects(1, "Сhemistry");
            Assert.IsTrue(mSQLSubjects.Update(oldSubject, newSubject));
        }
        [TestMethod]
        public void Test4Delete()
        {
            MSQLSubject mSQLSubjects = new MSQLSubject(CONNECTSTRING);
            Subjects subject = new Subjects(1, null);
            Assert.IsTrue(mSQLSubjects.Delete(subject));
        }
        [TestMethod]
        public void Test3GetAllSubjects()
        {
            MSQLSubject mSQLSubjects = new MSQLSubject(CONNECTSTRING);
            Subjects[] subjects =
            {
                new Subjects(1, "Сhemistry")
            };
            CollectionAssert.AreEqual(subjects, mSQLSubjects.GetAllSubjects());
        }
    }
}
