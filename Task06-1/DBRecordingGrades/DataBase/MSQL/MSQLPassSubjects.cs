using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    public class MSQLPassSubjects : IPassSubjects
    {
        private const string DELETE_PASSSUBJECT
            = "DELETE FROM PassSubjects WHERE PassSubjectId = @passSubjectId";
        private const string GET_ALL_PASSSUBJECTS
            = "SELECT * FROM PassSubjects";
        private const string INSERT_PASSSUBJECT
            = "INSERT INTO PassSubjects(GroupId, SessionTypeId, AssessmentFormId, SubjectId) VALUES (@groupId, @sessionTypeId, @assessmentFormId, @subjectId)";
        private const string UPDATE_PASSSUBJECT
            = "UPDATE PassSubjects SET GroupId = @groupId, SessionTypeId = @sessionTypeId, AssessmentFormId = @assessmentFormId, SubjectId = @subjectId WHERE PassSubjectId = @passSubjectId";


        private string connectString;
        public MSQLPassSubjects(string connectString)
        {
            this.connectString = connectString;
        }

        public bool Delete(PassSubjects passSubject)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(DELETE_PASSSUBJECT, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@passSubjectId", passSubject.PassSubjectId));
                return sqlCommand.ExecuteNonQuery() > 0;
            }
        }

        public PassSubjects[] GetAllPassSubjects()
        {
            List<PassSubjects> passSubjects = new List<PassSubjects>();
            using (SqlConnection sqlConnection = new SqlConnection(connectString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(GET_ALL_PASSSUBJECTS, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                    while (sqlDataReader.Read())
                    {
                        passSubjects.Add(new PassSubjects(
                        sqlDataReader.GetInt32(0),
                        sqlDataReader.GetInt32(1),
                        sqlDataReader.GetInt32(2),
                        sqlDataReader.GetInt32(3),
                        sqlDataReader.GetInt32(4)
                        ));
                    }
            }
            return passSubjects.ToArray();
        }

        public bool Insert(PassSubjects passSubject)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(INSERT_PASSSUBJECT, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@groupId", passSubject.GroupId));
                sqlCommand.Parameters.Add(new SqlParameter("@sessionTypeId", passSubject.SessionTypeId));
                sqlCommand.Parameters.Add(new SqlParameter("@assessmentFormId", passSubject.AssessmentFormId));
                sqlCommand.Parameters.Add(new SqlParameter("@subjectId", passSubject.SubjectId));
                return sqlCommand.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(PassSubjects oldPassSubject, PassSubjects newPassSubject)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(UPDATE_PASSSUBJECT, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@passSubjectId", oldPassSubject.PassSubjectId));
                sqlCommand.Parameters.Add(new SqlParameter("@groupId", newPassSubject.GroupId));
                sqlCommand.Parameters.Add(new SqlParameter("@sessionTypeId", newPassSubject.SessionTypeId));
                sqlCommand.Parameters.Add(new SqlParameter("@assessmentFormId", newPassSubject.AssessmentFormId));
                sqlCommand.Parameters.Add(new SqlParameter("@subjectId", newPassSubject.SubjectId));
                return sqlCommand.ExecuteNonQuery() > 0;
            }
        }
    }
}
