using System;
using System.Collections.Generic;
using System.Drawing;
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
        Сlockwise,
        CounterclockWise,
    }

    public abstract class Shape
    {
        internal int[] shapeX = new int[4];
        internal int[] shapeY = new int[4];

        public Shape(int startX, int startY)
        {
            shapeX[0] = startX;
            shapeY[0] = startY;
        }

        public abstract void PaintShape();

        public void Rotate(Direction direction = Direction.Сlockwise)
        {
            if (direction == Direction.Сlockwise)
            {
                for (int i = 1; i < shapeX.Length - 1; i++)
                {
                    shapeX[i]++;
                    shapeY[i]++;
                }
            }
            else
            {
                for (int i = 1; i < shapeX.Length - 1; i++)
                {
                    shapeX[i]--;
                    shapeY[i]--;
                }
            }
            this.PaintShape();
        }

        public void Accelerate()
        {
            TetrisGame.SPEED = 3;
        }

        public void Move()
        {
            for (int i = 0; i < shapeY.Length; i++)
            {
                shapeY[i]++;
            }
            this.PaintShape();
        }

        public void MoveLeft()
        {
            for (int i = 0; i < shapeY.Length; i++)
            {
                shapeX[i]--;
            }
        }

        public void MoveRight()
        {
            for (int i = 0; i < shapeY.Length; i++)
            {
                shapeX[i]++;
            }
        }
    }


}
