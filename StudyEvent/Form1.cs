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

namespace StudyEvent
{
    public partial class TetrisGame : Form
    {
        public static int WIDTH = 20;
        public static int HEIGHT = 40;
        public static int SCALE = 30;
        public static int SPEED = 1;


        public static Graphics mainGraphics;

        public TetrisGame()
        {
            InitializeComponent();
            mainArea.Panel1.ClientSize = new System.Drawing.Size(WIDTH * SCALE, HEIGHT * SCALE);
            mainGraphics = mainArea.Panel1.CreateGraphics();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {
            Shape testShape = new LShape(10, -2);
            testShape.PaintShape();

            while (true)
            {
                Thread.Sleep(500);
                mainGraphics.Clear(Color.LightGray);
                testShape.Move();
                
            }
        }
    }


}
