using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    /// <summary>
    /// MSQL assesment form connection.
    /// </summary>
    public class MSQLAssessmentForms : IAssessmentForms
    {
        private DataContext dataContext;
        /// <summary>
        /// Constructor MSQLAssessmentForms.
        /// </summary>
        /// <param name="connectString">Connection.</param>
        public MSQLAssessmentForms(string connectString)
        {
            dataContext = new DataContext(connectString);
        }
        /// <summary>
        /// Delete AssessmentForms.
        /// </summary>
        /// <param name="assessmentForm">AssessmentForms.</param>
        /// <returns>Successful completion method.</returns>
        public bool Delete(AssessmentForms assessmentForm)
        {
            dataContext.GetTable<AssessmentForms>().DeleteOnSubmit(dataContext.GetTable<AssessmentForms>().Where(form => form.AssessmentFormId == assessmentForm.AssessmentFormId).First());
            dataContext.SubmitChanges();
            return true;
        }
        /// <summary>
        /// Get all AssessmentForms in DB.
        /// </summary>
        /// <returns>All AssessmentForms.</returns>
        public AssessmentForms[] GetAllAssessmentForms()
        {
            return dataContext.GetTable<AssessmentForms>().ToArray();
        }
        /// <summary>
        /// Insert AssessmentForms.
        /// </summary>
        /// <param name="assessmentForm">AssessmentForms.</param>
        /// <returns>Successful completion method.</returns>
        public bool Insert(AssessmentForms assessmentForm)
        {
            dataContext.GetTable<AssessmentForms>().InsertOnSubmit(assessmentForm);
            dataContext.SubmitChanges();
            return true;
        }
        /// <summary>
        /// Update AssessmentForms.
        /// </summary>
        /// <param name="oldAssessmentForm">Old AssessmentForms.</param>
        /// <param name="newAssessmentForm">New AssessmentForms.</param>
        /// <returns>Successful completion method.</returns>
        public bool Update(AssessmentForms oldAssessmentForm, AssessmentForms newAssessmentForm)
        {
            var query = from assessmentForms in dataContext.GetTable<AssessmentForms>()
                        where assessmentForms.AssessmentFormId == oldAssessmentForm.AssessmentFormId
                        select assessmentForms;
            AssessmentForms updateAssessmentForm = query.First();
            updateAssessmentForm.AssessmentFormName = newAssessmentForm.AssessmentFormName;
            dataContext.SubmitChanges();
            return true;
        }
    }
}
