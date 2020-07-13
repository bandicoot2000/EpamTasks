namespace Geometry2D
{
    /// <summary>
    /// 2D geometric figure.
    /// </summary>
    public abstract class Figure
    {
        /// <summary>
        /// Get the perimeter of this figure.
        /// </summary>
        /// <returns>Perimeter figure.</returns>
        public abstract double GetPerimeter();
        /// <summary>
        /// Get the area of this figure.
        /// </summary>
        /// <returns>Area figure.</returns>
        public abstract double GetArea();

    }
}
