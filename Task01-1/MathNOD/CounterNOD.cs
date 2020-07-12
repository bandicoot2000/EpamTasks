using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathNOD
{
    /// <summary>
    /// Class allowing to calculate NOD.
    /// </summary>
    public class CounterNOD
    {
        private uint numberFirst;
        /// <summary>
        /// First number to calculate the NOD.
        /// </summary>
        public uint NumberFirst 
        {
            get { return numberFirst; } 
            set { numberFirst = value != 0 ? value : 
                    throw new Exception("Zero exception, number must be greater than zero"); } 
        }

        private uint numberSecond;
        /// <summary>
        /// Second number to calculate the NOD.
        /// </summary>
        public uint NumberSecond 
        {
            get { return numberSecond; }
            set { numberSecond = value != 0 ? value : 
                    throw new Exception("Zero exception, number must be greater than zero"); }
        }

        /// <summary>
        /// Class constructor CounterNOD.
        /// </summary>
        /// <param name="numberFirst">First number to calculate the NOD.</param>
        /// <param name="numberSecond">Second number to calculate the NOD.</param>
        public CounterNOD(uint numberFirst, uint numberSecond)
        {
            NumberFirst = numberFirst;
            NumberSecond = numberSecond;
        }

        /// <summary>
        /// Calculate NOD of two numbers Euclid's algorithm.
        /// </summary>
        /// <returns>NOD of two numbers.</returns>
        public uint GetNOD()
        {
            return NOD(numberFirst, numberSecond);
        }

        /// <summary>
        /// Calculate NOD of three numbers Euclid's algorithm.
        /// </summary>
        /// <param name="numberThird">Third number to calculate the NOD.</param>
        /// <returns>NOD of three numbers.</returns>
        public uint GetNOD(uint numberThird)
        {
            return NOD(GetNOD(), numberThird);
        }

        /// <summary>
        /// Calculate NOD of four numbers Euclid's algorithm.
        /// </summary>
        /// <param name="numberThird">Third number to calculate the NOD.</param>
        /// <param name="numberFourth">Fourth number to calculate the NOD.</param>
        /// <returns>NOD of four numbers.</returns>
        public uint GetNOD(uint numberThird, uint numberFourth)
        {
            return NOD(GetNOD(numberThird), numberFourth);
        }

        /// <summary>
        /// Calculate NOD of five numbers Euclid's algorithm.
        /// </summary>
        /// <param name="numberThird">Third number to calculate the NOD.</param>
        /// <param name="numberFourth">Fourth number to calculate the NOD.</param>
        /// <param name="numberFifth">Fifth number to calculate the NOD.</param>
        /// <returns>NOD of five numbers.</returns>
        public uint GetNOD(uint numberThird, uint numberFourth, uint numberFifth)
        {
            return NOD(GetNOD(numberThird, numberFourth), numberFifth);
        }

        /// <summary>
        /// Calculate NOD of two numbers Euclid's algorithm.
        /// </summary>
        /// <param name="time">NOD calculation time.</param>
        /// <returns>NOD of two numbers.</returns>
        public uint GetNOD(out long time)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            long startTime = stopwatch.ElapsedMilliseconds;
            uint answer = NOD(numberFirst, numberSecond);
            time = stopwatch.ElapsedMilliseconds - startTime;
            return answer;
        }

        /// <summary>
        /// Calculate NOD of two numbers Stein's algorithm.
        /// </summary>
        /// <param name="time">NOD calculation time.</param>
        /// <returns>NOD of two numbers.</returns>
        public uint GetNODStein(out long time)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            long startTime = stopwatch.ElapsedMilliseconds;
            uint answer = NODStein(numberFirst, numberSecond);
            time = stopwatch.ElapsedMilliseconds - startTime;
            return answer;
        }

        /// <summary>
        /// Collects data on the time of calculation of NOD.
        /// </summary>
        /// <param name="numberFirst">First number to calculate the NOD.</param>
        /// <param name="nemberSecondMax">The largest second number to calculate the NOD.</param>
        /// <returns>NOD calculation time data.</returns>
        public static long[,] GetTimeData(uint numberFirst, uint nemberSecondMax = 10000)
        {
            long[,] answer = new long[2, nemberSecondMax];
            long time;
            CounterNOD counterNOD = new CounterNOD(numberFirst, 1);
            for (uint number = 1; number < nemberSecondMax; number++)
            {
                counterNOD.numberSecond = number;

                counterNOD.GetNOD(out time);
                answer[0, number - 1] = time;

                counterNOD.GetNODStein(out time);
                answer[1, number - 1] = time;
            }
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
