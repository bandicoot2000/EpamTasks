using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    /// <summary>
    /// DAO Isubject interface.
    /// </summary>
    public interface ISubjects
    {
        /// <summary>
        /// Insert Subjects.
        /// </summary>
        /// <param name="subject">Subjects.</param>
        /// <returns>Successful completion method.</returns>
        bool Insert(Subjects subject);
        /// <summary>
        /// Update Subjects.
        /// </summary>
        /// <param name="oldSubject">Old Subjects.</param>
        /// <param name="newSubject">New Subjects.</param>
        /// <returns>Successful completion method.</returns>
        bool Update(Subjects oldSubject, Subjects newSubject);
        /// <summary>
        /// Delete Subjects.
        /// </summary>
        /// <param name="subject">Subjects.</param>
        /// <returns>Successful completion method.</returns>
        bool Delete(Subjects subject);
        /// <summary>
        /// Get All Subjects in DB.
        /// </summary>
        /// <returns>All Subjects.</returns>
        Subjects[] GetAllSubjects();
    }
}
