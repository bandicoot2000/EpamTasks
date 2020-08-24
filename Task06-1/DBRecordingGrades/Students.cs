using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    public class Students
    {
        public int StudentId { get; set; }
        public string SecondName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public int GroupId { get; set; }
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

        public override string ToString()
        {
            return StudentId + " " + SecondName + " " + FirstName + " " + MiddleName + " " + Gender + " " + Birthday + " " + GroupId;
        }
    }
}
