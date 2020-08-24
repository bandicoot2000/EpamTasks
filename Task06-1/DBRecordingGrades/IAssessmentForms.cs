using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    public interface IAssessmentForms
    {
        bool Insert(AssessmentForms assessmentForm);
        bool Update(AssessmentForms oldAssessmentForm, AssessmentForms newAssessmentForm);
        bool Delete(AssessmentForms assessmentForm);
        AssessmentForms[] GetAllAssessmentForms();
    }
}
