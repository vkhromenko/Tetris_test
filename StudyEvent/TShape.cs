using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyEvent
{
    class TShape : Shape
    {
        public TShape(int startX, int startY) : base(startX, startY)
        {
            shapeX[1] = startX - 1;
            shapeY[1] = startY - 1;

            shapeX[2] = startX - 1;
            shapeY[2] = startY;

            shapeX[3] = startX - 1;
            shapeY[3] = startY + 1;
        }
    }
}
