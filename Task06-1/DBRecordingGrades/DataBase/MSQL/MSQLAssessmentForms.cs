﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    public class MSQLAssessmentForms : IAssessmentForms
    {
        private const string DELETE_ASSESSMENTFORM
            = "DELETE FROM AssessmentForms WHERE AssessmentFormId = @assessmentFormId";
        private const string GET_ALL_ASSESSMENTFORMS 
            = "SELECT * FROM AssessmentForms";
        private const string INSERT_ASSESSMENTFORM
            = "INSERT INTO AssessmentForms(AssessmentFormName) VALUES (@assessmentFormName)";
        private const string UPDATE_ASSESSMENTFORM 
            = "UPDATE AssessmentForms SET AssessmentFormName = @assessmentFormName WHERE AssessmentFormId = @assessmentFormId";

        private string connectString;
        public MSQLAssessmentForms(string connectString)
        {
            this.connectString = connectString;
        }

        public bool Delete(AssessmentForms assessmentForm)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(DELETE_ASSESSMENTFORM, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@assessmentFormId", assessmentForm.AssessmentFormId));
                return sqlCommand.ExecuteNonQuery() > 0;
            }
        }

        public AssessmentForms[] GetAllAssessmentForms()
        {
            List<AssessmentForms> assessmentForms = new List<AssessmentForms>();
            using (SqlConnection sqlConnection = new SqlConnection(connectString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(GET_ALL_ASSESSMENTFORMS, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                    while (sqlDataReader.Read())
                    {
                        assessmentForms.Add(new AssessmentForms(
                        sqlDataReader.GetInt32(0),
                        sqlDataReader.GetString(1)
                        ));
                    }
            }
            return assessmentForms.ToArray();
        }

        public bool Insert(AssessmentForms assessmentForm)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(INSERT_ASSESSMENTFORM, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@assessmentFormName", assessmentForm.AssessmentFormName));
                return sqlCommand.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(AssessmentForms oldAssessmentForm, AssessmentForms newAssessmentForm)
        {
            using(SqlConnection sqlConnection = new SqlConnection(connectString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(UPDATE_ASSESSMENTFORM, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@assessmentFormId", oldAssessmentForm.AssessmentFormId));
                sqlCommand.Parameters.Add(new SqlParameter("@assessmentFormName", newAssessmentForm.AssessmentFormName));
                return sqlCommand.ExecuteNonQuery() > 0;
            }
        }
    }
}