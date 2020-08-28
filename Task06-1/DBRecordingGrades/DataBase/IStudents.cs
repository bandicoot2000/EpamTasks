using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    public interface IStudents
    {
        bool Insert(Students student);
        bool Update(Students oldStudent, Students newStudent);
        bool Delete(Students student);
        Students[] GetAllStudents();
    }
}
