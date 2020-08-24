using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    public interface IGroups
    {
        bool Insert(Groups group);
        bool Update(Groups oldGroup, Groups newGroup);
        bool Delete(Groups group);
        Groups[] GetAllGroups();
    }
}
