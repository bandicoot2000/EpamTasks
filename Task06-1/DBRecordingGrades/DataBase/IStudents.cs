using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    /// <summary>
    /// DAO IStudents interface.
    /// </summary>
    public interface IStudents
    {
        /// <summary>
        /// Insert Students.
        /// </summary>
        /// <param name="student">Students.</param>
        /// <returns>Successful completion method.</returns>
        bool Insert(Students student);
        /// <summary>
        /// Update Students.
        /// </summary>
        /// <param name="oldStudent">Old Students.</param>
        /// <param name="newStudent">New Students.</param>
        /// <returns>Successful completion method.</returns>
        bool Update(Students oldStudent, Students newStudent);
        /// <summary>
        /// Delete Students.
        /// </summary>
        /// <param name="student">Students.</param>
        /// <returns>Successful completion method.</returns>
        bool Delete(Students student);
        /// <summary>
        /// Get All Students in DB.
        /// </summary>
        /// <returns>All Students.</returns>
        Students[] GetAllStudents();
    }
}
