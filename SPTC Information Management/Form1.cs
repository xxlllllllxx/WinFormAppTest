using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Linq;
using System;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Text;

namespace SPTC_Information_Management
{
	public partial class Form1 : Form
	{

		private string mServerIP = "localhost";
		public Form1()
		{
			InitializeComponent();

			backgroundWorker = new BackgroundWorker();
			backgroundWorker.WorkerReportsProgress = true;
			backgroundWorker.DoWork += BackgroundWorker_DoWork;
			backgroundWorker.ProgressChanged += BackgroundWorker_ProgressChanged;
			backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
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

		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void printIDToolStripMenuItem_Click(object sender, EventArgs e)
		{
			DesignForm form = new DesignForm();
			form.Show();
		}

		private void captureImageToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ImageCapture form = new ImageCapture();
			form.Show();
		}

		private void nudMin_ValueChanged(object sender, EventArgs e)
		{
			nudMax.Value = nudMin.Value;
		}

		private BackgroundWorker backgroundWorker;

		private async void button2_Click(object sender, EventArgs e)
		{
			try
			{
				comboBox1.Items.Clear();
				progressBar1.Value = 0;
				progressBar1.Visible = true;

				var from = (int)nudMin.Value | 0;
				var to = (int)nudMax.Value | 255;

				var tasks = new Task<bool>[to - from + 1];

				for (int i = from; i <= to; i++)
				{
					var ip = "192.168.0." + i;
					var task = PingIpAddressAsync(ip);
					if (task != null)
					{
						tasks[i - from] = task;

						if (i % 10 == 0)
						{
							await Task.WhenAll(tasks.Where(t => t != null));
							backgroundWorker.ReportProgress((int)(((float)i - from) / (to - from) * 100));
						}
					}
				}
				await Task.WhenAll(tasks.Where(t => t != null));
				backgroundWorker.ReportProgress(100);


			} catch (Exception err)
			{
				MessageBox.Show(err.ToString());
			}
		}

		private async Task<bool> PingIpAddressAsync(string ipAddress)
		{
			using (var ping = new Ping())
			{
				var reply = await ping.SendPingAsync(ipAddress, 1000);

				if (reply.Status == IPStatus.Success)
				{
					comboBox1.Items.Add(ipAddress);
					return true;
				}
			}

			return false;
		}

		private void BackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
			var tasks = (Task<bool>[])e.Argument;

			for (int i = 0; i < tasks.Length; i++)
			{
				tasks[i].Wait();
				backgroundWorker.ReportProgress((int)(((float)i / tasks.Length) * 100));
			}
		}

		private void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			progressBar1.Value = e.ProgressPercentage;
		}

		private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			progressBar1.Visible = false;
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			mServerIP = comboBox1.SelectedItem.ToString();
		}

		private async void button7_Click(object sender, EventArgs e)
		{
			string uri = "";
			try {
				// Get the IP address of the first network interface that is up and has an IPv4 address
				var ip = NetworkInterface
					.GetAllNetworkInterfaces()
					.Where(i => i.OperationalStatus == OperationalStatus.Up && i.NetworkInterfaceType != NetworkInterfaceType.Loopback)
					.SelectMany(i => i.GetIPProperties().UnicastAddresses)
					.FirstOrDefault(a => a.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)?.Address;

				// Convert the IP address to a string
				var ipAddress = ip?.ToString() ?? "Unknown";

				if(ipAddress == mServerIP)
				{
					mServerIP = "localhost";
				}
				// Create a new HttpClient instance
				HttpClient client = new HttpClient();

				string username = tbUsername.Text.ToString();
				string password = tbPassword.Text.ToString();

				// Set the request URI and content
				uri = "http://" + mServerIP + "/server/sptc/login.php";
				var content = new StringContent("username=" + username + "&password=" + password, Encoding.UTF8, "application/x-www-form-urlencoded");

				// Send the POST request and wait for the response
				HttpResponseMessage response = await client.PostAsync(uri, content);

				// Get the response content as a string
				string responseString = await response.Content.ReadAsStringAsync();

				// Display the response
				MessageBox.Show(responseString);

			} catch(Exception ex){
				MessageBox.Show(ex.Message + "\nURI: " + uri);
			}
		}
	}
}
