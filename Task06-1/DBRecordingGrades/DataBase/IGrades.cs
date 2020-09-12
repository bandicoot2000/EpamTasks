using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    /// <summary>
    /// DAO IGrades interface.
    /// </summary>
    public interface IGrades
    {
        /// <summary>
        /// Insert Grades.
        /// </summary>
        /// <param name="grade">Grades</param>
        /// <returns>Successful completion method.</returns>
        bool Insert(Grades grade);
        /// <summary>
        /// Update Grades.
        /// </summary>
        /// <param name="oldGrade">Old Grades.</param>
        /// <param name="newGrade">New Grades.</param>
        /// <returns>Successful completion method.</returns>
        bool Update(Grades oldGrade, Grades newGrade);
        /// <summary>
        /// Delete Grades.
        /// </summary>
        /// <param name="grade">Grades.</param>
        /// <returns>Successful completion method.</returns>
        bool Delete(Grades grade);
        /// <summary>
        /// Get All Grades in DB.
        /// </summary>
        /// <returns>All Grades.</returns>
        Grades[] GetAllGrades();
    }
}
