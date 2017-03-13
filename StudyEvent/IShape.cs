using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyEvent
{
    class IShape : Shape
    {
        public IShape(int startX, int startY) : base(startX, startY)
        {
            shapeX[1] = startX;
            shapeY[1] = startY - 2;

            shapeX[2] = startX;
            shapeY[2] = startY - 1;

            shapeX[3] = startX;
            shapeY[3] = startY + 1;
        }
    }
}
