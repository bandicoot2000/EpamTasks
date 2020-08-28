﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    public class MSQLGrades : IGrades
    {
        private const string DELETE_GRADE
            = "DELETE FROM Grades WHERE GradeId = @gradeId";
        private const string GET_ALL_GRADES
            = "SELECT * FROM Grades";
        private const string INSERT_GRADE
            = "INSERT INTO Grades(PassSubjectId, StudentId, Grade) VALUES (@passSubjectId, @studentId, @grade)";
        private const string UPDATE_GRADE
            = "UPDATE Grades SET PassSubjectId = @passSubjectId, StudentId = @studentId, Grade = @grade WHERE GradeId = @gradeId";

        private string connectString;
        public MSQLGrades(string connectString)
        {
            this.connectString = connectString;
        }
        public bool Delete(Grades grade)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(DELETE_GRADE, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@gradeId", grade.GradeId));
                return sqlCommand.ExecuteNonQuery() > 0;
            }
        }

        public Grades[] GetAllGrades()
        {
            List<Grades> grades = new List<Grades>();
            using (SqlConnection sqlConnection = new SqlConnection(connectString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(GET_ALL_GRADES, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                    while (sqlDataReader.Read())
                    {
                        grades.Add(new Grades(
                        sqlDataReader.GetInt32(0),
                        sqlDataReader.GetInt32(1),
                        sqlDataReader.GetInt32(2),
                        sqlDataReader.GetInt32(3)
                        ));
                    }
            }
            return grades.ToArray();
        }

        public bool Insert(Grades grade)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(INSERT_GRADE, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@passSubjectId", grade.PassSubjectId));
                sqlCommand.Parameters.Add(new SqlParameter("@studentId", grade.StudentId));
                sqlCommand.Parameters.Add(new SqlParameter("@grade", grade.Grade));
                return sqlCommand.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(Grades oldGrade, Grades newGrade)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(UPDATE_GRADE, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@gradeId", oldGrade.GradeId));
                sqlCommand.Parameters.Add(new SqlParameter("@passSubjectId", newGrade.PassSubjectId));
                sqlCommand.Parameters.Add(new SqlParameter("@studentId", newGrade.StudentId));
                sqlCommand.Parameters.Add(new SqlParameter("@grade", newGrade.Grade));
                return sqlCommand.ExecuteNonQuery() > 0;
            }
        }
    }
}