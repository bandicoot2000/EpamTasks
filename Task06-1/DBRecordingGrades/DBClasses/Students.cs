using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    /// <summary>
    /// Student.
    /// </summary>
    public class Students
    {
        /// <summary>
        /// Student id.
        /// </summary>
        public int StudentId { get; set; }
        /// <summary>
        /// Second name.
        /// </summary>
        public string SecondName { get; set; }
        /// <summary>
        /// First name.
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Middle Name.
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// Gender Name.
        /// </summary>
        public string Gender { get; set; }
        /// <summary>
        /// Birthday.
        /// </summary>
        public DateTime Birthday { get; set; }
        /// <summary>
        /// Group id.
        /// </summary>
        public int GroupId { get; set; }
        /// <summary>
        /// Constructor student.
        /// </summary>
        /// <param name="studentId">Student id.</param>
        /// <param name="secondName">Second name.</param>
        /// <param name="firstName">First name.</param>
        /// <param name="middleName">Middle Name.</param>
        /// <param name="gender">Gender Name.</param>
        /// <param name="birthday">Birthday.</param>
        /// <param name="groupId">Group id.</param>
        public Students(int studentId, string secondName, string firstName, string middleName, string gender, DateTime birthday, int groupId)
        {
            StudentId = studentId;
            SecondName = secondName;
            FirstName = firstName;
            MiddleName = middleName;
            Gender = gender;
            Birthday = birthday;
            GroupId = groupId;
        }

        /// <summary>
        /// Override Equals.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>Result.</returns>
        public override bool Equals(object obj)
        {
            return obj is Students students &&
                   StudentId == students.StudentId &&
                   SecondName == students.SecondName &&
                   FirstName == students.FirstName &&
                   MiddleName == students.MiddleName &&
                   Gender == students.Gender &&
                   Birthday == students.Birthday &&
                   GroupId == students.GroupId;
        }
        /// <summary>
        /// Override GetHashCde.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            int hashCode = 334590149;
            hashCode = hashCode * -1521134295 + StudentId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SecondName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FirstName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(MiddleName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Gender);
            hashCode = hashCode * -1521134295 + Birthday.GetHashCode();
            hashCode = hashCode * -1521134295 + GroupId.GetHashCode();
            return hashCode;
        }
        /// <summary>
        /// Override ToString.
        /// </summary>
        /// <returns>String Object.</returns>
        public override string ToString()
        {
            return StudentId + " " + SecondName + " " + FirstName + " " + MiddleName + " " + Gender + " " + Birthday + " " + GroupId;
        }
    }
}
