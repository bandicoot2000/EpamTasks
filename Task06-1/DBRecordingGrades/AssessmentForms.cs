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
    }
}
