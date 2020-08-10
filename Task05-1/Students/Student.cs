using System;
using System.Collections.Generic;

namespace Students
{
    /// <summary>
    /// Student test data.
    /// </summary>
    [Serializable]
    public class StudentTest : IComparable
    {
        /// <summary>
        /// Student name.
        /// </summary>
        public string StudentName { get; set; }
        /// <summary>
        /// Test name.
        /// </summary>
        public string TestName { get; set; }
        /// <summary>
        /// Test date.
        /// </summary>
        public DateTime TestDate { get; set; }
        /// <summary>
        /// Test score.
        /// </summary>
        public int TestScore { get; set; }

        /// <summary>
        /// Create student test.
        /// </summary>
        /// <param name="studentName">Student name.</param>
        /// <param name="testName">Test name.</param>
        /// <param name="testDate">Test date.</param>
        /// <param name="testScore">Test score.</param>
        public StudentTest(string studentName, string testName, DateTime testDate, int testScore)
        {
            StudentName = studentName;
            TestName = testName;
            TestDate = testDate;
            TestScore = testScore;
        }

        /// <summary>
        /// Create student test.
        /// </summary>
        public StudentTest()
        {
            StudentName = null;
            TestName = null;
            TestDate = default(DateTime);
            TestScore = 0;
        }
        /// <summary>
        /// Compare to object.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>Result.</returns>
        public int CompareTo(object obj)
        {
            if (obj is StudentTest)
                return TestScore.CompareTo(((StudentTest)obj).TestScore);
            else
                throw new ArgumentException("The object must have the type StudentTest.");
        }

        /// <summary>
        /// Determines whether two objects are equal.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>Result.</returns>
        public override bool Equals(object obj)
        {
            return obj is StudentTest test &&
                   StudentName == test.StudentName &&
                   TestName == test.TestName &&
                   TestDate == test.TestDate &&
                   TestScore == test.TestScore;
        }
        /// <summary>
        /// Get object hash code.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            int hashCode = 369593031;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(StudentName);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(TestName);
            hashCode = hashCode * -1521134295 + TestDate.GetHashCode();
            hashCode = hashCode * -1521134295 + TestScore.GetHashCode();
            return hashCode;
        }
        /// <summary>
        /// Convert object to string.
        /// </summary>
        /// <returns>Result.</returns>
        public override string ToString()
        {
            return StudentName + " " + TestName + " " + TestDate.ToString() + " " + TestScore;
        }
    }
}
