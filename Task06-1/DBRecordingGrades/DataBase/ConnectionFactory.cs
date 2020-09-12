using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    /// <summary>
    /// Connection Factory.
    /// </summary>
    public abstract class ConnectionFactory
    {
        /// <summary>
        /// Get Assesment form connection.
        /// </summary>
        /// <returns>IAssesmentForm obj.</returns>
        public abstract IAssessmentForms GetAssessmentForms();
        /// <summary>
        /// Get Grade connection.
        /// </summary>
        /// <returns>IGrades obj.</returns>
        public abstract IGrades GetGrades();
        /// <summary>
        /// Get Group connection.
        /// </summary>
        /// <returns>IGroups obj.</returns>
        public abstract IGroups GetGroups();
        /// <summary>
        /// Get PassSubject connection.
        /// </summary>
        /// <returns>IPassSubjects obj.</returns>
        public abstract IPassSubjects GetPassSubjects();
        /// <summary>
        /// Get SessionType connection.
        /// </summary>
        /// <returns>ISessionTypes obj.</returns>
        public abstract ISessionTypes GetSessionTypes();
        /// <summary>
        /// Get Student connection.
        /// </summary>
        /// <returns>IStudents obj.</returns>
        public abstract IStudents GetStudents();
        /// <summary>
        /// Get Subject connection.
        /// </summary>
        /// <returns>ISubjects obj.</returns>
        public abstract ISubjects GetSubjects();

        /// <summary>
        /// Get Connection Factory.
        /// </summary>
        /// <param name="dbType">DB type.</param>
        /// <param name="connectionString">Connection.</param>
        /// <returns> Connection Factory.</returns>
        public static ConnectionFactory GetСonnectionFactory(DataBaseType dbType, string connectionString)
        {
            switch (dbType)
            {
                case DataBaseType.MSSQL:
                    return MSQLСonnectionFactory.GetInstance(connectionString);
                default:
                    return null;
            }
        }
    }
}
