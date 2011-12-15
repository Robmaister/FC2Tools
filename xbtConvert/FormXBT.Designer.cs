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
	partial class FormXBT
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
			this.components = new System.ComponentModel.Container();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.mm_file = new System.Windows.Forms.ToolStripMenuItem();
			this.mm_file_exit = new System.Windows.Forms.ToolStripMenuItem();
			this.mm_edit = new System.Windows.Forms.ToolStripMenuItem();
			this.mm_edit_preview = new System.Windows.Forms.ToolStripMenuItem();
			this.mm_edit_explorer = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.mm_edit_check = new System.Windows.Forms.ToolStripMenuItem();
			this.mm_edit_uncheck = new System.Windows.Forms.ToolStripMenuItem();
			this.mm_help = new System.Windows.Forms.ToolStripMenuItem();
			this.mm_help_help = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_setDir = new System.Windows.Forms.Button();
			this.btn_uncheck = new System.Windows.Forms.Button();
			this.btn_check = new System.Windows.Forms.Button();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.lbl_progress = new System.Windows.Forms.Label();
			this.btn_convert = new System.Windows.Forms.Button();
			this.folder_dialog = new System.Windows.Forms.FolderBrowserDialog();
			this.listView = new System.Windows.Forms.ListView();
			this.listViewcolFile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.listViewcolLoc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.listViewContext = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.lsvContext_Preview = new System.Windows.Forms.ToolStripMenuItem();
			this.lsvContext_Explorer = new System.Windows.Forms.ToolStripMenuItem();
			this.lsv_Context_separator = new System.Windows.Forms.ToolStripSeparator();
			this.lsvContext_Check = new System.Windows.Forms.ToolStripMenuItem();
			this.lsvContext_Uncheck = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_options = new System.Windows.Forms.Button();
			this.menuStrip1.SuspendLayout();
			this.listViewContext.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.mm_file,
			this.mm_edit,
			this.mm_help});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(498, 24);
			this.menuStrip1.TabIndex = 0;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// mm_file
			// 
			this.mm_file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.mm_file_exit});
			this.mm_file.Name = "mm_file";
			this.mm_file.Size = new System.Drawing.Size(37, 20);
			this.mm_file.Text = "File";
			// 
			// mm_file_exit
			// 
			this.mm_file_exit.Name = "mm_file_exit";
			this.mm_file_exit.Size = new System.Drawing.Size(92, 22);
			this.mm_file_exit.Text = "Exit";
			this.mm_file_exit.Click += new System.EventHandler(this.mm_file_exit_Click);
			// 
			// mm_edit
			// 
			this.mm_edit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.mm_edit_preview,
			this.mm_edit_explorer,
			this.toolStripSeparator1,
			this.mm_edit_check,
			this.mm_edit_uncheck});
			this.mm_edit.Name = "mm_edit";
			this.mm_edit.Size = new System.Drawing.Size(39, 20);
			this.mm_edit.Text = "Edit";
			this.mm_edit.DropDownOpening += new System.EventHandler(this.mm_edit_DropDownOpening);
			// 
			// mm_edit_preview
			// 
			this.mm_edit_preview.Name = "mm_edit_preview";
			this.mm_edit_preview.Size = new System.Drawing.Size(186, 22);
			this.mm_edit_preview.Text = "Preview...";
			this.mm_edit_preview.Click += new System.EventHandler(this.xbt_preview);
			// 
			// mm_edit_explorer
			// 
			this.mm_edit_explorer.Name = "mm_edit_explorer";
			this.mm_edit_explorer.Size = new System.Drawing.Size(186, 22);
			this.mm_edit_explorer.Text = "Show in Explorer...";
			this.mm_edit_explorer.Click += new System.EventHandler(this.xbt_showInExplorer);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(183, 6);
			// 
			// mm_edit_check
			// 
			this.mm_edit_check.Name = "mm_edit_check";
			this.mm_edit_check.Size = new System.Drawing.Size(186, 22);
			this.mm_edit_check.Text = "Check Highlighted";
			this.mm_edit_check.Click += new System.EventHandler(this.checkHighlighted);
			// 
			// mm_edit_uncheck
			// 
			this.mm_edit_uncheck.Name = "mm_edit_uncheck";
			this.mm_edit_uncheck.Size = new System.Drawing.Size(186, 22);
			this.mm_edit_uncheck.Text = "Uncheck Highlighted";
			this.mm_edit_uncheck.Click += new System.EventHandler(this.uncheckHighlighted);
			// 
			// mm_help
			// 
			this.mm_help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.mm_help_help});
			this.mm_help.Name = "mm_help";
			this.mm_help.Size = new System.Drawing.Size(44, 20);
			this.mm_help.Text = "Help";
			// 
			// mm_help_help
			// 
			this.mm_help_help.Name = "mm_help_help";
			this.mm_help_help.Size = new System.Drawing.Size(99, 22);
			this.mm_help_help.Text = "Help";
			this.mm_help_help.Click += new System.EventHandler(this.mm_help_help_Click);
			// 
			// btn_setDir
			// 
			this.btn_setDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_setDir.Location = new System.Drawing.Point(385, 27);
			this.btn_setDir.Name = "btn_setDir";
			this.btn_setDir.Size = new System.Drawing.Size(101, 23);
			this.btn_setDir.TabIndex = 1;
			this.btn_setDir.Text = "Set Directory";
			this.btn_setDir.UseVisualStyleBackColor = true;
			this.btn_setDir.Click += new System.EventHandler(this.btn_setDir_Click);
			// 
			// btn_uncheck
			// 
			this.btn_uncheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_uncheck.Location = new System.Drawing.Point(385, 101);
			this.btn_uncheck.Name = "btn_uncheck";
			this.btn_uncheck.Size = new System.Drawing.Size(101, 23);
			this.btn_uncheck.TabIndex = 3;
			this.btn_uncheck.Text = "Uncheck All";
			this.btn_uncheck.UseVisualStyleBackColor = true;
			this.btn_uncheck.Click += new System.EventHandler(this.btn_uncheck_Click);
			// 
			// btn_check
			// 
			this.btn_check.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_check.Location = new System.Drawing.Point(385, 72);
			this.btn_check.Name = "btn_check";
			this.btn_check.Size = new System.Drawing.Size(101, 23);
			this.btn_check.TabIndex = 4;
			this.btn_check.Text = "Check All";
			this.btn_check.UseVisualStyleBackColor = true;
			this.btn_check.Click += new System.EventHandler(this.btn_check_Click);
			// 
			// progressBar
			// 
			this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar.Location = new System.Drawing.Point(12, 362);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(474, 23);
			this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar.TabIndex = 5;
			// 
			// lbl_progress
			// 
			this.lbl_progress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lbl_progress.AutoSize = true;
			this.lbl_progress.Location = new System.Drawing.Point(12, 346);
			this.lbl_progress.Name = "lbl_progress";
			this.lbl_progress.Size = new System.Drawing.Size(35, 13);
			this.lbl_progress.TabIndex = 6;
			this.lbl_progress.Text = "label1";
			// 
			// btn_convert
			// 
			this.btn_convert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_convert.Location = new System.Drawing.Point(385, 320);
			this.btn_convert.Name = "btn_convert";
			this.btn_convert.Size = new System.Drawing.Size(101, 23);
			this.btn_convert.TabIndex = 7;
			this.btn_convert.Text = "Convert Checked";
			this.btn_convert.UseVisualStyleBackColor = true;
			this.btn_convert.Click += new System.EventHandler(this.btn_convert_Click);
			// 
			// folder_dialog
			// 
			this.folder_dialog.Description = "Select the folder where the extracted Far Cry 2 game data is located.";
			this.folder_dialog.ShowNewFolderButton = false;
			// 
			// listView
			// 
			this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.listView.CheckBoxes = true;
			this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
			this.listViewcolFile,
			this.listViewcolLoc});
			this.listView.ContextMenuStrip = this.listViewContext;
			this.listView.Location = new System.Drawing.Point(12, 27);
			this.listView.Name = "listView";
			this.listView.Size = new System.Drawing.Size(367, 316);
			this.listView.TabIndex = 9;
			this.listView.UseCompatibleStateImageBehavior = false;
			this.listView.View = System.Windows.Forms.View.Details;
			this.listView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listView_ItemChecked);
			// 
			// listViewcolFile
			// 
			this.listViewcolFile.Text = "File";
			this.listViewcolFile.Width = 100;
			// 
			// listViewcolLoc
			// 
			this.listViewcolLoc.Text = "Location";
			this.listViewcolLoc.Width = 245;
			// 
			// listViewContext
			// 
			this.listViewContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.lsvContext_Preview,
			this.lsvContext_Explorer,
			this.lsv_Context_separator,
			this.lsvContext_Check,
			this.lsvContext_Uncheck});
			this.listViewContext.Name = "listViewContext";
			this.listViewContext.Size = new System.Drawing.Size(187, 120);
			this.listViewContext.Opening += new System.ComponentModel.CancelEventHandler(this.listViewContext_Opening);
			// 
			// lsvContext_Preview
			// 
			this.lsvContext_Preview.Name = "lsvContext_Preview";
			this.lsvContext_Preview.Size = new System.Drawing.Size(186, 22);
			this.lsvContext_Preview.Text = "Preview...";
			this.lsvContext_Preview.Click += new System.EventHandler(this.xbt_preview);
			// 
			// lsvContext_Explorer
			// 
			this.lsvContext_Explorer.Name = "lsvContext_Explorer";
			this.lsvContext_Explorer.Size = new System.Drawing.Size(186, 22);
			this.lsvContext_Explorer.Text = "Show in Explorer...";
			this.lsvContext_Explorer.Click += new System.EventHandler(this.xbt_showInExplorer);
			// 
			// lsv_Context_separator
			// 
			this.lsv_Context_separator.Name = "lsv_Context_separator";
			this.lsv_Context_separator.Size = new System.Drawing.Size(183, 6);
			// 
			// lsvContext_Check
			// 
			this.lsvContext_Check.Name = "lsvContext_Check";
			this.lsvContext_Check.Size = new System.Drawing.Size(186, 22);
			this.lsvContext_Check.Text = "Check Highlighted";
			this.lsvContext_Check.Click += new System.EventHandler(this.checkHighlighted);
			// 
			// lsvContext_Uncheck
			// 
			this.lsvContext_Uncheck.Name = "lsvContext_Uncheck";
			this.lsvContext_Uncheck.Size = new System.Drawing.Size(186, 22);
			this.lsvContext_Uncheck.Text = "Uncheck Highlighted";
			this.lsvContext_Uncheck.Click += new System.EventHandler(this.uncheckHighlighted);
			// 
			// btn_options
			// 
			this.btn_options.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btn_options.Location = new System.Drawing.Point(385, 291);
			this.btn_options.Name = "btn_options";
			this.btn_options.Size = new System.Drawing.Size(101, 23);
			this.btn_options.TabIndex = 10;
			this.btn_options.Text = "Options";
			this.btn_options.UseVisualStyleBackColor = true;
			this.btn_options.Click += new System.EventHandler(this.btn_options_Click);
			// 
			// FormXBT
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(498, 397);
			this.Controls.Add(this.btn_options);
			this.Controls.Add(this.listView);
			this.Controls.Add(this.btn_convert);
			this.Controls.Add(this.lbl_progress);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.btn_check);
			this.Controls.Add(this.btn_uncheck);
			this.Controls.Add(this.btn_setDir);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.MinimumSize = new System.Drawing.Size(514, 433);
			this.Name = "FormXBT";
			this.Text = "Far Cry 2 XBT Converter";
			this.Load += new System.EventHandler(this.FormXBT_Load);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.listViewContext.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip menuStrip1;
		private System.Windows.Forms.ToolStripMenuItem mm_file;
		private System.Windows.Forms.ToolStripMenuItem mm_help;
		private System.Windows.Forms.ToolStripMenuItem mm_help_help;
		private System.Windows.Forms.Button btn_setDir;
		private System.Windows.Forms.Button btn_uncheck;
		private System.Windows.Forms.Button btn_check;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Label lbl_progress;
		private System.Windows.Forms.Button btn_convert;
		private System.Windows.Forms.FolderBrowserDialog folder_dialog;
		private System.Windows.Forms.ListView listView;
		private System.Windows.Forms.ColumnHeader listViewcolFile;
		private System.Windows.Forms.ColumnHeader listViewcolLoc;
		private System.Windows.Forms.ToolStripMenuItem mm_file_exit;
		private System.Windows.Forms.Button btn_options;
		private System.Windows.Forms.ContextMenuStrip listViewContext;
		private System.Windows.Forms.ToolStripMenuItem lsvContext_Preview;
		private System.Windows.Forms.ToolStripMenuItem lsvContext_Explorer;
		private System.Windows.Forms.ToolStripSeparator lsv_Context_separator;
		private System.Windows.Forms.ToolStripMenuItem lsvContext_Check;
		private System.Windows.Forms.ToolStripMenuItem lsvContext_Uncheck;
		private System.Windows.Forms.ToolStripMenuItem mm_edit;
		private System.Windows.Forms.ToolStripMenuItem mm_edit_preview;
		private System.Windows.Forms.ToolStripMenuItem mm_edit_explorer;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem mm_edit_check;
		private System.Windows.Forms.ToolStripMenuItem mm_edit_uncheck;
	}
}

