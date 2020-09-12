using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    /// <summary>
    /// Group
    /// </summary>
    public class Groups
    {
        /// <summary>
        /// Group id.
        /// </summary>
        public int GroupId { get; set; }
        /// <summary>
        /// Group name.
        /// </summary>
        public string GroupName { get; set; }

        /// <summary>
        /// Constructor group.
        /// </summary>
        /// <param name="groupId">Group id.</param>
        /// <param name="groupName">Group name.</param>
        public Groups(int groupId, string groupName)
        {
            GroupId = groupId;
            GroupName = groupName;
        }
        /// <summary>
        /// Override Equals.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>Result.</returns>
        public override bool Equals(object obj)
        {
            return obj is Groups groups &&
                   GroupId == groups.GroupId &&
                   GroupName == groups.GroupName;
        }
        /// <summary>
        /// Override GetHashCde.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            int hashCode = 746186864;
            hashCode = hashCode * -1521134295 + GroupId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GroupName);
            return hashCode;
        }
        /// <summary>
        /// Override ToString.
        /// </summary>
        /// <returns>String Object.</returns>
        public override string ToString()
        {
            return GroupId + " " + GroupName;
        }
    }
}
