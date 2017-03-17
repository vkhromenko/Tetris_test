using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace StudyEvent
{
    public partial class TetrisGame : Form
    {
        public static int WIDTH = 15;
        public static int HEIGHT = 25;
        public static int SCALE = 30;
        public static int SPEED = 1;
        private ShapesFactory factory;

        private static Shape testShape;
        private static Shape prevShape;

        private static Timer timer = new Timer();
        private static List<Shape> shapeContainer;
        private List<int> coordXContainer;
        private List<int> coordYContainer;
        private int score = 0;
        private int step = 1;

        public BufferedGraphicsContext bufferedGraphicsContext;
        public static BufferedGraphics bufferedGraphics;
        public static Graphics mainGraphics;

        public BufferedGraphicsContext preBufferedGraphicsContext;
        public static BufferedGraphics preBufferedGraphics;
        public static Graphics prevGraphics;

        public TetrisGame()
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(WIDTH * SCALE + 225, HEIGHT * SCALE);
            shapePicture.ClientSize = new System.Drawing.Size(WIDTH * SCALE, HEIGHT * SCALE);
            pbPreview.ClientSize = new Size(3 * SCALE, 4 * SCALE);
            prevGraphics = pbPreview.CreateGraphics();
            mainGraphics = shapePicture.CreateGraphics();

            bufferedGraphicsContext = new BufferedGraphicsContext();
            bufferedGraphics = bufferedGraphicsContext.Allocate(mainGraphics, new Rectangle(0, 0, shapePicture.Width, shapePicture.Height));

            preBufferedGraphicsContext = new BufferedGraphicsContext();
            preBufferedGraphics = preBufferedGraphicsContext.Allocate(prevGraphics, new Rectangle(0, 0, pbPreview.Width, pbPreview.Height));

            factory = new ShapesFactory();
            coordXContainer = new List<int>();
            coordYContainer = new List<int>();
            shapeContainer = new List<Shape>();
        }

        public static void ClearForm()
        {
            bufferedGraphics.Graphics.Clear(Color.Ivory);
            PrintGrid.PrintGridFromForm(bufferedGraphics);

            foreach (Shape shape in shapeContainer)
            {
                shape.PaintShape(bufferedGraphics);
            }
            testShape.PaintShape(bufferedGraphics);
            bufferedGraphics.Render();
        }

        public static void ClearForm(BufferedGraphics preBufferedGraphics)
        {
            preBufferedGraphics.Graphics.Clear(Color.LightGray);
            Shape tmp = prevShape;

            if (tmp != null)
            {
                for (int j = 0; j < prevShape.shapeY.Length; j++)
                {
                    tmp.shapeY[j] += 4;
                    tmp.shapeX[j] -= 6;
                }

                tmp.PaintShape(preBufferedGraphics);
                preBufferedGraphics.Render();
                for (int j = 0; j < prevShape.shapeY.Length; j++)
                {
                    tmp.shapeY[j] -= 4;
                    tmp.shapeX[j] += 6;
                }
            }
        }

        private bool AdditionInLists(Shape tempShape)
        {
            for (int i = 0; i < tempShape.shapeX.Length; i++)
            {
                if (tempShape.shapeY[i] == 0)
                {
                    timer.Stop();
                    MessageBox.Show("Game Over!");
                    break;
                }
                if (tempShape.shapeY[i] != 0)
                {
                    coordXContainer.Add(tempShape.shapeX[i]);
                    coordYContainer.Add(tempShape.shapeY[i]);
                }
                else return false;
            }
            shapeContainer.Add(tempShape);
            return true;
        }

        private bool ContainsCoord(Shape tempShape)
        {
            bool flag = false;
            for (int i = 0; i < coordXContainer.Count; i++)
            {
                for (int j = 0; j < tempShape.shapeX.Length; j++)
                {
                    if (tempShape.shapeX[j] == coordXContainer[i] && tempShape.shapeY[j] + 1 == coordYContainer[i])
                    {
                        flag = true;
                    }
                }
            }
            return flag;
        }

        private bool ContainsCoord(Shape tempShape, Direction direction)
        {
            bool flag = false;

            if (direction != Direction.Down)
            {
                for (int i = 0; i < coordXContainer.Count; i++)
                {
                    for (int j = 0; j < tempShape.shapeX.Length; j++)
                    {
                        if (tempShape.shapeX[j] + (int) direction == coordXContainer[i] &&
                            tempShape.shapeY[j] == coordYContainer[i])
                        {
                            flag = true;
                        }
                    }
                }
            }

            return flag;
        }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            ClearForm();
            bool isMoving = false;
            lbStep.Text = step.ToString();
        
            if (!ContainsCoord(testShape))
            {
                isMoving = testShape.Move();
                if (!isMoving)
                {
                    AddAndCreate();
                }
            }
            else
            {
                AddAndCreate();
            }
        }

        private void AddAndCreate()
        {
            AdditionInLists(testShape);
            testShape = prevShape;
            prevShape = factory.CreateShape();
            ClearForm(preBufferedGraphics);
            step++;
        }

        private void TetrisGame_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                if (!ContainsCoord(testShape, Direction.Left))
                    testShape.MoveLeft();
            }
            else if(e.KeyCode == Keys.Right)
            {
                if (!ContainsCoord(testShape, Direction.Right))
                    testShape.MoveRight();
            }
            else if (e.KeyCode == Keys.Up)
            {
                if (!ContainsCoord(testShape, Direction.Left) && !ContainsCoord(testShape, Direction.Right))
                    testShape.Rotate();
            }
            else if (e.KeyCode == Keys.Space)
            {
                if (timer.Enabled)
                    timer.Stop();
                else timer.Start();
            }
            else if (e.KeyCode == Keys.Enter)
            {
                timer.Interval = 100;

                timer.Tick += Timer_Tick;
                testShape = factory.CreateShape();
                prevShape = factory.CreateShape();
                ClearForm(preBufferedGraphics);

                timer.Enabled = true;
            }
            //else if (e.KeyCode == Keys.Down)
            //{
            //    if (!ContainsCoord(testShape, Direction.Down))
            //        SPEED = 2;
            //}
        }

        private void TetrisGame_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Down)
            //    SPEED = 1;
        }
    }
}
