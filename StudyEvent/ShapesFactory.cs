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
        public Shape CreateShape()
        {
            switch (new Random(DateTime.Now.Millisecond).Next(8))
            {
                case (int)ShapeKind.LShape:
                    return new LShape(7, -2);
                case (int)ShapeKind.JShape:
                    return new JShape(7, -2);
                case (int)ShapeKind.IShape:
                    return new IShape(7, -2);
                case (int)ShapeKind.TShape:
                    return new TShape(7, -2);
                case (int)ShapeKind.SShape:
                    return new SShape(7, -2);
                case (int)ShapeKind.OShape:
                    return new OShape(7, -2);
                case (int)ShapeKind.ZShape:
                    return new ZShape(7, -2);
                default:
                    return new OShape(7, -2);
            }
        }
    }
}
