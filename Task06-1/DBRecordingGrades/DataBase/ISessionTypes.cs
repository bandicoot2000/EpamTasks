using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBRecordingGrades
{
    public interface ISessionTypes
    {
        bool Insert(SessionTypes sessionType);
        bool Update(SessionTypes oldSessionType, SessionTypes newSessionType);
        bool Delete(SessionTypes sessionType);
        SessionTypes[] GetAllSessionTypes();
    }
}
