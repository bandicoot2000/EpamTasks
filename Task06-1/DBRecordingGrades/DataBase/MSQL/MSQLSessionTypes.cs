using System;
using System.Collections.Generic;
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
        private const string DELETE_SESSIONTYPE
            = "DELETE FROM SessionTypes WHERE SessionTypeId = @sessionTypeId";
        private const string GET_ALL_SESSIONTYPES
            = "SELECT * FROM SessionTypes";
        private const string INSERT_SESSIONTYPE
            = "INSERT INTO SessionTypes(SessionTypeName) VALUES (@sessionTypeName)";
        private const string UPDATE_SESSIONTYPE
            = "UPDATE SessionTypes SET SessionTypeName = @sessionTypeName WHERE SessionTypeId = @sessionTypeId";

        private string connectString;
        /// <summary>
        /// Constructor MSQLSessionTypes.
        /// </summary>
        /// <param name="connectString">Connection.</param>
        public MSQLSessionTypes(string connectString)
        {
            this.connectString = connectString;
        }
        /// <summary>
        /// Delete SessionTypes.
        /// </summary>
        /// <param name="sessionType">SessionTypes.</param>
        /// <returns>Successful completion method.</returns>
        public bool Delete(SessionTypes sessionType)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(DELETE_SESSIONTYPE, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@sessionTypeId", sessionType.SessionTypeId));
                return sqlCommand.ExecuteNonQuery() > 0;
            }
        }
        /// <summary>
        /// Get All SessionTypes in DB.
        /// </summary>
        /// <returns>All SessionTypes.</returns>
        public SessionTypes[] GetAllSessionTypes()
        {
            List<SessionTypes> sessionTypes = new List<SessionTypes>();
            using (SqlConnection sqlConnection = new SqlConnection(connectString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(GET_ALL_SESSIONTYPES, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                    while (sqlDataReader.Read())
                    {
                        sessionTypes.Add(new SessionTypes(
                        sqlDataReader.GetInt32(0),
                        sqlDataReader.GetString(1)
                        ));
                    }
            }
            return sessionTypes.ToArray();
        }
        /// <summary>
        /// Delete SessionTypes.
        /// </summary>
        /// <param name="sessionType">SessionTypes.</param>
        /// <returns>Successful completion method.</returns>
        public bool Insert(SessionTypes sessionType)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(INSERT_SESSIONTYPE, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@sessionTypeName", sessionType.SessionTypeName));
                return sqlCommand.ExecuteNonQuery() > 0;
            }
        }
        /// <summary>
        /// Update SessionTypes.
        /// </summary>
        /// <param name="oldSessionType">Old SessionTypes.</param>
        /// <param name="newSessionType">New SessionTypes.</param>
        /// <returns>Successful completion method.</returns>
        public bool Update(SessionTypes oldSessionType, SessionTypes newSessionType)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(UPDATE_SESSIONTYPE, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@sessionTypeId", oldSessionType.SessionTypeId));
                sqlCommand.Parameters.Add(new SqlParameter("@sessionTypeName", newSessionType.SessionTypeName));
                return sqlCommand.ExecuteNonQuery() > 0;
            }
        }
    }
}
