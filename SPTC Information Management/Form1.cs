using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPTC_Information_Management
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            var tabControl = (TabControl)sender;
            var tabPage = tabControl.TabPages[e.Index];
            var rect = tabControl.GetTabRect(e.Index);

            // Draw the tab background
            e.Graphics.FillRectangle(SystemBrushes.Control, e.Bounds);

            // Draw the close (x) icon
            using (var pen = new Pen(Color.Black, 2))
            using (var brush = new SolidBrush(Color.Black))
            {
                e.Graphics.DrawLine(pen, rect.Right - 15, rect.Top + 5, rect.Right - 5, rect.Top + 15);
                e.Graphics.DrawLine(pen, rect.Right - 15, rect.Top + 15, rect.Right - 5, rect.Top + 5);
            }

            // Draw the tab text
            TextRenderer.DrawText(e.Graphics, tabPage.Text, tabControl.Font,
              rect, tabControl.ForeColor, TextFormatFlags.Left);
        }


        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            var tabControl = (TabControl)sender;
            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                var rect = tabControl.GetTabRect(i);
                if (rect.Contains(e.Location) && e.Location.X > rect.Right - 20)
                {
                    tabControl.TabPages.RemoveAt(i);
                    break;
                }
            }
        }



    }
}
