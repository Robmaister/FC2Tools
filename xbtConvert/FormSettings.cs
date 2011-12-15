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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace FC2Tools.xbtConvert
{
	public partial class FormSettings : Form
	{
		//form-wide vars
		public bool b_backup { get; set; }
		public string s_back { get; set; }
		public bool b_delete { get; set; }
		public bool b_dir { get; set; }
		public string s_dir { get; set; }
		public bool b_dir_struct { get; set; }
		public bool b_explorer { get; set; }
		public bool b_accept { get; set; }

		//constructor overloads
		public FormSettings(bool backup, string sback, bool delete, bool dir, string sdir, bool dir_struct, bool explorer)
		{
			InitializeComponent();

			b_backup = backup;
			check_backup.Checked = backup;

			s_back = sback;
			textbox_back.Text = sback;

			b_delete = delete;
			check_delete.Checked = delete;

			b_dir = dir;
			check_dir.Checked = dir;

			s_dir = sdir;
			textbox_dir.Text = sdir;

			b_dir_struct = dir_struct;
			check_dir_struct.Checked = dir_struct;

			b_explorer = explorer;
			check_explorer.Checked = explorer;
		}

		//form-based functions
		private void check_backup_CheckedChanged(object sender, EventArgs e)
		{
			b_backup = check_backup.Checked;
			if (check_backup.Checked)
			{
				textbox_back.Enabled = true;
				btn_back_browse.Enabled = true;
				s_back = textbox_back.Text;
			}
			if (!check_backup.Checked)
			{
				textbox_back.Enabled = false;
				btn_back_browse.Enabled = false;
				s_back = "";
			}

		}

		private void check_delete_CheckedChanged(object sender, EventArgs e)
		{
			b_delete = check_delete.Checked;
		}

		private void check_dir_CheckedChanged(object sender, EventArgs e)
		{
			b_dir = check_dir.Checked;
			if (check_dir.Checked)
			{
				textbox_dir.Enabled = true;
				btn_dir_browse.Enabled = true;
				check_dir_struct.Enabled = true;
				s_dir = textbox_dir.Text;
				b_dir_struct = check_dir_struct.Checked;
			}
			if (!check_dir.Checked)
			{
				textbox_dir.Enabled = false;
				btn_dir_browse.Enabled = false;
				check_dir_struct.Enabled = false;
				s_dir = "";
				b_dir_struct = false;
			}
		}

		private void btn_dir_browse_Click(object sender, EventArgs e)
		{
			if (folderBrowserDialog_dir.ShowDialog() == DialogResult.OK)
			{
				textbox_dir.Text = folderBrowserDialog_dir.SelectedPath;
			}
		}

		private void textbox_dir_TextChanged(object sender, EventArgs e)
		{
			s_dir = textbox_dir.Text;
		}

		private void check_dir_struct_CheckedChanged(object sender, EventArgs e)
		{
			b_dir_struct = check_dir_struct.Checked;
		}

		private void check_explorer_CheckedChanged(object sender, EventArgs e)
		{
			b_explorer = check_explorer.Checked;
		}

		private void btn_apply_Click(object sender, EventArgs e)
		{

			if (textbox_back.Text == "" && check_backup.Checked)
			{
				MessageBox.Show("You have not selected a backup directory. Please enter one now.");
				return;
			}

			if (textbox_dir.Text == "" && check_dir.Checked)
			{
				MessageBox.Show("You have not selected a destination directory. Please enter one now.");
				return;
			}
			b_accept = true;

			this.Hide();
		}

		private void btn_cancel_Click(object sender, EventArgs e)
		{
			b_accept = false;
			this.Hide();
		}

		private void textbox_back_TextChanged(object sender, EventArgs e)
		{
			s_back = textbox_back.Text;
		}

		private void btn_back_browse_Click(object sender, EventArgs e)
		{
			if (folderBrowserDialog_back.ShowDialog() == DialogResult.OK)
			{
				textbox_back.Text = folderBrowserDialog_back.SelectedPath;
			}
		}

	}
}
