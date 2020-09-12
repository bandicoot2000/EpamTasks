using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    /// <summary>
    /// Assessmet Form Class;
    /// </summary>
    [Table(Name = "AssessmentForms")]
    public class AssessmentForms
    {
        /// <summary>
        /// Assessment form Id.
        /// </summary>
        [Column(Name = "AssessmentFormId", IsPrimaryKey = true, IsDbGenerated = true)]
        public int AssessmentFormId { get; set; }
        /// <summary>
        /// Assesment form Name.
        /// </summary>
        [Column(Name = "AssessmentFormName")]
        public string AssessmentFormName { get; set; }

        /// <summary>
        /// Constructor assessment form.
        /// </summary>
        /// <param name="assessmentFormId">Assessment form Id.</param>
        /// <param name="assessmentFormName">Assesment form Name.</param>
        public AssessmentForms(int assessmentFormId, string assessmentFormName)
        {
            AssessmentFormId = assessmentFormId;
            AssessmentFormName = assessmentFormName;
        }
        /// <summary>
        /// Override Equals.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>Result.</returns>
        public override bool Equals(object obj)
        {
            return obj is AssessmentForms forms &&
                   AssessmentFormId == forms.AssessmentFormId &&
                   AssessmentFormName == forms.AssessmentFormName;
        }
        /// <summary>
        /// Override GetHashCde.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            int hashCode = -970172954;
            hashCode = hashCode * -1521134295 + AssessmentFormId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AssessmentFormName);
            return hashCode;
        }
        /// <summary>
        /// Override ToString.
        /// </summary>
        /// <returns>String Object.</returns>
        public override string ToString()
        {
            return AssessmentFormId + " " + AssessmentFormName;
        }
    }
}
