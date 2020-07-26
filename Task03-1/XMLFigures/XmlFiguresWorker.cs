using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Figures;

namespace XMLFigures
{
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

            public static Figure SelectingFigureToRead(FiguresReader figuresReader, string type)
            {
                switch (type)
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
                        throw new Exception("Incorrect figure");
                }
            }

        }

        private string file;

        public XmlFiguresWorker(string file = @"..\..\Figures.xml")
        {
            this.file = file;
        }

        public void XmlFiguresWrite(Figure[] figures)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.IndentChars = "\t";
            settings.NewLineChars = "\n\r";
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

        public void StreamFiguresWrite(Figure[] figures)
        {
            using (StreamWriter stream = new StreamWriter(file))
            {
                StreamWriterFigures streamWriterFigures = new StreamWriterFigures(stream);
                stream.WriteLine("");
                stream.WriteLine("<figures>");
                for (int i = 0; i < figures.Length; i++)
                {
                    if (figures[i] != null)
                    {
                        stream.WriteLine("\t<figure>");
                        WorkerHalper.SelectingFigureToWrite(streamWriterFigures, figures[i]);
                        stream.Write("\t</figure>");
                    }
                }
                stream.Write("</figures>");
            }
        }

        public Figure[] XmlReadFigures()
        {
            List<Figure> figures = new List<Figure>();
            using(XmlReader xml = XmlReader.Create(file))
            {
                XmlReaderFigures xmlReaderFigures = new XmlReaderFigures(xml);
                while(xml.ReadToFollowing("type"))
                {
                    xml.Read();
                    figures.Add(WorkerHalper.SelectingFigureToRead(xmlReaderFigures, xml.Value));
                }
            }
            return figures.ToArray();
        }

        public Figure[] StreamReadFigures()
        {
            List<Figure> figures = new List<Figure>();
            using (StreamReader stream = new StreamReader(file))
            {
                StreamReaderFigures streamReaderFigures = new StreamReaderFigures(stream);
                string type = streamReaderFigures.ReadValue("type");
                while (type != null)
                {
                    figures.Add(WorkerHalper.SelectingFigureToRead(streamReaderFigures, type));
                    type = streamReaderFigures.ReadValue("type");
                }
            }
            return figures.ToArray();
        }
    }
}
