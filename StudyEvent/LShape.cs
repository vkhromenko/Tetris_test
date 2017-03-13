using System;
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

        public override void PaintShape()
        {
            for (int i = 0; i < shapeX.Length; i++)
            {
                TetrisGame.mainGraphics.FillRectangle(Brushes.DarkGreen, shapeX[i] * TetrisGame.SCALE + 1, shapeY[i] * TetrisGame.SCALE + 1, TetrisGame.SCALE - 1, TetrisGame.SCALE - 1);
            }
        }
    }
}
