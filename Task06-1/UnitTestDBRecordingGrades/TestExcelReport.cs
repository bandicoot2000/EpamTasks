using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBRecordingGrades;

namespace UnitTestDBRecordingGrades
{
    [TestClass]
    public class TestExcelReport
    {
        private const string CONNECTSTRING = @"Data Source=.\SQLEXPRESS;Initial Catalog = AcademicYear2020; Integrated Security = True";

        [TestMethod]
        public void TestSessionReport()
        {
            Assert.IsTrue( ExcelReport.SessionsReport(CONNECTSTRING, SortType.Name));
        }

        [TestMethod]
        public void GetSummaryTable()
        {
            Assert.IsTrue(ExcelReport.GetSummaryTable(CONNECTSTRING));
        }
    }
}
