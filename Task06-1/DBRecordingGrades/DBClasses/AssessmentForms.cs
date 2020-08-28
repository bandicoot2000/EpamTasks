using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    public class AssessmentForms
    {
        public int AssessmentFormId { get; set; }
        public string AssessmentFormName { get; set; }
        public AssessmentForms(int assessmentFormId, string assessmentFormName)
        {
            AssessmentFormId = assessmentFormId;
            AssessmentFormName = assessmentFormName;
        }

        public override bool Equals(object obj)
        {
            return obj is AssessmentForms forms &&
                   AssessmentFormId == forms.AssessmentFormId &&
                   AssessmentFormName == forms.AssessmentFormName;
        }

        public override int GetHashCode()
        {
            int hashCode = -970172954;
            hashCode = hashCode * -1521134295 + AssessmentFormId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(AssessmentFormName);
            return hashCode;
        }

        public override string ToString()
        {
            return AssessmentFormId + " " + AssessmentFormName;
        }
    }
}
