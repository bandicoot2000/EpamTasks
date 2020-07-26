using Figures;

namespace XMLFigures
{
    /// <summary>
    /// Figure reader.
    /// </summary>
    abstract class FiguresReader
    {
        /// <summary>
        /// Read circle.
        /// </summary>
        /// <returns>Circle.</returns>
        public abstract Circle ReadCircle();
        /// <summary>
        /// Read polygon.
        /// </summary>
        /// <returns>Polygon.</returns>
        public abstract Polygon ReadPolygon();
        /// <summary>
        /// Read rectangle.
        /// </summary>
        /// <returns>Rectangle.</returns>
        public abstract Rectangle ReadRectangle();
        /// <summary>
        /// Read square.
        /// </summary>
        /// <returns>Square.</returns>
        public abstract Square ReadSquare();
        /// <summary>
        /// Read triangle.
        /// </summary>
        /// <returns>Triangle.</returns>
        public abstract Triangle ReadTriangle();
    }
}
