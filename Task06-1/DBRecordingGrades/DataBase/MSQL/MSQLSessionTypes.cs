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
    /// MSQL session types connection.
    /// </summary>
    public class MSQLSessionTypes : ISessionTypes
    {
        private DataContext dataContext;
        /// <summary>
        /// Constructor MSQLSessionTypes.
        /// </summary>
        /// <param name="connectString">Connection.</param>
        public MSQLSessionTypes(string connectString)
        {
            dataContext = new DataContext(connectString);
        }
        /// <summary>
        /// Delete SessionTypes.
        /// </summary>
        /// <param name="sessionType">SessionTypes.</param>
        /// <returns>Successful completion method.</returns>
        public bool Delete(SessionTypes sessionType)
        {
            dataContext.GetTable<SessionTypes>().DeleteOnSubmit(dataContext.GetTable<SessionTypes>().Where(sessionTypes => sessionTypes.SessionTypeId == sessionType.SessionTypeId).First());
            dataContext.SubmitChanges();
            return true;
        }
        /// <summary>
        /// Get All SessionTypes in DB.
        /// </summary>
        /// <returns>All SessionTypes.</returns>
        public SessionTypes[] GetAllSessionTypes()
        {
            return dataContext.GetTable<SessionTypes>().ToArray();
        }
        /// <summary>
        /// Delete SessionTypes.
        /// </summary>
        /// <param name="sessionType">SessionTypes.</param>
        /// <returns>Successful completion method.</returns>
        public bool Insert(SessionTypes sessionType)
        {
            dataContext.GetTable<SessionTypes>().InsertOnSubmit(sessionType);
            dataContext.SubmitChanges();
            return true;
        }
        /// <summary>
        /// Update SessionTypes.
        /// </summary>
        /// <param name="oldSessionType">Old SessionTypes.</param>
        /// <param name="newSessionType">New SessionTypes.</param>
        /// <returns>Successful completion method.</returns>
        public bool Update(SessionTypes oldSessionType, SessionTypes newSessionType)
        {
            var query = from sessionTypes in dataContext.GetTable<SessionTypes>()
                        where sessionTypes.SessionTypeId == oldSessionType.SessionTypeId
                        select sessionTypes;
            SessionTypes updateSessionTypes = query.First();
            updateSessionTypes.SessionTypeName = newSessionType.SessionTypeName;
            dataContext.SubmitChanges();
            return true;
        }
    }
}
