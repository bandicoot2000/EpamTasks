using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    /// <summary>
    /// Grade.
    /// </summary>
    public class Grades
    {
        /// <summary>
        /// Grade id.
        /// </summary>
        public int GradeId { get; set; }
        /// <summary>
        /// Pass subject id.
        /// </summary>
        public int PassSubjectId { get; set; }
        /// <summary>
        /// Student id.
        /// </summary>
        public int StudentId { get; set; }
        /// <summary>
        /// Grade value.
        /// </summary>
        public int Grade { get; set; }
        /// <summary>
        /// Constructor grade.
        /// </summary>
        /// <param name="gradeId">Grade id.</param>
        /// <param name="passSubjectId">Pass subject id.</param>
        /// <param name="studentId">Student id.</param>
        /// <param name="grade">Grade value.</param>
        public Grades(int gradeId, int passSubjectId, int studentId, int grade)
        {
            GradeId = gradeId;
            PassSubjectId = passSubjectId;
            StudentId = studentId;
            Grade = grade;
        }
        /// <summary>
        /// Override Equals.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>Result.</returns>
        public override bool Equals(object obj)
        {
            return obj is Grades grades &&
                   GradeId == grades.GradeId &&
                   PassSubjectId == grades.PassSubjectId &&
                   StudentId == grades.StudentId &&
                   Grade == grades.Grade;
        }
        /// <summary>
        /// Override GetHashCde.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            int hashCode = -450550793;
            hashCode = hashCode * -1521134295 + GradeId.GetHashCode();
            hashCode = hashCode * -1521134295 + PassSubjectId.GetHashCode();
            hashCode = hashCode * -1521134295 + StudentId.GetHashCode();
            hashCode = hashCode * -1521134295 + Grade.GetHashCode();
            return hashCode;
        }
        /// <summary>
        /// Override ToString.
        /// </summary>
        /// <returns>String Object.</returns>
        public override string ToString()
        {
            return GradeId + " " + PassSubjectId + " " + StudentId + " " + Grade;
        }
    }
}
