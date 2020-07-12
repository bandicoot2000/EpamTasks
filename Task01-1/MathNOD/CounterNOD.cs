using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathNOD
{
    public class CounterNOD
    {
        private int numberFirst;

        public int NumberFirst 
        {
            get { return numberFirst; } 
            set { numberFirst = value > 0 ? value : 1; } 
        }

        private int numberSecond;

        public int NumberSecond 
        {
            get { return numberSecond; }
            set { numberSecond = value > 0 ? value : 1; }
        }

        public CounterNOD(int numberFirst, int numberSecond)
        {
            NumberFirst = numberFirst;
            NumberSecond = numberSecond;
        }

        public int GetNOD()
        {
            return NOD(numberFirst, numberSecond);
        }

        public int GetNOD(int numberThird)
        {
            return NOD(GetNOD(), numberThird);
        }

        public int GetNOD(int numberThird, int numberFourth)
        {
            return NOD(GetNOD(numberThird), numberFourth);
        }

        public int GetNOD(int numberThird, int numberFourth, int numberFifth)
        {
            return NOD(GetNOD(numberThird, numberFourth), numberFifth);
        }

        private int NOD(int numberFirst, int numberSecond)
        {
            int numberTemp = 0;

            while (numberSecond != 0)
            {
                numberTemp = numberSecond;
                numberSecond = numberFirst % numberSecond;
                numberFirst = numberTemp;
            }

            return numberFirst;
        }
    }
}
