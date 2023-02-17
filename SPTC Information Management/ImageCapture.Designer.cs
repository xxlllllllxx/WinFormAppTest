﻿namespace SPTC_Information_Management
{
    partial class ImageCapture
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.PictureBox pictureBox4;
            System.Windows.Forms.PictureBox pictureBox3;
            System.Windows.Forms.PictureBox pictureBox2;
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            pictureBox4 = new System.Windows.Forms.PictureBox();
            pictureBox3 = new System.Windows.Forms.PictureBox();
            pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(243, 331);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 60);
            this.button1.TabIndex = 1;
            this.button1.Text = "Capture";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(pictureBox4);
            this.panel1.Controls.Add(pictureBox3);
            this.panel1.Controls.Add(pictureBox2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(582, 28);
            this.panel1.TabIndex = 2;
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = global::SPTC_Information_Management.Properties.Resources.minimize;
            pictureBox4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pictureBox4.Dock = System.Windows.Forms.DockStyle.Right;
            pictureBox4.Location = new System.Drawing.Point(498, 0);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new System.Drawing.Size(28, 28);
            pictureBox4.TabIndex = 2;
            pictureBox4.TabStop = false;
            pictureBox4.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = global::SPTC_Information_Management.Properties.Resources.restore_down;
            pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pictureBox3.Dock = System.Windows.Forms.DockStyle.Right;
            pictureBox3.Location = new System.Drawing.Point(526, 0);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new System.Drawing.Size(28, 28);
            pictureBox3.TabIndex = 1;
            pictureBox3.TabStop = false;
            pictureBox3.Click += new System.EventHandler(this.MaximizeButton_Click);
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = global::SPTC_Information_Management.Properties.Resources.close;
            pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            pictureBox2.Dock = System.Windows.Forms.DockStyle.Right;
            pictureBox2.Location = new System.Drawing.Point(554, 0);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new System.Drawing.Size(28, 28);
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            pictureBox2.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(558, 379);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ImageCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 420);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ImageCapture";
            this.Text = "ImageCapture";
            this.Load += new System.EventHandler(this.ImageCapture_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
    }
}