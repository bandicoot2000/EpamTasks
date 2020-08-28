using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBRecordingGrades;

namespace UnitTestDBRecordingGrades
{
    [TestClass]
    public class TestMSQLAssessmentForms
    {
        private const string CONNECTSTRING = @"Data Source=.\SQLEXPRESS;Initial Catalog = AcademicYear2020; Integrated Security = True";

        [TestMethod]
        public void TestInsert()
        {
            MSQLAssessmentForms mSQLAssessmentForms = new MSQLAssessmentForms(CONNECTSTRING);
            AssessmentForms assessmentForm = new AssessmentForms(1, "Exem");
            Assert.IsTrue(mSQLAssessmentForms.Insert(assessmentForm));
        }
        [TestMethod]
        public void TestUpdate()
        {
            MSQLAssessmentForms mSQLAssessmentForms = new MSQLAssessmentForms(CONNECTSTRING);
            AssessmentForms oldAssessmentForm = new AssessmentForms(1, "Exem");
            AssessmentForms newAssessmentForm = new AssessmentForms(1, "Test");
            Assert.IsTrue(mSQLAssessmentForms.Update(oldAssessmentForm, newAssessmentForm));
        }
        [TestMethod]
        public void TestDelete()
        {
            MSQLAssessmentForms mSQLAssessmentForms = new MSQLAssessmentForms(CONNECTSTRING);
            AssessmentForms assessmentForm = new AssessmentForms(3, null);
            Assert.IsTrue(mSQLAssessmentForms.Delete(assessmentForm));
        }
        [TestMethod]
        public void TestGetAllAssesmentForms()
        {
            MSQLAssessmentForms mSQLAssessmentForms = new MSQLAssessmentForms(CONNECTSTRING);
            AssessmentForms[] assessmentForms =
            {
                new AssessmentForms(1, "Test"),
                new AssessmentForms(2, "Exem")
            };
            CollectionAssert.AreEqual(assessmentForms, mSQLAssessmentForms.GetAllAssessmentForms());
        }
    }
}
