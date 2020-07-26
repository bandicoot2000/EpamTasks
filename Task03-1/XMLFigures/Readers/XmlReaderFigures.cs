using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Figures;

namespace XMLFigures
{
    class XmlReaderFigures : FiguresReader
    {
        private  XmlReader xml;

        public XmlReaderFigures(XmlReader xmlReader)
        {
            xml = xmlReader;
        }

        public string ReadValue(string elementName)
        {
            while (xml.Name != elementName)
                xml.Read();
            xml.Read();
            return xml.Value;
        }

        public override Circle ReadCircle()
        {
            IMaterial material;
            if (ReadValue("material") == "Paper") material = new Paper((Color)(Enum.Parse(typeof(Color), ReadValue("color"))));
            else material = new Film();
            return new Circle(double.Parse(ReadValue("radius")), material);
        }

        public override Polygon ReadPolygon()
        {
            IMaterial material;
            if (ReadValue("material") == "Paper") material = new Paper((Color)(Enum.Parse(typeof(Color), ReadValue("color"))));
            else material = new Film();
            return new Polygon(double.Parse(ReadValue("side")), int.Parse(ReadValue("amountSide")), material);
        }

        public override Rectangle ReadRectangle()
        {
            IMaterial material;
            if (ReadValue("material") == "Paper") material = new Paper((Color)(Enum.Parse(typeof(Color), ReadValue("color"))));
            else material = new Film();
            return new Rectangle(double.Parse(ReadValue("lingth")), int.Parse(ReadValue("width")), material);
        }

        public override Square ReadSquare()
        {
            IMaterial material;
            if (ReadValue("material") == "Paper") material = new Paper((Color)(Enum.Parse(typeof(Color), ReadValue("color"))));
            else material = new Film();
            return new Square(double.Parse(ReadValue("side")), material);
        }

        public override Triangle ReadTriangle()
        {
            IMaterial material;
            if (ReadValue("material") == "Paper") material = new Paper((Color)(Enum.Parse(typeof(Color), ReadValue("color"))));
            else material = new Film();
            return new Triangle(double.Parse(ReadValue("sideA")), double.Parse(ReadValue("sideB")), double.Parse(ReadValue("sideC")), material);
        }
    }
}
