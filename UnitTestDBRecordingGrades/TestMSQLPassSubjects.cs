using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBRecordingGrades;

namespace UnitTestDBRecordingGrades
{
    [TestClass]
    public class TestMSQLPassSubjects
    {
        private const string CONNECTSTRING = @"Data Source=.\SQLEXPRESS;Initial Catalog = AcademicYear2020; Integrated Security = True";

        [TestMethod]
        public void TestInsert()
        {
            MSQLPassSubjects mSQLPassSubjects = new MSQLPassSubjects(CONNECTSTRING);
            PassSubjects passSubject = new PassSubjects(1, 1, 2, 1, 1);
            Assert.IsTrue(mSQLPassSubjects.Insert(passSubject));
        }
        [TestMethod]
        public void TestUpdate()
        {
            MSQLPassSubjects mSQLPassSubjects = new MSQLPassSubjects(CONNECTSTRING);
            PassSubjects oldPassSubject = new PassSubjects(1, 1, 2, 1, 1);
            PassSubjects newPassSubject = new PassSubjects(1, 2, 4, 2, 2);
            Assert.IsTrue(mSQLPassSubjects.Update(oldPassSubject, newPassSubject));
        }
        [TestMethod]
        public void TestDelete()
        {
            MSQLPassSubjects mSQLPassSubjects = new MSQLPassSubjects(CONNECTSTRING);
            PassSubjects passSubject = new PassSubjects(3, 1, 2, 1, 1);
            Assert.IsTrue(mSQLPassSubjects.Delete(passSubject));
        }
        [TestMethod]
        public void TestGetAllAssesmentForms()
        {
            MSQLPassSubjects mSQLPassSubjects = new MSQLPassSubjects(CONNECTSTRING);
            PassSubjects[] passSubjects =
            {
                new PassSubjects(1, 2, 4, 2, 2),
                new PassSubjects(2, 1, 2, 1, 1)
            };
            CollectionAssert.AreEqual(passSubjects, mSQLPassSubjects.GetAllPassSubjects());
        }
    }
}
