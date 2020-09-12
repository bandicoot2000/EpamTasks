using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    /// <summary>
    /// DAO IGroups interface.
    /// </summary>
    public interface IGroups
    {
        /// <summary>
        /// Insert Groups.
        /// </summary>
        /// <param name="group">Groups.</param>
        /// <returns>Successful completion method.</returns>
        bool Insert(Groups group);
        /// <summary>
        /// Update Groups.
        /// </summary>
        /// <param name="oldGroup">Old Groups</param>
        /// <param name="newGroup">New Groups</param>
        /// <returns>Successful completion method.</returns>
        bool Update(Groups oldGroup, Groups newGroup);
        /// <summary>
        /// Delete Groups.
        /// </summary>
        /// <param name="group">Groups.</param>
        /// <returns>Successful completion method.</returns>
        bool Delete(Groups group);
        /// <summary>
        /// Gat All Groups in DB.
        /// </summary>
        /// <returns>All Groups.</returns>
        Groups[] GetAllGroups();
    }
}
