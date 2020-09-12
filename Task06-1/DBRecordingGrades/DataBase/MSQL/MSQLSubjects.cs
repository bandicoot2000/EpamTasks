using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    /// <summary>
    /// MSQL subjects connection.
    /// </summary>
    public class MSQLSubject : ISubjects
    {
        private const string DELETE_SUBJECT
            = "DELETE FROM Subjects WHERE SubjectId = @subjectId";
        private const string GET_ALL_SUBJECTS
            = "SELECT * FROM Subjects";
        private const string INSERT_SUBJECT
            = "INSERT INTO Subjects(SubjectName) VALUES (@subjectName)";
        private const string UPDATE_SUBJECT
            = "UPDATE Subjects SET SubjectName = @subjectName WHERE SubjectId = @subjectId";

        private string connectString;
        /// <summary>
        /// Constructor MSQLSubject.
        /// </summary>
        /// <param name="connectString">Connection.</param>
        public MSQLSubject(string connectString)
        {
            this.connectString = connectString;
        }
        /// <summary>
        /// Delete Subjects.
        /// </summary>
        /// <param name="subject">Subjects.</param>
        /// <returns>Successful completion method.</returns>
        public bool Delete(Subjects subject)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(DELETE_SUBJECT, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@subjectId", subject.SubjectId));
                return sqlCommand.ExecuteNonQuery() > 0;
            }
        }
        /// <summary>
        /// Get All Subjects in DB.
        /// </summary>
        /// <returns>All Subjects.</returns>
        public Subjects[] GetAllSubjects()
        {
            List<Subjects> subjects = new List<Subjects>();
            using (SqlConnection sqlConnection = new SqlConnection(connectString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(GET_ALL_SUBJECTS, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                    while (sqlDataReader.Read())
                    {
                        subjects.Add(new Subjects(
                        sqlDataReader.GetInt32(0),
                        sqlDataReader.GetString(1)
                        ));
                    }
            }
            return subjects.ToArray();
        }
        /// <summary>
        /// Insert Subjects.
        /// </summary>
        /// <param name="subject">Subjects.</param>
        /// <returns>Successful completion method.</returns>
        public bool Insert(Subjects subject)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(INSERT_SUBJECT, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@subjectName", subject.SubjectName));
                return sqlCommand.ExecuteNonQuery() > 0;
            }
        }
        /// <summary>
        /// Update Subjects.
        /// </summary>
        /// <param name="oldSubject">Old Subjects.</param>
        /// <param name="newSubject">New Subjects.</param>
        /// <returns>Successful completion method.</returns>
        public bool Update(Subjects oldSubject, Subjects newSubject)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(UPDATE_SUBJECT, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@subjectId", oldSubject.SubjectId));
                sqlCommand.Parameters.Add(new SqlParameter("@subjectName", newSubject.SubjectName));
                return sqlCommand.ExecuteNonQuery() > 0;
            }
        }
    }
}
