using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    /// <summary>
    /// Pass subject.
    /// </summary>
    [Table(Name = "PassSubjects")]
    public class PassSubjects
    {
        /// <summary>
        /// Pass subject id.
        /// </summary>
        [Column(Name = "PassSubjectId", IsPrimaryKey = true, IsDbGenerated = true)]
        public int PassSubjectId { get; set; }
        /// <summary>
        /// Group id.
        /// </summary>
        [Column(Name = "GroupId")]
        public int GroupId { get; set; }
        /// <summary>
        /// Session type id.
        /// </summary>
        [Column(Name = "SessionTypeId")]
        public int SessionTypeId { get; set; }
        /// <summary>
        /// Assesment form id.
        /// </summary>
        [Column(Name = "AssessmentFormId")]
        public int AssessmentFormId { get; set; }
        /// <summary>
        /// Subject id.
        /// </summary>
        [Column(Name = "SubjectId")]
        public int SubjectId { get; set; }
        /// <summary>
        /// Examinator.
        /// </summary>
        [Column(Name = "Examinator")]
        public string Examinator { get; set; }
        /// <summary>
        /// Constructor pass subject.
        /// </summary>
        /// <param name="passSubjectId">Pass subject id.</param>
        /// <param name="groupId">Group id.</param>
        /// <param name="sessionTypeId">Session type id.</param>
        /// <param name="assessmentFormId">Assesment form id.</param>
        /// <param name="subjectId">Subject id.</param>
        /// <param name="examinator">Pass subject examinator.</param>
        public PassSubjects(int passSubjectId, int groupId, int sessionTypeId, int assessmentFormId, int subjectId, string examinator)
        {
            PassSubjectId = passSubjectId;
            GroupId = groupId;
            SessionTypeId = sessionTypeId;
            AssessmentFormId = assessmentFormId;
            SubjectId = subjectId;
            Examinator = examinator;
        }
        /// <summary>
        /// Override Equals.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>Result.</returns>
        public override bool Equals(object obj)
        {
            return obj is PassSubjects subjects &&
                   PassSubjectId == subjects.PassSubjectId &&
                   GroupId == subjects.GroupId &&
                   SessionTypeId == subjects.SessionTypeId &&
                   AssessmentFormId == subjects.AssessmentFormId &&
                   SubjectId == subjects.SubjectId;
        }
        /// <summary>
        /// Override GetHashCde.
        /// </summary>
        /// <returns>Hash code.</returns>
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
        /// <summary>
        /// Override ToString.
        /// </summary>
        /// <returns>String Object.</returns>
        public override string ToString()
        {
            return PassSubjectId + " " + GroupId + " " + SessionTypeId + " " + AssessmentFormId + " " + SubjectId;
        }
    }
}
