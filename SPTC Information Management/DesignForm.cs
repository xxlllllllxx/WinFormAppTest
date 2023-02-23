
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf;

namespace SPTC_Information_Management
{
    public partial class DesignForm : Form
    {
        public DesignForm()
        {
            InitializeComponent();
        }

		private void button2_Click(object sender, EventArgs e)
		{
			SaveFileDialog saveFileDialog = new SaveFileDialog();
			saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
			if (saveFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			//EDIT pdf here
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			//PRINT pdf here
		}
	}
}
