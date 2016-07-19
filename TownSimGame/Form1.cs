using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TownSimGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        GameManager gameManager;

        private void Form1_Load(object sender, EventArgs e)
        {
            //WindowState = FormWindowState.Maximized;
            gameManager = new GameManager(gamePanel.Size);
        }

        private void gamePanel_Click(object sender, EventArgs e)
        {
            Point point = gamePanel.PointToClient(Cursor.Position);
            gameManager.handleClick(point);
            //gamePanel.CreateGraphics().DrawLine(new Pen(Color.Black), Point.Empty, point);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            gameManager.doTick();
            using (Bitmap frame = new Bitmap(gamePanel.Width, gamePanel.Height))
            {
                using (Graphics gr = Graphics.FromImage(frame))
                {
                    gameManager.drawGame(gr);
                }
                using (Graphics gr = gamePanel.CreateGraphics())
                {
                    gr.DrawImage(frame, Point.Empty);
                }
            }
        }
    }
}
