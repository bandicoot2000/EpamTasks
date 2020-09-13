using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBRecordingGrades;

namespace UnitTestDBRecordingGrades
{
    [TestClass]
    public class TestMSQLSessionTypes
    {
        private const string CONNECTSTRING = @"Data Source=.\SQLEXPRESS;Initial Catalog = AcademicYear2020_t7; Integrated Security = True";

        [TestMethod]
        public void Test1Insert()
        {
            MSQLSessionTypes mSQLSessionTypes = new MSQLSessionTypes(CONNECTSTRING);
            SessionTypes sessionType = new SessionTypes(1, "Summer");
            Assert.IsTrue(mSQLSessionTypes.Insert(sessionType));
        }
        [TestMethod]
        public void Test2Update()
        {
            MSQLSessionTypes mSQLSessionTypes = new MSQLSessionTypes(CONNECTSTRING);
            SessionTypes oldSessionType = new SessionTypes(1, "Summer");
            SessionTypes newSessionType = new SessionTypes(1, "Winter");
            Assert.IsTrue(mSQLSessionTypes.Update(oldSessionType, newSessionType));
        }
        [TestMethod]
        public void Test4Delete()
        {
            MSQLSessionTypes mSQLSessionTypes = new MSQLSessionTypes(CONNECTSTRING);
            SessionTypes sessionType = new SessionTypes(1, null);
            Assert.IsTrue(mSQLSessionTypes.Delete(sessionType));
        }
        [TestMethod]
        public void Test3GetAllSessionTypes()
        {
            MSQLSessionTypes mSQLSessionTypes = new MSQLSessionTypes(CONNECTSTRING);
            SessionTypes[] sessionTypes =
            {
                new SessionTypes(1, "Winter")
            };
            CollectionAssert.AreEqual(sessionTypes, mSQLSessionTypes.GetAllSessionTypes());
        }
    }
}
