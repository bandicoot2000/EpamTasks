using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBRecordingGrades;

namespace UnitTestDBRecordingGrades
{
    [TestClass]
    public class TestExcelReport
    {
        private const string CONNECTSTRING = @"Data Source=.\SQLEXPRESS;Initial Catalog = AcademicYear2020_t7; Integrated Security = True";

        [TestMethod]
        public void TestSessionReport()
        {
            Assert.IsTrue( ExcelReport.SessionsReport(CONNECTSTRING, SortType.Name));
        }

        [TestMethod]
        public void TestGetSummaryTable()
        {
            Assert.IsTrue(ExcelReport.GetSummaryTable(CONNECTSTRING));
        }

        [TestMethod]
        public void TestGetSpecializationTable()
        {
            Assert.IsTrue(ExcelReport.GetSpecializationTable(CONNECTSTRING));
        }

        [TestMethod]
        public void TestGetExaminatorTable()
        {
            Assert.IsTrue(ExcelReport.GetExaminatorTable(CONNECTSTRING));
        }
    }
}
