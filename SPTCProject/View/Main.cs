using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPTCProject.View
{
    public partial class Main : Form
    {
        bool isMenuOpen;
        public Main()
        {
            InitializeComponent();
            isMenuOpen = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void sideBarTimer_Tick(object sender, EventArgs e)
        {
            if (isMenuOpen)
            {
                sideBar.Width -= 10;
                if (sideBar.Width == sideBar.MinimumSize.Width)
                {
                    sideBarTimer.Stop();
                    isMenuOpen = false;
                }
            }
                else
            {
                sideBar.Width += 10;
                if (sideBar.Width == sideBar.MaximumSize.Width)
                {
                    sideBarTimer.Stop();
                    isMenuOpen = true;
                }
            } 
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            sideBarTimer.Start();
        }

        private void btnMenu_MouseHover(object sender, EventArgs e)
        {
            btnMenu.PerformClick();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }
    }
}
