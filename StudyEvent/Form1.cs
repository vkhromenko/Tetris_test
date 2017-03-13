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
        private Timer timer;
        private List<Shape> shapeContainer;
        private List<int> coordXContainer;
        private List<int> coordYContainer;

        public static Graphics mainGraphics;

        public TetrisGame()
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(WIDTH * SCALE + 225, HEIGHT * SCALE);
            mainArea.Panel1.ClientSize = new System.Drawing.Size(WIDTH * SCALE, HEIGHT * SCALE);
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

        private void AdditionInLists(Shape tempShape)
        {
            shapeContainer.Add(testShape);
            for (int i = 0; i < testShape.shapeX.Length; i++)
            {
                coordXContainer.Add(testShape.shapeX[i]);
                coordYContainer.Add(testShape.shapeY[i]);
            }
        }

        private void shapePicture_Paint(object sender, PaintEventArgs e)
        {
            timer = new Timer();
            timer.Interval = 100;

            timer.Tick += Timer_Tick;
            testShape = factory.CreateShape();

            //testShape.PaintShape(mainGraphics);

            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (testShape.shapeY[3] == HEIGHT - 1 || testShape.shapeY[0] == HEIGHT - 1)
            {
                AdditionInLists(testShape);
                testShape = factory.CreateShape();
            }

            ClearForm();
            testShape.Move();
        }

    }


}
