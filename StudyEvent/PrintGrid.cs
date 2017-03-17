using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyEvent
{
    static class PrintGrid
    {
        /// <summary>
        /// Метод рисования сетки на главной форме
        /// </summary>
        /// <param name="mainFormGraphics"> Элемент Graphics главной формы</param>
        public static void PrintGridFromForm(BufferedGraphics mainFormGraphics)
        {
            //Заливка формы стандартным цветом
            //mainFormGraphics.Graphics.Clear(Color.LightGray);
            //Рисование сетки
            Pen myPen = new Pen(Color.DarkGray);

            for (int xx = 0; xx < TetrisGame.WIDTH * TetrisGame.SCALE; xx += TetrisGame.SCALE)
            {
                mainFormGraphics.Graphics.DrawLine(myPen, xx, 0, xx, TetrisGame.HEIGHT * TetrisGame.SCALE);
            }
            for (int yy = 0; yy <= TetrisGame.HEIGHT * TetrisGame.SCALE; yy += TetrisGame.SCALE)
            {
                mainFormGraphics.Graphics.DrawLine(myPen, 0, yy, TetrisGame.WIDTH * TetrisGame.SCALE, yy);
            }

            myPen.Dispose();
        }
    }
}
