using System;


namespace Figures
{
    /// <summary>
    /// Material film.
    /// </summary>
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
