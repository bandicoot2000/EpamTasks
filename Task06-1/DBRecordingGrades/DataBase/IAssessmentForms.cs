using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    /// <summary>
    /// DAO IAssessmentForms interface.
    /// </summary>
    public interface IAssessmentForms
    {
        /// <summary>
        /// Insert AssessmentForms.
        /// </summary>
        /// <param name="assessmentForm">AssessmentForms.</param>
        /// <returns>Successful completion method.</returns>
        bool Insert(AssessmentForms assessmentForm);
        /// <summary>
        /// Update AssessmentForms.
        /// </summary>
        /// <param name="oldAssessmentForm">Old AssessmentForms.</param>
        /// <param name="newAssessmentForm">New AssessmentForms.</param>
        /// <returns>Successful completion method.</returns>
        bool Update(AssessmentForms oldAssessmentForm, AssessmentForms newAssessmentForm);
        /// <summary>
        /// Delete AssessmentForms.
        /// </summary>
        /// <param name="assessmentForm">AssessmentForms.</param>
        /// <returns>Successful completion method.</returns>
        bool Delete(AssessmentForms assessmentForm);
        /// <summary>
        /// Get all AssessmentForms in DB.
        /// </summary>
        /// <returns>All AssessmentForms.</returns>
        AssessmentForms[] GetAllAssessmentForms();
    }
}
