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
using System.Windows.Forms;

namespace FC2Tools.xbtConvert
{
	public partial class FormHelp : Form
	{
		public FormHelp()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			this.Hide();
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				//use the default web browser to open webpage "s_url"
				System.Diagnostics.Process.Start("http://blog.gib.me/2008/10/28/unstable-fc2-tool-binaries-from-svn-revision-4/");
			}
			catch (Exception exc1)
			{
				//known issue with firefox as default browser. If error occurs, attempt to use IE
				if (exc1.GetType().ToString() != "System.ComponentModel.Win32Exception")
				{
					try
					{
						//start up a new instance of Internet Explorer
						System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo("IExplore.exe", "http://blog.gib.me/2008/10/28/unstable-fc2-tool-binaries-from-svn-revision-4/");
						System.Diagnostics.Process.Start(startInfo);
						startInfo = null;
					}
					catch
					{
						//if for some reason it can't open up, present a message to the user.
						MessageBox.Show("There seems to be an issue loading this webpage. Please copy and paste the link to your browser.");
					}
				}
			}
		}
	}
}
