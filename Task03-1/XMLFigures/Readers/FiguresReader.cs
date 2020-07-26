using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Figures;

namespace XMLFigures
{
    abstract class FiguresReader
    {
        public abstract Circle ReadCircle();

        public abstract Polygon ReadPolygon();

        public abstract Rectangle ReadRectangle();

        public abstract Square ReadSquare();

        public abstract Triangle ReadTriangle();
    }
}
