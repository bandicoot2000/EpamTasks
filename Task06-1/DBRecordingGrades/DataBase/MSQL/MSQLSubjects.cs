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
    /// MSQL subjects connection.
    /// </summary>
    public class MSQLSubject : ISubjects
    {
        private DataContext dataContext;
        /// <summary>
        /// Constructor MSQLSubject.
        /// </summary>
        /// <param name="connectString">Connection.</param>
        public MSQLSubject(string connectString)
        {
            dataContext = new DataContext(connectString);
        }
        /// <summary>
        /// Delete Subjects.
        /// </summary>
        /// <param name="subject">Subjects.</param>
        /// <returns>Successful completion method.</returns>
        public bool Delete(Subjects subject)
        {
            dataContext.GetTable<Subjects>().DeleteOnSubmit(dataContext.GetTable<Subjects>().Where(subjects => subjects.SubjectId == subject.SubjectId).First());
            dataContext.SubmitChanges();
            return true;
        }
        /// <summary>
        /// Get All Subjects in DB.
        /// </summary>
        /// <returns>All Subjects.</returns>
        public Subjects[] GetAllSubjects()
        {
            return dataContext.GetTable<Subjects>().ToArray();
        }
        /// <summary>
        /// Insert Subjects.
        /// </summary>
        /// <param name="subject">Subjects.</param>
        /// <returns>Successful completion method.</returns>
        public bool Insert(Subjects subject)
        {
            dataContext.GetTable<Subjects>().InsertOnSubmit(subject);
            dataContext.SubmitChanges();
            return true;
        }
        /// <summary>
        /// Update Subjects.
        /// </summary>
        /// <param name="oldSubject">Old Subjects.</param>
        /// <param name="newSubject">New Subjects.</param>
        /// <returns>Successful completion method.</returns>
        public bool Update(Subjects oldSubject, Subjects newSubject)
        {
            var query = from subject in dataContext.GetTable<Subjects>()
                        where subject.SubjectId == oldSubject.SubjectId
                        select subject;
            Subjects updateSubjects = query.First();
            updateSubjects.SubjectName = newSubject.SubjectName;
            dataContext.SubmitChanges();
            return true;
        }
    }
}
