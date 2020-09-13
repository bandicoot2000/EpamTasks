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
    /// MSQL groups connection.
    /// </summary>
    public class MSQLGroups : IGroups
    {
        private DataContext dataContext;
        /// <summary>
        /// Constructor MSQLGroups.
        /// </summary>
        /// <param name="connectString">Connection.</param>
        public MSQLGroups(string connectString)
        {
            dataContext = new DataContext(connectString);
        }
        /// <summary>
        /// Delete Groups.
        /// </summary>
        /// <param name="group">Groups.</param>
        /// <returns>Successful completion method.</returns>
        public bool Delete(Groups group)
        {
            dataContext.GetTable<Groups>().DeleteOnSubmit(dataContext.GetTable<Groups>().Where(groupe => groupe.GroupId == group.GroupId).First());
            dataContext.SubmitChanges();
            return true;
        }
        /// <summary>
        /// Gat All Groups in DB.
        /// </summary>
        /// <returns>All Groups.</returns>
        public Groups[] GetAllGroups()
        {
            return dataContext.GetTable<Groups>().ToArray();
        }
        /// <summary>
        /// Insert Groups.
        /// </summary>
        /// <param name="group">Groups.</param>
        /// <returns>Successful completion method.</returns>
        public bool Insert(Groups group)
        {
            dataContext.GetTable<Groups>().InsertOnSubmit(group);
            dataContext.SubmitChanges();
            return true;
        }
        /// <summary>
        /// Update Groups.
        /// </summary>
        /// <param name="oldGroup">Old Groups</param>
        /// <param name="newGroup">New Groups</param>
        /// <returns>Successful completion method.</returns>
        public bool Update(Groups oldGroup, Groups newGroup)
        {
            var query = from groupe in dataContext.GetTable<Groups>()
                        where groupe.GroupId == oldGroup.GroupId
                        select groupe;
            Groups updateGroup = query.First();
            updateGroup.GroupName = newGroup.GroupName;
            updateGroup.Specialization = newGroup.Specialization;
            dataContext.SubmitChanges();
            return true;
        }
    }
}
