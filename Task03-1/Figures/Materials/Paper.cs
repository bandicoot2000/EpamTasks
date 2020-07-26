using System;

namespace Figures
{
    /// <summary>
    /// Material paper.
    /// </summary>
    public class Paper : IMaterial
    {

        private Color color;
        /// <summary>
        /// Paper color.
        /// </summary>
        public  Color Color 
        { 
            get => color; 
            set 
            {
                if (color == Color.None) color = value;
                else throw new Exception("This shape is already painted");
            } 
        }

        /// <summary>
        /// Create new paper.
        /// </summary>
        /// <param name="color">Color new paper.</param>
        public Paper(Color color = Color.None)
        {
            this.color = color;
        }

        public override bool Equals(object obj)
        {
            return obj is Paper paper &&
                   color == paper.color;
        }

        public override int GetHashCode()
        {
            return 790427672 + color.GetHashCode();
        }

        public override string ToString()
        {
            return "Paper: Color = " + color;
        }

        public string ToString(string format)
        {
            if (format == "Type") return "Paper";
            else throw new Exception("Incorrect format");   
        }
    }
}
