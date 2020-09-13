using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace DBRecordingGrades
{
    /// <summary>
    /// Subject.
    /// </summary> 
    [Table(Name = "Subjects")]
    public class Subjects
    {
        /// <summary>
        /// Subject id.
        /// </summary>
        [Column(Name = "SubjectId", IsPrimaryKey = true, IsDbGenerated = true)]
        public int SubjectId { get; set; }
        /// <summary>
        /// Subject name.
        /// </summary>
        [Column(Name = "SubjectName")]
        public string SubjectName { get; set; }
        /// <summary>
        /// Constructor subject.
        /// </summary>
        /// <param name="subjectId">Subject id.</param>
        /// <param name="subjectName">Subject name.</param>
        public Subjects(int subjectId, string subjectName)
        {
            SubjectId = subjectId;
            SubjectName = subjectName;
        }

        /// <summary>
        /// Override Equals.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>Result.</returns>
        public override bool Equals(object obj)
        {
            return obj is Subjects subjects &&
                   SubjectId == subjects.SubjectId &&
                   SubjectName == subjects.SubjectName;
        }
        /// <summary>
        /// Override GetHashCde.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            int hashCode = -830864098;
            hashCode = hashCode * -1521134295 + SubjectId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SubjectName);
            return hashCode;
        }
        /// <summary>
        /// Override ToString.
        /// </summary>
        /// <returns>String Object.</returns>
        public override string ToString()
        {
            return SubjectId + " " + SubjectName;
        }
    }
}
