using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    public class PassSubjects
    {
        public int PassSubjectId { get; set; }
        public int GroupId { get; set; }
        public int SessionTypeId { get; set; }
        public int AssessmentFormId { get; set; }
        public int SubjectId { get; set; }
        public PassSubjects(int passSubjectId, int groupId, int sessionTypeId, int assessmentFormId, int subjectId)
        {
            PassSubjectId = passSubjectId;
            GroupId = groupId;
            SessionTypeId = sessionTypeId;
            AssessmentFormId = assessmentFormId;
            SubjectId = subjectId;
        }

        public override bool Equals(object obj)
        {
            return obj is PassSubjects subjects &&
                   PassSubjectId == subjects.PassSubjectId &&
                   GroupId == subjects.GroupId &&
                   SessionTypeId == subjects.SessionTypeId &&
                   AssessmentFormId == subjects.AssessmentFormId &&
                   SubjectId == subjects.SubjectId;
        }

        public override int GetHashCode()
        {
            int hashCode = 395968906;
            hashCode = hashCode * -1521134295 + PassSubjectId.GetHashCode();
            hashCode = hashCode * -1521134295 + GroupId.GetHashCode();
            hashCode = hashCode * -1521134295 + SessionTypeId.GetHashCode();
            hashCode = hashCode * -1521134295 + AssessmentFormId.GetHashCode();
            hashCode = hashCode * -1521134295 + SubjectId.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return PassSubjectId + " " + GroupId + " " + SessionTypeId + " " + AssessmentFormId + " " + SubjectId;
        }
    }
}
