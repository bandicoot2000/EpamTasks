using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ISerializeClasses
{
    /// <summary>
    /// Student test data.
    /// </summary>
    [Serializable]
    public class StudentTestISerializable : ISerializable
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
        public StudentTestISerializable(string studentName, string testName, DateTime testDate, int testScore)
        {
            StudentName = studentName;
            TestName = testName;
            TestDate = testDate;
            TestScore = testScore;
        }

        /// <summary>
        /// Create student test.
        /// </summary>
        public StudentTestISerializable()
        {
            StudentName = null;
            TestName = null;
            TestDate = default;
            TestScore = 0;
        }

        /// <summary>
        /// Create student test.
        /// </summary>
        /// <param name="info">Serialization Info.</param>
        /// <param name="context">Context.</param>
        public StudentTestISerializable(SerializationInfo info, StreamingContext context)
        {
            StudentName = (string)info.GetValue("StudentName", typeof(string));
            TestName = (string)info.GetValue("TestName", typeof(string));
            TestDate = (DateTime)info.GetValue("TestDate", typeof(DateTime));
            TestScore = (int)info.GetValue("TestScore", typeof(int));
        }

        /// <summary>
        /// Get object data.
        /// </summary>
        /// <param name="info">Serialization Info.</param>
        /// <param name="context">Context.</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("StudentName", StudentName);
            info.AddValue("TestName", TestName);
            info.AddValue("TestDate", TestDate);
            info.AddValue("TestScore", TestScore);
        }

        /// <summary>
        /// Determines whether two objects are equal.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>Result.</returns>
        public override bool Equals(object obj)
        {
            return obj is StudentTestISerializable test &&
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
