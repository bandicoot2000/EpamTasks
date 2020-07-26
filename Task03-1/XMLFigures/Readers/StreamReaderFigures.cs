using System;
using System.IO;
using System.Text.RegularExpressions;
using Figures;

namespace XMLFigures
{
    class StreamReaderFigures : FiguresReader
    {
        private  StreamReader stream;

        public StreamReaderFigures(StreamReader streamReader)
        {
            stream = streamReader;
        }

        public string ReadValue(string elementName)
        {
            Regex regex = new Regex("<" + elementName + ">(.*)</" + elementName + ">");
            string line = stream.ReadLine();
            while (!regex.IsMatch(line))
            {
                line = stream.ReadLine();
                if (stream.EndOfStream) return null;
            }
            string[] words = line.Split(new string[] { "\t\t<" + elementName + ">", "</" + elementName + ">" }, StringSplitOptions.RemoveEmptyEntries);
            return words[0];
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
            return new Rectangle(double.Parse(ReadValue("lingth")), double.Parse(ReadValue("width")), material);
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
