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
	partial class FormSettings
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
			this.btn_apply = new System.Windows.Forms.Button();
			this.check_backup = new System.Windows.Forms.CheckBox();
			this.check_delete = new System.Windows.Forms.CheckBox();
			this.check_dir = new System.Windows.Forms.CheckBox();
			this.check_dir_struct = new System.Windows.Forms.CheckBox();
			this.textbox_dir = new System.Windows.Forms.TextBox();
			this.btn_dir_browse = new System.Windows.Forms.Button();
			this.check_explorer = new System.Windows.Forms.CheckBox();
			this.folderBrowserDialog_dir = new System.Windows.Forms.FolderBrowserDialog();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.textbox_back = new System.Windows.Forms.TextBox();
			this.btn_back_browse = new System.Windows.Forms.Button();
			this.folderBrowserDialog_back = new System.Windows.Forms.FolderBrowserDialog();
			this.SuspendLayout();
			// 
			// btn_apply
			// 
			this.btn_apply.Location = new System.Drawing.Point(107, 213);
			this.btn_apply.Name = "btn_apply";
			this.btn_apply.Size = new System.Drawing.Size(75, 23);
			this.btn_apply.TabIndex = 0;
			this.btn_apply.Text = "Apply";
			this.btn_apply.UseVisualStyleBackColor = true;
			this.btn_apply.Click += new System.EventHandler(this.btn_apply_Click);
			// 
			// check_backup
			// 
			this.check_backup.AutoSize = true;
			this.check_backup.Location = new System.Drawing.Point(12, 12);
			this.check_backup.Name = "check_backup";
			this.check_backup.Size = new System.Drawing.Size(225, 17);
			this.check_backup.TabIndex = 2;
			this.check_backup.Text = "Create a backup of the extracted directory";
			this.check_backup.UseVisualStyleBackColor = true;
			this.check_backup.CheckedChanged += new System.EventHandler(this.check_backup_CheckedChanged);
			// 
			// check_delete
			// 
			this.check_delete.AutoSize = true;
			this.check_delete.Location = new System.Drawing.Point(12, 61);
			this.check_delete.Name = "check_delete";
			this.check_delete.Size = new System.Drawing.Size(193, 17);
			this.check_delete.TabIndex = 3;
			this.check_delete.Text = "Delete xbt textures after conversion";
			this.check_delete.UseVisualStyleBackColor = true;
			this.check_delete.CheckedChanged += new System.EventHandler(this.check_delete_CheckedChanged);
			// 
			// check_dir
			// 
			this.check_dir.AutoSize = true;
			this.check_dir.Location = new System.Drawing.Point(12, 84);
			this.check_dir.Name = "check_dir";
			this.check_dir.Size = new System.Drawing.Size(231, 17);
			this.check_dir.TabIndex = 4;
			this.check_dir.Text = "Set a separate directory for the dds textures";
			this.check_dir.UseVisualStyleBackColor = true;
			this.check_dir.CheckedChanged += new System.EventHandler(this.check_dir_CheckedChanged);
			// 
			// check_dir_struct
			// 
			this.check_dir_struct.AutoSize = true;
			this.check_dir_struct.Enabled = false;
			this.check_dir_struct.Location = new System.Drawing.Point(31, 133);
			this.check_dir_struct.Name = "check_dir_struct";
			this.check_dir_struct.Size = new System.Drawing.Size(144, 17);
			this.check_dir_struct.TabIndex = 5;
			this.check_dir_struct.Text = "Retain directory structure";
			this.check_dir_struct.UseVisualStyleBackColor = true;
			this.check_dir_struct.CheckedChanged += new System.EventHandler(this.check_dir_struct_CheckedChanged);
			// 
			// textbox_dir
			// 
			this.textbox_dir.Enabled = false;
			this.textbox_dir.Location = new System.Drawing.Point(31, 107);
			this.textbox_dir.Name = "textbox_dir";
			this.textbox_dir.Size = new System.Drawing.Size(201, 20);
			this.textbox_dir.TabIndex = 6;
			this.textbox_dir.TextChanged += new System.EventHandler(this.textbox_dir_TextChanged);
			// 
			// btn_dir_browse
			// 
			this.btn_dir_browse.Enabled = false;
			this.btn_dir_browse.Location = new System.Drawing.Point(238, 107);
			this.btn_dir_browse.Name = "btn_dir_browse";
			this.btn_dir_browse.Size = new System.Drawing.Size(25, 20);
			this.btn_dir_browse.TabIndex = 7;
			this.btn_dir_browse.Text = "...";
			this.btn_dir_browse.UseVisualStyleBackColor = true;
			this.btn_dir_browse.Click += new System.EventHandler(this.btn_dir_browse_Click);
			// 
			// check_explorer
			// 
			this.check_explorer.AutoSize = true;
			this.check_explorer.Location = new System.Drawing.Point(12, 156);
			this.check_explorer.Name = "check_explorer";
			this.check_explorer.Size = new System.Drawing.Size(219, 17);
			this.check_explorer.TabIndex = 8;
			this.check_explorer.Text = "Open Windows Explorer after conversion";
			this.check_explorer.UseVisualStyleBackColor = true;
			this.check_explorer.CheckedChanged += new System.EventHandler(this.check_explorer_CheckedChanged);
			// 
			// btn_cancel
			// 
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(188, 213);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(75, 23);
			this.btn_cancel.TabIndex = 9;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = true;
			this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
			// 
			// textbox_back
			// 
			this.textbox_back.Enabled = false;
			this.textbox_back.Location = new System.Drawing.Point(31, 35);
			this.textbox_back.Name = "textbox_back";
			this.textbox_back.Size = new System.Drawing.Size(200, 20);
			this.textbox_back.TabIndex = 10;
			this.textbox_back.TextChanged += new System.EventHandler(this.textbox_back_TextChanged);
			// 
			// btn_back_browse
			// 
			this.btn_back_browse.Enabled = false;
			this.btn_back_browse.Location = new System.Drawing.Point(238, 35);
			this.btn_back_browse.Name = "btn_back_browse";
			this.btn_back_browse.Size = new System.Drawing.Size(25, 20);
			this.btn_back_browse.TabIndex = 11;
			this.btn_back_browse.Text = "...";
			this.btn_back_browse.UseVisualStyleBackColor = true;
			this.btn_back_browse.Click += new System.EventHandler(this.btn_back_browse_Click);
			// 
			// FormSettings
			// 
			this.AcceptButton = this.btn_apply;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_cancel;
			this.ClientSize = new System.Drawing.Size(275, 248);
			this.Controls.Add(this.btn_back_browse);
			this.Controls.Add(this.textbox_back);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.check_explorer);
			this.Controls.Add(this.btn_dir_browse);
			this.Controls.Add(this.textbox_dir);
			this.Controls.Add(this.check_dir_struct);
			this.Controls.Add(this.check_dir);
			this.Controls.Add(this.check_delete);
			this.Controls.Add(this.check_backup);
			this.Controls.Add(this.btn_apply);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FormSettings";
			this.Text = "Settings";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btn_apply;
		private System.Windows.Forms.CheckBox check_backup;
		private System.Windows.Forms.CheckBox check_delete;
		private System.Windows.Forms.CheckBox check_dir;
		private System.Windows.Forms.CheckBox check_dir_struct;
		private System.Windows.Forms.TextBox textbox_dir;
		private System.Windows.Forms.Button btn_dir_browse;
		private System.Windows.Forms.CheckBox check_explorer;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_dir;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.TextBox textbox_back;
		private System.Windows.Forms.Button btn_back_browse;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_back;
	}
}