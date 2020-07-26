using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Film : IMaterial
    {
        public override bool Equals(object obj)
        {
            return obj is Film;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return "Film";
        }
        public string ToString(string format)
        {
            if (format == "Type") return "Film";
            else throw new Exception("Incorrect format");
        }
    }
}
