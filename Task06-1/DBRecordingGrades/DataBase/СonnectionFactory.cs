using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    public abstract class СonnectionFactory
    {
        public abstract IAssessmentForms GetAssessmentForms();
        public abstract IGrades GetGrades();
        public abstract IGroups GetGroups();
        public abstract IPassSubjects GetPassSubjects();
        public abstract ISessionTypes GetSessionTypes();
        public abstract IStudents GetStudents();
        public abstract ISubjects GetSubjects();

        public static СonnectionFactory GetСonnectionFactory(DataBaseType dbType, string connectionString)
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
