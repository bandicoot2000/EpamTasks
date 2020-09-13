using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    /// <summary>
    /// MSQL grades connection.
    /// </summary>
    public class MSQLGrades : IGrades
    {
        private DataContext dataContext;
        /// <summary>
        /// Constuctor MSQLGrades.
        /// </summary>
        /// <param name="connectString">Connection.</param>
        public MSQLGrades(string connectString)
        {
            dataContext = new DataContext(connectString);
        }
        /// <summary>
        /// Delete Grades.
        /// </summary>
        /// <param name="grade">Grades.</param>
        /// <returns>Successful completion method.</returns>
        public bool Delete(Grades grade)
        {
            dataContext.GetTable<Grades>().DeleteOnSubmit(dataContext.GetTable<Grades>().Where(grades => grades.GradeId == grade.GradeId).First());
            dataContext.SubmitChanges();
            return true;
        }
        /// <summary>
        /// Get All Grades in DB.
        /// </summary>
        /// <returns>All Grades.</returns>
        public Grades[] GetAllGrades()
        {
            return dataContext.GetTable<Grades>().ToArray();
        }
        /// <summary>
        /// Insert Grades.
        /// </summary>
        /// <param name="grade">Grades</param>
        /// <returns>Successful completion method.</returns
        public bool Insert(Grades grade)
        {
            dataContext.GetTable<Grades>().InsertOnSubmit(grade);
            dataContext.SubmitChanges();
            return true;
        }
        /// <summary>
        /// Update Grades.
        /// </summary>
        /// <param name="oldGrade">Old Grades.</param>
        /// <param name="newGrade">New Grades.</param>
        /// <returns>Successful completion method.</returns>
        public bool Update(Grades oldGrade, Grades newGrade)
        {
            var query = from gradee in dataContext.GetTable<Grades>()
                        where gradee.GradeId == oldGrade.GradeId
                        select gradee;
            Grades grade = query.First();
            grade.StudentId = newGrade.StudentId;
            grade.PassSubjectId = newGrade.PassSubjectId;
            grade.Grade = newGrade.Grade;
            dataContext.SubmitChanges();
            return true;
        }
    }
}
