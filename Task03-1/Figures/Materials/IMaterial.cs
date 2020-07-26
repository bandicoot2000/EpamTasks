namespace Figures
{
    /// <summary>
    /// Material figure
    /// </summary>
    public interface IMaterial
    {
        /// <summary>
        /// Return string info.
        /// </summary>
        /// <param name="format">Info format.</param>
        /// <returns>String info.</returns>
        string ToString(string format);
    }
}
