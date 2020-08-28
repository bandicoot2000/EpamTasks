using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    public class Subjects
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public Subjects(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        public override bool Equals(object obj)
        {
            return obj is Subjects subjects &&
                   SubjectId == subjects.SubjectId &&
                   SubjectName == subjects.SubjectName;
        }

        public override int GetHashCode()
        {
            int hashCode = -830864098;
            hashCode = hashCode * -1521134295 + SubjectId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SubjectName);
            return hashCode;
        }

        public override string ToString()
        {
            return SubjectId + " " + SubjectName;
        }
    }
}
