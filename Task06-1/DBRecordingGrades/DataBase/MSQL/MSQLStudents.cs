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
    /// MSQL students connection.
    /// </summary>
    public class MSQLStudents : IStudents
    {
        private DataContext dataContext;
        /// <summary>
        /// Constructor MSQLStudents.
        /// </summary>
        /// <param name="connectString">Connection.</param>
        public MSQLStudents(string connectString)
        {
            dataContext = new DataContext(connectString);
        }
        /// <summary>
        /// Delete Students.
        /// </summary>
        /// <param name="student">Students.</param>
        /// <returns>Successful completion method.</returns>
        public bool Delete(Students student)
        {
            dataContext.GetTable<Students>().DeleteOnSubmit(dataContext.GetTable<Students>().Where(students => students.StudentId == student.StudentId).First());
            dataContext.SubmitChanges();
            return true;
        }
        /// <summary>
        /// Get All Students in DB.
        /// </summary>
        /// <returns>All Students.</returns>
        public Students[] GetAllStudents()
        {
            return dataContext.GetTable<Students>().ToArray();
        }
        /// <summary>
        /// Insert Students.
        /// </summary>
        /// <param name="student">Students.</param>
        /// <returns>Successful completion method.</returns>
        public bool Insert(Students student)
        {
            dataContext.GetTable<Students>().InsertOnSubmit(student);
            dataContext.SubmitChanges();
            return true;
        }
        /// <summary>
        /// Update Students.
        /// </summary>
        /// <param name="oldStudent">Old Students.</param>
        /// <param name="newStudent">New Students.</param>
        /// <returns>Successful completion method.</returns>
        public bool Update(Students oldStudent, Students newStudent)
        {
            var query = from student in dataContext.GetTable<Students>()
                        where student.StudentId == oldStudent.StudentId
                        select student;
            Students updateStudents = query.First();
            updateStudents.FirstName = newStudent.FirstName;
            updateStudents.SecondName = newStudent.SecondName;
            updateStudents.MiddleName = newStudent.MiddleName;
            updateStudents.Birthday = newStudent.Birthday;
            updateStudents.Gender = newStudent.Gender;
            updateStudents.GroupId = newStudent.GroupId;
            dataContext.SubmitChanges();
            return true;
        }
    }
}
