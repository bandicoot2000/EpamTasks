using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBRecordingGrades;

namespace UnitTestDBRecordingGrades
{
    [TestClass]
    public class TestMSQLSessionTypes
    {
        private const string CONNECTSTRING = @"Data Source=.\SQLEXPRESS;Initial Catalog = AcademicYear2020; Integrated Security = True";

        [TestMethod]
        public void TestInsert()
        {
            MSQLSessionTypes mSQLSessionTypes = new MSQLSessionTypes(CONNECTSTRING);
            SessionTypes sessionType = new SessionTypes(1, "Summer");
            Assert.IsTrue(mSQLSessionTypes.Insert(sessionType));
        }
        [TestMethod]
        public void TestUpdate()
        {
            MSQLSessionTypes mSQLSessionTypes = new MSQLSessionTypes(CONNECTSTRING);
            SessionTypes oldSessionType = new SessionTypes(2, "Summer");
            SessionTypes newSessionType = new SessionTypes(2, "Winter");
            Assert.IsTrue(mSQLSessionTypes.Update(oldSessionType, newSessionType));
        }
        [TestMethod]
        public void TestDelete()
        {
            MSQLSessionTypes mSQLSessionTypes = new MSQLSessionTypes(CONNECTSTRING);
            SessionTypes sessionType = new SessionTypes(3, null);
            Assert.IsTrue(mSQLSessionTypes.Delete(sessionType));
        }
        [TestMethod]
        public void TestGetAllSessionTypes()
        {
            MSQLSessionTypes mSQLSessionTypes = new MSQLSessionTypes(CONNECTSTRING);
            SessionTypes[] sessionTypes =
            {
                new SessionTypes(2, "Winter"),
                new SessionTypes(4, "Summer")
            };
            CollectionAssert.AreEqual(sessionTypes, mSQLSessionTypes.GetAllSessionTypes());
        }
    }
}
