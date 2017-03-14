﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyEvent
{
    class LShape : Shape
    {
        public LShape(int startX, int startY) : base(startX, startY)
        {
            shapeX[1] = startX;
            shapeY[1] = startY - 1;

            shapeX[2] = startX;
            shapeY[2] = startY + 1;

            shapeX[3] = startX + 1;
            shapeY[3] = startY + 1;
        }

    }
}
