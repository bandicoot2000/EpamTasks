using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vectors
{
    public class Vector3
    {
        private double axisX;
        private double axisY;
        private double axisZ;

        public double AxisX { get { return axisX; } }
        public double AxisY { get { return axisY; } }
        public double AxisZ { get { return axisZ; } }
        public double Length { get { return Math.Sqrt(axisX * axisX + axisY * axisY + axisZ * axisZ); } } 

        public Vector3(double axisX = 0.0, double axisY = 0.0, double axisZ = 0.0)
        {
            this.axisX = axisX;
            this.axisY = axisY;
            this.axisZ = axisZ;
        }

        public static Vector3 operator +(Vector3 vector1, Vector3 vector2)
        {
            return new Vector3(vector1.axisX + vector2.axisX, vector1.axisY + vector2.axisY, vector1.axisZ + vector2.axisZ);
        }

        public static Vector3 operator -(Vector3 vector1, Vector3 vector2)
        {
            return new Vector3(vector1.axisX - vector2.axisX, vector1.axisY - vector2.axisY, vector1.axisZ - vector2.axisZ);
        }

        public static Vector3 operator *(double value, Vector3 vector)
        {
            return new Vector3(value * vector.axisX, value * vector.axisY, value * vector.axisZ);
        }

        public static double operator *(Vector3 vector1, Vector3 vector2)
        {
            return vector1.axisX * vector2.axisX + vector1.axisY * vector2.axisY + vector1.axisZ * vector2.axisZ;
        }

        public override bool Equals(object obj)
        {
            return obj is Vector3 vector &&
                   axisX == vector.axisX &&
                   axisY == vector.axisY &&
                   axisZ == vector.axisZ;
        }

        public override int GetHashCode()
        {
            int hashCode = -1654883107;
            hashCode = hashCode * -1521134295 + axisX.GetHashCode();
            hashCode = hashCode * -1521134295 + axisY.GetHashCode();
            hashCode = hashCode * -1521134295 + axisZ.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "Vector3{ "+axisX+", "+axisY+", "+axisZ+" }";
        }
    }
}
