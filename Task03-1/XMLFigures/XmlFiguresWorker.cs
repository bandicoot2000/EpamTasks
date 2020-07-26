using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using Figures;

namespace XMLFigures
{
    /// <summary>
    /// Class works with xml files.
    /// </summary>
    public class XmlFiguresWorker
    {
        private static class WorkerHalper
        {
            public static void SelectingFigureToWrite(FiguresWriter figuresWriter, Figure figure)
            {
                switch (figure)
                {
                    case Circle circle:
                        figuresWriter.WriteCircle(circle);
                        break;
                    case Polygon polygon:
                        figuresWriter.WritePolygon(polygon);
                        break;
                    case Rectangle rectangle:
                        figuresWriter.WriteRectangle(rectangle);
                        break;
                    case Square square:
                        figuresWriter.WriteSquare(square);
                        break;
                    case Triangle triangle:
                        figuresWriter.WriteTriangle(triangle);
                        break;
                    default:
                        throw new Exception("Incorrect figure");
                }
            }

            public static Figure SelectingFigureToRead(FiguresReader figuresReader, string kind)
            {
                switch (kind)
                {
                    case "Circle":
                        return figuresReader.ReadCircle();
                    case "Polygon":
                        return figuresReader.ReadPolygon();
                    case "Rectangle":
                        return figuresReader.ReadRectangle();
                    case "Square":
                        return figuresReader.ReadSquare();
                    case "Triangle":
                        return figuresReader.ReadTriangle();
                    default:
                        throw new Exception("Incorrect figure " + kind);
                }
            }

        }

        private string file;

        /// <summary>
        /// Created new XmlFiguresWorker.
        /// </summary>
        /// <param name="file">File.</param>
        public XmlFiguresWorker(string file = @"..\..\..\Figures.xml")
        {
            this.file = file;
        }

        /// <summary>
        /// Write figures to xml file use XmlWriter.
        /// </summary>
        /// <param name="figures">Figures.</param>
        public void XmlFiguresWrite(Figure[] figures)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            settings.NewLineChars = "\r\n";
            using (XmlWriter xml = XmlWriter.Create(file, settings))
            {
                XmlWriterFigures xmlWriterFigures = new XmlWriterFigures(xml);
                xml.WriteStartDocument();
                xml.WriteStartElement("figures");
                for (int i = 0; i < figures.Length; i++)
                {
                    if(figures[i] != null)
                    {
                        xml.WriteStartElement("figure");
                        WorkerHalper.SelectingFigureToWrite(xmlWriterFigures, figures[i]);
                        xml.WriteEndElement();
                    }
                }
                xml.WriteEndElement();
            }
        }

        /// <summary>
        /// Write figures to xml file use StreamWriter.
        /// </summary>
        /// <param name="figures">Figures.</param>
        public void StreamFiguresWrite(Figure[] figures)
        {
            using (StreamWriter stream = new StreamWriter(file))
            {
                StreamWriterFigures streamWriterFigures = new StreamWriterFigures(stream);
                stream.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                stream.WriteLine("<figures>");
                for (int i = 0; i < figures.Length; i++)
                {
                    if (figures[i] != null)
                    {
                        stream.WriteLine("\t<figure>");
                        WorkerHalper.SelectingFigureToWrite(streamWriterFigures, figures[i]);
                        stream.WriteLine("\t</figure>");
                    }
                }
                stream.Write("</figures>");
            }
        }

        /// <summary>
        /// Read figures from file use XmlReader.
        /// </summary>
        /// <returns>Figures.</returns>
        public Figure[] XmlFiguresRead()
        {
            List<Figure> figures = new List<Figure>();
            using(XmlReader xml = XmlReader.Create(file))
            {
                XmlReaderFigures xmlReaderFigures = new XmlReaderFigures(xml);
                while(xml.ReadToFollowing("kind"))
                {
                    xml.Read();
                    figures.Add(WorkerHalper.SelectingFigureToRead(xmlReaderFigures, xml.Value));
                }
            }
            return figures.ToArray();
        }

        /// <summary>
        /// Read figures from file use StreamReader.
        /// </summary>
        /// <returns>Figures.</returns>
        public Figure[] StreamFiguresRead()
        {
            List<Figure> figures = new List<Figure>();
            using (StreamReader stream = new StreamReader(file))
            {
                StreamReaderFigures streamReaderFigures = new StreamReaderFigures(stream);
                string kind = streamReaderFigures.ReadValue("kind");
                while (kind != null)
                {
                    figures.Add(WorkerHalper.SelectingFigureToRead(streamReaderFigures, kind));
                    kind = streamReaderFigures.ReadValue("kind");
                }
            }
            return figures.ToArray();
        }
    }
}
