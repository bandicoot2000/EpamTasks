using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    public class Paper : IMaterial
    {

        private Color color;
        public  Color Color 
        { 
            get => color; 
            set 
            {
                if (color == Color.None) color = value;
                else throw new Exception("This shape is already painted");
            } 
        }

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
    }
}
