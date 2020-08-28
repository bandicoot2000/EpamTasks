using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBRecordingGrades;

namespace UnitTestDBRecordingGrades
{
    [TestClass]
    public class TestMSQLGroups
    {
        private const string CONNECTSTRING = @"Data Source=.\SQLEXPRESS;Initial Catalog = AcademicYear2020; Integrated Security = True";

        [TestMethod]
        public void TestInsert()
        {
            MSQLGroups mSQLGroups = new MSQLGroups(CONNECTSTRING);
            Groups group = new Groups(1, "ITI");
            Assert.IsTrue(mSQLGroups.Insert(group));
        }
        [TestMethod]
        public void TestUpdate()
        {
            MSQLGroups mSQLGroups = new MSQLGroups(CONNECTSTRING);
            Groups oldGroup = new Groups(1, "ITI");
            Groups newGroup = new Groups(1, "ITP");
            Assert.IsTrue(mSQLGroups.Update(oldGroup, newGroup));
        }
        [TestMethod]
        public void TestDelete()
        {
            MSQLGroups mSQLGroups = new MSQLGroups(CONNECTSTRING);
            Groups group = new Groups(3, null);
            Assert.IsTrue(mSQLGroups.Delete(group));
        }
        [TestMethod]
        public void TestGetAllGroups()
        {
            MSQLGroups mSQLGroups = new MSQLGroups(CONNECTSTRING);
            Groups[] groups =
            {
                new Groups(1, "ITP"),
                new Groups(2, "ITI")
            };
            CollectionAssert.AreEqual(groups, mSQLGroups.GetAllGroups());
        }
    }
}
