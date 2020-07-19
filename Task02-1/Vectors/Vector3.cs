using System;

namespace Vectors
{
    /// <summary>
    /// Class for working with vector3.
    /// </summary>
    public class Vector3
    {
        private double axisX;
        private double axisY;
        private double axisZ;

        /// <summary>
        /// Get value axisX.
        /// </summary>
        public double AxisX { get { return axisX; } }
        /// <summary>
        /// Get value axisY.
        /// </summary>
        public double AxisY { get { return axisY; } }
        /// <summary>
        /// Get value axisZ.
        /// </summary>
        public double AxisZ { get { return axisZ; } }
        /// <summary>
        /// Get vector 3 length.
        /// </summary>
        public double Length { get { return Math.Sqrt(axisX * axisX + axisY * axisY + axisZ * axisZ); } }

        /// <summary>
        /// Vector3 class constructor.
        /// </summary>
        /// <param name="axisX">Value vector3 axisX.</param>
        /// <param name="axisY">Value vector3 axisY.</param>
        /// <param name="axisZ">Value vector3 axisZ.</param>
        public Vector3(double axisX = 0.0, double axisY = 0.0, double axisZ = 0.0)
        {
            this.axisX = axisX;
            this.axisY = axisY;
            this.axisZ = axisZ;
        }

        /// <summary>
        /// The sum of two vectors.
        /// </summary>
        /// <param name="vector1">First Vector.</param>
        /// <param name="vector2">Second vector.</param>
        /// <returns>Sum vector.</returns>
        public static Vector3 operator +(Vector3 vector1, Vector3 vector2)
        {
            return new Vector3(vector1.axisX + vector2.axisX, vector1.axisY + vector2.axisY, vector1.axisZ + vector2.axisZ);
        }

        /// <summary>
        /// Difference of two vectors
        /// </summary>
        /// <param name="vector1">First Vector.</param>
        /// <param name="vector2">Second vector.</param>
        /// <returns>Def vector.</returns>
        public static Vector3 operator -(Vector3 vector1, Vector3 vector2)
        {
            return new Vector3(vector1.axisX - vector2.axisX, vector1.axisY - vector2.axisY, vector1.axisZ - vector2.axisZ);
        }

        /// <summary>
        /// Product of value by a vector.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="vector">Vector.</param>
        /// <returns>Result vector.</returns>
        public static Vector3 operator *(int value, Vector3 vector)
        {
            return new Vector3(value * vector.axisX, value * vector.axisY, value * vector.axisZ);
        }

        /// <summary>
        /// Product of value by a vector.
        /// </summary>
        /// <param name="value">Value.</param>
        /// <param name="vector">Vector.</param>
        /// <returns>Result vector.</returns>
        public static Vector3 operator *(Vector3 vector, int value)
        {
            return value * vector;
        }

        /// <summary>
        /// Product of a vector by a vector.
        /// </summary>
        /// <param name="vector1">First Vector.</param>
        /// <param name="vector2">Second vector.</param>
        /// <returns>Result vector.</returns>
        public static double operator *(Vector3 vector1, Vector3 vector2)
        {
            return vector1.axisX * vector2.axisX + vector1.axisY * vector2.axisY + vector1.axisZ * vector2.axisZ;
        }

        /// <summary>
        /// Override method Equals.
        /// </summary>
        /// <param name="obj">Object.</param>
        /// <returns>Comparison result.</returns>
        public override bool Equals(object obj)
        {
            return obj is Vector3 vector &&
                   axisX == vector.axisX &&
                   axisY == vector.axisY &&
                   axisZ == vector.axisZ;
        }

        /// <summary>
        /// Override method GetHashCode.
        /// </summary>
        /// <returns>Hash code.</returns>
        public override int GetHashCode()
        {
            int hashCode = -1654883107;
            hashCode = hashCode * -1521134295 + axisX.GetHashCode();
            hashCode = hashCode * -1521134295 + axisY.GetHashCode();
            hashCode = hashCode * -1521134295 + axisZ.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Override method ToString.
        /// </summary>
        /// <returns>String vector.</returns>
        public override string ToString()
        {
            return "Vector3{ "+axisX+", "+axisY+", "+axisZ+" }";
        }
    }
}
