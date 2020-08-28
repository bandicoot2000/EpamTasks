using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    public class Grades
    {
        public int GradeId { get; set; }
        public int PassSubjectId { get; set; }
        public int StudentId { get; set; }
        public int Grade { get; set; }
        public Grades(int gradeId, int passSubjectId, int studentId, int grade)
        {
            GradeId = gradeId;
            PassSubjectId = passSubjectId;
            StudentId = studentId;
            Grade = grade;
        }

        public override bool Equals(object obj)
        {
            return obj is Grades grades &&
                   GradeId == grades.GradeId &&
                   PassSubjectId == grades.PassSubjectId &&
                   StudentId == grades.StudentId &&
                   Grade == grades.Grade;
        }

        public override int GetHashCode()
        {
            int hashCode = -450550793;
            hashCode = hashCode * -1521134295 + GradeId.GetHashCode();
            hashCode = hashCode * -1521134295 + PassSubjectId.GetHashCode();
            hashCode = hashCode * -1521134295 + StudentId.GetHashCode();
            hashCode = hashCode * -1521134295 + Grade.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return GradeId + " " + PassSubjectId + " " + StudentId + " " + Grade;
        }
    }
}
