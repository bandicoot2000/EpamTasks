﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figures
{
    interface IFigure
    {
        double GetPerimeter();
        double GetArea();
        IMaterial GetMaterial();
        void PaintFigure(Color color);
    }
}
