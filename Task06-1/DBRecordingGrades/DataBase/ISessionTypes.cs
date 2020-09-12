using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    /// <summary>
    /// DAO ISessionTypes interface.
    /// </summary>
    public interface ISessionTypes
    {
        /// <summary>
        /// Insert SessionTypes.
        /// </summary>
        /// <param name="sessionType">SessionTypes.</param>
        /// <returns>Successful completion method.</returns>
        bool Insert(SessionTypes sessionType);
        /// <summary>
        /// Update SessionTypes.
        /// </summary>
        /// <param name="oldSessionType">Old SessionTypes.</param>
        /// <param name="newSessionType">New SessionTypes.</param>
        /// <returns>Successful completion method.</returns>
        bool Update(SessionTypes oldSessionType, SessionTypes newSessionType);
        /// <summary>
        /// Delete SessionTypes.
        /// </summary>
        /// <param name="sessionType">SessionTypes.</param>
        /// <returns>Successful completion method.</returns>
        bool Delete(SessionTypes sessionType);
        /// <summary>
        /// Get All SessionTypes in DB.
        /// </summary>
        /// <returns>All SessionTypes.</returns>
        SessionTypes[] GetAllSessionTypes();
    }
}
