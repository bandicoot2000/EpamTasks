using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    public interface ISubjects
    {
        bool Insert(Subjects subject);
        bool Update(Subjects oldSubject, Subjects newSubject);
        bool Delete(Subjects subject);
        Subjects[] GetAllSubjects();
    }
}
