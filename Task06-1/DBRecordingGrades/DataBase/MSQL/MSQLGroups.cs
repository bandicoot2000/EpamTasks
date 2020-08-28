using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    public class MSQLGroups : IGroups
    {
        private const string DELETE_GROUP
            = "DELETE FROM Groups WHERE GroupId = @groupId";
        private const string GET_ALL_GROUP
            = "SELECT * FROM Groups";
        private const string INSERT_GROUP
            = "INSERT INTO Groups(GroupName) VALUES (@groupName)";
        private const string UPDATE_GROUP
            = "UPDATE Groups SET GroupName = @groupName WHERE GroupId = @groupId";

        private string connectString;
        public MSQLGroups(string connectString)
        {
            this.connectString = connectString;
        }

        public bool Delete(Groups group)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(DELETE_GROUP, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@groupId", group.GroupId));
                return sqlCommand.ExecuteNonQuery() > 0;
            }
        }

        public Groups[] GetAllGroups()
        {
            List<Groups> groups = new List<Groups>();
            using (SqlConnection sqlConnection = new SqlConnection(connectString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(GET_ALL_GROUP, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.HasRows)
                    while (sqlDataReader.Read())
                    {
                        groups.Add(new Groups(
                        sqlDataReader.GetInt32(0),
                        sqlDataReader.GetString(1)
                        ));
                    }
            }
            return groups.ToArray();
        }

        public bool Insert(Groups group)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(INSERT_GROUP, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@groupName", group.GroupName));
                return sqlCommand.ExecuteNonQuery() > 0;
            }
        }

        public bool Update(Groups oldGroup, Groups newGroup)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand(UPDATE_GROUP, sqlConnection);
                sqlCommand.Parameters.Add(new SqlParameter("@groupId", oldGroup.GroupId));
                sqlCommand.Parameters.Add(new SqlParameter("@groupName", newGroup.GroupName));
                return sqlCommand.ExecuteNonQuery() > 0;
            }
        }
    }
}
