using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBRecordingGrades;

namespace UnitTestDBRecordingGrades
{
    [TestClass]
    public class TestMSQLGroups
    {
        private const string CONNECTSTRING = @"Data Source=.\SQLEXPRESS;Initial Catalog = AcademicYear2020_t7; Integrated Security = True";

        [TestMethod]
        public void Test1Insert()
        {
            MSQLGroups mSQLGroups = new MSQLGroups(CONNECTSTRING);
            Groups group = new Groups(1, "ITI", "Specializitoin");
            Assert.IsTrue(mSQLGroups.Insert(group));
        }
        [TestMethod]
        public void Test2Update()
        {
            MSQLGroups mSQLGroups = new MSQLGroups(CONNECTSTRING);
            Groups oldGroup = new Groups(1, "ITI", "Specializitoin");
            Groups newGroup = new Groups(1, "ITP", "1Specializitoin");
            Assert.IsTrue(mSQLGroups.Update(oldGroup, newGroup));
        }
        [TestMethod]
        public void Test4Delete()
        {
            MSQLGroups mSQLGroups = new MSQLGroups(CONNECTSTRING);
            Groups group = new Groups(1, "ITI", "Specializitoin");
            Assert.IsTrue(mSQLGroups.Delete(group));
        }
        [TestMethod]
        public void Test3GetAllGroups()
        {
            MSQLGroups mSQLGroups = new MSQLGroups(CONNECTSTRING);
            Groups[] groups =
            {
                new Groups(1, "ITI", "Specializitoin")
            };
            CollectionAssert.AreEqual(groups, mSQLGroups.GetAllGroups());
        }
    }
}
