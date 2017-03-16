using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
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


        public static Graphics mainGraphics;
        public static Graphics prevGraphics;

        public TetrisGame()
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(WIDTH * SCALE + 225, HEIGHT * SCALE);
            shapePicture.ClientSize = new System.Drawing.Size(WIDTH * SCALE, HEIGHT * SCALE);
            pbPreview.ClientSize = new Size(3 * SCALE, 4 * SCALE);
            prevGraphics = pbPreview.CreateGraphics();
            mainGraphics = shapePicture.CreateGraphics();
            factory = new ShapesFactory();
            coordXContainer = new List<int>();
            coordYContainer = new List<int>();
            shapeContainer = new List<Shape>();
        }

        public static void ClearForm()
        {
            mainGraphics.Clear(Color.LightGray);

            foreach (Shape shape in shapeContainer)
            {
                shape.PaintShape(mainGraphics);
            }
            testShape.PaintShape(mainGraphics);
        }

        public static void ClearForm(Graphics preGraphics)
        {
            preGraphics.Clear(Color.LightGray);
            Shape tmp = prevShape;

            if (tmp != null)
            {
                for (int j = 0; j < prevShape.shapeY.Length; j++)
                {
                    tmp.shapeY[j] += 4;
                    tmp.shapeX[j] -= 6;
                }
                tmp.PaintShape(preGraphics);
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
        private void shapePicture_Paint(object sender, PaintEventArgs e)
        {
            timer.Interval = 50;

            timer.Tick += Timer_Tick;
            testShape = factory.CreateShape();
            prevShape = factory.CreateShape();
            ClearForm(prevGraphics);
            //testShape.PaintShape(mainGraphics);

            timer.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
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
            ClearForm();
        }

        private void AddAndCreate()
        {
            AdditionInLists(testShape);
            testShape = prevShape;
            prevShape = factory.CreateShape();
            ClearForm(prevGraphics);
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
            //else if (e.KeyCode == Keys.Down)
            //{
            //    if (!ContainsCoord(testShape, Direction.Down))
            //        testShape.Accelerate();
            //}
        }

        private void TetrisGame_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Down)
            //    SPEED = 1;
        }
    }
}
