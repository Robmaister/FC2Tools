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
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Reflection;

using FC2Tools.libFC2;

namespace FC2Tools.xbtConvert
{
	public partial class FormXBT : Form
	{
		//Form-wide variables
		public bool b_list_created = false;
		public string root_dir = "";
		public int duplicateNumber = 0;

		//Delegated invoke methods
		public delegate string CheckedItemCallBack(int num);
		public delegate void setMaxCallBack(int num);
		public delegate void setlblTextCallBack(string text);
		public delegate void progressCallBack(int num);
		public delegate void completedCallBack();

		//Settings variables
		public bool settingsBackup = false;
		public string settingsBackupDir = "";
		public bool settingsDeleteOrig = false;
		public bool b_dir = false;
		public string s_dir = "";
		public bool b_dir_struct = false;
		public bool b_explorer = false;

		//Constructor
		public FormXBT()
		{
			InitializeComponent();
		}

		//Initialize form
		private void FormXBT_Load(object sender, EventArgs e)
		{
			lbl_progress.Text = "";
		}
		
		//Form event methods
		private void btn_options_Click(object sender, EventArgs e)
		{
			//Create a new instance of the options form, and pass the current vars to it
			FormSettings settings = new FormSettings(settingsBackup, settingsBackupDir, settingsDeleteOrig, b_dir, s_dir, b_dir_struct, b_explorer);

			//Show the form
			settings.ShowDialog();

			//If the user hit OK, set all the new vars
			if (settings.b_accept)
			{
				settingsBackup = settings.b_backup;
				settingsBackupDir = settings.s_back;
				settingsDeleteOrig = settings.b_delete;
				b_dir = settings.b_dir;
				s_dir = settings.s_dir;
				b_dir_struct = settings.b_dir_struct;
				b_explorer = settings.b_explorer;
			}
		}

		private void btn_setDir_Click(object sender, EventArgs e)
		{
			progressBar.Value = 0;
			b_list_created = false;
			lbl_progress.Text = "";
			listView.Items.Clear();
			listView.Refresh();
			listView.BeginUpdate();

			//Make sure the user accepts the folder
			if (folder_dialog.ShowDialog() == DialogResult.OK)
			{
				lbl_progress.Text = "Generating Filelist";
				root_dir = folder_dialog.SelectedPath;

				//Pass the directory to FillItemList to recursively track down all xbt files.
				FillItemList(root_dir);

				//If there are any xbt files, continue
				if (listView.Items.Count >= 1)
				{
					lbl_progress.Text = listView.CheckedItems.Count + "/" + listView.Items.Count + " files are ready to be converted.";
					b_list_created = true;
				}
				else
				{
					MessageBox.Show("The directory selected contains no .xbt files, please select another directory.");
					lbl_progress.Text = "Operation Canceled";
				}
			}

			//the user closed out the window or hit cancel
			else
			{
				lbl_progress.Text = "Operation Canceled";
			}

			listView.EndUpdate();
		}

		private void btn_convert_Click(object sender, EventArgs e)
		{
			//make sure there's a list before we convert
			if (!b_list_created)
				MessageBox.Show("No directory loaded! Please click the \"Set Directory\" button to load a directory first.");

			else
			{
				//Disable all interaction and set values prior to work thread.
				lbl_progress.Text = "Initializing...";
				listView.Enabled = false;
				btn_check.Enabled = false;
				btn_uncheck.Enabled = false;
				btn_convert.Enabled = false;
				btn_setDir.Enabled = false;
				btn_options.Enabled = false;
				menuStrip1.Enabled = false;
				if (s_dir == "")
				{
					s_dir = root_dir;
				}
				progressBar.Maximum = listView.CheckedItems.Count;

				List<string> files = new List<string>();

				foreach (ListViewItem item in listView.CheckedItems)
					files.Add(item.SubItems[1].Text + "\\" + item.Text);

				//Run the conversion in a separate thread
				Thread converter = new Thread(xbt_convert);
				converter.Name = "XBTConverterThread";
				converter.Start((object)files.ToArray());
			}
		}

		private void btn_check_Click(object sender, EventArgs e)
		{
			//Make sure there's something in the listview
			if (b_list_created)
			{
				//Prevent any tampering
				b_list_created = false;
				listView.BeginUpdate();

				//Go through each item and check it
				foreach (ListViewItem item in listView.Items)
					item.Checked = true;

				//Update progress text and allow checking/unchecking
				lbl_progress.Text = listView.CheckedItems.Count + "/" + listView.Items.Count + " files are ready to be converted.";
				listView.EndUpdate();
				b_list_created = true;
			}
			else
				MessageBox.Show("No directory loaded! Please click the \"Set Directory\" button to load a directory");
		}

		private void btn_uncheck_Click(object sender, EventArgs e)
		{
			//Make sure there's something in the listview
			if (b_list_created)
			{
				//Prevent any tampering
				b_list_created = false;
				listView.BeginUpdate();

				//Go through each item and check it
				foreach (ListViewItem item in listView.Items)
					item.Checked = false;

				//Update progress text and allow checking/unchecking
				lbl_progress.Text = listView.CheckedItems.Count + "/" + listView.Items.Count + " files are ready to be converted.";
				listView.EndUpdate();
				b_list_created = true;
			}
			else
				MessageBox.Show("No directory loaded! Please click the \"Set Directory\" button to load a directory first.");
		}

		private void listView_ItemChecked(object sender, ItemCheckedEventArgs e)
		{
			//Make sure there's something in the listview
			if (b_list_created)
			{
				//Update progress text
				lbl_progress.Text = listView.CheckedItems.Count + "/" + listView.Items.Count + " files are ready to be converted.";
			}
		}

		//Secondary thread methods
		private void xbt_convert(object selectedPaths)
		{

			//Setup
			string[] files = (string[])selectedPaths;
			Invoke(new setlblTextCallBack(setlblProgressText), "Generating filelist...");

			//Call back to main and grab all the file locations, update progress bar
			/*for (int init = 0; init < files.Length; init++)
			{
				files[init] = (string)Invoke(new CheckedItemCallBack(ReturnListViewItem), init);
				Invoke(new progressCallBack(setProgressBarVal), init);
				Thread.Sleep(1);
			}*/

			//Reset progress bar and do some more setup
			Invoke(new progressCallBack(setProgressBarVal), 0);
			int progress = 0;
			int total = files.Length;

			//Backup the directory if the user set the option
			if (settingsBackup)
			{
				Invoke(new setlblTextCallBack(setlblProgressText), "Creating backup...");
				BackupRootDir(root_dir);
			}

			//Reset progress bar
			Invoke(new progressCallBack(setProgressBarVal), 0);

			//Generate new directory structure if user set option
			if (b_dir_struct)
			{
				Invoke(new setlblTextCallBack(setlblProgressText), "Generating destination directories...");
				BuildDestinationDir(s_dir);
			}

			//Reset progress bar and update label text
			Invoke(new progressCallBack(setProgressBarVal), 0);
			Invoke(new setlblTextCallBack(setlblProgressText), "0/" + total + " textures converted");

			for (progress = 0; progress < total; progress++)
			{
				//Grab the full directory and filename, change the extension
				String fs_out_loc = Path.ChangeExtension(files[progress], ".dds");

				//If the output directory isn't the same as the root dir
				if (b_dir)
				{
					//Directory structure retained
					if (b_dir_struct)
					{
						fs_out_loc = fs_out_loc.Replace(root_dir, s_dir);
					}

					//Everything in one folder
					else
					{
						//Some files have duplicate names
						if (File.Exists(s_dir + "\\" + Path.GetFileName(fs_out_loc)))
						{
							//add a number to the end of the filename
#warning "Change number when filename changes"
							fs_out_loc = s_dir + "\\" + Path.GetFileNameWithoutExtension(fs_out_loc) + "_" + duplicateNumber + ".dds";
							duplicateNumber++;
						}

						else
						{
							fs_out_loc = s_dir + "\\" + Path.GetFileName(fs_out_loc);
						}

					}
				}

				//Finally start converting
				XBT xbt = new XBT(files[progress]);

				//Write output to file
				FileStream fs_out = new FileStream(fs_out_loc, FileMode.Create, FileAccess.Write);
				BinaryWriter writer = new BinaryWriter(fs_out);
				writer.Write(xbt.Texture);

				//Do some cleanup
				writer.Close();
				fs_out.Close();

				//Progress Bar gets updated
				int i_progresslbl = progress + 1;
				Invoke(new progressCallBack(setProgressBarVal), i_progresslbl);
				Invoke(new setlblTextCallBack(setlblProgressText), i_progresslbl + "/" + total + " textures converted");

				//Now that there are no handles on the file, delete the original if the user wants to
				if (settingsDeleteOrig)
				{
					File.Delete(files[progress]);
				}
			}

			//Restore UI functionality
			Invoke(new completedCallBack(resetUI));
		}

		//Menu methods
		private void mm_file_exit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void mm_help_help_Click(object sender, EventArgs e)
		{
			FormHelp help = new FormHelp();
			help.Show();
		}

		private void mm_edit_DropDownOpening(object sender, EventArgs e)
		{
			mm_edit_preview.Enabled = false;
			mm_edit_explorer.Enabled = false;
			mm_edit_check.Enabled = false;
			mm_edit_uncheck.Enabled = false;

			if (b_list_created)
			{
				if (listView.SelectedItems.Count == 1)
				{
					mm_edit_preview.Enabled = true;
					mm_edit_explorer.Enabled = true;
					mm_edit_check.Enabled = true;
					mm_edit_uncheck.Enabled = true;
				}

				else if (listView.SelectedItems.Count > 1)
				{
					mm_edit_check.Enabled = true;
					mm_edit_uncheck.Enabled = true;
				}
			}
		}

		private void listViewContext_Opening(object sender, CancelEventArgs e)
		{
			lsvContext_Preview.Enabled = false;
			lsvContext_Explorer.Enabled = false;
			lsvContext_Check.Enabled = false;
			lsvContext_Uncheck.Enabled = false;

			if (b_list_created)
			{
				if (listView.SelectedItems.Count == 1)
				{
					lsvContext_Preview.Enabled = true;
					lsvContext_Explorer.Enabled = true;
					lsvContext_Check.Enabled = true;
					lsvContext_Uncheck.Enabled = true;
				}

				//if more than one item is selected, disable preview and open in explorer.
				else if (listView.SelectedItems.Count > 1)
				{
					lsvContext_Check.Enabled = true;
					lsvContext_Uncheck.Enabled = true;
				}
			}
		}

		//Recursive I/O methods
		public void FillItemList(string dir_root)
		{
			//Define the root dir and list out all the folders.
			DirectoryInfo dir_info = new DirectoryInfo(dir_root);

			//Before we delve into subfolders, search root dir for xbt files
			foreach (FileInfo f in dir_info.GetFiles("*.xbt"))
			{
				ListViewItem tempItem = new ListViewItem(f.Name);
				tempItem.SubItems.Add(Path.GetDirectoryName(f.FullName));
				listView.Items.Add(tempItem);
			}

			foreach (DirectoryInfo d in dir_info.GetDirectories())
			{
				FillItemList(d.FullName);
			}

		}

		public void BackupRootDir(string dir_root)
		{
			DirectoryInfo dir_info = new DirectoryInfo(dir_root);
			int progress = 0;
			int totalFiles = dir_info.GetFileSystemInfos().Count();
			Invoke(new setMaxCallBack(progressBarSetMax), totalFiles);

			foreach (FileInfo f in dir_info.GetFiles())
			{
				File.Copy(f.FullName, f.FullName.Replace(root_dir, settingsBackupDir), true);
				progress++;
				Invoke(new progressCallBack(setProgressBarVal), progress);
			}

			foreach (DirectoryInfo d in dir_info.GetDirectories())
			{
				Directory.CreateDirectory(d.FullName.Replace(root_dir, settingsBackupDir));
				BackupRootDir(d.FullName);
			}
		}

		public void BuildDestinationDir(string dir_root)
		{
			DirectoryInfo dir_root_info = new DirectoryInfo(dir_root);

			foreach (DirectoryInfo d in dir_root_info.GetDirectories())
			{
				Directory.CreateDirectory(d.FullName.Replace(root_dir, s_dir));
				BuildDestinationDir(d.FullName);
			}
		}

		//Invoked methods
		public void progressBarSetMax(int num)
		{
			//set progress bar maximum
			progressBar.Maximum = num;
		}

		public void setlblProgressText(string text)
		{
			//set progress label text
			lbl_progress.Text = text;
		}

		public string ReturnListViewItem(int num)
		{
			return listView.CheckedItems[num].SubItems[1].Text;
		}

		public void setProgressBarVal(int num)
		{
			//set progress bar value
			progressBar.Value = num;
		}

		public void resetUI()
		{
			//Re-enable everything
			btn_check.Enabled = true;
			btn_uncheck.Enabled = true;
			btn_convert.Enabled = true;
			btn_setDir.Enabled = true;
			btn_options.Enabled = true;
			menuStrip1.Enabled = true;
			listView.Enabled = true;
			lbl_progress.Text = "Conversion completed!";

			//
			if (root_dir == s_dir)
			{
				s_dir = "";
			}

			//Open up explorer
			if (b_explorer)
			{
				System.Diagnostics.Process.Start("explorer.exe", s_dir);
			}
		}

		//Other methods
		public void xbt_preview(object sender, EventArgs e)
		{
			MessageBox.Show("This feature hasn't been implemented yet :(");
		}

		public void xbt_showInExplorer(object sender, EventArgs e)
		{
			string filename = listView.SelectedItems[0].SubItems[1].Text;
			System.Diagnostics.Process.Start("explorer.exe", "/select," + filename);
		}

		public void checkHighlighted(object sender, EventArgs e)
		{
			foreach (ListViewItem item in listView.SelectedItems)
			{
				item.Checked = true;
			}
		}

		public void uncheckHighlighted(object sender, EventArgs e)
		{
			foreach (ListViewItem item in listView.SelectedItems)
			{
				item.Checked = false;
			}
		}

	}
}
