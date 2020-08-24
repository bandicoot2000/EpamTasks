using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    public interface IGrades
    {
        bool Insert(Grades grade);
        bool Update(Grades oldGrade, Grades newGrade);
        bool Delete(Grades grade);
        Grades[] GetAllGrades();
    }
}
