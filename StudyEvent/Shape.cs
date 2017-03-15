using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyEvent
{
    public enum ShapeKind
    {
        LShape = 0,
        JShape = 1,
        ZShape = 2,
        SShape = 3,
        TShape = 4,
        IShape = 5,
        OShape = 6,
    }

    public enum Direction
    {
        Right = 1,
        Left = -1,
        Down = 2,
    }

    //public enum ShapeColor
    //{
    //    Green,
    //    Red,
    //    Blue,
    //    Gray,
    //    Yellow,
    //    Brown,
    //}

    public abstract class Shape
    {
        internal int[] shapeX = new int[4];
        internal int[] shapeY = new int[4];
        internal Brush[] brushColor = new SolidBrush[]{ new SolidBrush(Color.Blue), new SolidBrush(Color.DarkGreen), new SolidBrush(Color.Brown), new SolidBrush(Color.DarkOrange), new SolidBrush(Color.DarkSlateBlue), new SolidBrush(Color.DimGray) };
        internal Brush brush;

        public Shape(int startX, int startY)
        {
            shapeX[0] = startX;
            shapeY[0] = startY;
            brush = brushColor[new Random().Next(6)];
        }

        public virtual void PaintShape(Graphics g)
        {
            for (int i = 0; i < shapeX.Length; i++)
            {
                TetrisGame.mainGraphics.FillRectangle(brush, shapeX[i] * TetrisGame.SCALE + 1, shapeY[i] * TetrisGame.SCALE + 1, TetrisGame.SCALE - 1, TetrisGame.SCALE - 1);
            }
        }

        public void Rotate()
        {
            if (this.GetType().Name != "OShape")
            {
                int count = 0;

                int[] shapeXTemp = new int[4];
                int[] shapeYTemp = new int[4];

                shapeX.CopyTo(shapeXTemp, 0);
                shapeY.CopyTo(shapeYTemp, 0);

                for (int i = 0; i < shapeX.Length; i++)
                {
                    if (shapeX[0] == shapeX[i])
                        count++;

                } 
                if ((shapeX[0] > 0 && shapeX[1] > 0 && shapeX[2] > 0 && shapeX[3] > 0) && count >= 2)
                {

                    for (int i = 1; i < shapeX.Length; i++)
                    {
                        shapeX[i] = shapeXTemp[0] - (shapeYTemp[i] - shapeYTemp[0]);
                        shapeY[i] = shapeYTemp[0] + (shapeXTemp[i] - shapeXTemp[0]);
                    }

                    this.PaintShape(TetrisGame.mainGraphics);
                    TetrisGame.ClearForm();
                }
            }
        }

        public void Move()
        {
            for (int i = 0; i < shapeY.Length; i++)
            {
                shapeY[i] += 1 * TetrisGame.SPEED;
            }
            this.PaintShape(TetrisGame.mainGraphics);
        }

        public void MoveLeft()
        {
            if (shapeX[0] > 0 && shapeX[1] > 0 && shapeX[2] > 0 && shapeX[3] > 0)
            {
                for (int i = 0; i < shapeY.Length; i++)
                {
                    shapeX[i]--;
                }
            }
        }

        public void MoveRight()
        {
            if (shapeX[0] < TetrisGame.WIDTH - 1 && shapeX[1] < TetrisGame.WIDTH - 1 && shapeX[2] < TetrisGame.WIDTH - 1 && shapeX[3] < TetrisGame.WIDTH - 1)
            {
                for (int i = 0; i < shapeY.Length; i++)
                {
                    shapeX[i]++;
                }
            }
        }

        public override string ToString()
        {
            return string.Format("[X = {}, Y = {}]", shapeX[0], shapeY[0]);
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}
