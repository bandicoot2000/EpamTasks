using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
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
        public MSQLSubject(string connectString)
        {
            this.connectString = connectString;
        }

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
