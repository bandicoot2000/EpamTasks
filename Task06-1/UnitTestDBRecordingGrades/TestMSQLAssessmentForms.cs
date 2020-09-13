using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DBRecordingGrades;

namespace UnitTestDBRecordingGrades
{
    [TestClass]
    public class TestMSQLAssessmentForms
    {
        private const string CONNECTSTRING = @"Data Source=.\SQLEXPRESS;Initial Catalog = AcademicYear2020_t7; Integrated Security = True";

        [TestMethod]
        public void Test1Insert()
        {
            MSQLAssessmentForms mSQLAssessmentForms = new MSQLAssessmentForms(CONNECTSTRING);
            AssessmentForms assessmentForm = new AssessmentForms(1, "Exem");
            Assert.IsTrue(mSQLAssessmentForms.Insert(assessmentForm));
        }
        [TestMethod]
        public void Test2Update()
        {
            MSQLAssessmentForms mSQLAssessmentForms = new MSQLAssessmentForms(CONNECTSTRING);
            AssessmentForms oldAssessmentForm = new AssessmentForms(1, "Exem");
            AssessmentForms newAssessmentForm = new AssessmentForms(1, "Test");
            Assert.IsTrue(mSQLAssessmentForms.Update(oldAssessmentForm, newAssessmentForm));
        }
        [TestMethod]
        public void Test4Delete()
        {
            MSQLAssessmentForms mSQLAssessmentForms = new MSQLAssessmentForms(CONNECTSTRING);
            AssessmentForms assessmentForm = new AssessmentForms(1, null);
            Assert.IsTrue(mSQLAssessmentForms.Delete(assessmentForm));
        }
        [TestMethod]
        public void Test3GetAllAssesmentForms()
        {
            MSQLAssessmentForms mSQLAssessmentForms = new MSQLAssessmentForms(CONNECTSTRING);
            AssessmentForms[] assessmentForms =
            {
                new AssessmentForms(1, "Test"),
            };
            CollectionAssert.AreEqual(assessmentForms, mSQLAssessmentForms.GetAllAssessmentForms());
        }
    }
}
