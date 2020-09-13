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
    /// MSQL pass subject connection.
    /// </summary>
    public class MSQLPassSubjects : IPassSubjects
    {
        private DataContext dataContext;
        /// <summary>
        /// Constructor MSQLPassSubjects.
        /// </summary>
        /// <param name="connectString">Connection.</param>
        public MSQLPassSubjects(string connectString)
        {
            dataContext = new DataContext(connectString);
        }
        /// <summary>
        /// Delete PassSubjects.
        /// </summary>
        /// <param name="passSubject">PassSubjects.</param>
        /// <returns>Successful completion method.</returns>
        public bool Delete(PassSubjects passSubject)
        {
            dataContext.GetTable<PassSubjects>().DeleteOnSubmit(dataContext.GetTable<PassSubjects>().Where(passSubjects => passSubjects.PassSubjectId == passSubject.PassSubjectId).First());
            dataContext.SubmitChanges();
            return true;
        }
        /// <summary>
        /// Get All PassSubjects in DB.
        /// </summary>
        /// <returns>All PassSubjects.</returns>
        public PassSubjects[] GetAllPassSubjects()
        {
            return dataContext.GetTable<PassSubjects>().ToArray();
        }
        /// <summary>
        /// Insert PassSubjects.
        /// </summary>
        /// <param name="passSubject">PassSubjects.</param>
        /// <returns>Successful completion method.</returns>
        public bool Insert(PassSubjects passSubject)
        {
            dataContext.GetTable<PassSubjects>().InsertOnSubmit(passSubject);
            dataContext.SubmitChanges();
            return true;
        }
        /// <summary>
        /// Update PassSubjects.
        /// </summary>
        /// <param name="oldPassSubject">Old PassSubjects.</param>
        /// <param name="newPassSubject">New PassSubjects.</param>
        /// <returns>Successful completion method.</returns>
        public bool Update(PassSubjects oldPassSubject, PassSubjects newPassSubject)
        {
            var query = from passSubject in dataContext.GetTable<PassSubjects>()
                        where passSubject.PassSubjectId == oldPassSubject.PassSubjectId
                        select passSubject;
            PassSubjects updatePassSubjects = query.First();
            updatePassSubjects.AssessmentFormId = newPassSubject.AssessmentFormId;
            updatePassSubjects.SubjectId = newPassSubject.SubjectId;
            updatePassSubjects.SessionTypeId = newPassSubject.SessionTypeId;
            updatePassSubjects.Examinator = newPassSubject.Examinator;
            updatePassSubjects.GroupId = newPassSubject.GroupId;
            dataContext.SubmitChanges();
            return true;
        }
    }
}
