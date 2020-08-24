using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    interface IPassSubjects
    {
        bool Insert(PassSubjects passSubject);
        bool Update(PassSubjects oldPassSubject, Groups newPassSubject);
        bool Delete(PassSubjects passSubject);
        PassSubjects[] GetAllPassSubjects();
    }
}
