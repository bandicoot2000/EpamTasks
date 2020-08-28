using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    public class SessionTypes
    {
        public int SessionTypeId { get; set; }
        public string SessionTypeName { get; set; }

        public SessionTypes(int sessionTypeId, string sessionTypeName)
        {
            SessionTypeId = sessionTypeId;
            SessionTypeName = sessionTypeName;
        }

        public override bool Equals(object obj)
        {
            return obj is SessionTypes types &&
                   SessionTypeId == types.SessionTypeId &&
                   SessionTypeName == types.SessionTypeName;
        }

        public override int GetHashCode()
        {
            int hashCode = 1173319966;
            hashCode = hashCode * -1521134295 + SessionTypeId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SessionTypeName);
            return hashCode;
        }

        public override string ToString()
        {
            return SessionTypeId + " " + SessionTypeName;
        }
    }
}
