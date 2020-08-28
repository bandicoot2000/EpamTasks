using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    public class Groups
    {
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        public Groups(int groupId, string groupName)
        {
            GroupId = groupId;
            GroupName = groupName;
        }

        public override bool Equals(object obj)
        {
            return obj is Groups groups &&
                   GroupId == groups.GroupId &&
                   GroupName == groups.GroupName;
        }

        public override int GetHashCode()
        {
            int hashCode = 746186864;
            hashCode = hashCode * -1521134295 + GroupId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(GroupName);
            return hashCode;
        }

        public override string ToString()
        {
            return GroupId + " " + GroupName;
        }
    }
}
