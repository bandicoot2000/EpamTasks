using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figures;

namespace XMLFigures
{
    class StreamWriterFigures : FiguresWriter
    {
        private  StreamWriter stream;

        public StreamWriterFigures(StreamWriter streamWriter)
        {
            stream = streamWriter;
        }

        private void WriteValue(string value, string elementName)
        {
            stream.Write("\t\t<" + elementName + ">");
            stream.Write(value);
            stream.WriteLine("</" + elementName + ">");
        }

        public override void WriteCircle(Circle circle)
        {
            WriteValue("Circle", "kind");
            WriteValue(circle.GetMaterial().ToString("Type"), "material");
            if (circle.GetMaterial() is Paper) WriteValue(((Paper)circle.GetMaterial()).Color.ToString(), "color");
            WriteValue(circle.Radius.ToString("F"), "radius");
        }

        public override void WritePolygon(Polygon polygon)
        {
            WriteValue("Polygon", "kind");
            WriteValue(polygon.GetMaterial().ToString("Type"), "material");
            if (polygon.GetMaterial() is Paper) WriteValue(((Paper)polygon.GetMaterial()).Color.ToString(), "color");
            WriteValue(polygon.Side.ToString("F"), "side");
            WriteValue(polygon.AmountSides.ToString(), "amountSide");
        }

        public override void WriteRectangle(Rectangle rectangle)
        {
            WriteValue("Rectangle", "kind");
            WriteValue(rectangle.GetMaterial().ToString("Type"), "material");
            if (rectangle.GetMaterial() is Paper) WriteValue(((Paper)rectangle.GetMaterial()).Color.ToString(), "color");
            WriteValue(rectangle.Length.ToString("F"), "lingth");
            WriteValue(rectangle.Width.ToString("F"), "width");
        }

        public override void WriteSquare(Square square)
        {
            WriteValue("Square", "kind");
            WriteValue(square.GetMaterial().ToString("Type"), "material");
            if (square.GetMaterial() is Paper) WriteValue(((Paper)square.GetMaterial()).Color.ToString(), "color");
            WriteValue(square.Side.ToString("F"), "side");
        }

        public override void WriteTriangle(Triangle triangle)
        {
            WriteValue("Square", "kind");
            WriteValue(triangle.GetMaterial().ToString("Type"), "material");
            if (triangle.GetMaterial() is Paper) WriteValue(((Paper)triangle.GetMaterial()).Color.ToString(), "color");
            WriteValue(triangle.SideA.ToString("F"), "sideA");
            WriteValue(triangle.SideB.ToString("F"), "sideB");
            WriteValue(triangle.SideC.ToString("F"), "sideC");
        }
    }
}
