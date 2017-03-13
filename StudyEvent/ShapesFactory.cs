using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyEvent
{
    class ShapesFactory
    {

        private Random rand;

        public Shape CreateShape()
        {
            rand = new Random();
            switch(rand.Next(8))
            {
                case (int)ShapeKind.LShape:
                    return new LShape(rand.Next(1, TetrisGame.WIDTH - 1), -2);
                case (int)ShapeKind.JShape:
                    return new JShape(rand.Next(1, TetrisGame.WIDTH - 1), -2);
                case (int)ShapeKind.IShape:
                    return new IShape(rand.Next(1, TetrisGame.WIDTH - 1), -2);
                case (int)ShapeKind.TShape:
                    return new TShape(rand.Next(1, TetrisGame.WIDTH - 1), -2);
                case (int)ShapeKind.SShape:
                    return new SShape(rand.Next(1, TetrisGame.WIDTH - 1), -2);
                case (int)ShapeKind.OShape:
                    return new OShape(rand.Next(1, TetrisGame.WIDTH - 1), -2);
                case (int)ShapeKind.ZShape:
                    return new ZShape(rand.Next(1, TetrisGame.WIDTH - 1), -2);
                default:
                    return new OShape(rand.Next(1, TetrisGame.WIDTH - 1), -2);
            }
        }
    }
}
