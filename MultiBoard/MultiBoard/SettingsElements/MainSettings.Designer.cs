﻿namespace MultiBoard.SettingsElements
{
    partial class MainSettings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainSettings));
            this.TOP_PANEL = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.TOP_LEFT_LOGO_PICTUREBOX = new System.Windows.Forms.PictureBox();
            this.LEFT_PANEL = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GENERAL_BUTTON = new System.Windows.Forms.Button();
            this.INFO_BUTTON = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.MAIN_PANEL = new System.Windows.Forms.Panel();
            this.TOP_PANEL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TOP_LEFT_LOGO_PICTUREBOX)).BeginInit();
            this.LEFT_PANEL.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TOP_PANEL
            // 
            this.TOP_PANEL.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.TOP_PANEL.Controls.Add(this.label1);
            this.TOP_PANEL.Controls.Add(this.TOP_LEFT_LOGO_PICTUREBOX);
            this.TOP_PANEL.Dock = System.Windows.Forms.DockStyle.Top;
            this.TOP_PANEL.Location = new System.Drawing.Point(0, 0);
            this.TOP_PANEL.Name = "TOP_PANEL";
            this.TOP_PANEL.Size = new System.Drawing.Size(168, 32);
            this.TOP_PANEL.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(39, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Settings";
            // 
            // TOP_LEFT_LOGO_PICTUREBOX
            // 
            this.TOP_LEFT_LOGO_PICTUREBOX.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("TOP_LEFT_LOGO_PICTUREBOX.BackgroundImage")));
            this.TOP_LEFT_LOGO_PICTUREBOX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TOP_LEFT_LOGO_PICTUREBOX.Dock = System.Windows.Forms.DockStyle.Left;
            this.TOP_LEFT_LOGO_PICTUREBOX.Location = new System.Drawing.Point(0, 0);
            this.TOP_LEFT_LOGO_PICTUREBOX.Name = "TOP_LEFT_LOGO_PICTUREBOX";
            this.TOP_LEFT_LOGO_PICTUREBOX.Size = new System.Drawing.Size(32, 32);
            this.TOP_LEFT_LOGO_PICTUREBOX.TabIndex = 0;
            this.TOP_LEFT_LOGO_PICTUREBOX.TabStop = false;
            // 
            // LEFT_PANEL
            // 
            this.LEFT_PANEL.Controls.Add(this.panel2);
            this.LEFT_PANEL.Controls.Add(this.panel1);
            this.LEFT_PANEL.Controls.Add(this.TOP_PANEL);
            this.LEFT_PANEL.Dock = System.Windows.Forms.DockStyle.Left;
            this.LEFT_PANEL.Location = new System.Drawing.Point(0, 0);
            this.LEFT_PANEL.Name = "LEFT_PANEL";
            this.LEFT_PANEL.Size = new System.Drawing.Size(168, 508);
            this.LEFT_PANEL.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(167, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 476);
            this.panel1.TabIndex = 1;
            // 
            // GENERAL_BUTTON
            // 
            this.GENERAL_BUTTON.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.GENERAL_BUTTON.Dock = System.Windows.Forms.DockStyle.Top;
            this.GENERAL_BUTTON.FlatAppearance.BorderSize = 0;
            this.GENERAL_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GENERAL_BUTTON.ForeColor = System.Drawing.Color.White;
            this.GENERAL_BUTTON.Location = new System.Drawing.Point(0, 0);
            this.GENERAL_BUTTON.Name = "GENERAL_BUTTON";
            this.GENERAL_BUTTON.Size = new System.Drawing.Size(167, 38);
            this.GENERAL_BUTTON.TabIndex = 0;
            this.GENERAL_BUTTON.Text = "General";
            this.GENERAL_BUTTON.UseVisualStyleBackColor = false;
            this.GENERAL_BUTTON.Click += new System.EventHandler(this.GENERAL_BUTTON_Click);
            // 
            // INFO_BUTTON
            // 
            this.INFO_BUTTON.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.INFO_BUTTON.Dock = System.Windows.Forms.DockStyle.Top;
            this.INFO_BUTTON.FlatAppearance.BorderSize = 0;
            this.INFO_BUTTON.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.INFO_BUTTON.ForeColor = System.Drawing.Color.White;
            this.INFO_BUTTON.Location = new System.Drawing.Point(0, 38);
            this.INFO_BUTTON.Margin = new System.Windows.Forms.Padding(0);
            this.INFO_BUTTON.Name = "INFO_BUTTON";
            this.INFO_BUTTON.Size = new System.Drawing.Size(167, 38);
            this.INFO_BUTTON.TabIndex = 2;
            this.INFO_BUTTON.Text = "Info";
            this.INFO_BUTTON.UseVisualStyleBackColor = false;
            this.INFO_BUTTON.Click += new System.EventHandler(this.INFO_BUTTON_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.INFO_BUTTON);
            this.panel2.Controls.Add(this.GENERAL_BUTTON);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(167, 476);
            this.panel2.TabIndex = 2;
            // 
            // MAIN_PANEL
            // 
            this.MAIN_PANEL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MAIN_PANEL.Location = new System.Drawing.Point(168, 0);
            this.MAIN_PANEL.Name = "MAIN_PANEL";
            this.MAIN_PANEL.Size = new System.Drawing.Size(689, 508);
            this.MAIN_PANEL.TabIndex = 2;
            // 
            // MainSettings
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.Controls.Add(this.MAIN_PANEL);
            this.Controls.Add(this.LEFT_PANEL);
            this.Name = "MainSettings";
            this.Size = new System.Drawing.Size(857, 508);
            this.TOP_PANEL.ResumeLayout(false);
            this.TOP_PANEL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TOP_LEFT_LOGO_PICTUREBOX)).EndInit();
            this.LEFT_PANEL.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TOP_PANEL;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox TOP_LEFT_LOGO_PICTUREBOX;
        private System.Windows.Forms.Panel LEFT_PANEL;
        private System.Windows.Forms.Button GENERAL_BUTTON;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button INFO_BUTTON;
        private System.Windows.Forms.Panel MAIN_PANEL;
    }
}
