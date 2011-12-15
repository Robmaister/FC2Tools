/*Copyright (c) 2011 Robert Rouhani

This software is provided 'as-is', without any express or implied
warranty. In no event will the authors be held liable for any damages
arising from the use of this software.

Permission is granted to anyone to use this software for any purpose,
including commercial applications, and to alter it and redistribute it
freely, subject to the following restrictions:

   1. The origin of this software must not be misrepresented; you must not
   claim that you wrote the original software. If you use this software
   in a product, an acknowledgment in the product documentation would be
   appreciated but is not required.

   2. Altered source versions must be plainly marked as such, and must not be
   misrepresented as being the original software.

   3. This notice may not be removed or altered from any source
   distribution.
 
Robert Rouhani <robert.rouhani@gmail.com>*/

namespace FC2Tools.xbtConvert
{
	partial class FormHelp
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
			this.label1 = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel_help = new System.Windows.Forms.Panel();
			this.panel_help.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(14, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(75, 33);
			this.label1.TabIndex = 0;
			this.label1.Text = "Help";
			// 
			// linkLabel1
			// 
			this.linkLabel1.AutoSize = true;
			this.linkLabel1.Location = new System.Drawing.Point(240, 56);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(373, 13);
			this.linkLabel1.TabIndex = 1;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "http://blog.gib.me/2008/10/28/unstable-fc2-tool-binaries-from-svn-revision-4/";
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(17, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(226, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "1) Download the Far Cry 2 extraction tool here:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(17, 78);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(243, 13);
			this.label3.TabIndex = 3;
			this.label3.Text = "2) Extract the Far Cry 2 game data to any location.";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(17, 100);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(389, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "3) Using this tool, set the directory to the location you extracted the game data" +
				" to.";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(17, 122);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(325, 13);
			this.label5.TabIndex = 5;
			this.label5.Text = "4) Check the textures you want to convert and change the settings.";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(17, 144);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(194, 13);
			this.label6.TabIndex = 6;
			this.label6.Text = "5) Press the \"Convert checked\" button.";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(536, 174);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 7;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(0, 166);
			this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
			this.groupBox1.Size = new System.Drawing.Size(629, 2);
			this.groupBox1.TabIndex = 8;
			this.groupBox1.TabStop = false;
			// 
			// panel_help
			// 
			this.panel_help.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.panel_help.Controls.Add(this.label1);
			this.panel_help.Controls.Add(this.linkLabel1);
			this.panel_help.Controls.Add(this.label6);
			this.panel_help.Controls.Add(this.label2);
			this.panel_help.Controls.Add(this.label5);
			this.panel_help.Controls.Add(this.label3);
			this.panel_help.Controls.Add(this.label4);
			this.panel_help.Location = new System.Drawing.Point(-2, 0);
			this.panel_help.Name = "panel_help";
			this.panel_help.Size = new System.Drawing.Size(627, 166);
			this.panel_help.TabIndex = 9;
			// 
			// FormHelp
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(623, 209);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.panel_help);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormHelp";
			this.Text = "Help";
			this.panel_help.ResumeLayout(false);
			this.panel_help.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Panel panel_help;
	}
}