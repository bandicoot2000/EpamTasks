using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathNOD
{
    public class CounterNOD
    {
        private uint numberFirst;

        public uint NumberFirst 
        {
            get { return numberFirst; } 
            set { numberFirst = value != 0 ? value : 
                    throw new Exception("Zero exception, number must be greater than zero"); } 
        }

        private uint numberSecond;

        public uint NumberSecond 
        {
            get { return numberSecond; }
            set { numberSecond = value != 0 ? value : 
                    throw new Exception("Zero exception, number must be greater than zero"); }
        }


        public CounterNOD(uint numberFirst, uint numberSecond)
        {
            NumberFirst = numberFirst;
            NumberSecond = numberSecond;
        }

        public uint GetNOD()
        {
            return NOD(numberFirst, numberSecond);
        }

        public uint GetNOD(uint numberThird)
        {
            return NOD(GetNOD(), numberThird);
        }

        public uint GetNOD(uint numberThird, uint numberFourth)
        {
            return NOD(GetNOD(numberThird), numberFourth);
        }

        public uint GetNOD(uint numberThird, uint numberFourth, uint numberFifth)
        {
            return NOD(GetNOD(numberThird, numberFourth), numberFifth);
        }

        public uint GetNOD(out long time)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            long startTime = stopwatch.ElapsedMilliseconds;
            uint answer = NOD(numberFirst, numberSecond);
            time = stopwatch.ElapsedMilliseconds - startTime;
            return answer;
        }



        public uint GetNODStein(out long time)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            long startTime = stopwatch.ElapsedMilliseconds;
            uint answer = NODStein(numberFirst, numberSecond);
            time = stopwatch.ElapsedMilliseconds - startTime;
            return answer;
        }


        private uint NOD(uint numberFirst, uint numberSecond)
        {
            uint numberTemp = 0;

            while (numberSecond != 0)
            {
                numberTemp = numberSecond;
                numberSecond = numberFirst % numberSecond;
                numberFirst = numberTemp;
            }

            return numberFirst;
        }

        private uint NODStein(uint numberFirst, uint numberSecond)
        {
            if (numberFirst == numberSecond)
                return numberFirst;

            if (numberFirst == 0)
                return numberSecond;

            if (numberSecond == 0)
                return numberFirst;

            if (1 == (~numberFirst & 1)) 
                if (1 == (numberSecond & 1))
                    return NODStein(numberFirst >> 1, numberSecond);
                else 
                    return NODStein(numberFirst >> 1, numberSecond >> 1) << 1;

            if (1 == (~numberSecond & 1)) 
                return NODStein(numberFirst, numberSecond >> 1);

            if (numberFirst > numberSecond)
                return NODStein((numberFirst - numberSecond) >> 1, numberSecond);

            return NODStein((numberSecond - numberFirst) >> 1, numberFirst);
        }
    }
}
