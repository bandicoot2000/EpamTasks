using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    /// <summary>
    /// Session type.
    /// </summary>
    public class SessionTypes
    {
        /// <summary>
        /// Sesion type id.
        /// </summary>
        public int SessionTypeId { get; set; }
        /// <summary>
        /// Session type name.
        /// </summary>
        public string SessionTypeName { get; set; }
        /// <summary>
        /// Constructor session type.
        /// </summary>
        /// <param name="sessionTypeId">Sesion type id.</param>
        /// <param name="sessionTypeName">Session type name.</param>

        public SessionTypes(int sessionTypeId, string sessionTypeName)
        {
            SessionTypeId = sessionTypeId;
            SessionTypeName = sessionTypeName;
        }

        /// <summary>
        /// Override Equals.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>Result.</returns>
        public override bool Equals(object obj)
        {
            return obj is SessionTypes types &&
                   SessionTypeId == types.SessionTypeId &&
                   SessionTypeName == types.SessionTypeName;
        }
        /// <summary>
        /// Override GetHashCde.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            int hashCode = 1173319966;
            hashCode = hashCode * -1521134295 + SessionTypeId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(SessionTypeName);
            return hashCode;
        }
        /// <summary>
        /// Override ToString.
        /// </summary>
        /// <returns>String Object.</returns>
        public override string ToString()
        {
            return SessionTypeId + " " + SessionTypeName;
        }
    }
}
