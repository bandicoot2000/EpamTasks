using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    /// <summary>
    /// MSQl Connection Factoy.
    /// </summary>
    public class MSQLСonnectionFactory : ConnectionFactory
    {
        private string connectionString;
        private static MSQLСonnectionFactory instance;

        private MSQLСonnectionFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Get MSQLСonnectionFactory.
        /// </summary>
        /// <param name="connectionString">Connection string.</param>
        /// <returns>MSQLСonnectionFactory</returns>
        public static MSQLСonnectionFactory GetInstance(string connectionString)
        {
            if (instance == null)
                instance = new MSQLСonnectionFactory(connectionString);
            return instance;
        }

        /// <summary>
        /// Get Assesment form connection.
        /// </summary>
        /// <returns>MSQL AssesmentForm connection.</returns>
        public override IAssessmentForms GetAssessmentForms()
        {
            return new MSQLAssessmentForms(connectionString);
        }

        /// <summary>
        /// Get grade connection.
        /// </summary>
        /// <returns>MSQL Grades connection.</returns>
        public override IGrades GetGrades()
        {
            return new MSQLGrades(connectionString);
        }

        /// <summary>
        /// Get group connection.
        /// </summary>
        /// <returns>MSQL Group connection.</returns>
        public override IGroups GetGroups()
        {
            return new MSQLGroups(connectionString);
        }

        /// <summary>
        /// Get pass subject connection.
        /// </summary>
        /// <returns>MSQL pass subject connection.</returns>
        public override IPassSubjects GetPassSubjects()
        {
            return new MSQLPassSubjects(connectionString);
        }

        /// <summary>
        /// Get session type connection.
        /// </summary>
        /// <returns>MSQL session type connection.</returns>
        public override ISessionTypes GetSessionTypes()
        {
            return new MSQLSessionTypes(connectionString);
        }

        /// <summary>
        /// Get student connection.
        /// </summary>
        /// <returns>MSQL student connection.</returns>
        public override IStudents GetStudents()
        {
            return new MSQLStudents(connectionString);
        }

        /// <summary>
        /// Get subject connection.
        /// </summary>
        /// <returns>MSQL subject connection.</returns>
        public override ISubjects GetSubjects()
        {
            return new MSQLSubject(connectionString);
        }
    }
}
