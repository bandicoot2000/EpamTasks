using Figures;

namespace XMLFigures
{
    /// <summary>
    /// Figure Writer
    /// </summary>
    abstract class FiguresWriter
    {
        /// <summary>
        /// Write circle.
        /// </summary>
        /// <param name="circle">Circle.</param>
        public abstract void WriteCircle(Circle circle);
        /// <summary>
        /// Write polygon.
        /// </summary>
        /// <param name="polygon">Polygon.</param>
        public abstract void WritePolygon(Polygon polygon);
        /// <summary>
        /// Write rectangle.
        /// </summary>
        /// <param name="rectangle">Rectangle.</param>
        public abstract void WriteRectangle(Rectangle rectangle);
        /// <summary>
        /// Write square.
        /// </summary>
        /// <param name="square">Square.</param>
        public abstract void WriteSquare(Square square);
        /// <summary>
        /// Write triangle.
        /// </summary>
        /// <param name="triangle">Triangle.</param>
        public abstract void WriteTriangle(Triangle triangle);
    }
}
