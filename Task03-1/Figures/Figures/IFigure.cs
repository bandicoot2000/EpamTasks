namespace Figures
{
    /// <summary>
    /// Interface figure.
    /// </summary>
    public interface IFigure
    {
        /// <summary>
        /// Calculation perimeter figure.
        /// </summary>
        /// <returns>Perimeter.</returns>
        double GetPerimeter();
        /// <summary>
        /// Calculation area figure.
        /// </summary>
        /// <returns>Area.</returns>
        double GetArea();
        /// <summary>
        /// Material figure.
        /// </summary>
        /// <returns>Material.</returns>
        IMaterial GetMaterial();
        /// <summary>
        /// Paint figure
        /// </summary>
        /// <param name="color">Color.</param>
        void PaintFigure(Color color);
    }
}
