using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    public class MSQLСonnectionFactory : СonnectionFactory
    {
        private string connectionString;
        private static MSQLСonnectionFactory instance;

        private MSQLСonnectionFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public static MSQLСonnectionFactory GetInstance(string connectionString)
        {
            if (instance == null)
                instance = new MSQLСonnectionFactory(connectionString);
            return instance;
        }

        public override IAssessmentForms GetAssessmentForms()
        {
            return new MSQLAssessmentForms(connectionString);
        }

        public override IGrades GetGrades()
        {
            return new MSQLGrades(connectionString);
        }

        public override IGroups GetGroups()
        {
            return new MSQLGroups(connectionString);
        }

        public override IPassSubjects GetPassSubjects()
        {
            return new MSQLPassSubjects(connectionString);
        }

        public override ISessionTypes GetSessionTypes()
        {
            return new MSQLSessionTypes(connectionString);
        }

        public override IStudents GetStudents()
        {
            return new MSQLStudents(connectionString);
        }

        public override ISubjects GetSubjects()
        {
            return new MSQLSubject(connectionString);
        }
    }
}
