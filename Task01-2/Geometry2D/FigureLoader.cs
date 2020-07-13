using System;
using System.IO;
using System.Collections.Generic;

namespace Geometry2D
{
    /// <summary>
    /// FigureLoader work with file and text. Parse it to figure.
    /// </summary>
    public static class FigureLoader
    {
        /// <summary>
        /// Load all figures from file.
        /// </summary>
        /// <param name="file">File.</param>
        /// <returns>Array of figures.</returns>
        public static Figure[] LoadFigures(string file)
        {
            if (!File.Exists(file)) throw new Exception("File not exist");
            StreamReader streamReader = new StreamReader(file);

            string[] strings = streamReader.ReadToEnd().Split(new string[] { "\n\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            List<Figure> figures = new List<Figure>();

            for (int i = 0; i < strings.Length; i++)
            {
                figures.Add(ParseFigure(strings[i]));
            }

            streamReader.Close();

            return figures.ToArray();
        }

        /// <summary>
        /// Convert some text to figure.
        /// </summary>
        /// <param name="text">Text.</param>
        /// <returns>Figure.</returns>
        public static Figure ParseFigure(string text)
        {
            string[] words = text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            Figure figure;
            switch(words[0])
            {
                case "Polygon":
                    figure = new Polygon(double.Parse(words[1]), int.Parse(words[2])); 
                    break;
                case "Rectangle":
                    figure = new Rectangle(double.Parse(words[1]), double.Parse(words[2]));
                    break;
                case "Square":
                    figure = new Square(double.Parse(words[1]));
                    break;
                case "Triangle":
                    figure = new Triangle(double.Parse(words[1]), double.Parse(words[2]), double.Parse(words[3]));
                    break;
                case "Circle":
                    figure = new Сircle(double.Parse(words[1]));
                    break;
                default: throw new Exception("Uncorrect figure.");
            }
            return figure;
        }
    }
}
