using System;
using System.Collections.Generic;

namespace Students
{
    public class StudentTest : IComparable
    {
        public string StudentName { get; private set; }
        public string TestName { get; private set; }
        public DateTime TestDate { get; private set; }
        public int TestScore { get; private set; }

        public StudentTest(string studentName, string testName, DateTime testDate, int testScore)
        {
            StudentName = studentName;
            TestName = testName;
            TestDate = testDate;
            TestScore = testScore;
        }

        public int CompareTo(object obj)
        {
            if (obj is StudentTest)
                return TestScore.CompareTo(((StudentTest)obj).TestScore);
            else
                throw new ArgumentException("The object must have the type StudentTest.");
        }

        public override bool Equals(object obj)
        {
            return obj is StudentTest test &&
                   StudentName == test.StudentName &&
                   TestName == test.TestName &&
                   TestDate == test.TestDate &&
                   TestScore == test.TestScore;
        }

        public override int GetHashCode()
        {
            int hashCode = 369593031;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(StudentName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TestName);
            hashCode = hashCode * -1521134295 + TestDate.GetHashCode();
            hashCode = hashCode * -1521134295 + TestScore.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return StudentName + " " + TestName + " " + TestDate.ToString() + " " + TestScore;
        }
    }
}
