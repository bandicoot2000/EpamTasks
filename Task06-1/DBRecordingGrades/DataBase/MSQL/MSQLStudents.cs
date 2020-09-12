using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    /// <summary>
    /// MSQL students connection.
    /// </summary>
    public class MSQLStudents : IStudents
    {
        private const string DELETE_STUDENT
            = "DELETE FROM Students WHERE StudentId = @studentId";
        private const string GET_ALL_STUDENTS
            = "SELECT * FROM Students";
        private const string INSERT_STUDENT
            = "INSERT INTO Students(SecondName, FirstName, MiddleName, Gender, Birthday, GroupId) VALUES (@secondName, @firstName, @middleName, @gender, @birthday, @groupId)";
        private const string UPDATE_STUDENT
            = "UPDATE Students SET SecondName = @secondName, FirstName = @firstName, MiddleName = @middleName, Gender = @gender, Birthday = @birthday, GroupId = @groupId WHERE StudentId = @studentId";
        
        private string connectString;

        /// <summary>
        /// Constructor MSQLStudents.
        /// </summary>
        /// <param name="connectString">Connection.</param>
        public MSQLStudents(string connectString)
        {
            this.connectString = connectString;
        }
        /// <summary>
        /// Delete Students.
        /// </summary>
        /// <param name="student">Students.</param>
        /// <returns>Successful completion method.</returns>
        public bool Delete(Students student)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(DELETE_STUDENT, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@studentId", student.StudentId));
                return sqlCommand.ExecuteNonQuery() > 0;
            }
        }
        /// <summary>
        /// Get All Students in DB.
        /// </summary>
        /// <returns>All Students.</returns>
        public Students[] GetAllStudents()
        {
            List<Students> assessmentForms = new List<Students>();
            using (SqlConnection sqlConnection = new SqlConnection(connectString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(GET_ALL_STUDENTS, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                    while (sqlDataReader.Read())
                    {
                        assessmentForms.Add(new Students(
                        sqlDataReader.GetInt32(0),
                        sqlDataReader.GetString(1),
                        sqlDataReader.GetString(2),
                        sqlDataReader.GetString(3),
                        sqlDataReader.GetString(4),
                        sqlDataReader.GetDateTime(5),
                        sqlDataReader.GetInt32(6)
                        ));
                    }
            }
            return assessmentForms.ToArray();
        }
        /// <summary>
        /// Insert Students.
        /// </summary>
        /// <param name="student">Students.</param>
        /// <returns>Successful completion method.</returns>
        public bool Insert(Students student)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(INSERT_STUDENT, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@secondName", student.SecondName));
                sqlCommand.Parameters.Add(new SqlParameter("@firstName", student.FirstName));
                sqlCommand.Parameters.Add(new SqlParameter("@middleName", student.MiddleName));
                sqlCommand.Parameters.Add(new SqlParameter("@gender", student.Gender));
                sqlCommand.Parameters.Add(new SqlParameter("@birthday", student.Birthday));
                sqlCommand.Parameters.Add(new SqlParameter("@groupId", student.GroupId));
                return sqlCommand.ExecuteNonQuery() > 0;
            }
        }
        /// <summary>
        /// Update Students.
        /// </summary>
        /// <param name="oldStudent">Old Students.</param>
        /// <param name="newStudent">New Students.</param>
        /// <returns>Successful completion method.</returns>
        public bool Update(Students oldStudent, Students newStudent)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(UPDATE_STUDENT, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@studentId", oldStudent.StudentId));
                sqlCommand.Parameters.Add(new SqlParameter("@secondName", newStudent.SecondName));
                sqlCommand.Parameters.Add(new SqlParameter("@firstName", newStudent.FirstName));
                sqlCommand.Parameters.Add(new SqlParameter("@middleName", newStudent.MiddleName));
                sqlCommand.Parameters.Add(new SqlParameter("@gender", newStudent.Gender));
                sqlCommand.Parameters.Add(new SqlParameter("@birthday", newStudent.Birthday));
                sqlCommand.Parameters.Add(new SqlParameter("@groupId", newStudent.GroupId));
                return sqlCommand.ExecuteNonQuery() > 0;
            }
        }
    }
}
