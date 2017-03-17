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
        private Random rand;
        public Shape(int startX, int startY)
        {
            shapeX[0] = startX;
            shapeY[0] = startY;
            rand = new Random();
            brush = brushColor[rand.Next(6)];
        }

        public virtual void PaintShape(BufferedGraphics g)
        {
            for (int i = 0; i < shapeX.Length; i++)
            {
                g.Graphics.FillRectangle(brush, shapeX[i] * TetrisGame.SCALE + 1, shapeY[i] * TetrisGame.SCALE + 1, TetrisGame.SCALE - 1, TetrisGame.SCALE - 1);
                //g.Render();
            }
        }

        public void Rotate()
        {
            if (this.GetType().Name != "OShape")
            {
                bool flag = true; //флаг проверки на границу поля
                int[] shapeXTemp = new int[4];
                int[] shapeYTemp = new int[4];

                shapeX.CopyTo(shapeXTemp, 0);
                shapeY.CopyTo(shapeYTemp, 0);


                for (int i = 1; i < shapeX.Length; i++)
                {
                    shapeXTemp[i] = shapeX[0] - (shapeY[i] - shapeY[0]);

                    if (shapeXTemp[i] < 0 || shapeXTemp[i] >= TetrisGame.WIDTH)
                    {
                        flag = false;
                        break;
                    }
                    shapeYTemp[i] = shapeY[0] + (shapeX[i] - shapeX[0]);
                }

                if (flag)
                {
                    shapeX = shapeXTemp;
                    shapeY = shapeYTemp;
                    this.PaintShape(TetrisGame.bufferedGraphics);
                    TetrisGame.ClearForm();
                }
            }
        }

        public bool Move()
        {
            bool flag = false;
            int tempYY = 0;

            int[] shapeYTemp = new int[4];
            shapeY.CopyTo(shapeYTemp, 0);

            for (int i = 0; i < shapeY.Length; i++)
            {
                tempYY = shapeYTemp[i];
                if (!((tempYY += 1 * TetrisGame.SPEED) >= TetrisGame.HEIGHT))
                {
                    shapeYTemp[i] += 1 * TetrisGame.SPEED; 
                }

                else
                {
                    flag = false;
                    break;
                }
                flag = true;
            }
            if (flag)
            {
                shapeY = shapeYTemp;
                this.PaintShape(TetrisGame.bufferedGraphics);
            }
            return flag;
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
