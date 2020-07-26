using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figures;

namespace XMLFigures
{
    abstract class FiguresWriter
    {
        public abstract void WriteCircle(Circle circle);

        public abstract void WritePolygon(Polygon polygon);

        public abstract void WriteRectangle(Rectangle rectangle); 
        
        public abstract void WriteSquare(Square square);

        public abstract void WriteTriangle(Triangle triangle);
    }
}
