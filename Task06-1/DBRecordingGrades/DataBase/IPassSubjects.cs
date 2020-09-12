using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    /// <summary>
    /// DAO IPassSubjects interface.
    /// </summary>
    public interface IPassSubjects
    {
        /// <summary>
        /// Insert PassSubjects.
        /// </summary>
        /// <param name="passSubject">PassSubjects.</param>
        /// <returns>Successful completion method.</returns>
        bool Insert(PassSubjects passSubject);
        /// <summary>
        /// Update PassSubjects.
        /// </summary>
        /// <param name="oldPassSubject">Old PassSubjects.</param>
        /// <param name="newPassSubject">New PassSubjects.</param>
        /// <returns>Successful completion method.</returns>
        bool Update(PassSubjects oldPassSubject, PassSubjects newPassSubject);
        /// <summary>
        /// Delete PassSubjects.
        /// </summary>
        /// <param name="passSubject">PassSubjects.</param>
        /// <returns>Successful completion method.</returns>
        bool Delete(PassSubjects passSubject);
        /// <summary>
        /// Get All PassSubjects in DB.
        /// </summary>
        /// <returns>All PassSubjects.</returns>
        PassSubjects[] GetAllPassSubjects();
    }
}
