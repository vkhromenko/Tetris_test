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
        private Shape testShape;
        private static Timer timer = new Timer();
        private List<Shape> shapeContainer;
        private List<int> coordXContainer;
        private List<int> coordYContainer;

        public static Graphics mainGraphics;

        public TetrisGame()
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(WIDTH * SCALE + 225, HEIGHT * SCALE);
            shapePicture.ClientSize = new System.Drawing.Size(WIDTH * SCALE, HEIGHT * SCALE);
            mainGraphics = shapePicture.CreateGraphics();
            factory = new ShapesFactory();
            coordXContainer = new List<int>();
            coordYContainer = new List<int>();
            shapeContainer = new List<Shape>();
        }

        private void ClearForm()
        {
            mainGraphics.Clear(Color.LightGray);
            foreach (Shape shape in shapeContainer)
            {
                shape.PaintShape(mainGraphics);
            }
        }

        private bool AdditionInLists(Shape tempShape)
        {

            for (int i = 0; i < testShape.shapeX.Length; i++)
            {
                if (testShape.shapeY[i] != 0)
                {
                    coordXContainer.Add(testShape.shapeX[i]);
                    coordYContainer.Add(testShape.shapeY[i]);
                }
                else return false;
            }
            shapeContainer.Add(testShape);
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
        private void shapePicture_Paint(object sender, PaintEventArgs e)
        {
            timer.Interval = 500;

            timer.Tick += Timer_Tick;
            testShape = factory.CreateShape();

            //testShape.PaintShape(mainGraphics);

            timer.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (testShape.shapeY[3] > HEIGHT || testShape.shapeY[0] > HEIGHT || testShape.shapeY[1] > HEIGHT || testShape.shapeY[2] > HEIGHT)
            {
                AdditionInLists(testShape);
                testShape = factory.CreateShape();
            }

            if (!ContainsCoord(testShape))
            {
                ClearForm();
                testShape.Move();
            }
            else
            {
                if (AdditionInLists(testShape))
                    testShape = factory.CreateShape();
                else
                {
                    timer.Stop();
                    MessageBox.Show("Game Over!");
                }
            }
        }

        private void TetrisGame_KeyPress(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                testShape.MoveLeft();
            }
            else if(e.KeyCode == Keys.Right)
            {
                testShape.MoveRight();
            }else if (e.KeyCode == Keys.Up)
            {
                testShape.Rotate();
            }else if (e.KeyCode == Keys.Down)
            {
                testShape.Accelerate();
            }
        }
    }
}
